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
