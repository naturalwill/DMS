using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Threading;
using ZCommon;

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
                pageNow = Convert.ToInt32(txtPageNow.Text = ZCommon.cRegex.getString(txtURL.Text, sMatch, sPattern));
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
                List<cWord> lw=new List<cWord>();
                for (int i = 0; i < listDoc.CheckedItems.Count; i++)
                {
                    //if (listDoc.CheckedItems[i].Checked == true)
                    for (int j = 0; j < cCrawler.lcl.Count; j++)
                    {
                        if (listDoc.CheckedItems[i].SubItems[0].Text == cCrawler.lcl[j].ID.ToString())
                        {
                            lw.Add(new cWord(cCrawler.lcl[j].listInfo[0], cCrawler.lcl[j].URL, strType, cCrawler.lcl[j].listInfo[1], cCrawler.lcl[j].listInfo[2],"批量添加的公文"));
                            break;
                        }
                    }
                }
                //执行下载操作
                cMakeWord mw = new cMakeWord(lw);
                Thread th = new Thread(new ThreadStart(mw.makeWord));
                th.Start();
            }
        }
    }
}
