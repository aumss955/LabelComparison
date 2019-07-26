using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TraceabilityNew
{
    public partial class Scanlabel : Form
    {
        private Form1 main;
       

        public Scanlabel(string label_num,Form1 MainForm)
        {
            main = MainForm;
            InitializeComponent();
            this.label2.Text = label_num;
           // MessageBox.Show(main.hash_config.ContainsKey(label_num).ToString());
            //this.pictureBox1.ImageLocation = main.hash_config.ContainsKey(label_num).ToString();
            this.pictureBox1.Image = Image.FromFile(main.hash_config["label"+label_num].ToString());
            this.btnOk_scan.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            main.TextBoxAppend("INPUT : " + this.txtScan.Text + Environment.NewLine);
            //main.inserttoArrayList(this.txtScan.Text);
            string label_length = main.hash_config["label_length"].ToString();
            int[] lenth_array = System.Array.ConvertAll(label_length.Split(','), int.Parse);


            if (main.skip_openPort == false)
            {
                if (this.txtScan.Text != "")
                {
                    if (this.txtScan.TextLength == main.sn.Length)
                    {

                        if (this.txtScan.Text != main.sn)
                        {
                            MessageBox.Show("Serial Number บน Label ไม่ตรงกับตัวงาน");
                            main.TextBoxAppend("ERROR : Serial Number บน Label ไม่ตรงกับตัวงาน" + Environment.NewLine);
                            main.inserttoArrayList(this.txtScan.Text);
                            this.txtScan.Text = "";
                            this.txtScan.Focus();
                            this.Close();
                        }
                        else
                        {

                            main.TextBoxAppend("PASS >> " + this.txtScan.Text + " == " + main.sn + Environment.NewLine);
                            main.inserttoArrayList(this.txtScan.Text);
                            this.Close();
                        }

                    }
                    else
                    {
                        MessageBox.Show("จำนวนตัวอักษรของ Label ไม่ถูกต้อง");
                        this.txtScan.Text = "";
                        this.txtScan.Focus();
                    }

                }
                else
                {
                    MessageBox.Show("กรุณาแสกน Label");
                    this.txtScan.Text = "";
                    this.txtScan.Focus();
                }
            }
            else
            {

                if (this.txtScan.Text != "")
                {
                    Console.WriteLine(lenth_array[Int32.Parse(this.label2.Text) - 1]);
                    if (this.txtScan.Text.Length == lenth_array[Int32.Parse(this.label2.Text) - 1])
                    {
                        string labelText = this.txtScan.Text;
                        char specialChar = ',';

                        if(this.label2.Text == "1")
                        {
                            specialChar = ',';
                        }
                        else
                        {
                            specialChar = ';';
                        }

                        string[] values = labelText.Split(specialChar);

                        main.sImei.Add(values[0]);
                        main.sSn.Add(values[1]);
                        this.Close();
                        this.txtScan.Focus();
                    }
                    else
                    {
                        MessageBox.Show("จำนวน Length ไม่ถูกต้อง");
                        this.txtScan.Text = "";

                    }
                }
                else
                {
                    MessageBox.Show("กรุณาแสกน Label");
                    this.txtScan.Text = "";
                    this.txtScan.Focus();
                }
            }
        }

        private void txtScan_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 13:
                    this.btnOk_scan.Focus();
                    this.button1_Click(sender,e);
                    break;
            }
        }

        private void Scanlabel_Load(object sender, EventArgs e)
        {

        }

        private void Scanlabel_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            
        }

        private void Scanlabel_FormClosing(object sender, FormClosingEventArgs e)
        {

            
                //e.Cancel = true;
             

            

         }

        public string gettbText()
        {
            return this.txtScan.Text;
        }

        private void txtScan_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
