using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DMS.Camera
{
    public partial class frmSave : Form
    {
        public frmSave()
        {
            InitializeComponent();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (File.Exists(frmCamera.ScanDocPath + "\\" + txtTitle.Text + ".jpg"))
            {
                MessageBox.Show("已存在同名公文，请更改标题");
                return;
            }
            if (MessageBox.Show("确定要储存照片吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                frmCamera.shouldBeSave = true;
                frmCamera.name = txtTitle.Text;
                frmCamera.note = txtnote.Text;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        ////__________________________________________________拖动窗体——————————————————————————————————————————
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
        ////__________________________________________________________拖动窗体__________________________________________________________________________

    }
}
