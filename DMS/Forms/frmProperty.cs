using System;
using System.IO;
using System.Windows.Forms;
using DMS;

namespace DMS.Forms
{
    public partial class frmProperty : Form
    {
        public frmProperty(string ID)
        {
            InitializeComponent();
            strID = ID;
        }
        string strID;
        //加载窗体
        private void frmProperty_Load(object sender, EventArgs e)
        {
            foreach (string str in frmMain.TypeList)
            {
                cobType.Items.Add(str);
            }
            cobType.Items.Add(cConfig.strNewType);

            for (int row = 0; row < cAccess.basicDt.Rows.Count; row++)
            {
                if (strID == cAccess.basicDt.Rows[row]["ID"].ToString())
                {
                    txtTitle.Text = cAccess.basicDt.Rows[row]["DocTitle"].ToString();
                    txtreleasetime.Text = cAccess.basicDt.Rows[row]["ReleaseDate"].ToString();
                    txtunit.Text = cAccess.basicDt.Rows[row]["Provider"].ToString();
                    labcollecttime.Text = cAccess.basicDt.Rows[row]["AddTime"].ToString();
                    cobType.Text = cAccess.basicDt.Rows[row]["DocType"].ToString();
                    libsource.Text = cAccess.basicDt.Rows[row]["Source"].ToString();
                    txtnote.Text = cAccess.basicDt.Rows[row]["Notes"].ToString();
                    liblocalpath.Text = cAccess.basicDt.Rows[row]["LocalPath"].ToString();
                    break;
                }
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("确定要修改“" + txtTitle.Text + "”的属性?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {

                    string OldPath;
                    for (int row = 0; row < cAccess.basicDt.Rows.Count; row++)
                    {
                        if (strID == cAccess.basicDt.Rows[row]["ID"].ToString())
                        {
                            OldPath = cAccess.basicDt.Rows[row]["LocalPath"].ToString();
                            cAccess.ChangePermissions(txtTitle.Text, txtreleasetime.Text, cobType.Text, txtunit.Text, txtnote.Text, row);
                            File.Move(OldPath, cAccess.basicDt.Rows[row]["LocalPath"].ToString());//移动相应的word文档到所需类型的目录

                        }
                    }
                }
                frmMain.fm.flashTypeList();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cobType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cobType.Text == cConfig.strNewType || cobType.Text == cConfig.strNoType)
                cobType.Text = "";
        }

    }
}
