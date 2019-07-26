namespace TraceabilityNew
{
    partial class Menu_settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb4 = new System.Windows.Forms.RadioButton();
            this.rb3 = new System.Windows.Forms.RadioButton();
            this.rb2 = new System.Windows.Forms.RadioButton();
            this.btnOK_setting = new System.Windows.Forms.Button();
            this.btnCancel_setting = new System.Windows.Forms.Button();
            this.btnApply_setting = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb4);
            this.groupBox1.Controls.Add(this.rb3);
            this.groupBox1.Controls.Add(this.rb2);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(334, 229);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Main settings";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // rb4
            // 
            this.rb4.AutoSize = true;
            this.rb4.Location = new System.Drawing.Point(27, 106);
            this.rb4.Name = "rb4";
            this.rb4.Size = new System.Drawing.Size(61, 17);
            this.rb4.TabIndex = 2;
            this.rb4.Text = "4 labels";
            this.rb4.UseVisualStyleBackColor = true;
            this.rb4.CheckedChanged += new System.EventHandler(this.rb4_CheckedChanged);
            // 
            // rb3
            // 
            this.rb3.AutoSize = true;
            this.rb3.Location = new System.Drawing.Point(27, 70);
            this.rb3.Name = "rb3";
            this.rb3.Size = new System.Drawing.Size(61, 17);
            this.rb3.TabIndex = 1;
            this.rb3.Text = "3 labels";
            this.rb3.UseVisualStyleBackColor = true;
            this.rb3.Click += new System.EventHandler(this.rb3_Click);
            // 
            // rb2
            // 
            this.rb2.AutoSize = true;
            this.rb2.Location = new System.Drawing.Point(27, 36);
            this.rb2.Name = "rb2";
            this.rb2.Size = new System.Drawing.Size(61, 17);
            this.rb2.TabIndex = 0;
            this.rb2.Text = "2 labels";
            this.rb2.UseVisualStyleBackColor = true;
            this.rb2.CheckedChanged += new System.EventHandler(this.rb2_CheckedChanged);
            // 
            // btnOK_setting
            // 
            this.btnOK_setting.Enabled = false;
            this.btnOK_setting.Location = new System.Drawing.Point(104, 248);
            this.btnOK_setting.Name = "btnOK_setting";
            this.btnOK_setting.Size = new System.Drawing.Size(75, 23);
            this.btnOK_setting.TabIndex = 1;
            this.btnOK_setting.Text = "Ok";
            this.btnOK_setting.UseVisualStyleBackColor = true;
            this.btnOK_setting.Click += new System.EventHandler(this.btnOK_setting_Click);
            // 
            // btnCancel_setting
            // 
            this.btnCancel_setting.Location = new System.Drawing.Point(185, 248);
            this.btnCancel_setting.Name = "btnCancel_setting";
            this.btnCancel_setting.Size = new System.Drawing.Size(75, 23);
            this.btnCancel_setting.TabIndex = 2;
            this.btnCancel_setting.Text = "Cancel";
            this.btnCancel_setting.UseVisualStyleBackColor = true;
            // 
            // btnApply_setting
            // 
            this.btnApply_setting.Location = new System.Drawing.Point(272, 248);
            this.btnApply_setting.Name = "btnApply_setting";
            this.btnApply_setting.Size = new System.Drawing.Size(75, 23);
            this.btnApply_setting.TabIndex = 3;
            this.btnApply_setting.Text = "Apply";
            this.btnApply_setting.UseVisualStyleBackColor = true;
            this.btnApply_setting.Click += new System.EventHandler(this.btnApply_setting_Click);
            // 
            // Menu_settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 291);
            this.Controls.Add(this.btnApply_setting);
            this.Controls.Add(this.btnCancel_setting);
            this.Controls.Add(this.btnOK_setting);
            this.Controls.Add(this.groupBox1);
            this.Name = "Menu_settings";
            this.Text = "Settings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rb4;
        private System.Windows.Forms.RadioButton rb3;
        private System.Windows.Forms.RadioButton rb2;
        private System.Windows.Forms.Button btnOK_setting;
        private System.Windows.Forms.Button btnCancel_setting;
        private System.Windows.Forms.Button btnApply_setting;
    }
}