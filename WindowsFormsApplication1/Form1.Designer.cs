using LSSERVICEPROVIDERLib;
namespace WindowsFormsApplication1
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
            this.openPacsDigital1 = new PacsDigital.OpenPacsDigital();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxSDG = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // openPacsDigital1
            // 
            this.openPacsDigital1.Location = new System.Drawing.Point(70, 200);
            this.openPacsDigital1.Name = "openPacsDigital1";
            this.openPacsDigital1.Size = new System.Drawing.Size(150, 39);
            this.openPacsDigital1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(12, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(274, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "enter sdg id or \"test\" for testing";
            // 
            // textBoxSDG
            // 
            this.textBoxSDG.Location = new System.Drawing.Point(93, 66);
            this.textBoxSDG.Name = "textBoxSDG";
            this.textBoxSDG.Size = new System.Drawing.Size(100, 20);
            this.textBoxSDG.TabIndex = 3;
            this.textBoxSDG.TextChanged += new System.EventHandler(this.textBoxSDG_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.textBoxSDG);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.openPacsDigital1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PacsDigital.OpenPacsDigital openPacsDigital1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxSDG;
    }
}

