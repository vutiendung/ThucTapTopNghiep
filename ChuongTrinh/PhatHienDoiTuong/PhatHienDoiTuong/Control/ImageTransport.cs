using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;

namespace PhatHienDoiTuong
{
    class ImageTransport
    {
        private static ImageTransport _instance = new ImageTransport();
        private Image<Gray, byte> image = null;

        public static ImageTransport Instance
        {
            get
            {
                return _instance;
            }
        }

        public void setImage(Image<Bgr, byte> image)
        {
            this.image = image.Convert<Gray, byte>();
        }

        public Image<Gray, byte> GetImage()
        {
            return image;
        }
    }
}
