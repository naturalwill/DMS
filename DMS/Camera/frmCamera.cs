using System;
using System.Windows.Forms;
using System.IO;
using DMS;
using System.Drawing.Imaging;
using System.Collections.Generic;


namespace DMS.Camera
{
    public partial class frmCamera : Form
    {
        #region
        public static WebCamera camera;
        public static DeviceCapabilityInfo _DeviceCapabilityInfo;
        public static DeviceInfo _DeviceInfo;
        string photopath;
        public static string ScanDocPath = cConfig.strWorkPath + "\\" + cConfig.strScanType;
        //string ftpsource;
        #endregion


        public static List<DeviceInfo> ls1;
        public frmCamera()
        {
            InitializeComponent();
            camera = new WebCamera();
            ls1 = new List<DeviceInfo>();
            foreach (DeviceInfo info in camera.GetCameras())
            {
                ls1.Add(info);
            }

            camera.NewFrameEvent += new NewFrameEventHandler(camera_NewFrameEvent);
            Control.CheckForIllegalCrossThreadCalls = false;
        }


        private void frmCamera_Load(object sender, EventArgs e)
        {
            while (cConfig.CameraIndex < 0 || cConfig.resolutionIndex < 0)
            {
                if (frmSetting.isClose)
                { break; }
                frmSetting fs = new frmSetting();
                fs.ShowDialog();

            }

            if (frmSetting.isClose)
            { this.Close(); return; }

            ls2.Clear();
            _DeviceCapabilityInfo = null;
            _DeviceInfo = ls1[cConfig.CameraIndex];
            foreach (DeviceCapabilityInfo info in camera.GetDeviceCapability(_DeviceInfo))
            {
                ls2.Add(info);
            }

            _DeviceCapabilityInfo = ls2[cConfig.resolutionIndex];

            if (_DeviceInfo != null && _DeviceCapabilityInfo != null)
            {
                if (camera.StartVideo(_DeviceInfo, _DeviceCapabilityInfo))
                {
                    btnphotograph.Enabled = true;
                }
            }
            toolStripStatusLabel1.Text = "工作中......";
            pictureBox2.Visible = false;
        }

        ////__________________________________________________拖动窗体——————————————————————————————————————————
        private const int WM_NCHITTEST = 0x84;
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    if ((int)m.Result == HTCLIENT)
                        m.Result = (IntPtr)HTCAPTION;
                    return;
            }
            base.WndProc(ref m);
        }
        ////__________________________________________________________拖动窗体__________________________________________________________________________


        void camera_NewFrameEvent(object sender, EventArgs e)
        {
            pictureBox1.Image = camera.NewFrame;
        }

        public static List<DeviceCapabilityInfo> ls2 = new List<DeviceCapabilityInfo>();


        //private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    comboBox2.Items.Clear();
        //    _DeviceCapabilityInfo = null;
        //    _DeviceInfo = (DeviceInfo)comboBox1.SelectedItem;
        //    foreach (DeviceCapabilityInfo info in camera.GetDeviceCapability(_DeviceInfo))
        //    {
        //        comboBox2.Items.Add(info);
        //    }
        //}

        //private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    _DeviceCapabilityInfo = (DeviceCapabilityInfo)comboBox2.SelectedItem;
        //}

        //private void btnreunion_Click(object sender, EventArgs e)
        //{
        //    if (_DeviceInfo != null && _DeviceCapabilityInfo != null)
        //    {
        //        if (camera.StartVideo(_DeviceInfo, _DeviceCapabilityInfo))
        //        {
        //            btnphotograph.Enabled = true;
        //        }
        //    }
        //}



        public static bool shouldBeSave = false;
        public static string name, note;
        private void btnphotograph_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = camera.NewFrame;
            pictureBox2.Visible = true;
            frmSave fs = new frmSave();
            fs.ShowDialog();
            if (shouldBeSave)
            {

                if (!Directory.Exists(ScanDocPath)) Directory.CreateDirectory(ScanDocPath);
                pictureBox2.Image.Save(ScanDocPath + "\\" + name + ".jpg", ImageFormat.Jpeg);
                photopath = ScanDocPath + "\\" + name + ".jpg";
                cAccess.add(name, "", photopath, cConfig.strScanType, DateTime.Now.ToString(), Environment.UserName, note);
                frmMain.fm.flash();
                toolStripStatusLabel1.Text = "照片已储存";
                shouldBeSave = false;
            }
            pictureBox2.Image = null;
            pictureBox2.Visible = false;

        }


        private void frmCamera_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (pictureBox2.Image != null && toolStripStatusLabel1.Text != "照片已储存")
            {
                if (MessageBox.Show("照片未保存，确定要退出吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    this.Dispose();
                }
                else
                    e.Cancel = true;
            }
        }





        private void button1_Click(object sender, EventArgs e)
        {
            frmSetting fs = new frmSetting();
            fs.ShowDialog();
        }

        private void btnMax_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Camera_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (camera.DeviceExist)
            {
                if (camera.CloseVideo())
                    btnphotograph.Enabled = false;
            }
            if (camera.DeviceExist)
                camera.CloseVideo();
            this.Dispose();
        }

    }


}
