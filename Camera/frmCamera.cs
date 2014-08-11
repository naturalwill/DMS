using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace Camera
{
    public partial class frmCamera : Form
    {
        WebCamera camera;
        DeviceCapabilityInfo _DeviceCapabilityInfo;
        DeviceInfo _DeviceInfo;
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
            _DeviceInfo=(DeviceInfo)comboBox1.SelectedItem;
            foreach (DeviceCapabilityInfo info in camera.GetDeviceCapability(_DeviceInfo))
            {
                comboBox2.Items.Add(info);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            _DeviceCapabilityInfo = (DeviceCapabilityInfo)comboBox2.SelectedItem;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_DeviceInfo != null && _DeviceCapabilityInfo != null)
            {
                if (camera.StartVideo(_DeviceInfo, _DeviceCapabilityInfo))
                    button2.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (camera.DeviceExist)
            {
                if (camera.CloseVideo())
                    button2.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = camera.NewFrame;
        }

        private void Camera_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (camera.DeviceExist)
                camera.CloseVideo();
            this.Dispose();
        }
       
       
    }

   
}
