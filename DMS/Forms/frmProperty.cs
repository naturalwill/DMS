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


        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void liblocalpath_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(this.liblocalpath.Text);
        }

        private void libsource_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(this.libsource.Text);
        }

     
    }
}
