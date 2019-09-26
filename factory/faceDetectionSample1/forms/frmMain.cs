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
    public partial class frmMain : Form
    {
        emgu.capture _capture;

        public frmMain()
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

        private void frmMain_Load(object sender, EventArgs e)
        {
            this._capture.start();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this._capture.stop();

            frmRegister _frmRegister = new frmRegister();
            DialogResult result = _frmRegister.ShowDialog(this);

            this._capture.start();
        }
    }
}
