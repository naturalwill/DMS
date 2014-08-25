using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DMS.Camera
{
    public partial class frmSetting : Form
    {
        public static bool isClose = false;
        public frmSetting()
        {
            InitializeComponent();
            foreach (DeviceInfo info in frmCamera.ls1)
            {
                comboBox1.Items.Add(info);
            }
            if (cConfig.CameraIndex >= 0)
                comboBox1.SelectedIndex = cConfig.CameraIndex;
            if (cConfig.resolutionIndex >= 0)
                comboBox2.SelectedIndex = cConfig.resolutionIndex;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            cConfig.SaveConfig();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            isClose = true;
            this.Close();
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cConfig.CameraIndex = comboBox1.SelectedIndex;
            comboBox2.Items.Clear();
            frmCamera._DeviceCapabilityInfo = null;
            frmCamera._DeviceInfo = (DeviceInfo)comboBox1.SelectedItem;
            foreach (DeviceCapabilityInfo info in frmCamera.camera.GetDeviceCapability(frmCamera._DeviceInfo))
            {
                comboBox2.Items.Add(info);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cConfig.resolutionIndex = comboBox2.SelectedIndex;
            frmCamera._DeviceCapabilityInfo = (DeviceCapabilityInfo)comboBox2.SelectedItem;
            btnReunion.Enabled = true;
        }


        #region 移动窗体

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
        #endregion
    }
}
