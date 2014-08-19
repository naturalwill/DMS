using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using ZCommon;

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
                if (txtURL.Text.IndexOf('/') > 0)
                {//网址
                    List<cWord> lw = new List<cWord>();
                    lw.Add(new cWord(txtTitle.Text, txtURL.Text, comboBoxDocType.Text, txtDate.Text, txtProvider.Text, txtRemindMessage.Text));
                    cMakeWord mw = new cMakeWord(lw);
                    Thread th = new Thread(new System.Threading.ThreadStart(mw.makeWord));
                    th.Start();
                }
                else if (txtURL.Text.IndexOf('\\') >= 0)
                {//本地文件
                    string HouZui = txtURL.Text.Substring(txtURL.Text.LastIndexOf('.'));

                    string pFilePath;
                    if (comboBoxDocType.Text == "")
                        comboBoxDocType.Text = cConfig.strNoType;
                    pFilePath = cConfig.strWorkPath + "\\" + comboBoxDocType.Text;

                    if (!(Directory.Exists(pFilePath)))
                        Directory.CreateDirectory(pFilePath);

                    pFilePath += "\\" + txtTitle.Text + HouZui;

                    if (File.Exists(pFilePath))
                    {
                        MessageBox.Show("公文库中已有同名公文，请修改公文标题或类型！");
                        return;
                    }
                    File.Copy(txtURL.Text, pFilePath);
                    cAccess.add(txtTitle.Text, txtURL.Text, pFilePath, comboBoxDocType.Text, txtDate.Text, txtProvider.Text, txtRemindMessage.Text);
                    cConfig.working = false;
                    cConfig.needFlash = true;
                }
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
