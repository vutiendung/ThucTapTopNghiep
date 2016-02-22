using System;
using System.Globalization;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using DirectShowLib;

namespace PhatHienDoiTuong
{
    public partial class frmMain : Form
    {
        #region Field

        private frmTruNen _frmTruNen;
        private frmChenhLechTamThoi _frmChenhLechTamThoi;
        private frmOpticalFlow _frmOpticalFlow;
        private Image<Bgr, byte> _imageTemp;
        private bool _run = true;
        #endregion

        #region Constructor

        public frmMain()
        {
            InitializeComponent();
        }

        #endregion

        #region Event

        private void BtnRunClick(object sender, EventArgs e)
        {
            Capture cap = null;
            if (_rdCamera.Checked)
            {
                cap = new Capture(0);
                _run = true;
            }
            else
            {
                if(_rdVideo.Checked)
                {
                    var filePath = _txtPathFile.Text;
                    if(System.IO.File.Exists(filePath))
                    {
                        cap = new Capture(@"F:/Videos/MV/Crazier.mp4");
                        _run = true;
                    }
                    else
                    {
                        _run = !_run;
                        MessageBox.Show(
                            "File not Found!", 
                            "Error", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Error);
                    }
                }
            }

            //vong lap chay vo han lay anh
            while (_run)
            {
                if (cap != null) _imageTemp = cap.QueryFrame();
                _picScreen.Image = _imageTemp.ToBitmap();
                if (_frmTruNen == null || _frmTruNen.IsDisposed)
                {
                    _frmTruNen = new frmTruNen();
                }

                if(_frmChenhLechTamThoi != null)
                {
                    _frmChenhLechTamThoi.Process(_imageTemp);
                }
                if(_frmTruNen != null)
                {
                    _frmTruNen.Process(_imageTemp);
                }
                if(_frmOpticalFlow != null)
                {
                    _frmOpticalFlow.Process(_imageTemp);
                }
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
            var systemCameras = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);
            var deviceIndex = 0;
            foreach (var camera in systemCameras)
            {
                deviceIndex++;
                _cbCamera.Items.Add(deviceIndex.ToString(CultureInfo.InvariantCulture) + "-" + camera.Name);
            }
            _cbCamera.SelectedIndex = 0;
        }

        private void ChkTruNenCheckedChanged(object sender, EventArgs e)
        {
            if(_chkTruNen.Checked)
            {
                if(_frmTruNen == null)
                {
                    _frmTruNen = new frmTruNen();
                }
                _frmTruNen.Show();
            }
            else
            {
                _frmTruNen.Close();
                _frmTruNen = null;
            }
        }

        private void ChckChenhlechTamThoiCheckedChanged(object sender, EventArgs e)
        {
            if(_chkChenhlechTamThoi.Checked)
            {
                if(_frmChenhLechTamThoi == null)
                {
                    _frmChenhLechTamThoi = new frmChenhLechTamThoi();
                }
                _frmChenhLechTamThoi.Show();
            }
            else
            {
                _frmChenhLechTamThoi.Close();
                _frmChenhLechTamThoi = null;
            }
        }

        private void BtnBrowserClick(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog {Title = "Select file Videos"};
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _txtPathFile.Text = openFileDialog.FileName;
            }
        }

        private void ChckOpticalFlowCheckedChanged(object sender, EventArgs e)
        {
            if(_chckOpticalFlow.Checked)
            {
                if(_frmOpticalFlow == null)
                {
                    _frmOpticalFlow = new frmOpticalFlow(); 
                }
                _frmOpticalFlow.Show();
            }
            else
            {
                _frmOpticalFlow.Close();
                _frmOpticalFlow = null;
            }
        }

        #endregion
    }
}
