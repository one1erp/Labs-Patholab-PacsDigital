namespace PacsDigital
{
    partial class OpenPacsBrowser
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
            this.pacsDigital = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.pacsDigital)).BeginInit();
            this.SuspendLayout();
            // 
            // pacsDigital
            // 
            this.pacsDigital.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pacsDigital.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.pacsDigital.Location = new System.Drawing.Point(1, 1);
            this.pacsDigital.Name = "pacsDigital";
            // 
            // 
            // 
            this.pacsDigital.RootElement.ControlBounds = new System.Drawing.Rectangle(1, 1, 110, 24);
            this.pacsDigital.Size = new System.Drawing.Size(98, 31);
            this.pacsDigital.TabIndex = 0;
            this.pacsDigital.Text = "סריקה דיגיטלית";
            this.pacsDigital.Click += new System.EventHandler(this.pacsDigital_Click);
            // 
            // OpenPacsBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.pacsDigital);
            this.Name = "OpenPacsBrowser";
            this.Size = new System.Drawing.Size(102, 35);
            ((System.ComponentModel.ISupportInitialize)(this.pacsDigital)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadButton pacsDigital;


    }
}
