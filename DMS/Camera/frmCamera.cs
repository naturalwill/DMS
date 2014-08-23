using System;
using System.Windows.Forms;
using System.IO;
using DMS;
using System.Drawing.Imaging;


namespace Camera
{
    public partial class frmCamera : Form
    {
        #region
        WebCamera camera;
        DeviceCapabilityInfo _DeviceCapabilityInfo;
        DeviceInfo _DeviceInfo;
        int inta;
        string photopath;
        string CameraPath = cConfig.strWorkPath + "\\" + cConfig.strScanType;
        //string ftpsource;
        #endregion
        public frmCamera()
        {
            InitializeComponent();
            camera = new WebCamera();
            foreach (DeviceInfo info in camera.GetCameras())
            {
                comboBox1.Items.Add(info);
            }
            camera.NewFrameEvent += new NewFrameEventHandler(camera_NewFrameEvent);
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        void camera_NewFrameEvent(object sender, EventArgs e)
        {
            pictureBox1.Image = camera.NewFrame;
        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            _DeviceCapabilityInfo = null;
            _DeviceInfo = (DeviceInfo)comboBox1.SelectedItem;
            foreach (DeviceCapabilityInfo info in camera.GetDeviceCapability(_DeviceInfo))
            {
                comboBox2.Items.Add(info);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            _DeviceCapabilityInfo = (DeviceCapabilityInfo)comboBox2.SelectedItem;
        }

        private void btnreunion_Click(object sender, EventArgs e)
        {
            if (_DeviceInfo != null && _DeviceCapabilityInfo != null)
            {
                if (camera.StartVideo(_DeviceInfo, _DeviceCapabilityInfo))
                {
                    btnphotograph.Enabled = true;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (camera.DeviceExist)
            {
                if (camera.CloseVideo())
                    btnphotograph.Enabled = false;
            }
        }

        private void btnphotograph_Click(object sender, EventArgs e)
        {
            if (inta == 0)
            {
                pictureBox2.Image = camera.NewFrame;
                pictureBox2.Visible = true;
                btnphotograph.Text = "重拍";
                inta = 1;
            }
            else if (inta == 1)
            {
                pictureBox2.Image = null;
                btnphotograph.Text = "拍照";
                pictureBox2.Visible = false;
                inta = 0;
            }
        }

        private void Camera_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (camera.DeviceExist)
                camera.CloseVideo();
            this.Dispose();
        }

        private void frmCamera_Load(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
            inta = 0;
        }
        ////使用两个进程，进程一是本地缓存，进程二是储存在ftp服务器上。
        //bool singal = false;
        //void thead_1()
        //{
        //    /*储存到本地磁盘。*/
        //    Directory.CreateDirectory(CameraPath);
        //    if (Directory.Exists(CameraPath))
        //    {
        //        if (MessageBox.Show("确定要储存照片吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
        //        {
        //            pictureBox1.Image.Save(CameraPath + "\\" + txtTitle.Text + ".jpg", ImageFormat.Jpeg);
        //            photopath = CameraPath + "\\" + txtTitle.Text + ".jpg";
        //        }
        //    }
        //    else Directory.CreateDirectory(CameraPath);
        //    singal = true;
        //}
        //void thead_2()
        //{
        //    //备份到ftp服务器
        //    while (singal)
        //    {
        //        if (cConfig.FTP_IP != "")
        //        {
        //            FTPHelper FTP = new FTPHelper(cConfig.FTP_IP, "", cConfig.FTP_user, cConfig.FTP_password);
        //            FTP.MakeDir(cConfig.strWorkFolder);
        //            FTPHelper FTP1 = new FTPHelper(cConfig.FTP_IP, cConfig.strWorkFolder+"/", cConfig.FTP_user, cConfig.FTP_password);
        //            FTP1.MakeDir(cConfig.strScanType);
        //            FTP1.Upload(photopath);
        //            ftpsource = FTPHelper.ftpsavePath;
        //            break;
        //        }
        //        else
        //        {
        //            //MessageBox.Show("请输入ftp服务器ip地址!", "提示", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
        //            break;
        //        }
        //    }
        //}
        private void btnsave_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("确定要储存照片吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                if (!Directory.Exists(CameraPath)) Directory.CreateDirectory(CameraPath);
                pictureBox2.Image.Save(CameraPath + "\\" + txtTitle.Text + ".jpg", ImageFormat.Jpeg);
                photopath = CameraPath + "\\" + txtTitle.Text + ".jpg";
                cAccess.add(txtTitle.Text, "", photopath, cConfig.strScanType, "", Environment.UserName, txtnote.Text);
                cConfig.working = false;
                cConfig.needFlash = true;
                this.Close();
            }

        }

    }


}
