using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DMS.Store
{
    public partial class frmAddDoc : Form
    {
        public frmAddDoc()
        {
            InitializeComponent();
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtURL.Text.IndexOf('/') > 0)
            {//网址
                
            }
            else
            {//本地文件
            }
            this.Close();
        }

        private void frmAddDoc_Load(object sender, EventArgs e)
        {

        }

        private void btnLocal_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtURL.Text = openFileDialog1.FileName;
                txtTitle.Text = openFileDialog1.FileName.Substring(openFileDialog1.FileName.LastIndexOf("\\") + 1);
                if (txtDate.Text != null)
                {
                    string DateOfTime = txtDate.Text; 
                }
                if (comboBoxDocType.SelectedIndex >= 0)
                {
 
                }
                if (txtRemindMessage.Text != null)
                {
                    string RemindMessage = txtRemindMessage.Text;
                }
            }
        }

        private void textShowAll_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }


    }
}
