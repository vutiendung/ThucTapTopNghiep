namespace PhatHienDoiTuong
{
    partial class frmMain
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
            this._btnBrowser = new System.Windows.Forms.Button();
            this._txtPathFile = new System.Windows.Forms.TextBox();
            this._cbCamera = new System.Windows.Forms.ComboBox();
            this._rdVideo = new System.Windows.Forms.RadioButton();
            this._rdCamera = new System.Windows.Forms.RadioButton();
            this.panelHead = new System.Windows.Forms.Panel();
            this._chkChenhlechTamThoi = new System.Windows.Forms.CheckBox();
            this._chkTruNen = new System.Windows.Forms.CheckBox();
            this._btnRun = new System.Windows.Forms.Button();
            this.pictureContain = new System.Windows.Forms.PictureBox();
            this._picScreen = new System.Windows.Forms.PictureBox();
            this._chckOpticalFlow = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.panelHead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureContain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._picScreen)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._btnBrowser);
            this.groupBox1.Controls.Add(this._txtPathFile);
            this.groupBox1.Controls.Add(this._cbCamera);
            this.groupBox1.Controls.Add(this._rdVideo);
            this.groupBox1.Controls.Add(this._rdCamera);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(255, 215);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nguồn";
            // 
            // _btnBrowser
            // 
            this._btnBrowser.Enabled = false;
            this._btnBrowser.Location = new System.Drawing.Point(135, 168);
            this._btnBrowser.Name = "_btnBrowser";
            this._btnBrowser.Size = new System.Drawing.Size(89, 32);
            this._btnBrowser.TabIndex = 10;
            this._btnBrowser.Text = "Chọn file";
            this._btnBrowser.UseVisualStyleBackColor = true;
            this._btnBrowser.Click += new System.EventHandler(this.BtnBrowserClick);
            // 
            // _txtPathFile
            // 
            this._txtPathFile.Enabled = false;
            this._txtPathFile.Location = new System.Drawing.Point(33, 135);
            this._txtPathFile.Name = "_txtPathFile";
            this._txtPathFile.Size = new System.Drawing.Size(191, 23);
            this._txtPathFile.TabIndex = 9;
            // 
            // _cbCamera
            // 
            this._cbCamera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbCamera.FormattingEnabled = true;
            this._cbCamera.Location = new System.Drawing.Point(32, 61);
            this._cbCamera.Name = "_cbCamera";
            this._cbCamera.Size = new System.Drawing.Size(192, 24);
            this._cbCamera.TabIndex = 8;
            // 
            // _rdVideo
            // 
            this._rdVideo.AutoSize = true;
            this._rdVideo.Location = new System.Drawing.Point(21, 105);
            this._rdVideo.Name = "_rdVideo";
            this._rdVideo.Size = new System.Drawing.Size(135, 21);
            this._rdVideo.TabIndex = 7;
            this._rdVideo.Text = "Video từ máy tính";
            this._rdVideo.UseVisualStyleBackColor = true;
            this._rdVideo.CheckedChanged += new System.EventHandler(this.RdVideoCheckedChanged);
            // 
            // _rdCamera
            // 
            this._rdCamera.AutoSize = true;
            this._rdCamera.Checked = true;
            this._rdCamera.Location = new System.Drawing.Point(21, 30);
            this._rdCamera.Name = "_rdCamera";
            this._rdCamera.Size = new System.Drawing.Size(75, 21);
            this._rdCamera.TabIndex = 6;
            this._rdCamera.TabStop = true;
            this._rdCamera.Text = "Camera";
            this._rdCamera.UseVisualStyleBackColor = true;
            this._rdCamera.CheckedChanged += new System.EventHandler(this.RdCameraCheckedChanged);
            // 
            // panelHead
            // 
            this.panelHead.BackColor = System.Drawing.SystemColors.Control;
            this.panelHead.Controls.Add(this._chckOpticalFlow);
            this.panelHead.Controls.Add(this._chkChenhlechTamThoi);
            this.panelHead.Controls.Add(this._chkTruNen);
            this.panelHead.Controls.Add(this._btnRun);
            this.panelHead.Controls.Add(this.groupBox1);
            this.panelHead.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelHead.Location = new System.Drawing.Point(0, 0);
            this.panelHead.Name = "panelHead";
            this.panelHead.Size = new System.Drawing.Size(255, 399);
            this.panelHead.TabIndex = 0;
            // 
            // _chkChenhlechTamThoi
            // 
            this._chkChenhlechTamThoi.AutoSize = true;
            this._chkChenhlechTamThoi.Location = new System.Drawing.Point(38, 261);
            this._chkChenhlechTamThoi.Name = "_chkChenhlechTamThoi";
            this._chkChenhlechTamThoi.Size = new System.Drawing.Size(152, 21);
            this._chkChenhlechTamThoi.TabIndex = 3;
            this._chkChenhlechTamThoi.Text = "Chênh lệch tạm thời";
            this._chkChenhlechTamThoi.UseVisualStyleBackColor = true;
            this._chkChenhlechTamThoi.CheckedChanged += new System.EventHandler(this.ChckChenhlechTamThoiCheckedChanged);
            // 
            // _chkTruNen
            // 
            this._chkTruNen.AutoSize = true;
            this._chkTruNen.Location = new System.Drawing.Point(37, 234);
            this._chkTruNen.Name = "_chkTruNen";
            this._chkTruNen.Size = new System.Drawing.Size(77, 21);
            this._chkTruNen.TabIndex = 2;
            this._chkTruNen.Text = "Trừ nền";
            this._chkTruNen.UseVisualStyleBackColor = true;
            this._chkTruNen.CheckedChanged += new System.EventHandler(this.ChkTruNenCheckedChanged);
            // 
            // _btnRun
            // 
            this._btnRun.Location = new System.Drawing.Point(136, 361);
            this._btnRun.Name = "_btnRun";
            this._btnRun.Size = new System.Drawing.Size(89, 30);
            this._btnRun.TabIndex = 1;
            this._btnRun.Text = "Run";
            this._btnRun.UseVisualStyleBackColor = true;
            this._btnRun.Click += new System.EventHandler(this.BtnRunClick);
            // 
            // pictureContain
            // 
            this.pictureContain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureContain.Location = new System.Drawing.Point(255, 0);
            this.pictureContain.Name = "pictureContain";
            this.pictureContain.Size = new System.Drawing.Size(572, 399);
            this.pictureContain.TabIndex = 1;
            this.pictureContain.TabStop = false;
            // 
            // _picScreen
            // 
            this._picScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this._picScreen.Location = new System.Drawing.Point(255, 0);
            this._picScreen.Name = "_picScreen";
            this._picScreen.Size = new System.Drawing.Size(572, 399);
            this._picScreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this._picScreen.TabIndex = 2;
            this._picScreen.TabStop = false;
            // 
            // _chckOpticalFlow
            // 
            this._chckOpticalFlow.AutoSize = true;
            this._chckOpticalFlow.Location = new System.Drawing.Point(38, 288);
            this._chckOpticalFlow.Name = "_chckOpticalFlow";
            this._chckOpticalFlow.Size = new System.Drawing.Size(99, 21);
            this._chckOpticalFlow.TabIndex = 4;
            this._chckOpticalFlow.Text = "OpticalFlow";
            this._chckOpticalFlow.UseVisualStyleBackColor = true;
            this._chckOpticalFlow.CheckedChanged += new System.EventHandler(this.ChckOpticalFlowCheckedChanged);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 399);
            this.Controls.Add(this._picScreen);
            this.Controls.Add(this.pictureContain);
            this.Controls.Add(this.panelHead);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phát Hiện Đối Tượng";
            this.Load += new System.EventHandler(this.FrmMainLoad);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelHead.ResumeLayout(false);
            this.panelHead.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureContain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._picScreen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button _btnBrowser;
        private System.Windows.Forms.TextBox _txtPathFile;
        private System.Windows.Forms.ComboBox _cbCamera;
        private System.Windows.Forms.RadioButton _rdVideo;
        private System.Windows.Forms.RadioButton _rdCamera;
        private System.Windows.Forms.Panel panelHead;
        private System.Windows.Forms.PictureBox pictureContain;
        private System.Windows.Forms.Button _btnRun;
        private System.Windows.Forms.CheckBox _chkTruNen;
        private System.Windows.Forms.PictureBox _picScreen;
        private System.Windows.Forms.CheckBox _chkChenhlechTamThoi;
        private System.Windows.Forms.CheckBox _chckOpticalFlow;

    }
}

