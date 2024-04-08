namespace PacsDigital
{
    partial class OpenPacsBrowserForWPF
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pacsDigitalForWPF = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pacsDigitalForWPF
            // 
            this.pacsDigitalForWPF.Location = new System.Drawing.Point(1, 1);
            this.pacsDigitalForWPF.Name = "pacsDigitalForWPF";
            this.pacsDigitalForWPF.Size = new System.Drawing.Size(111, 29);
            this.pacsDigitalForWPF.TabIndex = 0;
            this.pacsDigitalForWPF.Text = "סריקה דיגיטלית";
            this.pacsDigitalForWPF.UseVisualStyleBackColor = true;
            this.pacsDigitalForWPF.Click += new System.EventHandler(this.pacsDigitalForWPF_Click);
            // 
            // OpenPacsBrowserForWPF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pacsDigitalForWPF);
            this.Name = "OpenPacsBrowserForWPF";
            this.Size = new System.Drawing.Size(115, 33);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button pacsDigitalForWPF;
    }
}
