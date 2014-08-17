using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZCommon;
using DMS;
using System.IO;

namespace DMS.View
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
            cobType.Items.Add(cConfig. strNewType);

            for (int row = 0; row < cAccess.DtTable.Rows.Count; row++)
            {
                if (strID == cAccess.DtTable.Rows[row]["ID"].ToString())
                {
                    txtTitle.Text = cAccess.DtTable.Rows[row]["DocTitle"].ToString();
                    txtreleasetime.Text = cAccess.DtTable.Rows[row]["ReleaseDate"].ToString();
                    txtunit.Text = cAccess.DtTable.Rows[row]["Provider"].ToString();
                    labcollecttime.Text = cAccess.DtTable.Rows[row]["AddTime"].ToString();
                    cobType.Text = cAccess.DtTable.Rows[row]["DocType"].ToString();
                    libsource.Text = cAccess.DtTable.Rows[row]["Source"].ToString();
                    txtnote.Text = cAccess.DtTable.Rows[row]["Notes"].ToString();
                    liblocalpath.Text = cAccess.DtTable.Rows[row]["LocalPath"].ToString();
                    break;
                }
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要修改“" + txtTitle.Text + "”的属性?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                try
                {
                    string OldPath;
                    for (int row = 0; row < cAccess.DtTable.Rows.Count; row++)
                    {
                        if (strID == cAccess.DtTable.Rows[row]["ID"].ToString())
                        {
                            OldPath = cAccess.DtTable.Rows[row]["LocalPath"].ToString();
                            cAccess.ChangePermissions(txtTitle.Text, txtreleasetime.Text, cobType.Text, txtunit.Text, txtnote.Text, row);
                            File.Move(OldPath, cAccess.DtTable.Rows[row]["LocalPath"].ToString());//移动相应的word文档到所需类型的目录
                            string b = cAccess.DtTable.Rows[row]["LocalPath"].ToString();

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
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
