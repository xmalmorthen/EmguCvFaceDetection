using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emgu
{
    public class capture
    {
        private VideoCapture _capture = null;
        private ImageBox objImg = null;
        private VideoCapture Capture { get => _capture; set => _capture = value; }
        
        public capture(ImageBox objImg)
        {
            this.objImg = objImg;
            this.Capture = new VideoCapture();
        }


        public void ProcessFrame(object sender, EventArgs arg)
        {
            if (this.Capture != null && this.Capture.Ptr != IntPtr.Zero)
            {
                Mat frame = this.Capture.QueryFrame();

                long detectionTime;
                List<Rectangle> faces = new List<Rectangle>();
                List<Rectangle> eyes = new List<Rectangle>();
                face.detect(frame, "haarcascade_frontalface_default.xml", "haarcascade_eye.xml", faces, eyes, out detectionTime);

                this._faceDetected = faces.Count() > 0 ? true : false;
                this._facesDetected = (short)faces.Count();

                foreach (Rectangle face in faces)
                {
                    Rectangle recFrame = new Rectangle(face.X, face.Y, face.Width, face.Height);

                    CvInvoke.Rectangle(frame, recFrame, new Bgr(Color.Red).MCvScalar, 2);
                    
                    //CvInvoke.Rectangle(frame, new Rectangle(recFrame.X, recFrame.Y - 20, recFrame.Width / 2, 20), new Bgr(Color.Red).MCvScalar, -1);
                    //CvInvoke.PutText(frame, "Xmal", new Point(recFrame.X + 3, recFrame.Y - 3), FontFace.HersheyComplexSmall, 1.0, new MCvScalar(255.0, 255.0, 255.0), 1);

                }

                this.objImg.Image = frame;
            }
        }

        public void start() {
            this.Capture.Start();            
        }

        public void stop() {
            this.Capture.Stop();
        }

        private ImageBox pictureImage = new ImageBox();
        private Bitmap pictureBitmap = null;
        public Bitmap getPictureBitmap { 
            get
            {
                this.pictureImage.Image = this.Capture.QueryFrame();

                this.pictureBitmap = this.pictureImage.Image.Bitmap;
                return this.pictureBitmap;
            }
        }

        public Byte[] getPictureByte {
            get 
            {
                if (this.pictureBitmap == null)
                {
                    this.pictureImage.Image = this.Capture.QueryFrame();
                    this.pictureBitmap = this.objImg.Image.Bitmap;
                }

                Bitmap faceToSave = this.pictureBitmap;
                ImageConverter converter = new ImageConverter();
                return (byte[])converter.ConvertTo(this.objImg.Image.Bitmap, typeof(byte[]));
            }
        }

        private Boolean _faceDetected = false;
        public Boolean faceDetected { get => this._faceDetected; }

        private short _facesDetected = 0;
        public short facesDetected { get => this._facesDetected; }

    }
}
