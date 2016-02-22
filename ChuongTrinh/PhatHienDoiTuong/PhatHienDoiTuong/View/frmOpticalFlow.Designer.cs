namespace PhatHienDoiTuong
{
    partial class frmOpticalFlow
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
            this._picScreen.Size = new System.Drawing.Size(640, 442);
            this._picScreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this._picScreen.TabIndex = 1;
            this._picScreen.TabStop = false;
            // 
            // frmOpticalFlow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 442);
            this.Controls.Add(this._picScreen);
            this.Name = "frmOpticalFlow";
            this.ShowIcon = false;
            this.Text = "Optical Flow";
            ((System.ComponentModel.ISupportInitialize)(this._picScreen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox _picScreen;
    }
}