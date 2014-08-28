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
            {if (!string.IsNullOrWhiteSpace(txtreleasetime.Text))
                        DateTime.Parse(txtreleasetime.Text);
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
                frmMain.fm.initialize();
                this.Close();
            }
            catch //(Exception )
            {
                MessageBox.Show("发布时间输入错误！可能是日期格式错误，日期格式为：yyyy-mm-dd hh:nn:ss或yyyy/mm/dd hh:nn:ss(PS:可以不输入时间)","提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                this.txtreleasetime.Focus();
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

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
