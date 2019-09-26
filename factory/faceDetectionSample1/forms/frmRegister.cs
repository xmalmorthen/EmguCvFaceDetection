using DAL.dataBases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace faceDetectionSample1.forms
{

    public partial class frmRegister : Form
    {
        emgu.capture _capture;

        public frmRegister()
        {
            InitializeComponent();

            try
            {
                this._capture = new emgu.capture(pbImg);
                Application.Idle += this._capture.ProcessFrame;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void frmRegister_Load(object sender, EventArgs e)
        {
            this._capture.start();
        }

        private void frmRegister_FormClosed(object sender, FormClosedEventArgs e)
        {
            this._capture.stop();
            Application.Idle -= this._capture.ProcessFrame;
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            pbPicture.Image = this._capture.getPictureBitmap;
            //pbPicture.Visible = true;
            btnOtherPicture.Visible = true;

            //pbImg.Visible = false;
            //btnCapture.Visible = false;

        }

        private void btnOtherPicture_Click(object sender, EventArgs e)
        {
            pbImg.Visible = true;
            btnCapture.Visible = true;

            pbPicture.Visible = false;
            btnOtherPicture.Visible = false;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {

            DAL.actions.post _dalPost = new DAL.actions.post();

            caUsers model = _dalPost.saveUser(
                new caUsers
                {
                    caPerson = new caPerson
                    {
                        fIns = DateTime.Now,
                        ap1 = this.txtAp1.Text.Trim().ToUpper(),
                        ap2 = this.txtAp2.Text.Trim().ToUpper(),
                        names = this.txtNames.Text.Trim().ToUpper(),
                    },
                    nip = this.txtNip.Text.Trim(),
                    username = this.txtUserName.Text.Trim(),
                    active = true,
                    fIns = DateTime.Now
                }
            );

            caFaces face = _dalPost.saveFace(
                new caFaces
                {
                    fIns = DateTime.Now,
                    idUsr = model.id,
                    face = this._capture.getPictureByte,
                    active = true
                }
            );

        }
    }
}
