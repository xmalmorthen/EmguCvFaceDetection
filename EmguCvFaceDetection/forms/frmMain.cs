using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Face;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using FaceDetection;

namespace EmguCvFaceDetection
{
    public partial class frmMain : Form
    {
        private VideoCapture _capture = null;

        public frmMain()
        {
            InitializeComponent();
            try
            {
                _capture = new VideoCapture();                
            }
            catch (NullReferenceException excpt)
            {
                MessageBox.Show(excpt.Message);
            }            

            Application.Idle += ProcessFrame;
        }


        private void ProcessFrame(object sender, EventArgs arg)
        {
            if (_capture != null && _capture.Ptr != IntPtr.Zero)
            {
                Mat frame = _capture.QueryFrame();

                long detectionTime;
                List<Rectangle> faces = new List<Rectangle>();
                List<Rectangle> eyes = new List<Rectangle>();

                DetectFace.Detect(frame, "haarcascade_frontalface_default.xml", "haarcascade_eye.xml",faces, eyes,out detectionTime);

                foreach (Rectangle face in faces)
                {
                    Rectangle recFrame = new Rectangle(face.X, face.Y, face.Width, face.Height);

                    CvInvoke.Rectangle(frame, recFrame, new Bgr(Color.Red).MCvScalar, 2);
                    CvInvoke.Rectangle(frame, new Rectangle(recFrame.X, recFrame.Y - 20, recFrame.Width / 2, 20), new Bgr(Color.Red).MCvScalar, -1);
                    CvInvoke.PutText(frame, "Xmal", new Point(recFrame.X + 3, recFrame.Y - 3), FontFace.HersheyComplexSmall,1.0, new MCvScalar(255.0, 255.0, 255.0),1);
                }

                pbImg.Image = frame;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (_capture != null)
            {
                _capture.Start();
            }
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            Bitmap faceToSave = pbImg.Image.Bitmap;
            ImageConverter converter = new ImageConverter();

            Byte[] file = (byte[])converter.ConvertTo(pbImg.Image.Bitmap, typeof(byte[]));

            IDataStoreAccess dataStore = new DataStoreAccess(@"db/imagesDB.db");
            var result = dataStore.SaveFace("xmal", file);
            MessageBox.Show(result, "Save Result", MessageBoxButtons.OK);
            
        }
    }
}
