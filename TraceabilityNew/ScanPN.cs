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
    public partial class ScanPN : Form
    {
        private Form1 main;
        private string Scan_stage;

        public ScanPN(Form1 MainForm, string scan_stage)
        {
            main = MainForm;
            InitializeComponent();
            this.Scan_stage = scan_stage;
            this.Text = scan_stage;
            this.label1.Text = "แสกน "+scan_stage;
        }

        private void btnOk_scan_Click(object sender, EventArgs e)
        {
            main.TextBoxAppend("===== SCAN "+Scan_stage+" =====" + Environment.NewLine);
            main.TextBoxAppend("INPUT : " + this.txtScan.Text + Environment.NewLine);
            //main.inserttoArrayList(this.txtScan.Text);
            XmlManager xmlPartnumber = new XmlManager(null, "C:\\Users\\AumHey\\Documents\\Visual Studio 2015\\Projects\\TraceabilityNew\\TraceabilityNew\\bin\\Debug\\Matrix\\DIGImatrix.xml");
            bool partnumberExist;

            if (this.txtScan.Text != "")
            {
                if (this.Scan_stage == "PartNumber")
                {
                
                   partnumberExist = xmlPartnumber.checkPartnumber(this.txtScan.Text);


                    if (partnumberExist == true)
                    {
                        main.partnumber = this.txtScan.Text;
                        this.Close();
                    }
                    else
                    {
                        this.txtScan.Text = "";
                        MessageBox.Show("ไม่มี Partnumber อยู่ใน config file");
                    }
                }
                else
                {
                    main.wo = this.txtScan.Text;
                    this.Close();


                    //Loadconfig file

                }
                
            }
            else
            {
                MessageBox.Show("กรุณาใส่ " + Scan_stage);
                this.txtScan.Text = "";
                this.txtScan.Focus();
            }
        }

        private void txtScan_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 13:
                    this.btnOk_scan_Click(sender, e);
                    break;
            }
        }
    }
}
