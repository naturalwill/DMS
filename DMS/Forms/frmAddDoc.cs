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
                if (txtDate.Text != "")
                {
                    DateTime data = Convert.ToDateTime(txtDate.Text);
                }
                if (cSync.GetDoc(txtTitle.Text, txtURL.Text, comboBoxDocType.Text, txtDate.Text, txtProvider.Text, txtRemindMessage.Text))
                {
                    frmMain.fm.initialize();
                    this.Close();
                }
                else { MessageBox.Show("添加失败！"); }
            }
            catch
            {
                MessageBox.Show("发布时间输入错误！可能是日期格式错误，日期格式为：yyyy-mm-dd hh:nn:ss或yyyy/mm/dd hh:nn:ss(PS:可以不输入时间)", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtDate.Focus();
            }
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

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

      

    }
}
