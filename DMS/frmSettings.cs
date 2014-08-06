using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DMS
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = fbd.SelectedPath;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!(cConfig.defaultPath))
                cConfig.strWorkPath = txtPath.Text;
            cConfig.FTP_IP = txtIP.Text;
            cConfig.FTP_user = txtUser.Text;
            cConfig.FTP_password = txtPassword.Text;
            cConfig.SaveConfig();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            
            if (cConfig.defaultPath)
            {
                radioButton1.Checked = true;
            }
            else
            {
                radioButton2.Checked = true;
              txtPath.Text  = cConfig.strWorkPath ;
            }
            txtIP.Text =cConfig.FTP_IP; 
            txtUser.Text =cConfig.FTP_user; 
            txtPassword.Text =cConfig.FTP_password;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                cConfig.defaultPath = true;
                txtPath.Enabled = false;
                btnBrowse.Enabled = false;
            }
            else
            {
                cConfig.defaultPath = false;
                txtPath.Enabled = true;
                btnBrowse.Enabled = true;
            }
        }



    }
}
