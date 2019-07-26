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
    public partial class Menu_settings : Form
    {
        private int rd_label;
        private int setting_label;
        private Form1 main;

        public Menu_settings(Form1 mainForm)
        {
            main = mainForm;
            InitializeComponent();
            //setting_label = Form1.iLabel;
            setting_label = Properties.Settings.Default.iLabel;

            switch (setting_label)
            {
                case 2:
                    rb2.Checked = true;
                    break;
                case 3:
                    rb3.Checked = true;
                    break;
                case 4:
                    rb4.Checked = true;
                    break;
            }
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnOK_setting_Click(object sender, EventArgs e)
        {
            Form1.iLabel = rd_label;
            this.Close();
        }

        private void btnApply_setting_Click(object sender, EventArgs e)
        {
 
            Properties.Settings.Default.iLabel = rd_label;
            Properties.Settings.Default.Save();
            setting_label = Properties.Settings.Default.iLabel;
            main.UpdateiLabel(setting_label);
            this.btnOK_setting.Enabled = true;
            this.btnApply_setting.Enabled = false;
            this.btnOK_setting.Focus();
            
        }

        private void rb3_Click(object sender, EventArgs e)
        {
            rd_label = 3;
  
        }

        private void rb2_CheckedChanged(object sender, EventArgs e)
        {
            rd_label = 2;
        }

        private void rb4_CheckedChanged(object sender, EventArgs e)
        {
            rd_label = 4;
        }
    }
}
