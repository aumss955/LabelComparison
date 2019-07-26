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
    public partial class ScanMAC : Form
    {

        private Form1 main;

        public ScanMAC(Form1 MainForm)
        {
            main = MainForm;
            InitializeComponent();
        }

        private void btnOk_scan_Click(object sender, EventArgs e)
        {
            main.TextBoxAppend("INPUT : " + this.txtScan.Text + Environment.NewLine);

            if (this.txtScan.Text != "")
            {
                if (this.txtScan.TextLength == main.macaddress.Length)
                {
                    if (this.txtScan.Text != main.macaddress)
                    {
                        MessageBox.Show("MAC Address บน Label ไม่ตรงกับตัวงาน");
                        main.TextBoxAppend("ERROR : MAC Address บน Label ไม่ตรงกับตัวงาน" + Environment.NewLine);
                        main.inserttoArrayList(this.txtScan.Text);
                        this.txtScan.Text = "";
                        this.txtScan.Focus();
                        this.Close();
                    }
                    else
                    {

                        main.TextBoxAppend("PASS >> " + this.txtScan.Text + " == " + main.macaddress + Environment.NewLine);
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

        public string gettbText()
        {
            return this.txtScan.Text;
        }

        private void ScanMAC_KeyDown(object sender, KeyEventArgs e)
        {
            
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

        private void txtScan_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
