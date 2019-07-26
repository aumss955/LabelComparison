using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace TraceabilityNew
{
    public partial class Form1 : Form
    {


        public string operatorid;
        public string test_station;
        private string SN;
        private string macAddress;
        private string Partnumber;
        private string Wo;
        public static bool formClose = false;
        public bool skip_openPort;
        public Hashtable hash_config = new Hashtable();
        public List<string> sImei = new List<string>();
        public List<string> sSn = new List<string>();
        public StringBuilder labelText = new StringBuilder();
        


        public string sn
        {
            get
            {
                return this.SN;
            }

            set
            {
                this.SN = value;
            }
        }

        public string macaddress
        {
            get
            {
                return this.macAddress;
            }

            set
            {
                this.macAddress = value;
            }
        }

        public string partnumber
        {
            get
            {
                return Partnumber;
            }

            set
            {
                Partnumber = value;
            }
        }

        public string wo
        {
            get
            {
                return Wo;
            }

            set
            {
                Wo = value;
            }
        }

        ArrayList al = new ArrayList();

        //public static int iLabel = Properties.Settings.Default.iLabel;

        public static int iLabel;
        private string tStringSN = string.Empty;
        private string tStringMAC = string.Empty;


        public Form1()
        {

            InitializeComponent();
            

        }

        public Form1(string id, string station)
        {
            this.operatorid = id;
            this.test_station = station;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadPorts();


            //Thread t_timer = new Thread(new ThreadStart(Thread_timer));
            //timer1.Enabled = true;
            //t_timer.Start(timer1);

        }

        static void Thread_timer(object timer)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }

            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void labelsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            lbStatus.BackColor = Color.Black;

            //var webcheckResult = WebAPI.CheckForInternetConnection("http://localhost:8000//");
            //Console.WriteLine(webcheckResult.ToString());

            //HttpRequest request = new HttpRequest();

            //var result = request.Get("http://localhost:8000/api/testresult/");
            //Console.WriteLine(result.ToString());

            //MessageBox.Show(result.ToString(), "TEST");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {


        }

        private void btOpen_Click(object sender, EventArgs e)
        {
            btOpen.Enabled = false;
            btClose.Enabled = true;

            try
            {
                serialPort1.PortName = cbPort.Text;
                serialPort1.BaudRate = 115200;
                serialPort1.Parity = Parity.None;
                serialPort1.DataBits = 8;
                serialPort1.StopBits = StopBits.One;
                //serialPort1.Handshake = Handshake.RequestToSend;
                //serialPort1.DtrEnable = true;
                //serialPort1.RtsEnable = true;
                //serialPort1.NewLine = System.Environment.NewLine;
                serialPort1.Open();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            btOpen.Enabled = false;
            btClose.Enabled = true;

            try
            {
                textBox1.AppendText("====== Sending Commands ======");
                textBox1.AppendText(Environment.NewLine);

                if (serialPort1.IsOpen)
                {
                    serialPort1.Write("print SN\n");
                    serialPort1.Write("print ethaddr\n");
                    textBox1.AppendText("print SN" + Environment.NewLine);
                    serialPort1.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
                    serialPort1.WriteTimeout = 1000;



                    Thread.Sleep(500);


                    if (SN != string.Empty && macAddress != string.Empty)
                    {
                        serialPort1.DataReceived -= DataReceivedHandler;
                    }

                    //serialPort1.DiscardOutBuffer();

                    //textBox1.AppendText("print ethaddr" + Environment.NewLine);
                    //serialPort1.Write("print ethaddr\n");
                    //serialPort1.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandlerMAC);
                    //serialPort1.WriteTimeout = 1000;




                    //this.txtSN.Text = SN;
                    //this.txtSN.Text += ";" + macAddress;


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            btOpen.Enabled = true;
            btClose.Enabled = false;

            try
            {
                serialPort1.Close();
                serialPort1.DataReceived -= DataReceivedHandler;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRecieve_Click(object sender, EventArgs e)
        {
            bool test;
            XmlManager xml = new XmlManager(hash_config, "C:\\Users\\AumHey\\Documents\\Visual Studio 2015\\Projects\\TraceabilityNew\\TraceabilityNew\\bin\\Debug\\Matrix\\DIGImatrix.xml");
            //xml.getInfo("C:\\Users\\AumHey\\Documents\\Visual Studio 2015\\Projects\\TraceabilityNew\\TraceabilityNew\\bin\\Debug\\Matrix\\DIGImatrix.xml");
            //MessageBox.Show(hash_config["Label1"].ToString());

            test = xml.checkPartnumber("123456789");
            Scanlabel test_scan = new Scanlabel("Label1", this);

            test_scan.ShowDialog();

        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            this.tStringSN = string.Empty;

            byte[] buffer = new byte[this.serialPort1.ReadBufferSize];
            int bytesRead = this.serialPort1.Read(buffer, 0, buffer.Length);

            this.tStringSN += Encoding.ASCII.GetString(buffer, 0, bytesRead);


            string expr = "[A-Z]\\d{12}";
            string expr2 = "\\w\\w:\\w\\w:\\w\\w:\\w\\w:\\w\\w:\\w\\w";

            SerialPort sp = (SerialPort)sender;
            //string indata = sp.ReadExisting();

            //this.SN = this.tStringSN;

            MatchCollection mc = Regex.Matches(this.tStringSN, expr);
            foreach (Match m in mc)
            {
                //Console.WriteLine(m);
                this.SN = m.ToString();
            }

            MatchCollection mc2 = Regex.Matches(this.tStringSN, expr2);
            foreach (Match m in mc2)
            {
                //Console.WriteLine(m);
                this.macAddress = m.ToString();
            }




            //Console.Write(indata);
            textBox1.Invoke(new Action(() =>
            textBox1.AppendText(this.SN + Environment.NewLine)
           ));

            txtSN.Invoke(new Action(() =>
            txtSN.Text = "SN:" + this.SN + " MAC:" + this.macAddress));


        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Menu_settings menu_setting = new Menu_settings(this);
            menu_setting.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
            string tbText;
            string tbMAC;
            string[] tbTextArray;
           
            int sqlRow_count, sqlRow_countMAC;
            al.Clear();
            this.lbStatus.Text = "Status";
            this.lbStatus.BackColor = Color.White;
            this.txtSN.Text = "";
            skip_openPort = false;

            if (hash_config["ReadSerialport"].ToString() == "True")
            {
                this.btOpen_Click(sender, e);
            }
            else
            {
                skip_openPort = true;
                //this.groupBox2.Enabled = false;
            }

            //Thread.Sleep(3000);

            if (serialPort1.IsOpen || skip_openPort == true)
            {
                this.btnSend_Click(sender, e);
                this.lbStatus.Text = "Running";
                this.lbStatus.BackColor = Color.Yellow;
                this.pictureBox1.BackColor = Color.Yellow;

                if (SN != null && macAddress != null || skip_openPort == true)
                {



                    for (int i = 1; i <= iLabel; i++)
                    {
                        // MessageBox.Show(i.ToString());
                        textBox1.AppendText("====== Scan Label" + i + "======" + Environment.NewLine);
                        Scanlabel scan = new Scanlabel(i.ToString(), this);
                        scan.ShowDialog();
                        tbText = scan.gettbText();

                  

                        if (skip_openPort.ToString() == "True")
                        {
                            char specialChar = ',';

                            if (i == 1)
                            {
                                specialChar = ',';
                            }
                            else
                            {
                                specialChar = ';';
                            }

                            tbTextArray = tbText.Split(',');

                            tbText = tbTextArray[0];
                        }


                        SQLiteManager sql_sn = new SQLiteManager(Properties.Settings.Default.DatabasePath);
                        sqlRow_count = sql_sn.countRow(sql_sn.CreateConnection(), "SELECT * FROM MACadress WHERE data_read LIKE '%" + tbText + "%' AND status = 'PASS';");

                        if (sqlRow_count == 0)
                        {

                            if (skip_openPort == false)
                            {
                                textBox1.AppendText(DateTime.Now.ToString("HH:mm:ss") + " => Skip serial port : False" + Environment.NewLine);

                                if (tbText != SN)
                                {

                                    this.lbStatus.Text = "FAIL";
                                    this.lbStatus.BackColor = Color.Red;
                                    this.pictureBox1.BackColor = Color.Red;
                                    break;
                                }
                                else
                                {

                                    if (i == iLabel)
                                    {
                                        textBox1.AppendText("====== Scan MAC Address ======" + Environment.NewLine);
                                        ScanMAC scanMac = new ScanMAC(this);

                                        scanMac.ShowDialog();
                                        tbMAC = scanMac.gettbText();

                                        SQLiteManager sql_mac = new SQLiteManager(Properties.Settings.Default.DatabasePath);
                                        sqlRow_countMAC = sql_mac.countRow(sql_mac.CreateConnection(), "SELECT * FROM MACadress WHERE data_read LIKE '%" + tbMAC + "%'");

                                        if (sqlRow_countMAC == 0)
                                        {

                                            if (tbMAC == macAddress)
                                            {
                                                this.lbStatus.Text = "PASS";
                                                this.lbStatus.BackColor = Color.GreenYellow;
                                                this.pictureBox1.BackColor = Color.GreenYellow;
                                            }
                                            else
                                            {
                                                this.lbStatus.Text = "FAIL";
                                                this.lbStatus.BackColor = Color.Red;
                                                this.pictureBox1.BackColor = Color.Red;

                                            }
                                        }
                                        else
                                        {
                                            textBox1.AppendText(DateTime.Now.ToString("HH:mm:ss") + " => Found dulplicate MACadddress" + Environment.NewLine);
                                            MessageBox.Show("MACaddress ซ้ำ");
                                            this.lbStatus.Text = "ERROR";
                                            this.lbStatus.BackColor = Color.Red;
                                            this.pictureBox1.BackColor = Color.Red;

                                            goto End;
                                        }

                                    }
                                }

                            }
                            else
                            {
                                textBox1.AppendText(DateTime.Now.ToString("HH:mm:ss") + " => Skip serial port : False" + Environment.NewLine);


                                //MessageBox.Show(sSn[i - 1]);
                                //MessageBox.Show(sImei[i - 1]);

                                if (i > 1)
                                {
                                    if (sImei[0] == sImei[i - 1])
                                    {
                                        textBox1.AppendText(DateTime.Now.ToString("HH:mm:ss") + "Imei comparison" + Environment.NewLine);
                                        MessageBox.Show(sImei[0].ToString() + "==" + sImei[i - 1].ToString());
                                        this.lbStatus.Text = "PASS";
                                        this.lbStatus.BackColor = Color.GreenYellow;
                                        this.pictureBox1.BackColor = Color.GreenYellow;

                                    }
                                    else
                                    {
                                        this.lbStatus.Text = "FAIL";
                                        this.lbStatus.BackColor = Color.Red;
                                        this.pictureBox1.BackColor = Color.Red;

                                    }



                                }
                                labelText.Append(tbText + ',');
                            }

                        }
                        else
                        {
                            textBox1.AppendText(DateTime.Now.ToString("HH:mm:ss") + " => Found dulplicate serial number" + Environment.NewLine);
                            MessageBox.Show("Serial Number ซ้ำ");
                            this.lbStatus.Text = "ERROR";
                            this.lbStatus.BackColor = Color.Red;
                            this.pictureBox1.BackColor = Color.Red;

                            goto End;

                        }

                    

                    }
                    
                
                }
                else
                {
                    MessageBox.Show("Cannot connect to UUT. กรุญาเลือก port อื่น");
                    this.lbStatus.Text = "ERROR";
                    this.lbStatus.BackColor = Color.Red;
                    this.pictureBox1.BackColor = Color.Red;

                    goto End;
                }

         
            }
            else
            {
                this.lbStatus.Text = "ERROR";
                this.lbStatus.BackColor = Color.Red;
                this.pictureBox1.BackColor = Color.Red;
            }


            //Write values to text file
            //foreach(var item in al)
            //{
            //    MessageBox.Show(item.ToString());
            //}
            StringBuilder sb_label_scan = new StringBuilder();
            textBox1.AppendText("====== RESULT FILE ======" + Environment.NewLine);
            textBox1.AppendText(DateTime.Now.ToString("HH:mm:ss") + " => Writing to a result file" + Environment.NewLine);
            using (StreamWriter sw = File.AppendText(DateTime.Now.ToString("dd-MM-yyyy") + " Result.txt"))
            {
                
                sw.Write(DateTime.Now.ToString("HH:mm:ss"));
                sw.Write(",");
                sw.Write(Partnumber);
                sw.Write(",");
                sw.Write(Wo);
                sw.Write(",");
                sw.Write(iLabel);
                sw.Write(",");
                sw.Write(txtSN.Text);
                sw.Write(",");

                if (skip_openPort.ToString() == "False")
                {
                    foreach (string s in al)
                    {
                        sw.Write(s);
                        sw.Write(",");
                        sb_label_scan.Append(s + ",");
                    }

                }
                else
                {
                    sw.Write("IMEI:");
                    sb_label_scan.Append("IMEI:");
                    foreach (string imei in sImei)
                    {
                        sw.Write(imei);
                        sw.Write(",");
                        sb_label_scan.Append(imei + ",");
                    }

                    sw.Write("SN:");
                    sb_label_scan.Append("SN:");
                    foreach (string sn in sSn)
                    {
                        sw.Write(sn);
                        sw.Write(",");
                        sb_label_scan.Append(sn + ",");
                    }

                    txtSN.Text = labelText.ToString();
                }

                sw.Write(this.lbStatus.Text);
                sw.WriteLine();
            }
            //MessageBox.Show(sb_label_scan.ToString());

            textBox1.AppendText(DateTime.Now.ToString("HH:mm:ss")+ " => Finished Write" + Environment.NewLine);

            //Database write
            textBox1.AppendText("====== DATABASE ======" + Environment.NewLine);
            textBox1.AppendText(DateTime.Now.ToString("HH:mm:ss") + " => Database Insert" + Environment.NewLine);
            SQLiteManager sql = new SQLiteManager(Properties.Settings.Default.DatabasePath);
            sql.InsertData(sql.CreateConnection(), "INSERT INTO MACadress (partnumber,wo,data_read,label_scan,status,timestamp) VALUES('"+Partnumber+"','"+Wo+"','"+ txtSN.Text + "','"+ sb_label_scan.ToString() + "','"+ this.lbStatus.Text + "','"+ DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + "');");
            textBox1.AppendText(DateTime.Now.ToString("HH: mm:ss")+ " => Insert Completed" + Environment.NewLine);

            btClose_Click(sender,e);



            
        End:
            SN = null;
            macAddress = null;
            serialPort1.Close();
            clearPorts();
            loadPorts();
            sSn.Clear();
            sImei.Clear();
        }

        public void UpdateiLabel(int label_num)
        {
            iLabel = label_num;
        }

        public void TextBoxAppend(string sText)
        {
            this.textBox1.AppendText(sText);
        }

        public void inserttoArrayList(string sText) {
            al.Add(sText);
        }

        public void loadPorts()
        {
            lbOperator.Text = operatorid;
            lbTeststation.Text = test_station;
            string[] ports = SerialPort.GetPortNames();


            Console.Write(ports.Length);


            cbPort.Items.AddRange(ports);
            if (ports.Length != 0)
            {
                cbPort.SelectedIndex = 0;
            }

            btClose.Enabled = false;
        }

        public void clearPorts()
        {
            cbPort.Items.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            serialPort1.PortName = cbPort.Text;
            serialPort1.BaudRate = 115200;
            serialPort1.Parity = Parity.None;
            serialPort1.DataBits = 8;
            serialPort1.StopBits = StopBits.One;
            //serialPort1.Handshake = Handshake.RequestToSend;
            //serialPort1.DtrEnable = true;
            //serialPort1.RtsEnable = true;
            //serialPort1.NewLine = System.Environment.NewLine;
            serialPort1.Open();
            int test2;
            string tbMAC = "00:04:F3:1A:9B:B0";

            if (serialPort1.IsOpen)
            {
                MessageBox.Show("SerialPort is Open!!");
                SQLiteManager test1 = new SQLiteManager(Properties.Settings.Default.DatabasePath);
                test2 = test1.countRow(test1.CreateConnection(), "SELECT count(id) FROM MACadress WHERE data_read LIKE '%" + tbMAC + "%';");
                MessageBox.Show(test2.ToString());
               
                }
            else
            {
                MessageBox.Show("SerialPort NOT Open!!");
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void lbStatus_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //XmlManager xmlmanager = new XmlManager();
            //xmlmanager.test2();
            SQLiteManager sql = new SQLiteManager(Properties.Settings.Default.DatabasePath);
            sql.InsertData(sql.CreateConnection(), "INSERT INTO MACadress (partnumber,wo,label_scan,data_read,status) VALUES('123456','11111','123123','12345','PASS');");
            

            //sql.ReadData(sql.CreateConnection(),"SELECT * FROM Test");
           
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            string configPath = Path.Combine(System.IO.Directory.GetCurrentDirectory()+"\\Matrix", "DIGImatrix.xml");
            //MessageBox.Show("HAS SHOWN");
            ScanPN scanPN = new ScanPN(this,"PartNumber");
            scanPN.ShowDialog();
            ScanPN scanWO = new ScanPN(this, "WorkOrder");
            scanWO.ShowDialog();

            this.lbPN.Text = this.Partnumber;
            this.lbWO.Text = this.Wo;

            //XmlManager xml1 = new XmlManager(hash_config, "C:\\Users\\AumHey\\Documents\\Visual Studio 2015\\Projects\\TraceabilityNew\\TraceabilityNew\\bin\\Debug\\Matrix\\DIGImatrix.xml");
            XmlManager xml1 = new XmlManager(hash_config, configPath);
            xml1.getInfo(this.Partnumber);

            iLabel = Int32.Parse(hash_config["label_check"].ToString());

            if (hash_config["ReadSerialport"].ToString() == "True")
            {
                this.groupBox2.Enabled = true;
            }
            else
            {
                this.groupBox2.Enabled = false;
            }
            //MessageBox.Show(hash_config["Label1"].ToString());

        }
    }
}
