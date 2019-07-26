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
    public partial class Login : Form
    {

        User user = new User("123456789");

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            textBox1.Focus();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            string id = textBox1.Text;

            textBox1.CharacterCasing = CharacterCasing.Upper;

            if(e.KeyCode.ToString() == "Return")
            {
               // MessageBox.Show(textBox1.Text, "test");

                if(textBox1.Text.Trim() == this.user.operator_id)
                {
                    this.Hide();
                    Form1 fm1 = new Form1(user.operator_id,"Check MAC Address");
                    fm1.Show();
                    fm1.Enabled = true;
                
                    
                }else if(textBox1.Text.Trim() == "")
                {
                    MessageBox.Show("กรุณาใส่ Operator ID", "test");
                }else
                {
                    MessageBox.Show("Operator ID ไม่ถูกต้อง", "test");
                }
                //MessageBox.Show(this.user.operator_id, "test");
            }
            
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
