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



        #region 拖动窗体

        /// <summary>
        /// 判断鼠标是否按下
        /// </summary>
        private bool _isDown = false;
        /// <summary>
        /// 原来的鼠标点
        /// </summary>
        private System.Drawing.Point _oldPoint;
        /// <summary>
        /// 原来窗口点
        /// </summary>
        private System.Drawing.Point _oldForm;

        private void _MouseDown(object sender, MouseEventArgs e)
        {
            _isDown = true;
            _oldPoint = new System.Drawing.Point();
            _oldPoint = e.Location;
            _oldForm = this.Location;
        }

        private void _MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDown)
            {
                _oldForm.Offset(e.X - _oldPoint.X, e.Y - _oldPoint.Y);
                this.Location = _oldForm;
            }
        }

        private void _MouseUp(object sender, MouseEventArgs e)
        {
            _isDown = false;
        }

        #endregion

    }
}
