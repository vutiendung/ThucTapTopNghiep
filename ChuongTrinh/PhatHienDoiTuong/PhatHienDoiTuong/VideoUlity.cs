using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;
using System.Drawing;

namespace PhatHienDoiTuong
{
    class VideoUlity
    {
        /// <summary>
        /// thuật toán đóng ảnh
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public Image<Gray, byte> CloseImage(Image<Gray, byte> image)
        {
            byte rows = 1;
            byte column = 2;
            Image<Gray, byte> imageResult = new Image<Gray, byte>(image.Data);
            byte[, ,] imgData = image.Data;
            byte[, ,] imgResult = imageResult.Data;


            int height = image.Height;
            int width = image.Width;

            for (int i = rows; i < height - rows; i++)
            {
                for (int j = column; j < width - column; j++)
                {
                    if (imgData[i, j, 0] == 0)
                    {
                        if (imgData[i, j + 1, 0] == 255 || imgData[i, j - 1, 0] == 255)
                        {
                            imgResult[i, j, 0] = 255;
                            imgResult[i + 1, j, 0] = 255;

                            imgResult[i, j + 1, 0] = 255;
                            imgResult[i, j - 1, 0] = 255;
                        }
                    }
                    else
                    {
                        if (imgData[i, j + 1, 0] == 0 && imgData[i, j - 1, 0] == 0 && imgData[i - 1, j, 0] == 0 && imgData[i + 1, j, 0] == 0)
                            imgResult[i, j, 0] = 0;
                    }
                }
            }
            return new Image<Gray, byte>(imgResult);
        }

