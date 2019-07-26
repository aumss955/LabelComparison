namespace TraceabilityNew
{
    partial class ScanMAC
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
            this.txtScan = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOk_scan = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtScan
            // 
            this.txtScan.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtScan.Location = new System.Drawing.Point(23, 54);
            this.txtScan.Name = "txtScan";
            this.txtScan.Size = new System.Drawing.Size(397, 29);
            this.txtScan.TabIndex = 1;
            this.txtScan.TextChanged += new System.EventHandler(this.txtScan_TextChanged);
            this.txtScan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtScan_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(20, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "แสกน MAC Address";
            // 
            // btnOk_scan
            // 
            this.btnOk_scan.Location = new System.Drawing.Point(24, 89);
            this.btnOk_scan.Name = "btnOk_scan";
            this.btnOk_scan.Size = new System.Drawing.Size(75, 23);
            this.btnOk_scan.TabIndex = 3;
            this.btnOk_scan.Text = "Ok";
            this.btnOk_scan.UseVisualStyleBackColor = true;
            this.btnOk_scan.Click += new System.EventHandler(this.btnOk_scan_Click);
            // 
            // ScanMAC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 124);
            this.Controls.Add(this.btnOk_scan);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtScan);
            this.Name = "ScanMAC";
            this.Text = "ScanMAC";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ScanMAC_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtScan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOk_scan;
    }
}