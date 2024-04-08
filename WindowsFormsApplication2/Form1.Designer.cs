namespace WindowsFormsApplication2
{
    partial class Form1
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
            this.openPacsBrowser1 = new PacsDigital.OpenPacsBrowser();
            this.SuspendLayout();
            // 
            // openPacsBrowser1
            // 
            this.openPacsBrowser1.AutoSize = true;
            this.openPacsBrowser1.Location = new System.Drawing.Point(87, 177);
            this.openPacsBrowser1.Name = "openPacsBrowser1";
            this.openPacsBrowser1.Size = new System.Drawing.Size(115, 33);
            this.openPacsBrowser1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.openPacsBrowser1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PacsDigital.OpenPacsBrowser openPacsBrowser1;


    }
}

