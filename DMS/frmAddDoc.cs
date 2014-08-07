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
    public partial class frmAddDoc : Form
    {
        public frmAddDoc()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtURL.Text = ofd.FileName;
                int start = txtURL.Text.LastIndexOf('\\');
                int end = txtURL.Text.LastIndexOf('.');
                txtTitle.Text = txtURL.Text.Substring(start + 1, end - start - 2);
            }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtURL.Text.IndexOf('/') > 0)
            {//网址
                cMakeWork mw = new cMakeWork(txtTitle.Text, comboBoxDocType.Text, txtURL.Text);
                System.Threading.Thread th = new System.Threading.Thread(new System.Threading.ThreadStart(mw.makeWord));
                th.Start();
                cAccess.add(txtTitle.Text, txtURL.Text, mw.pPath, comboBoxDocType.Text, txtRTime.Text, "", txtNotes.Text);              
            }
            else
            {//本地文件
            }
            this.Close();
        }

        private void frmAddDoc_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
