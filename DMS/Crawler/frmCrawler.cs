using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using DMS;
using System.Drawing;

namespace Crawler
{
    public partial class frmCrawler : Form
    {
        public frmCrawler()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 目录页
        /// </summary>
        const string strParentURL = "http://oa.gdmc.edu.cn:8083/ggxx_new/list_bm.jsp?notemplate=&classcode=704&boardid=704&pageno=";
        const string strType = "办公网";
        /// <summary>
        /// 声明2个变量，存放总页码和当前页码
        /// </summary>
        int pagesAll = 1, pageNow = 1;

        //List<int> li = new List<int>();
        int[] li = { 20, 450, 150, 100 };
        string[] ls = { "", "通知", "时间", "发布单位" };

        /// <summary>
        /// cMatch为要匹配的字符串，sPattern为要去掉的字符串
        /// </summary>
        string sMatch = "pageno=\\d*", sPattern = "pageno=";

        private void getPage()
        {
            try
            {
                pageNow = Convert.ToInt32(txtPageNow.Text = DMS.cRegex.getString(txtURL.Text, sMatch, sPattern));
            }
            catch
            {
                pageNow = 1;
            }
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            list();
        }
        private void list()
        {
            try
            {
                txtPageNow.Text = pageNow.ToString();
                txtURL.Text = Regex.Replace(txtURL.Text, sMatch, sPattern + pageNow, RegexOptions.IgnoreCase);

                cCrawler.getInformation(txtURL.Text);
                pagesAll = Convert.ToInt32(labPageAll.Text = cCrawler.pages.ToString());
                listDoc.Items.Clear();
                for (int i = 0; i < cCrawler.lcl.Count; i++)
                {
                    int j = 0;
                    if (j < cCrawler.lcl[i].listInfo.Count)
                    {

                        ListViewItem lvi = new ListViewItem();
                        lvi = listDoc.Items.Add(cCrawler.lcl[i].ID.ToString());
                        for (; j < cCrawler.lcl[i].listInfo.Count; )
                        {
                            lvi.SubItems.Add(cCrawler.lcl[i].listInfo[j++]);
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            listDoc.Columns.Clear();
            for (int i = 0; i < ls.Length; i++)
            {
                listDoc.Columns.Add(ls[i], li[i]);
            }
            btnUpdate_Click(sender, e);
            tsslStatus.Text = "";
        }

        private void btnPageDown_Click(object sender, EventArgs e)
        {
            getPage();
            if (pageNow++ >= pagesAll)
            {
                MessageBox.Show("已经到末页");
                return;
            }
            list();

        }
        private void btnPageUp_Click(object sender, EventArgs e)
        {
            getPage();
            if (pageNow-- == 1)
            {
                MessageBox.Show("已经到首页");
                return;
            }
            list();
        }



        private void txtPageNow_Leave(object sender, EventArgs e)
        {
            try
            {
                pageNow = Convert.ToInt32(txtPageNow.Text);
                if (pageNow < 1 || pageNow > pagesAll)
                {
                    MessageBox.Show("输入的页码超出范围！");
                    return;
                }
                else
                {

                    list();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void txtPageNow_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                try
                {//执行“跳转”
                    pageNow = Convert.ToInt32(txtPageNow.Text);
                    if (pageNow < 1 || pageNow > pagesAll)
                    {
                        MessageBox.Show("输入的页码超出范围！");
                        return;
                    }
                    else
                    {
                        list();
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            if (e.KeyChar != '\b')//这是允许输入退格键
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字
                {
                    e.Handled = true;
                }
            }
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            if (listDoc.Items.Count != listDoc.CheckedItems.Count)
            {
                foreach (ListViewItem tempItem in listDoc.Items)//循环遍历listView控件中的每一项
                {
                    tempItem.Checked = true;
                }
            }
            else
            {
                foreach (ListViewItem tempItem in listDoc.Items)//循环遍历listView控件中的每一项
                {
                    tempItem.Checked = false;
                }
            }
        }

        private void btnContrary_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem tempItem in listDoc.Items)//循环遍历listView控件中的每一项
            {
                if (tempItem.Checked == true)//如果当前项处于选中状态
                    tempItem.Checked = false;
                else
                    tempItem.Checked = true;
            }
        }



        private void makeWord_Click(object sender, EventArgs e)
        {

            if (listDoc.CheckedItems.Count > 0)
            {
                this.UseWaitCursor = true;
                List<cWord> lw = new List<cWord>();
                for (int i = 0; i < listDoc.CheckedItems.Count; i++)
                {
                    for (int j = 0; j < cCrawler.lcl.Count; j++)
                    {
                        if (listDoc.CheckedItems[i].SubItems[0].Text == cCrawler.lcl[j].ID.ToString())
                        {
                            lw.Add(new cWord(cCrawler.lcl[j].listInfo[0], cCrawler.lcl[j].URL, strType, cCrawler.lcl[j].listInfo[1], cCrawler.lcl[j].listInfo[2], "批量添加的公文"));
                            break;
                        }
                    }
                }
                //执行下载操作
                cMakeWord mw = new cMakeWord(lw);
                Thread th = new Thread(new ThreadStart(mw.makeWord));
                th.Start();
                this.UseWaitCursor = false;
                tsslStatus.Text = "命令已执行！";
            }
            else { tsslStatus.Text = "请选择公文！"; }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMax_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
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

        ToolTip tt = new ToolTip();
        private void txtURL_Enter(object sender, EventArgs e)
        {

            tt.SetToolTip(this.txtURL, "办公网公文下载器，暂时只支持对“http://oa.gdmc.edu.cn:8083/ggxx_new/”网站公文的下载，如果你有其他需求，请联系我们！");
        }

        private void listDoc_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.X <= 16) return;
            Point curPos = this.listDoc.PointToClient(Control.MousePosition);
            ListViewItem lvwItem = this.listDoc.GetItemAt(curPos.X, curPos.Y);

            if (lvwItem != null)
            {
                if (lvwItem.Checked)
                    lvwItem.Checked = false;
                else
                    lvwItem.Checked = true;
            }
        }


    }
}
