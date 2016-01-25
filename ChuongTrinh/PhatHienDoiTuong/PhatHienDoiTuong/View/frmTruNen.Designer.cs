namespace PhatHienDoiTuong
{
    partial class frmTruNen
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
            this._picScreen = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this._picScreen)).BeginInit();
            this.SuspendLayout();
            // 
            // _picScreen
            // 
            this._picScreen.Dock = System.Windows.Forms.DockStyle.Left;
            this._picScreen.Location = new System.Drawing.Point(0, 0);
            this._picScreen.Name = "_picScreen";
            this._picScreen.Size = new System.Drawing.Size(475, 453);
            this._picScreen.TabIndex = 0;
            this._picScreen.TabStop = false;
            // 
            // frmTruNen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 453);
            this.Controls.Add(this._picScreen);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTruNen";
            this.ShowIcon = false;
            this.Text = "Trừ nền";
            this.Load += new System.EventHandler(this.FrmTruNenLoad);
            ((System.ComponentModel.ISupportInitialize)(this._picScreen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox _picScreen;
    }
}