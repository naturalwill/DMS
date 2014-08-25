using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using DMS.Forms;
using System.Drawing;

namespace DMS
{
    public partial class frmMain : Form
    {
        /// <summary>
        /// 主窗口，引用方法：
        /// DMS.frmMain.fm
        /// </summary>
        public static frmMain fm;

        public frmMain()
        {
            InitializeComponent();
            fm = this;
            CheckForIllegalCrossThreadCalls = false;
        }

        //-----------------------下有2个函数未做完---------------

        #region 启动时运行

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Load(object sender, EventArgs e)
        {

            try
            {
                listDoc.Columns.Clear();
                string[] listColumnName = { "", "公文标题", "发布时间", "发布单位", "收录时间", "公文类型" };
                int[] listColumnWidth = CalculateWidth(listDoc.Width);

                for (int i = 0; i < listColumnName.Length; i++)
                {
                    listDoc.Columns.Add(listColumnName[i], listColumnWidth[i]);
                }

                if (cAccess.load() == false) MessageBox.Show("加载数据库失败");

                cConfig.ReadConfig();


                string[] pi = { "15", "20", "30", "50", cConfig.strNoLimit };
                foreach (string p in pi)
                {
                    comboBoxpaginal.Items.Add(p);
                }


                cSync.AddRecord();

                if (cConfig.paginalItems == 0)
                    comboBoxpaginal.Text = cConfig.strNoLimit;
                else
                    comboBoxpaginal.Text = cConfig.paginalItems.ToString();
                //this.listDoc.ListViewItemSorter = new ListViewColumnSorter();
                //this.listDoc.ColumnClick += new ColumnClickEventHandler(ListViewHelper.ListView_ColumnClick);
                initialize();

                tsslStatus.Text = "启动完成！欢迎使用公文管理系统~";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private static int[] CalculateWidth(int w)
        {
            int[] listColumnWidth = { 20, 0, 132, 100, 132, 90, 22 };
            foreach (int i in listColumnWidth)
                w -= i;
            listColumnWidth[1] = w;
            return listColumnWidth;
        }
        /// <summary>
        /// 初始化
        /// </summary>
        private void initialize()
        {
            txtSearch.Text = cConfig.strSearchTips;

            tsslSyncStatus.Text = "";
            try
            {
                if (cAccess.newDt.Rows.Count > 0)
                    dateStart.Value = DateTime.Parse(cAccess.newDt.Rows[(cAccess.newDt.Rows.Count - 1)]["AddTime"].ToString()).AddDays(-1);
                dateEnd.Value = DateTime.Now.AddDays(1);
            }
            catch { }
            flashTypeList();

            search();
        }

        #endregion

        #region 定期运行

        //private void timerAutoSync_Tick(object sender, EventArgs e)
        //{
        //    tssbSync_ButtonClick(sender, e);
        //}


        public void flash()
        {
            dateEnd.Value = DateTime.Now.AddDays(1);
            flashTypeList();
            search();
            tsslStatus.Text = "OK!";
        }

        private void isWorking()
        {
            tsslStatus.Text = "正在工作中...";
        }

        #endregion

        //---------------------------上有2个函数没完成----------------------------

        #region 列出公文
        List<string> listID = new List<string>();

        public void getList()
        {
            if (listDocType.Items.Count == 1)
                TypeSelectedIndex = 0;
            else if (TypeSelectedIndex >= listDocType.Items.Count)
                TypeSelectedIndex = listDocType.Items.Count - 1;

            string strSelected = listDocType.Items[TypeSelectedIndex].ToString();
            if (strSelected == cConfig.strAllType)
            {
                listID = cAccess.selectType();
            }
            else
            {
                listID = cAccess.selectType(strSelected);
            }

            if (cConfig.paginalItems > 0)
            {
                pagesAll = listID.Count / cConfig.paginalItems;
                if (listID.Count != pagesAll * cConfig.paginalItems) pagesAll++;
            }
            else
                pagesAll = 1;
            if (pagesAll < 1) pagesAll = 1;
            labPageAll.Text = pagesAll.ToString();
            listDocType.SelectedIndex = TypeSelectedIndex;
            list();
        }

        /// <summary>
        /// 按"listID"列出公文
        /// </summary>
        /// <param name="startIndex"></param>
        void list(int startIndex = 0)
        {
            listDoc.Items.Clear();

            if (cConfig.paginalItems > 0)
                for (int i = 0; i < cConfig.paginalItems; i++)
                {
                    if (startIndex >= listID.Count) break;
                    for (int row = 0; row < cAccess.basicDt.Rows.Count; row++)
                    {
                        if (listID[startIndex] == cAccess.basicDt.Rows[row]["ID"].ToString())
                        {
                            ListViewItem lvitem = new ListViewItem();
                            lvitem = listDoc.Items.Add(cAccess.basicDt.Rows[row]["ID"].ToString());
                            lvitem.SubItems.Add(cAccess.basicDt.Rows[row]["DocTitle"].ToString());
                            lvitem.SubItems.Add(cAccess.basicDt.Rows[row]["ReleaseDate"].ToString());
                            lvitem.SubItems.Add(cAccess.basicDt.Rows[row]["Provider"].ToString());
                            lvitem.SubItems.Add(cAccess.basicDt.Rows[row]["AddTime"].ToString());
                            lvitem.SubItems.Add(cAccess.basicDt.Rows[row]["DocType"].ToString());
                            break;
                            //System.Diagnostics.Debug.WriteLine("vv" + cConfig.paginalItems);
                        }
                    }
                    startIndex++;
                }
            else if (cConfig.paginalItems == 0)
            {
                for (int i = 0; i < listID.Count; i++)
                {
                    for (int row = 0; row < cAccess.basicDt.Rows.Count; row++)
                    {
                        if (listID[i] == cAccess.basicDt.Rows[row]["ID"].ToString())
                        {
                            ListViewItem lvitem = new ListViewItem();
                            lvitem = listDoc.Items.Add(cAccess.basicDt.Rows[row]["ID"].ToString());
                            lvitem.SubItems.Add(cAccess.basicDt.Rows[row]["DocTitle"].ToString());
                            lvitem.SubItems.Add(cAccess.basicDt.Rows[row]["ReleaseDate"].ToString());
                            lvitem.SubItems.Add(cAccess.basicDt.Rows[row]["Provider"].ToString());
                            lvitem.SubItems.Add(cAccess.basicDt.Rows[row]["AddTime"].ToString());
                            lvitem.SubItems.Add(cAccess.basicDt.Rows[row]["DocType"].ToString());
                            break;
                        }
                    }
                }
            }
        }


        #endregion

        string keyword = "";

        private void search()
        {
            string st = txtSearch.Text;
            if (st == cConfig.strSearchTips)
                st = "";
            if (cAccess.isChanged)
            {
                keyword = st + dateStart.Value.ToString() + dateEnd.Value.ToString();
                cAccess.search(st, dateStart.Value.ToString(), dateEnd.Value.ToString(), 0);
                btnClear.Visible = true;
            }
            else
            {
                if (keyword == st + dateStart.Value.ToString() + dateEnd.Value.ToString())
                {
                }
                else
                {
                    keyword = st + dateStart.Value.ToString() + dateEnd.Value.ToString();
                    cAccess.search(st, dateStart.Value.ToString(), dateEnd.Value.ToString(), 0);
                    btnClear.Visible = true;
                }
            }
            getList();
            Page();
        }


        #region 更新类型列表
        public static List<string> TypeList = new List<string>();
        static int TypeSelectedIndex = 0;
        /// <summary>
        /// 刷新类型列表
        /// </summary>
        public void flashTypeList()
        {
            TypeList.Clear();
            if (Directory.Exists(cConfig.strWorkPath))
            {
                searchDirectory(cConfig.strWorkPath);
            }
            else
            {
                Directory.CreateDirectory(cConfig.strWorkPath);
            }
            for (int row = 0; row < cAccess.basicDt.Rows.Count; row++)
            {
                string str = cAccess.basicDt.Rows[row]["DocType"].ToString();
                if (string.IsNullOrEmpty(str)) str = cConfig.strNoType;
                bool different = true;
                for (int i = 0; i < TypeList.Count; i++)
                {
                    if (TypeList[i] == str)
                    {
                        different = false;
                        break;
                    }
                }
                if (different)
                    TypeList.Add(str);
            }

            listDocType.Items.Clear(); tssbMoveType.DropDownItems.Clear();
            listDocType.Items.Add(cConfig.strAllType);
            foreach (string str in TypeList)
            {
                tssbMoveType.DropDownItems.Add(str);
                listDocType.Items.Add(str);
            }
            tssbMoveType.DropDownItems.Add(new ToolStripSeparator());
            tssbMoveType.DropDownItems.Add(cConfig.strNewType);
            if (listDocType.Items.Count <= TypeSelectedIndex)
                listDocType.SelectedIndex = listDocType.Items.Count - 1;
            else
                listDocType.SelectedIndex = TypeSelectedIndex;
        }

        //public void btnMove()
        //{
        //    btnAddType.Top = listDocType.ItemHeight * (listDocType.Items.Count + 1) + listDocType.Top + scBody.Top;
        //    btnAddType.Left = ((listDocType.Width - btnAddType.Width) / 2) + listDocType.Left + scBody.Left;
        //    if (btnAddType.Bottom >= scBody.Bottom) btnAddType.Top = scBody.Bottom + 3;
        //}

        /// <summary>
        /// 遍历文件夹，搜索符合条件的文件
        /// </summary>
        /// <param name="path"></param>
        private void searchDirectory(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            //foreach (FileInfo f in dir.GetFiles("*.sql"))
            //{
            //    //addlist(f.FullName);
            //}
            foreach (DirectoryInfo f in dir.GetDirectories())
            {
                if (f.Name != cConfig.strTemp)
                {
                    TypeList.Add(f.Name);
                    searchDirectory(f.FullName);
                }
            }
        }

        #endregion


        #region 搜索


        private void btnSearch_Click(object sender, EventArgs e)
        {
            search();
        }


        private void dateStart_CloseUp(object sender, EventArgs e)
        {
            search();
        }

        private void dateEnd_CloseUp(object sender, EventArgs e)
        {
            search();
        }



        private void btnClear_Click(object sender, EventArgs e)
        {
            initialize();
            btnClear.Visible = false;
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                if (e.KeyChar == '\r')
                {
                    search();
                }
            }
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == cConfig.strSearchTips) txtSearch.Text = "";

        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (txtSearch.Text == "" || txtSearch.Text == cConfig.strSearchTips)
            {
                txtSearch.Text = cConfig.strSearchTips;
            }
        }



