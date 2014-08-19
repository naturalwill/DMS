﻿using System;
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
                frmMain.fm.AddNewType(txtNewType.Text);
            }
            this.Close();
        }

        private void frmNewType_Load(object sender, EventArgs e)
        {

        }

       
    }
}
