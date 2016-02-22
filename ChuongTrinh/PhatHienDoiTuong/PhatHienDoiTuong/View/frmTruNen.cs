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
    public partial class frmTruNen : Form
    {
        private Image<Gray, byte> backgrImage;
        private Image<Gray, byte> nextImage;
        private int count = 0;
        VideoUlity videoProcessing = new VideoUlity();
        StructuringElementEx structElement = new StructuringElementEx(3, 3, 1, 1, Emgu.CV.CvEnum.CV_ELEMENT_SHAPE.CV_SHAPE_RECT);
        private Image<Bgr, byte> image;
        private bool isFirst = true;

        public frmTruNen()
        {
            InitializeComponent();
        }

        private void FrmTruNenLoad(object sender, EventArgs e)
        {
        }

        public void Process(Image<Bgr,byte> image2)
        {
            image = image2.Clone();
            var t = new Thread(ProcessImage);
            t.Start();
        }

        public void ProcessImage()
        {
            //4 frame update lai background
            nextImage = image.Convert<Gray, byte>();
            if(isFirst)
            {
                backgrImage = nextImage;
                isFirst = !isFirst;
            }
            else
            {
                {
                    if (count == 4)
                    {
                        count = -1;
                        backgrImage = videoProcessing.UpdateBackground(nextImage, backgrImage);
                    }
                } 
            }
            
            count++;

            var imgTruanh = videoProcessing.DetectDifference(backgrImage, nextImage, 50);

            //tien xu ly anh
            var finalImage = new Image<Gray, byte>(imgTruanh.Width, imgTruanh.Height);
            imgTruanh = imgTruanh.SmoothMedian(3);
            imgTruanh = videoProcessing.CloseImage(imgTruanh);
            imgTruanh = videoProcessing.CloseImage(imgTruanh);
            var imgTemplate = new Image<Gray, byte>(imgTruanh.Width, imgTruanh.Height);
            CvInvoke.cvMorphologyEx(imgTruanh, finalImage, imgTemplate, structElement, Emgu.CV.CvEnum.CV_MORPH_OP.CV_MOP_CLOSE, 5);

            //finalImage la anh sau khi da xu ly
            
            var listRectange = videoProcessing.DetectBlock(finalImage, 120, 170);

            //ve khung bao quanh doi tuong
            for (int i = listRectange.Count - 1; i >= 0; --i)
            {
                var drawRec = new Rectangle(
                    listRectange[i].X,
                    listRectange[i].Y,
                    listRectange[i].Size.Width,
                    listRectange[i].Size.Height
                    );
                image.Draw(drawRec, new Bgr(Color.Red), 2);
            }
            _picScreen.Image = image.ToBitmap();
        }
    }
}