        #endregion

        //-------------------------------------------------------------------------

        #region 读取或储存类型列表（暂不使用）

        //public static List<string> DocTypeList;

        ///// <summary>
        ///// 储存公文类型列表
        ///// </summary>
        //private void saveDocTypeList()
        //{
        //    if (DocTypeList == null) return;
        //    XElement xe = new XElement("DocTypeList");
        //    for (int i = 0; i < DocTypeList.Count; i++)
        //    {
        //        XElement NoteList = new XElement("DocType", DocTypeList[i]);
        //        xe.Add(NoteList);
        //    }
        //    xe.Save(".\\DocTypeList.xml");
        //    xe.RemoveAll();
        //}

        ///// <summary>
        ///// 读取公文类型列表
        ///// </summary>
        //private void readDocTypeList()
        //{
        //    if (DocTypeList == null)
        //        DocTypeList = new List<string>();

        //    if (File.Exists(".\\DocTypeList.xml"))
        //    {
        //        XElement xe = XElement.Load(".\\DocTypeList.xml");
        //        IEnumerable<XElement> elements = from PInfo in xe.Elements("DocTypeList") select PInfo;
        //        foreach (XElement element in elements)
        //        {
        //            DocTypeList.Add(element.Element("DocType").Value);
        //        }
        //        xe.RemoveAll();
        //    }

