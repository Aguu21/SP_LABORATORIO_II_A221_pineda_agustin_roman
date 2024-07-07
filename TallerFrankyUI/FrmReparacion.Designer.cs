namespace TallerFrankyUi
{
    partial class FrmReparacion
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReparacion));
            this.lstTaller = new System.Windows.Forms.ListBox();
            this.RepararBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstTaller
            // 
            this.lstTaller.FormattingEnabled = true;
            this.lstTaller.ItemHeight = 16;
            this.lstTaller.Location = new System.Drawing.Point(229, 143);
            this.lstTaller.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstTaller.Name = "lstTaller";
            this.lstTaller.Size = new System.Drawing.Size(792, 292);
            this.lstTaller.TabIndex = 0;
            // 
            // RepararBtn
            // 
            this.RepararBtn.Location = new System.Drawing.Point(142, 45);
            this.RepararBtn.Name = "RepararBtn";
            this.RepararBtn.Size = new System.Drawing.Size(75, 23);
            this.RepararBtn.TabIndex = 1;
            this.RepararBtn.Text = "RepararBtn";
            this.RepararBtn.UseVisualStyleBackColor = true;
            this.RepararBtn.Click += new System.EventHandler(this.RepararBtn_Click);
            // 
            // FrmReparacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1305, 674);
            this.Controls.Add(this.RepararBtn);
            this.Controls.Add(this.lstTaller);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmReparacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmReparacion";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmReparacion_FormClosing);
            this.Load += new System.EventHandler(this.FrmReparacion_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstTaller;
        private System.Windows.Forms.Button RepararBtn;
    }
}

