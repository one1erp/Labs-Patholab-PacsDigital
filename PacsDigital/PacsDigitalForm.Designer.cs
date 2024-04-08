namespace PacsDigital
{
    partial class PacsDigitalForm
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
            this.clearUrl = new System.Windows.Forms.Button();
            this.closeUrl = new System.Windows.Forms.Button();
            this.testUrl = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.URLTestLabel = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // clearUrl
            // 
            this.clearUrl.Location = new System.Drawing.Point(115, 496);
            this.clearUrl.Name = "clearUrl";
            this.clearUrl.Size = new System.Drawing.Size(75, 23);
            this.clearUrl.TabIndex = 0;
            this.clearUrl.Text = "Clear URL";
            this.clearUrl.UseVisualStyleBackColor = true;
            this.clearUrl.Click += new System.EventHandler(this.clearUrl_Click);
            // 
            // closeUrl
            // 
            this.closeUrl.Location = new System.Drawing.Point(342, 496);
            this.closeUrl.Name = "closeUrl";
            this.closeUrl.Size = new System.Drawing.Size(75, 23);
            this.closeUrl.TabIndex = 1;
            this.closeUrl.Text = "IDS7";
            this.closeUrl.UseVisualStyleBackColor = true;
            this.closeUrl.Click += new System.EventHandler(this.closeUrl_Click);
            // 
            // testUrl
            // 
            this.testUrl.Location = new System.Drawing.Point(597, 496);
            this.testUrl.Name = "testUrl";
            this.testUrl.Size = new System.Drawing.Size(75, 23);
            this.testUrl.TabIndex = 2;
            this.testUrl.Text = "UniView";
            this.testUrl.UseVisualStyleBackColor = true;
            this.testUrl.Click += new System.EventHandler(this.testUrl_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(12, 3);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(750, 487);
            this.webBrowser1.TabIndex = 3;
            this.webBrowser1.Url = new System.Uri("http://fff", System.UriKind.Absolute);
            // 
            // URLTestLabel
            // 
            this.URLTestLabel.Location = new System.Drawing.Point(41, 529);
            this.URLTestLabel.Name = "URLTestLabel";
            this.URLTestLabel.Size = new System.Drawing.Size(699, 20);
            this.URLTestLabel.TabIndex = 4;
            // 
            // PacsDigitalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 561);
            this.Controls.Add(this.URLTestLabel);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.testUrl);
            this.Controls.Add(this.closeUrl);
            this.Controls.Add(this.clearUrl);
            this.Name = "PacsDigitalForm";
            this.Text = "PacsDigitalForm";
            this.SizeChanged += new System.EventHandler(this.PacsDigitalForm_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button clearUrl;
        private System.Windows.Forms.Button closeUrl;
        private System.Windows.Forms.Button testUrl;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.TextBox URLTestLabel;
    }
}