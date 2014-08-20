using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using DMS;

namespace DMS.Forms
{
    public partial class frmAddDoc : Form
    {
        public frmAddDoc()
        {
            InitializeComponent();
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                cSync.GetDoc(txtTitle.Text, txtURL.Text, comboBoxDocType.Text, txtDate.Text, txtProvider.Text, txtRemindMessage.Text);
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }



        private void frmAddDoc_Load(object sender, EventArgs e)
        {
            foreach (string str in frmMain.TypeList)
            {
                if (str != cConfig.strNoType)
                    comboBoxDocType.Items.Add(str);
            }
            //comboBoxDocType.Items.Add(cConfig.strNewType);
        }

        private void btnLocal_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtURL.Text = ofd.FileName;
                    int start = txtURL.Text.LastIndexOf('\\');
                    int end = txtURL.Text.LastIndexOf('.');
                    txtTitle.Text = txtURL.Text.Substring(start + 1, end - start - 1);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void comboBoxDocType_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (comboBoxDocType.Text == cConfig.strNewType)
        //        comboBoxDocType.Text = "";
        //}

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            if (txtTitle.Text == "" || txtURL.Text == "")
                btnOK.Enabled = false;
            else btnOK.Enabled = true;
        }

        private void txtURL_TextChanged(object sender, EventArgs e)
        {
            if (txtTitle.Text == "" || txtURL.Text == "")
                btnOK.Enabled = false;
            else btnOK.Enabled = true;
        }

    }
}
