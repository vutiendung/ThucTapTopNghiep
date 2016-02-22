using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Threading;

namespace PhatHienDoiTuong
{
    public partial class frmChenhLechTamThoi : Form
    {
        #region Field
        private Image<Gray, byte> _nextImage;
        private Image<Gray, byte> _prevImage;

        List<Rectangle> _lstRectangles = new List<Rectangle>();
        readonly VideoUlity _videoUlity = new VideoUlity();

        private const byte ThressSoild = 20;
        private Image<Bgr, byte> _image;
        private int _width;
        private int _height;
        private bool _isFirst = true;
        #endregion

        #region Constructor
        public frmChenhLechTamThoi()
        {
            InitializeComponent();
        }
        #endregion

        #region Method
        public void Process(Image<Bgr, byte> image2)
        {
            _width = image2.Width;
            _height = image2.Height;
            _image = image2.Clone();
            var t = new Thread(ProcessImage);
            t.Start();
        }

        public void ProcessImage()
        {
            if (_isFirst)
            {
                _nextImage = _prevImage = _image.Convert<Gray, byte>();
                _isFirst = !_isFirst;
            }
            else
            {
                _prevImage = _nextImage;
                _nextImage = _image.Convert<Gray, byte>();
                var imageResult = TinhSuChenhLech();
                _lstRectangles = _videoUlity.DetectBlock(imageResult, imageResult.Width, imageResult.Height);

                //draw rectangle
                foreach (var rectangle in _lstRectangles)
                {
                    var drawRec = new Rectangle(
                    rectangle.X,
                    rectangle.Y,
                    rectangle.Size.Width,
                    rectangle.Size.Height
                    );
                    _image.Draw(drawRec, new Bgr(Color.Yellow), 2);
                }
                _picScreen.Image = _image.Clone().ToBitmap();
            }
        }

        public Image<Gray, byte> TinhSuChenhLech()
        {
            var arrayResult = new byte[_height, _width, 1];
            var nextArray = _nextImage.Data;
            var prevArray = _prevImage.Data;

            for (int i = 0; i < _height; i++ )
            {
                for(int j = 0; j < _width; j++)
                {
                    if(nextArray[i,j,0] - prevArray[i,j,0] > ThressSoild)
                    {
                        arrayResult[i, j, 0] = 255;
                    }
                    else
                    {
                        arrayResult[i, j, 0] = 0;
                    }
                }
            }
            return new Image<Gray, byte>(arrayResult);
        }
        #endregion
    }
}