        //    for (int row = 0; row < cAccess.basicDt.Rows.Count; row++)
        //    {
        //        string str = cAccess.basicDt.Rows[row]["DocType"].ToString();

        //        //if (DocTypeList.Count == 0)
        //        //{
        //        //    DocTypeList.Add(str);
        //        //    continue;
        //        //}

        //        bool different = true;
        //        for (int i = 0; i < DocTypeList.Count; i++)
        //        {
        //            if (DocTypeList[i] == str)
        //            {
        //                different = false;
        //                break;
        //            }
        //        }
        //        if (different)
        //            DocTypeList.Add(str);
        //    }

        //    listDocType.Items.Add("全部类型");
        //    foreach (string str in DocTypeList)
        //    {
        //        tscbMove.Items.Add(str);
        //        listDocType.Items.Add(str);
        //    }
        //    tscbMove.Items.Add("(新类型)");
        //    listDocType.SelectedIndex = 0;
        //}

        #endregion

        //-------------------------------------------------------------

        #region 工具栏窗体事件

        private void tssbAdd_ButtonClick(object sender, EventArgs e)
        {
            using (frmAddDoc frmAd = new frmAddDoc())
            {
                isWorking();
                frmAd.ShowDialog();
            }
        }

        private void tsmiAdd_Click(object sender, EventArgs e)
        {
            tssbAdd_ButtonClick(sender, e);
        }

