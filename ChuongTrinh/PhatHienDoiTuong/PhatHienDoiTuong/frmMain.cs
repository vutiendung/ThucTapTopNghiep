using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;
using DirectShowLib;

namespace PhatHienDoiTuong
{
    public partial class frmMain : Form
    {
        #region Field

        private frmTruNen _frmTruNen;
        private Image<Bgr, byte> imageTemp;

        public delegate void SendImage(Image<Bgr, byte> image);

        public SendImage sendImage;

        #endregion

        #region Constructor

        public frmMain()
        {
            InitializeComponent();
        }

        #endregion

        private void BtnRunClick(object sender, EventArgs e)
        {
            Capture cap = new Capture(0);
            while(true)
            {
                imageTemp = cap.QueryFrame();
                _picScreen.Image = imageTemp.ToBitmap();
                SendKeys.Flush();
            }
        }

        private void RdCameraCheckedChanged(object sender, EventArgs e)
        {
            _btnBrowser.Enabled = false;
            if(_cbCamera.Enabled == false)
            {
                _cbCamera.Enabled = true;
            }
        }

        private void RdVideoCheckedChanged(object sender, EventArgs e)
        {
            _cbCamera.Enabled = false;
            if(_btnBrowser.Enabled == false)
            {
                _btnBrowser.Enabled = true;
            }
        }

        private void FrmMainLoad(object sender, EventArgs e)
        {
            LoadAllCamera();
        }

        private void LoadAllCamera()
        {
            DsDevice[] _SystemCamereas = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);
            int _DeviceIndex = 0;
            foreach (DirectShowLib.DsDevice _Camera in _SystemCamereas)
            {
                _DeviceIndex++;
                _cbCamera.Items.Add(_DeviceIndex.ToString() + "-" + _Camera.Name);
            }
            _cbCamera.SelectedIndex = 0;
        }

        private void ChkTruNenCheckedChanged(object sender, EventArgs e)
        {
            if(_chkTruNen.Checked == true)
            {
                if(_frmTruNen == null || _frmTruNen.IsDisposed)
                {
                    _frmTruNen = new frmTruNen();
                    _frmTruNen.Show();
                }
            }
            else
            {
                _frmTruNen.Close();
                _frmTruNen = null;
            }
        }
    }
}