        /// <summary>
        /// hàm trừ hai ảnh và trả về ảnh sau khi đã trừ (0 hoặc 255 tương ứng là màu đen hoặc màu trắng)
        /// </summary>
        /// <param name="imgBackground"></param>
        /// <param name="imgNow"></param>
        /// <param name="threshold"></param>
        /// <returns></returns>
        public Image<Gray, byte> DetectDifference(Image<Gray, byte> imgBackground, Image<Gray, byte> imgNow, int threshold)
        {
            int width = imgBackground.Width;
            int height = imgBackground.Height;
            byte[, ,] dataBackground = imgBackground.Data;
            byte[, ,] dataNow = imgNow.Data;
            byte[, ,] dataResult = new byte[height, width, 1];

            const int COLOR_WHITE = 255;

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    int KQ = Math.Abs(dataNow[i, j, 0] - dataBackground[i, j, 0]);
                    /*
                     * Nếu KQ lớn hơn sai số cho phép thì đó là hình chuyển động
                     * Ngược lại thì đó là hình nền
                     */
                    if (KQ >= threshold)
                    {
                        dataResult[i, j, 0] = COLOR_WHITE;
                    }
                }
            }
            return new Image<Gray, byte>(dataResult);
        }

        /// <summary>
        /// hàm phát hiện các khối blobs sau khi đã trừ ảnh và tiền xử lý ảnh
        /// </summary>
        /// <param name="imgGray"></param>
        /// <param name="objectWidth"></param>
        /// <param name="objectHeight"></param>
        /// <returns></returns>
        public List<Rectangle> DetectBlock(Image<Gray, byte> imgGray, int objectWidth, int objectHeight)
        {
            byte[, ,] data = imgGray.Data;
            int width = imgGray.Width;
            int height = imgGray.Height;

            List<Point> listPoint = new List<Point>(); ;
            List<Rectangle> listRectange = new List<Rectangle>();
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    /*
                     * Kiểm tra xem điểm ảnh đang xét có phải là màu trắng hay không
                     * Nếu đúng thì ta sẽ tiến hành loang khu vực này và lưu toàn bộ các giá trị có màu trắng
                     * trong vùng đó vào biến listPoint
                     */
                    if (data[i, j, 0] == 255)
                    {
                        loang(data, i, j, width, height, ref listPoint);
                        /*
                         * Sau khi loang xong thì vùng đang xét sẽ được lưu vào biến listPoint
                         * Ta cần tìm ra hình chữ nhật lớn nhất bao quanh vùng này
                         * Nếu diện tích của nó quá nhỏ thì kết luận là nhiễu, ta k xét trường hợp này
                         * Ngược lại thì đó là vùng chứa đối tượng chuyển động
                         * */
                        if (listPoint.Count != 0)
                        {
                            Rectangle rcSource = getRectangle(listPoint);
                            int area = rcSource.Width * rcSource.Height;
                            if (rcSource.Width >= 50 && rcSource.Height >= 50)
                            {
                                listRectange.Add(rcSource);
                            }
                        }
                        listPoint = new List<Point>();
                    }
                }
            }
            return listRectange;
        }

        /// <summary>
        /// hàm tìm ra hình chữ nhật nhỏ nhất bao quanh tập điểm cho trước
        /// </summary>
        /// <param name="listPoint"></param>
        /// <returns></returns>
        private Rectangle getRectangle(List<Point> listPoint)
        {
            int minX = listPoint[0].X;
            int minY = listPoint[0].Y;
            int maxX = listPoint[0].X;
            int maxY = listPoint[0].Y;
            for (int i = 1; i < listPoint.Count; i++)
            {
                int x = listPoint[i].X;
                int y = listPoint[i].Y;
                if (x < minX) minX = x;
                if (x > maxX) maxX = x;
                if (y < minY) minY = y;
                if (y > maxY) maxY = y;
            }
            Point p = new Point(minY, minX);
            Size s = new Size(maxY - minY, maxX - minX);
            Rectangle rcResult = new Rectangle(p, s);
            return rcResult;
        }

        /// <summary>
        /// Hàm loang ảnh không sử dụng đệ quy
        /// </summary>
        /// <param name="data"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="listPoint"></param>
        private void loang(byte[, ,] data, int i, int j, int width, int height, ref List<Point> listPoint)
        {
            byte fillColor = 0;
            byte backgroundColor = 255;
            Queue<Point> queue = new Queue<Point>();
            if (backgroundColor == fillColor) return;
            if (i + 1 >= height || i - 1 <= 0 || j + 1 >= width || j - 1 <= 0) return;

            queue.Enqueue(new Point(i, j));
            listPoint.Add(new Point(i, j));

            while (queue.Count > 0)
            {
                Point currentPoint = queue.Dequeue();
                byte currentColor = data[currentPoint.X, currentPoint.Y, 0];
                int x = currentPoint.X;
                int y = currentPoint.Y;

                if (currentColor == backgroundColor)
                {
                    data[x, y, 0] = fillColor;
                    listPoint.Add(new Point(x, y));
                    if (!(x + 1 >= height))
                    {
                        queue.Enqueue(new Point(x + 1, y));
                    }
                    if (!(x - 1 <= 00))
                    {
                        queue.Enqueue(new Point(x - 1, currentPoint.Y));
                    }
                    if (!(y + 1 >= width))
                    {
                        queue.Enqueue(new Point(x, y + 1));
                    }
                    if (!(y - 1 <= 0))
                    {
                        queue.Enqueue(new Point(x, y - 1));
                    }
                }
            }
        }

        /// <summary>
        /// Hàm cập nhật background cho nền dựa  vào công thức chuẩn
        /// </summary>
        /// <param name="imgNow"></param>
        /// <param name="imgBackground"></param>
        /// <returns></returns>
        public Image<Gray, byte> UpdateBackground(Image<Gray, byte> imgNow, Image<Gray, byte> imgBackground)
        {
            byte[, ,] dataNow = imgNow.Data;
            byte[, ,] dataBackground = imgBackground.Data;
            byte[, ,] dataResult = new byte[imgNow.Height, imgNow.Width, 1];
            //cap nhat nen
            float alpha = 0.5f;
            for (int i = 0; i < imgNow.Height; i++)
            {
                for (int j = 0; j < imgNow.Width; j++)
                {
                    float KQ = alpha * dataNow[i, j, 0] + (1 - alpha) * dataBackground[i, j, 0];
                    if (KQ > 255) KQ = 255;
                    else if (KQ < 0) KQ = 0;
                    dataResult[i, j, 0] = (byte)KQ;
                }
            }
            return new Image<Gray, byte>(dataResult);
        }

        /// <summary>
        /// Tính sai số giữa hai ảnh
        /// </summary>
        /// <param name="img1"></param>
        /// <param name="img2"></param>
        /// <returns></returns>
        private int CaculateErrorTwoImage(Image<Gray, byte> img1, Image<Gray, byte> img2)
        {
            byte[, ,] data1 = img1.Data;
            byte[, ,] data2 = img2.Data;
            int width = img1.Width;
            int height = img1.Height;
            int sum = 0;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    sum += Math.Abs(data1[i, j, 0] - data2[i, j, 0]);
                }
            }
            return sum / (width * height);
        }

        /// <summary>
        /// Khử nhiễu
        /// </summary>
        /// <param name="imgSource"></param>
        /// <returns></returns>
        public Image<Gray, byte> RemoveNoise(Image<Gray, byte> imgSource)
        {
            byte[, ,] data = imgSource.Data;
            for (int i = 1; i < imgSource.Height - 1; i++)
            {
                for (int j = 1; j < imgSource.Width - 1; j++)
                {
                    if (data[i, j, 0] == 255)
                    {
                        if (data[i, j, 0] == 0
                            && data[i, j, 0] == 0
                            && data[i, j, 0] == 0
                            && data[i, j, 0] == 0)
                        {
                            data[i, j, 0] = 0;
                        }
                    }
                }
            }
            imgSource.Data = data;
            return imgSource;
        }

        /// <summary>
        /// Hàm lọc màu ảnh
        /// </summary>
        /// <param name="imgSource"></param>
        /// <returns></returns>
        public Image<Gray, byte> FilterImage(Image<Gray, byte> imgSource)
        {
            int MIN = 40;
            int MAX = 255;
            byte[, ,] data = imgSource.Data;
            for (int i = 0; i < imgSource.Height; i++)
            {
                for (int j = 0; j < imgSource.Width; j++)
                {
                    if (data[i, j, 0] >= MIN && data[i, j, 0] <= MAX)
                    {
                        data[i, j, 0] = 255;
                    }
                    else
                    {
                        data[i, j, 0] = 0;
                    }
                }
            }
            imgSource.Data = data;
            return imgSource;
        }
    }
}
