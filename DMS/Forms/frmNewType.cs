using System;
using System.Windows.Forms;

namespace DMS.Forms
{
    public partial class frmNewType : Form
    {
        public frmNewType()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.Text == "新增类型")
            {
                frmMain.fm.addType(txtNewType.Text);
            }
            else if (this.Text == "修改类型")
            {
                frmMain.fm.changeType(txtNewType.Text);
            }
            else if (this.Text == "添加类型")
            {
                frmMain.fm.MoveToNewType(txtNewType.Text);
            }
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