        private void tsmiAddMore_Click(object sender, EventArgs e)
        {
            using (Crawler.frmCrawler cr = new Crawler.frmCrawler())
            {
                isWorking();
                cr.ShowDialog();
            }
        }

        private void tsbScan_Click(object sender, EventArgs e)
        {
            using (Camera.frmCamera frmScan = new Camera.frmCamera())
            {
                isWorking();
                frmScan.ShowDialog();
            }
        }

        private void tsbSetting_Click(object sender, EventArgs e)
        {
            using (frmSettings frmS = new frmSettings())
            {
                frmS.ShowDialog();
            }
        }

        private void tsbAbout_Click(object sender, EventArgs e)
        {
            using (frmAboutBox frmAb = new frmAboutBox())
            {
                frmAb.ShowDialog();
            }
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 工具栏其他事件

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            if (listDoc.CheckedItems.Count > 0)
            {
                if (MessageBox.Show("确定要删除 " + listDoc.CheckedItems.Count + " 个文件?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    for (int i = 0; i < listDoc.CheckedItems.Count; i++)
                    {
                        cAccess.delect(listDoc.CheckedItems[i].SubItems[0].Text);
                    }
                    search();
                }
            }
        }

        private void tssbMoveType_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(e.ClickedItem.Text))
                return;
            else if (e.ClickedItem.Text == cConfig.strNewType)
            {
                using (frmNewType frmNewtype = new frmNewType())
                {
                    frmNewtype.groupBoxType.Text = "添加类型";
                    frmNewtype.Text = "添加类型";
                    frmNewtype.ShowDialog();
                }
                return;
            }
            for (int i = 0; i < listDoc.CheckedItems.Count; i++)
            {
                for (int row = 0; row < cAccess.basicDt.Rows.Count; row++)
                {
                    if (listDoc.CheckedItems[i].Text == cAccess.basicDt.Rows[row]["ID"].ToString())
                    {
                        string OldPath = cAccess.basicDt.Rows[row]["LocalPath"].ToString();
                        cAccess.ModifyTheType(listDoc.CheckedItems[i].SubItems[0].Text, e.ClickedItem.Text);
                        string newPath = cAccess.basicDt.Rows[row]["LocalPath"].ToString();
                        //移动相应的word文档到所需类型的目录
                        try
                        {
                            File.Move(OldPath, newPath);
                        }
                        catch
                        {

                        }

                    }
                }
            }
            flashTypeList();
            search();

        }




        /// <summary>
        /// 移动到新类型
        /// </summary>
        /// <param name="strNewType"></param>
        public void MoveToNewType(string strNewType)
        {
            listDocType.Items.Add(strNewType);
            if (!Directory.Exists(cConfig.strWorkPath + "\\" + strNewType))//添加所添加类型的目录
            {
                Directory.CreateDirectory(cConfig.strWorkPath + "\\" + strNewType);
            }

            for (int i = 0; i < listDoc.CheckedItems.Count; i++)
            {
                for (int row = 0; row < cAccess.basicDt.Rows.Count; row++)
                {
                    if (listDoc.CheckedItems[i].Text == cAccess.basicDt.Rows[row]["ID"].ToString())
                    {
                        string OldPath = cAccess.basicDt.Rows[row]["LocalPath"].ToString();
                        cAccess.ModifyTheType(listDoc.CheckedItems[i].SubItems[0].Text, strNewType);
                        string newPath = cAccess.basicDt.Rows[row]["LocalPath"].ToString();
                        //移动相应的word文档到所需类型的目录
                        try
                        {
                            File.Move(OldPath, newPath);
                        }
                        catch
                        {

                        }
                    }
                }
            }
            flashTypeList();
            search();
        }

