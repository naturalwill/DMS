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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
