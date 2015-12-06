using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using DMS;
using System.Drawing;
using System.Collections;
using Newtonsoft.Json;

namespace Crawler
{
    public partial class frmCrawlerNew : Form
    {
        public frmCrawlerNew()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 目录页
        /// </summary>
        const string strParentURL = "http://oanews.gdmc.edu.cn/oa/infoDisplayAction.do";
        const string strType = "新办公网";
        const int interval = 15;
        string getUrl(string colId = "5e90e1d53bd0b3b0013bd0cb646b0006", string start = "0")
        {
            IDictionary<string, string> idc = new Dictionary<string, string>();
            idc.Add("method", "getInformationOfColumn");
            idc.Add("colId", colId);
            idc.Add("start", start);
            idc.Add("interval", interval.ToString());
            idc.Add("title", "");
            idc.Add("departments", "");
            idc.Add("htmlContent", "");
            idc.Add("after", "");
            idc.Add("before", "");
            idc.Add("pageURL", @"/application/service/col_detail.jsp");

            string url = strParentURL + "?";
            string s = "";
            foreach (var kvp in idc)
            {
                url += s + kvp.Key + "=" + kvp.Value;
                s = "&";
            }
            return url;
        }
        IDictionary<string, string> colinfo = new Dictionary<string, string>{
                { "学校通知", "5e90e1d53bd0b3b0013bd0cb646b0006" },
                { "部门通知", "ff8080813bcc27dc013bd06bfa560030" }
            };

        string curcol = "5e90e1d53bd0b3b0013bd0cb646b0006";

        /// <summary>
        /// 声明2个变量，存放总页码和当前页码
        /// </summary>
        int pagesAll = 1, pageNow = 1;

        //List<int> li = new List<int>();
        int[] li = { 20, 450, 150, 100 };
        string[] ls = { "", "通知", "时间", "发布单位" };
        oainfo m;
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            list();
        }
        private void list()
        {
            try
            {
                txtPageNow.Text = pageNow.ToString();

                string start = pageNow > 1 ? ((pageNow - 1) * interval).ToString() : "0";
                string url = getUrl(curcol, start);

                string s;
                using (System.Net.WebClient wc = new System.Net.WebClient())
                {
                    Byte[] pageData = wc.DownloadData(url);

                    s = System.Text.Encoding.GetEncoding("GBK").GetString(pageData);
                    //Stream stream = new System.IO.MemoryStream(Encoding.Convert(Encoding.GetEncoding("GBK"), Encoding.UTF8, pageData));
                    //s = System.Text.Encoding.UTF8.GetString(pageData);去除中文乱码

                    s += @"
    function getstring(){
        var s=serv_loadColumnNews();
        return  JSON.stringify(s);
    }
";
                    var eng = new Jurassic.ScriptEngine();
                    eng.Evaluate(s);
                    var b = eng.CallGlobalFunction<string>(@"getstring");

                    m = JsonConvert.DeserializeObject<oainfo>(b);
                }
                pagesAll = m.total / interval + (m.total % interval == 0 ? 0 : 1);
                labPageAll.Text = pagesAll.ToString();

                listDoc.Items.Clear();
                foreach (var v in m.informations)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi = listDoc.Items.Add(v.id);
                    lvi.SubItems.Add(v.bt);
                    lvi.SubItems.Add(v.time);
                    lvi.SubItems.Add(v.mc);
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
            cmbCol.Items.Clear();
            foreach (var item in colinfo)
            {
                cmbCol.Items.Add(item.Key);
            }
            cmbCol.SelectedIndex = cmbCol.Items.Count > 0 ? 0 : -1;
           
            tsslStatus.Text = "";
        }

        private void btnPageDown_Click(object sender, EventArgs e)
        {
            if (pageNow >= pagesAll)
            {
                MessageBox.Show("已经到末页");
                return;
            }
            ++pageNow;
            list();

        }
        private void btnPageUp_Click(object sender, EventArgs e)
        {
            if (pageNow <= 1)
            {
                MessageBox.Show("已经到首页");
                return;
            }
            --pageNow;
            list();
        }



        private void txtPageNow_Leave(object sender, EventArgs e)
        {
            try
            {
                int tmp = Convert.ToInt32(txtPageNow.Text);
                if (tmp < 1 || tmp > pagesAll)
                {
                    txtPageNow.Text = pageNow.ToString();
                    MessageBox.Show("输入的页码超出范围！");
                    return;
                }
                else
                {
                    pageNow = tmp;
                    list();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void txtPageNow_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')//执行“跳转”
            {
                listDoc.Focus();
            }
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
                List<cWord2> lw = new List<cWord2>();
                for (int i = 0; i < listDoc.CheckedItems.Count; i++)
                {
                    foreach (var v in m.informations)
                    {
                        if (listDoc.CheckedItems[i].SubItems[0].Text == v.id)
                        {
                            cWord2 cw = new cWord2(v.bt, v.link, m.name, v.time, v.mc, "来自办公网的公文，公文id为: " + v.id);
                            lw.Add(cw);
                        }
                    }
                }


                //执行下载操作
                cMakeWord2 mw = new cMakeWord2(lw);
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



        private void cmbCol_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCol.SelectedIndex >= 0)
            {
                curcol = colinfo[cmbCol.SelectedItem.ToString()];
                pagesAll = pageNow = 1;
                list();
            }
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
    /// <summary>
    /// 新办公网公文信息列表
    /// </summary>
    class oainfo
    {
        public string id;
        public string name;
        public int total;
        public int start;
        public int interval;
        public newinfo[] informations;
        public class newinfo
        {
            public string id;
            public string bt;
            public string time;
            public string fbsj;
            public string link;
            public string mc;
            public string cjsj;

        }
    }
}