        private void tsbPrint_Click(object sender, EventArgs e)
        {
            if (listDoc.CheckedItems.Count > 0)
            {
                List<string> ls = new List<string>();
                for (int i = 0; i < listDoc.CheckedItems.Count; i++)
                {
                    //if (listDoc.CheckedItems[i].Checked == true)
                    for (int row = 0; row < cAccess.basicDt.Rows.Count; row++)
                    {
                        if (listDoc.CheckedItems[i].SubItems[0].Text == cAccess.basicDt.Rows[row]["ID"].ToString())
                        {
                            ls.Add(cAccess.basicDt.Rows[row]["LocalPath"].ToString());
                        }
                    }
                }
                cPrintFiles cpf = new cPrintFiles(ls);
                Thread th = new Thread(new ThreadStart(cpf.printFiles));
            }
        }

        #endregion

        //-------------------------------------------------------------

        #region 类型列表事件 listDocType

        private void listDocType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TypeSelectedIndex == listDocType.SelectedIndex) { }
            else if (listDocType.SelectedIndex >= 0)
            {
                TypeSelectedIndex = listDocType.SelectedIndex;
                getList();
                //当所加类型的名称过长时，完全显示其命名
                tipListDocType.SetToolTip(this.listDocType, listDocType.SelectedItem.ToString());
            }


        }

        #endregion

        #region 类型列表右键菜单

        private void tsmiAddType_Click(object sender, EventArgs e)
        {
            using (frmNewType frmNewtype = new frmNewType())
            {
                frmNewtype.groupBoxType.Text = "新增类型";
                frmNewtype.Text = "新增类型";
                frmNewtype.ShowDialog();
            }
        }

        /// <summary>
        /// 新增类型
        /// </summary>
        /// <param name="strNewType"></param>
        public void addType(string strNewType)
        {
            listDocType.Items.Add(strNewType);
            if (!Directory.Exists(cConfig.strWorkPath + "\\" + strNewType))//添加所添加类型的目录
            {
                Directory.CreateDirectory(cConfig.strWorkPath + "\\" + strNewType);
            }
            flashTypeList();
            search();
        }


        private void tsmiChangeType_Click(object sender, EventArgs e)
        {
            if (listDocType.SelectedIndex > 0)
            {
                TypeSelectedIndex = listDocType.SelectedIndex;
                using (frmNewType frmNewtype = new frmNewType())
                {
                    frmNewtype.groupBoxType.Text = "修改类型";
                    frmNewtype.Text = "修改类型";
                    frmNewtype.ShowDialog();
                }
            }
        }

        /// <summary>
        /// 更改类型
        /// </summary>
        /// <param name="strNewType"></param>
        public void changeType(string strNewType)
        {

            cAccess.ModifyType(listDocType.Items[TypeSelectedIndex].ToString(), strNewType);
            flashTypeList();
            search();
        }

        private void tsmiDeleteType_Click(object sender, EventArgs e)
        {
            btnDelType_Click(sender, e);
        }

        #endregion

        //-------------------------------------------------------------

        #region 公文列表事件 listDoc

        private void listDoc_ItemMouseHover(object sender, ListViewItemMouseHoverEventArgs e)
        {
            Point curPos = this.listDoc.PointToClient(Control.MousePosition);
            ListViewItem lvwItem = this.listDoc.GetItemAt(curPos.X, curPos.Y);

            if (lvwItem != null)
            {
                System.Diagnostics.Debug.WriteLine("aa");
            }

            //tipListDoc.ShowAlways = false;
            //string notes = "";
            //if (listDoc.SelectedItems.Count > 0)
            //{
            //    for (int row = 0; row < cAccess.basicDt.Rows.Count; row++)
            //    {
            //        try
            //        {
            //            if (listDoc.SelectedItems[0].SubItems[0].Text == cAccess.basicDt.Rows[row]["ID"].ToString())
            //            {
            //                notes = cAccess.basicDt.Rows[row]["Notes"].ToString();
            //            }
            //        }
            //        catch { }
            //    }
            //}
            ////显示备注
            //tipListDoc.SetToolTip(this.listDoc, notes);
            ////tipListDoc.Show(notes, this.listDoc);
            //tipListDoc.ShowAlways = true;
        }
        private void listDoc_MouseClick(object sender, MouseEventArgs e)
        {
            Point curPos = this.listDoc.PointToClient(Control.MousePosition);
            ListViewItem lvwItem = this.listDoc.GetItemAt(curPos.X, curPos.Y);

            if (lvwItem != null)
            {
                System.Diagnostics.Debug.WriteLine("aa");
            }
        }

        private void listDoc_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (listDoc.CheckedItems.Count > 0)
            {
                tsbDelete.Enabled = true;
                tsbPrint.Enabled = true;
                tssbMoveType.Enabled = true;
            }
            else
            {
                tsbDelete.Enabled = false;
                tssbMoveType.Enabled = false;
                tsbPrint.Enabled = false;
            }
        }

        private void listDoc_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listDoc.SelectedItems.Count > 0)
                for (int row = 0; row < cAccess.basicDt.Rows.Count; row++)
                {
                    if (listDoc.SelectedItems[0].SubItems[0].Text == cAccess.basicDt.Rows[row]["ID"].ToString())
                    {
                        try
                        {
                            System.Diagnostics.Process.Start(cAccess.basicDt.Rows[row]["LocalPath"].ToString());

                        }
                        catch { MessageBox.Show("此文件的格式不被支持"); }
                    }
                }
        }

        #endregion

        #region 公文列表右键菜单

        /// <summary>
        /// 查看公文
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiLook_Click(object sender, EventArgs e)
        {
            if (listDoc.SelectedItems.Count > 0)
                for (int row = 0; row < cAccess.basicDt.Rows.Count; row++)
                {
                    if (listDoc.SelectedItems[0].SubItems[0].Text == cAccess.basicDt.Rows[row]["ID"].ToString())
                    {
                        if (!File.Exists(cAccess.basicDt.Rows[row]["LocalPath"].ToString()))
                        {
                            if (MessageBox.Show("文件不存在，是否从来源获取？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                            {//从来源下载
                                if (cSync.GetDoc(cAccess.basicDt.Rows[row]["DocTitle"].ToString(), cAccess.basicDt.Rows[row]["Source"].ToString(),
                                      cAccess.basicDt.Rows[row]["DocType"].ToString(), "", "", "", false))
                                { System.Diagnostics.Process.Start(cAccess.basicDt.Rows[row]["LocalPath"].ToString()); }
                                else
                                { MessageBox.Show("获取失败！"); }
                            }
                        }
                        else
                        {
                            System.Diagnostics.Process.Start(cAccess.basicDt.Rows[row]["LocalPath"].ToString());
                        }
                    }
                }
        }

        /// <summary>
        /// 查看公文位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiLocation_Click(object sender, EventArgs e)
        {
            if (listDoc.SelectedItems.Count == 1)
            {
                for (int row = 0; row < cAccess.basicDt.Rows.Count; row++)
                {
                    if (listDoc.SelectedItems[0].SubItems[0].Text == cAccess.basicDt.Rows[row]["ID"].ToString())
                    {
                        int localint = cAccess.basicDt.Rows[row]["LocalPath"].ToString().LastIndexOf(@"\");
                        string loacaldirect = cAccess.basicDt.Rows[row]["LocalPath"].ToString().Substring(0, localint);
                        Process.Start(loacaldirect);
                    }
                }
            }
        }

        /// <summary>
        /// 打开公文的网站
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiFindSource_Click(object sender, EventArgs e)
        {
            if (listDoc.SelectedItems.Count == 1)
            {
                for (int row = 0; row < cAccess.basicDt.Rows.Count; row++)
                {
                    if (listDoc.SelectedItems[0].SubItems[0].Text == cAccess.basicDt.Rows[row]["ID"].ToString())
                    {
                        try
                        {
                            Process.Start(cAccess.basicDt.Rows[row]["Source"].ToString());
                        }
                        catch
                        {
                            if (MessageBox.Show("文件丢失，并且通过来源重新获取失败，是否从数据库中排除这些文件？\n", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                                cAccess.delect(cAccess.basicDt.Rows[row]["Source"].ToString());
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 删除并刷新列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            if (listDoc.SelectedItems.Count > 0)
            {
                for (int i = 0; i < listDoc.SelectedItems.Count; i++)
                {
                    for (int row = 0; row < cAccess.basicDt.Rows.Count; row++)
                    {
                        if (listDoc.SelectedItems[i].Text == cAccess.basicDt.Rows[row]["ID"].ToString())
                        {
                            cAccess.delect(listDoc.SelectedItems[i].Text);
                            //System.Diagnostics.Debug.WriteLine(listDoc.CheckedItems[i].Text);
                        }
                    }
                }
                getList();
            }
        }
        /// <summary>
        /// 查看属性
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiInfo_Click(object sender, EventArgs e)
        {
            using (frmProperty property = new frmProperty(listDoc.SelectedItems[0].SubItems[0].Text))
            {
                property.ShowDialog();
            }
        }
        #endregion

        //---------------------------------------------------------------

        #region 批量选择

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
        #endregion

        #region 分页
        int pagesAll = 1, pageNow = 1;
        private void btnPageUp_Click(object sender, EventArgs e)
        {
            Page();
            int temp = pageNow;
            if (pageNow-- <= 1)
            {
                pageNow = temp;
                MessageBox.Show("已经到首页");
                return;
            }
            textBoxNow.Text = pageNow.ToString();
            list((pageNow - 1) * cConfig.paginalItems);
        }

        private void btnPageDown_Click(object sender, EventArgs e)
        {
            Page();
            int temp = pageNow;
            if (pageNow++ >= pagesAll)
            {
                pageNow = temp;
                MessageBox.Show("已经到末页");
                return;
            }
            textBoxNow.Text = pageNow.ToString();
            list((pageNow - 1) * cConfig.paginalItems);
        }

        private void Page()
        {
            if (int.Parse(textBoxNow.Text) > int.Parse(labPageAll.Text))
            {
                int page = 1;
                textBoxNow.Text = page.ToString();
                pageNow = page;

            }
        }

        #endregion

        #region 页码
        private void textBoxNow_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                textBoxNow_Leave(sender, e);
            }
            if (e.KeyChar != '\b')//这是允许输入退格键
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字
                {
                    e.Handled = true;
                }
            }
        }
        private void textBoxNow_Leave(object sender, EventArgs e)
        {
            int temp = pageNow;
            //执行“跳转”
            try
            {
                if (pageNow != Convert.ToInt32(textBoxNow.Text))
                {
                    pageNow = Convert.ToInt32(textBoxNow.Text);
                    if (pageNow < 1 || pageNow > pagesAll)
                    {
                        pageNow = temp;
                        MessageBox.Show("输入的页码超出范围！");
                        return;
                    }
                    else
                    {
                        list((pageNow - 1) * cConfig.paginalItems);
                    }
                }
            }
            catch (Exception ex) { pageNow = temp; MessageBox.Show(ex.Message); }
        }
        #endregion

        #region 每页显示数目

        private void comboBoxpaginal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxpaginal.Text == cConfig.strNoLimit)
            {
                if (cConfig.paginalItems == 0)
                    return;
            }
            else if (cConfig.paginalItems == Convert.ToInt32(comboBoxpaginal.Text))
                return;
            if (comboBoxpaginal.Text == cConfig.strNoLimit)
            {
                cConfig.paginalItems = 0;
                btnPageDown.Enabled = false;
                btnPageUp.Enabled = false;
                textBoxNow.Enabled = false;
            }
            else
            {
                cConfig.paginalItems = Convert.ToInt32(comboBoxpaginal.Text);
                btnPageDown.Enabled = true;
                btnPageUp.Enabled = true;
                textBoxNow.Enabled = true;
            }
            getList();

            cConfig.SaveConfig();
        }

        private void comboBoxpaginal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                comboBoxpaginal_SelectedIndexChanged(sender, e);
            if (e.KeyChar != '\b')//这是允许输入退格键
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字
                {
                    e.Handled = true;
                }
            }
        }

        private void comboBoxpaginal_Leave(object sender, EventArgs e)
        {
            comboBoxpaginal_SelectedIndexChanged(sender, e);
        }

        #endregion

        //---------------------------------------------------------------

        private void btnAddType_Click(object sender, EventArgs e)
        {
            using (frmNewType frmNewtype = new frmNewType())
            {
                frmNewtype.groupBoxType.Text = "新增类型";
                frmNewtype.Text = "新增类型";
                frmNewtype.ShowDialog();

            }
        }


        private void btnDelType_Click(object sender, EventArgs e)
        {
            if (listDocType.SelectedIndex > 0)
            {
                string delType = listDocType.SelectedItem.ToString();
                if (delType == cConfig.strNoType || delType == cConfig.strAllType)
                    MessageBox.Show("禁止删除" + delType);
                else if (MessageBox.Show("确定删除该类型及其中所有公文？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    List<string> ls = new List<string>();
                    string filterExpression = "DocType = '" + delType + "'";
                    foreach (System.Data.DataRow drs in cAccess.basicDt.Select(filterExpression))
                    {
                        cAccess.delect(drs["ID"].ToString());
                    }
                    if (Directory.Exists(cConfig.strWorkPath + "\\" + delType))
                    {
                        DeleteRunner.Delete(cConfig.strWorkPath + "\\" + delType);
                    }

                    flashTypeList();
                    search();
                }
            }
        }

        private void tssbSync_ButtonClick(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cConfig.FTP_IP))
            {
                if (MessageBox.Show("未设置备份服务器，是否现在设置？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    tsbSetting_Click(sender, e);
                return;
            }
            Thread th = new Thread(new ThreadStart(sync));
            th.Start();
        }

        private void sync()
        {
            try
            {
                tsslSyncStatus.Text = "正在同步...";
                tsslSyncStatus.BackColor = System.Drawing.SystemColors.Highlight;
                cSync Sync = new cSync();
                Sync.Contrast();

                Sync.LocalReplenish();

                if (Sync.listNotRecord.count > 0)
                {
                    if (MessageBox.Show("发现有" + Sync.listNotRecord.count + "个文件未同步到本地。是否执行同步？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        Sync.FtpToLocal();
                    }
                }

                if (Sync.listNotInFtp.Count > 0)
                {
                    tsslSyncStatus.Text = "发现有" + Sync.listNotInFtp.Count + "个文件未备份，正在备份...";
                    Sync.LocalToFtp();
                }
                Sync.Contrast();
                tsslSyncStatus.Text = "备份完成!";
                //------------------------------------------------------------
                flashTypeList(); search();
                //------------------------------------------------------------
                tsslSyncStatus.Text += "有" + Sync.listNotInFtp.Count + "个文件备份失败。";
                tsslSyncStatus.BackColor = System.Drawing.SystemColors.Control;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "/n" + "ps:检查网络是否连接，备份服务器地址是否有错", "警告");
            }
        }

        private void tsbHelp_Click(object sender, EventArgs e)
        {
            if (File.Exists(".\\help.chm")) { System.Diagnostics.Process.Start(".\\help.chm"); }
            else
            {
                FileStream fs = new FileStream(".\\help.chm", FileMode.OpenOrCreate, FileAccess.Write);
                try
                {
                    //创建byte数组，装资源 
                    Byte[] b = DMS.Properties.Resources.help;
                    fs.Write(b, 0, b.Length);
                    if (fs != null)
                        fs.Close();
                    System.Diagnostics.Process.Start(".\\help.chm");
                }
                catch
                {
                    if (fs != null)
                        fs.Close();
                }

            }
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


        //private void tsmiAutoSync_Click(object sender, EventArgs e)
        //{
        //    //cConfig.isAutoSync = true;
        //    //tsmiAutoSync.Checked = true;
        //    timerAutoSync.Enabled = true;
        //    cConfig.SaveConfig();
        //}








        //---------------------------------------------------------------




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

        private void tssbMoveType_ButtonClick(object sender, EventArgs e)
        {
            tssbMoveType.ShowDropDown();
        }

        private void listDoc_SizeChanged(object sender, EventArgs e)
        {
            int[] listColumnWidth = CalculateWidth(listDoc.Width);
            if (listColumnWidth[1] > 0)
                listDoc.Columns[1].Width = listColumnWidth[1];
        }

    }
}
