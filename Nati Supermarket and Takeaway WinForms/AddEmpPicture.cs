using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using System.IO;

namespace Nati_Supermarket_and_Takeaway_WinForms
{
    public partial class AddEmpPicture : Form
    {
        private FilterInfoCollection webcam;
        private VideoCaptureDevice cam;

        public AddEmpPicture()
        {
            InitializeComponent();
        }

        private void AddEmpPicture_Load(object sender, EventArgs e)
        {
            webcam = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo VideoCaptureDevice in webcam)
            {
                comboBox1.Items.Add(VideoCaptureDevice.Name);
            }
            comboBox1.SelectedIndex = 0;
            btnSavePhoto.Enabled = false;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            cam = new VideoCaptureDevice(webcam[comboBox1.SelectedIndex].MonikerString);
            cam.NewFrame += new NewFrameEventHandler(cam_NewFrame);
            cam.Start();
            btnSavePhoto.Enabled = true;
        }
        void cam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bit = (Bitmap)eventArgs.Frame.Clone();
            pictureBox1.Image = bit;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (cam.IsRunning)
            {
                cam.Stop();
            }
        }

        private void btnSavePhoto_Click(object sender, EventArgs e)
        {
            string photoSource = Path.Combine(Application.StartupPath, @"EmployeeImages\" + Globals.cName + ".jpg");


            pictureBox1.Image.Save(photoSource);

            DialogResult dialogResult = MessageBox.Show("Photo Has Been Saved!", "Employee Photo Captured", MessageBoxButtons.OK);
            if (dialogResult == DialogResult.OK)
            {
                this.Close();
                cam.Stop();
            }
        } 
    }
}
