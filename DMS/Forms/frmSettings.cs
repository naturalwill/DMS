using System;
using System.Windows.Forms;
using DMS;

namespace DMS.Forms
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {

            if (cConfig.isDefaultPath )
            {
                radioButton1.Checked = true;
            }
            else
            {
                radioButton2.Checked = true;
                txtPath.Text = cConfig.strWorkPath;
            }
            txtIP.Text = cConfig.FTP_IP;
            txtUser.Text = cConfig.FTP_user;
            txtPassword.Text = cConfig.FTP_password;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtPath.Text = fbd.SelectedPath;
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (cConfig.isDefaultPath)
                {
                    cConfig.strWorkPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + cConfig.strWorkFolder;
                }
                else
                    cConfig.strWorkPath = txtPath.Text;
                cConfig.FTP_IP = txtIP.Text;
                cConfig.FTP_user = txtUser.Text;
                cConfig.FTP_password = txtPassword.Text;
                cConfig.SaveConfig();
                this.Close();
            }
            catch
            {
                MessageBox.Show("自定义路径不能为空!", "提示");
                this.txtPath.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                cConfig.isDefaultPath = true;
                txtPath.Enabled = false;
                btnBrowse.Enabled = false;
            }
            else
            {
                cConfig.isDefaultPath = false;
                txtPath.Enabled = true;
                btnBrowse.Enabled = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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
