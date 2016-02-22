using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;

namespace PhatHienDoiTuong
{
    public partial class frmOpticalFlow : Form
    {
        private Image<Bgr, byte> Image; 
        public frmOpticalFlow()
        {
            InitializeComponent();
        }

        public void Process(Image<Bgr,byte> image)
        {
            Image = image;
            var t = new Thread(Run);
            t.Start();
        }

        private void Run()
        {
            _picScreen.Image = Image.ToBitmap();
        }
    }
}
