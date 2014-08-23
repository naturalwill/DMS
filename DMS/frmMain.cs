using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using DMS.Forms;

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

                if (cAccess.load() == false) MessageBox.Show("加载数据库失败");

                cConfig.ReadConfig();


                string[] pi = { "10", "15", "20", "30", "50", cConfig.strNoLimit };
                foreach (string p in pi)
                {
                    comboBoxpaginal.Items.Add(p);
                }
                if (cConfig.paginalItems == 0)
                    comboBoxpaginal.Text = cConfig.strNoLimit;
                else
                    comboBoxpaginal.Text = cConfig.paginalItems.ToString();

                cSync.AddRecord();


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
                    dateStart.Value = DateTime.Parse(cAccess.newDt.Rows[(cAccess.newDt.Rows.Count - 1)]["AddTime"].ToString());
                dateEnd.Value = DateTime.Now;
            }
            catch { throw; }
            flashTypeList();
        }

        #endregion

        #region 定期运行

        //private void timerAutoSync_Tick(object sender, EventArgs e)
        //{
        //    tssbSync_ButtonClick(sender, e);
        //}
        private void timer1_Tick(object sender, EventArgs e)
        {
            //根据工作状态，判断是否需要刷新
            if (cConfig.working)
            {
                tsslStatus.Text = "正在工作中...";
            }
            else
            {
                if (cConfig.needFlash) { search(); tsslStatus.Text = "OK!"; timer1.Enabled = false; }
            }
        }

        #endregion

        //---------------------------上有2个函数没完成----------------------------

        #region 列出公文
        List<string> listID = new List<string>();

        private void getList()
        {
            if (listDocType.Items.Count == 1)
                TypeIndex = 0;
            else if (TypeIndex >= listDocType.Items.Count)
                TypeIndex = listDocType.Items.Count - 1;

            string strSelected = listDocType.Items[TypeIndex].ToString();
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

        #region 更新类型列表
        public static List<string> TypeList = new List<string>();
        static int TypeIndex = 0;
        /// <summary>
        /// 刷新类型列表
        /// </summary>
        public void flashTypeList()
        {
            TypeList.Clear();
            if (!Directory.Exists(cConfig.strWorkPath))
                Directory.CreateDirectory(cConfig.strWorkPath);
            searchDirectory(cConfig.strWorkPath);

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

            listDocType.Items.Clear(); tscbMove.Items.Clear();
            listDocType.Items.Add(cConfig.strAllType);
            foreach (string str in TypeList)
            {
                tscbMove.Items.Add(str);
                listDocType.Items.Add(str);
            }
            tscbMove.Items.Add(cConfig.strNewType);

            getList();


        }

        public void btnMove()
        {
            btnAddType.Top = listDocType.ItemHeight * (listDocType.Items.Count + 1) + listDocType.Top + scBody.Top;
            btnAddType.Left = ((listDocType.Width - btnAddType.Width) / 2) + listDocType.Left + scBody.Left;
            if (btnAddType.Bottom >= scBody.Bottom) btnAddType.Top = scBody.Bottom + 3;
        }

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

        private void search()
        {
            string st = txtSearch.Text;
            if (st == cConfig.strSearchTips) st = "";
            //cAccess.search(st, dateStart.Value.ToShortDateString(), dateEnd.Value.ToShortDateString(), 0);
            cAccess.search(st, dateStart.Value.ToString(), dateEnd.Value.ToString(), 0);
            getList();
            flashTypeList();
            btnClear.Visible = true;
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
                cConfig.working = true;
                timer1.Enabled = true;
                frmAd.ShowDialog();
            }
        }

        private void tsmiAdd_Click(object sender, EventArgs e)
        {
            using (frmAddDoc frmAd = new frmAddDoc())
            {
                cConfig.working = true;
                timer1.Enabled = true;
                frmAd.ShowDialog();
            }
        }

        private void tsmiAddMore_Click(object sender, EventArgs e)
        {
            using (Crawler.frmCrawler cr = new Crawler.frmCrawler())
            {
                cConfig.working = true;
                timer1.Enabled = true;
                cr.ShowDialog();
            }
        }

        private void tsbScan_Click(object sender, EventArgs e)
        {
            using (Camera.frmCamera frmScan = new Camera.frmCamera())
            {
                cConfig.working = true;
                timer1.Enabled = true;
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
                    getList();
                }
            }
        }



        private void tscbMove_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tscbMove.SelectedIndex >= 0)
            {

                if (tscbMove.SelectedItem.ToString() == cConfig.strNewType)
                {
                    using (frmNewType frmNewtype = new frmNewType())
                    {
                        frmNewtype.labNewType.Text = "添加类型";
                        frmNewtype.Text = "添加类型";
                        frmNewtype.ShowDialog();
                    }
                    return;
                }
                for (int i = 0; i < listDoc.CheckedItems.Count; i++)
                {
                    string OldPath;
                    for (int row = 0; row < cAccess.basicDt.Rows.Count; row++)
                    {
                        if (listDoc.CheckedItems[i].Text == cAccess.basicDt.Rows[row]["ID"].ToString())
                        {
                            OldPath = cAccess.basicDt.Rows[row]["LocalPath"].ToString();

                            cAccess.ModifyTheType(listDoc.CheckedItems[i].SubItems[0].Text, tscbMove.Text);

                            File.Move(OldPath, cAccess.basicDt.Rows[row]["LocalPath"].ToString());//移动相应的word文档到所需类型的目录
                            string a = cAccess.basicDt.Rows[row]["LocalPath"].ToString();
                        }
                    }
                }
                tscbMove.Text = "";
                flashTypeList();

            }
        }

        public void AddNewType(string strNewType)
        {
            listDocType.Items.Add(strNewType);
            if (!Directory.Exists(cConfig.strWorkPath + "\\" + strNewType))//添加所添加类型的目录
            {
                Directory.CreateDirectory(cConfig.strWorkPath + "\\" + strNewType);
            }

            tscbMove.Items.Clear();
            foreach (string str in listDocType.Items)
            {
                if (str != cConfig.strAllType)
                {
                    tscbMove.Items.Add(str);
                }
            }
            tscbMove.Items.Add(cConfig.strNewType);

            for (int i = 0; i < listDoc.CheckedItems.Count; i++)
            {
                string OldPath;
                for (int row = 0; row < cAccess.basicDt.Rows.Count; row++)
                {
                    if (listDoc.CheckedItems[i].Text == cAccess.basicDt.Rows[row]["ID"].ToString())
                    {
                        OldPath = cAccess.basicDt.Rows[row]["LocalPath"].ToString();

                        cAccess.ModifyTheType(listDoc.CheckedItems[i].Text, strNewType);

                        File.Move(OldPath, cAccess.basicDt.Rows[row]["LocalPath"].ToString());//移动相应的word文档到所需类型的目录
                        string a = cAccess.basicDt.Rows[row]["LocalPath"].ToString();
                    }
                }
            }
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
            if (listDocType.SelectedIndex >= 0)
            {
                TypeIndex = listDocType.SelectedIndex;
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
                frmNewtype.labNewType.Text = "新增类型";
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
        }


        private void tsmiChangeType_Click(object sender, EventArgs e)
        {
            if (listDocType.SelectedIndex > 0)
            {
                TypeIndex = listDocType.SelectedIndex;
                using (frmNewType frmNewtype = new frmNewType())
                {
                    frmNewtype.labNewType.Text = "修改类型";
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

            cAccess.ModifyType(listDocType.Items[TypeIndex].ToString(), strNewType);
            search();
        }

        private void tsmiDeleteType_Click(object sender, EventArgs e)
        {
            if (listDocType.SelectedIndex > 0)
            {
                string delType = listDocType.SelectedItem.ToString();
                if (listDocType.SelectedItem.ToString() == cConfig.strNoType || listDocType.SelectedItem.ToString() == cConfig.strAllType)
                    MessageBox.Show("禁止删除" + listDocType.SelectedItem);
                else if (MessageBox.Show("确定删除该类型？", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
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
                }
            }
        }

        #endregion

        //-------------------------------------------------------------

        #region 公文列表事件 listDoc

        private void listDoc_ItemMouseHover(object sender, ListViewItemMouseHoverEventArgs e)
        {
            tipListDoc.ShowAlways = false;
            string notes = "";
            if (listDoc.SelectedItems.Count > 0)
            {
                for (int row = 0; row < cAccess.basicDt.Rows.Count; row++)
                {
                    if (listDoc.SelectedItems[0].SubItems[0].Text == cAccess.basicDt.Rows[row]["ID"].ToString())
                    {
                        notes = cAccess.basicDt.Rows[row]["Notes"].ToString();
                    }
                }
            }
            //显示备注
            tipListDoc.SetToolTip(this.listDoc, notes);
            //tipListDoc.Show(notes, this.listDoc);
            tipListDoc.ShowAlways = true;
        }

        private void listDoc_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (listDoc.CheckedItems.Count > 0)
            {
                tsbDelete.Enabled = true;
                tsbPrint.Enabled = true;
                tslMove.Enabled = true;
                tscbMove.Enabled = true;
            }
            else
            {
                tsbDelete.Enabled = false;
                tslMove.Enabled = false;
                tscbMove.Enabled = false;
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
                        System.Diagnostics.Process.Start(cAccess.basicDt.Rows[row]["LocalPath"].ToString());
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
        /// 查看配置
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
            flashTypeList();
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
                frmNewtype.labNewType.Text = "新增类型";
                frmNewtype.Text = "新增类型";
                frmNewtype.ShowDialog();

            }
        }


        private void btnDelType_Click(object sender, EventArgs e)
        {
            if (listDocType.SelectedIndex > 0)
            {
                string delType = listDocType.SelectedItem.ToString();
                if (listDocType.SelectedItem.ToString() == cConfig.strNoType || listDocType.SelectedItem.ToString() == cConfig.strAllType)
                    MessageBox.Show("禁止删除" + listDocType.SelectedItem);
                else if (MessageBox.Show("确定删除该类型？", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
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
            tsslSyncStatus.Text += "有" + Sync.listNotInFtp.Count + "个文件备份失败。";
            tsslSyncStatus.BackColor = System.Drawing.SystemColors.Control;
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
                        fs.Close(); System.Diagnostics.Process.Start(".\\help.chm");
                }
                catch
                {
                    if (fs != null)
                        fs.Close();
                }

            }
        }





        //private void tsmiAutoSync_Click(object sender, EventArgs e)
        //{
        //    //cConfig.isAutoSync = true;
        //    //tsmiAutoSync.Checked = true;
        //    timerAutoSync.Enabled = true;
        //    cConfig.SaveConfig();
        //}








        //---------------------------------------------------------------

    }
}
