using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using DMS.Forms;
using ICSharpCode.SharpZipLib.Zip;
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
            //int SW = Screen.PrimaryScreen.Bounds.Width;
            int w = System.Windows.Forms.SystemInformation.WorkingArea.Width;
            if (w * 0.8 > this.Width)
                this.Width = (int)(w * 0.8);
            fm = this;
            CheckForIllegalCrossThreadCalls = false;
        }


        //-----------------------------拖动窗体------------------------------
        #region 拖动窗体
        /// <summary>
        /// 判断鼠标是否按下
        /// </summary>
        private bool _isDown = false;
        /// <summary>
        /// 原来的鼠标点
        /// </summary>
        private Point _oldPoint;
        /// <summary>
        /// 原来窗口点
        /// </summary>
        private Point _oldForm;
        private void pBody_MouseDown(object sender, MouseEventArgs e)
        {
            _isDown = true;
            _oldPoint = new Point();
            _oldPoint = e.Location;
            _oldForm = this.Location;
        }

        private void pBody_MouseUp(object sender, MouseEventArgs e)
        {
            _isDown = false;
        }

        private void pBody_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDown)
            {
                _oldForm.Offset(e.X - _oldPoint.X, e.Y - _oldPoint.Y);
                this.Location = _oldForm;
            }
        }

        private void picHead_MouseDown(object sender, MouseEventArgs e)
        {
            _isDown = true;
            _oldPoint = new Point();
            _oldPoint = e.Location;
            _oldForm = this.Location;
        }

        private void picHead_MouseUp(object sender, MouseEventArgs e)
        {
            _isDown = false;
        }

        private void picHead_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDown)
            {
                _oldForm.Offset(e.X - _oldPoint.X, e.Y - _oldPoint.Y);
                this.Location = _oldForm;
            }
        }
        #endregion
        //---------------------------------------------------------

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
                //labHead.Left = (this.Width - labHead.Width) / 2;

                listDoc.Columns.Clear();
                string[] listColumnName = { "", "公文标题", "发布时间", "发布单位", "收录时间", "公文类型", "备注" };
                int[] listColumnWidth = CalculateWidth(listDoc.Width);

                for (int i = 0; i < listColumnName.Length; i++)
                {
                    listDoc.Columns.Add(listColumnName[i], listColumnWidth[i]);
                }

                if (cAccess.load() == false) MessageBox.Show("加载数据库失败");

                cConfig.ReadConfig();


                string[] pi = { "20", "30", "50", "100", cConfig.strNoLimit };//,cConfig.strAutoSize };
                foreach (string p in pi)
                {
                    comboBoxpaginal.Items.Add(p);
                }


                cSync.AddRecord();

                if (cConfig.paginalItems == 0)
                    comboBoxpaginal.Text = cConfig.strNoLimit;
                //else if (cConfig.paginalItems == -1)
                //    comboBoxpaginal.Text = cConfig.strAutoSize;
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
            int[] listColumnWidth = { 20, 0, 132, 100, 132, 90, 0, 22 };
            foreach (int i in listColumnWidth)
                w -= i;
            if (w - 90 > 132)
            {
                listColumnWidth[6] = 90;
                listColumnWidth[1] = w - 90;
            }

            else
            {
                listColumnWidth[1] = w - 1;
                listColumnWidth[6] = 1;
            }
            return listColumnWidth;
        }
        /// <summary>
        /// 初始化
        /// </summary>
        public void initialize()
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
            tsslStatus.Text = "OK!";
        }

        #endregion

        #region 定期运行

        //private void timerAutoSync_Tick(object sender, EventArgs e)
        //{
        //    tssbSync_ButtonClick(sender, e);
        //}


        private void isWorking()
        {
            tsslStatus.Text = "正在工作中...";
        }

        #endregion

        //---------------------------------------------------------

        #region 列出公文
        List<string> listID = new List<string>();

        public void getList()
        {
            if (TypeSelectedIndex >= listDocType.Items.Count)
                TypeSelectedIndex = listDocType.Items.Count - 1;
            if (TypeSelectedIndex < 0) TypeSelectedIndex = 0;

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
            if (pageNow > pagesAll)
                pageNow = pagesAll;
            labPageAll.Text = pagesAll.ToString();
            textBoxNow.Text = pageNow.ToString();
            listDocType.SelectedIndex = TypeSelectedIndex;
            list();
            GC.Collect();
        }

        /// <summary>
        /// 按"listID"列出公文
        /// </summary>
        /// <param name="startIndex"></param>
        void list(int startIndex = 0)
        {
            listDoc.Items.Clear();

            if (cConfig.paginalItems > 0)
            {
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
                            if (string.IsNullOrWhiteSpace(cAccess.basicDt.Rows[row]["ReleaseDate"].ToString()))
                                lvitem.SubItems.Add("");
                            else
                                lvitem.SubItems.Add(cAccess.basicDt.Rows[row]["ReleaseDate"].ToString());
                            lvitem.SubItems.Add(cAccess.basicDt.Rows[row]["Provider"].ToString());
                            lvitem.SubItems.Add(cAccess.basicDt.Rows[row]["AddTime"].ToString());
                            lvitem.SubItems.Add(cAccess.basicDt.Rows[row]["DocType"].ToString());
                            lvitem.SubItems.Add(cAccess.basicDt.Rows[row]["Notes"].ToString());
                            //lvitem.ToolTipText = cAccess.basicDt.Rows[row]["DocTitle"].ToString();//+ "\n备注：\n" + cAccess.basicDt.Rows[row]["Notes"].ToString();
                            break;
                            //System.Diagnostics.Debug.WriteLine("vv" + cConfig.paginalItems);
                        }
                    }
                    startIndex++;
                }
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
                            if (string.IsNullOrWhiteSpace(cAccess.basicDt.Rows[row]["ReleaseDate"].ToString()))
                                lvitem.SubItems.Add("");
                            else
                                lvitem.SubItems.Add(cAccess.basicDt.Rows[row]["ReleaseDate"].ToString());
                            lvitem.SubItems.Add(cAccess.basicDt.Rows[row]["Provider"].ToString());
                            lvitem.SubItems.Add(cAccess.basicDt.Rows[row]["AddTime"].ToString());
                            lvitem.SubItems.Add(cAccess.basicDt.Rows[row]["DocType"].ToString());
                            lvitem.SubItems.Add(cAccess.basicDt.Rows[row]["Notes"].ToString());
                            //lvitem.ToolTipText = cAccess.basicDt.Rows[row]["DocTitle"].ToString();//+ "\n备注：\n" + cAccess.basicDt.Rows[row]["Notes"].ToString();
                            break;
                        }
                    }
                }
            }
            //else if (cConfig.paginalItems == -1)
            //{
            //    int num = (this.listDoc.Height - 50) / this.listDoc.Font.Height;
            //    for (int i = 0; i < cConfig.paginalItems; i++)
            //    {
            //        if (startIndex >= listID.Count) break;
            //        for (int row = 0; row < cAccess.basicDt.Rows.Count; row++)
            //        {
            //            if (listID[startIndex] == cAccess.basicDt.Rows[row]["ID"].ToString())
            //            {
            //                ListViewItem lvitem = new ListViewItem();
            //                lvitem = listDoc.Items.Add(cAccess.basicDt.Rows[row]["ID"].ToString());
            //                lvitem.SubItems.Add(cAccess.basicDt.Rows[row]["DocTitle"].ToString());
            //                if (string.IsNullOrWhiteSpace(cAccess.basicDt.Rows[row]["ReleaseDate"].ToString()))
            //                    lvitem.SubItems.Add("");
            //                else
            //                    lvitem.SubItems.Add(cAccess.basicDt.Rows[row]["ReleaseDate"].ToString());
            //                lvitem.SubItems.Add(cAccess.basicDt.Rows[row]["Provider"].ToString());
            //                lvitem.SubItems.Add(cAccess.basicDt.Rows[row]["AddTime"].ToString());
            //                lvitem.SubItems.Add(cAccess.basicDt.Rows[row]["DocType"].ToString());
            //                lvitem.SubItems.Add(cAccess.basicDt.Rows[row]["Notes"].ToString());
            //                lvitem.ToolTipText = cAccess.basicDt.Rows[row]["DocTitle"].ToString();//+ "\n备注：\n" + cAccess.basicDt.Rows[row]["Notes"].ToString();
            //                break;
            //                //System.Diagnostics.Debug.WriteLine("vv" + cConfig.paginalItems);
            //            }
            //        }
            //        startIndex++;
            //    }
            //}
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
            if (TypeSelectedIndex < 0) TypeSelectedIndex = 0;
            if (listDocType.Items.Count > 0)
            {
                if (listDocType.Items.Count <= TypeSelectedIndex)
                    listDocType.SelectedIndex = listDocType.Items.Count - 1;
                else
                    listDocType.SelectedIndex = TypeSelectedIndex;
            }
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
                TypeList.Add(f.Name);
                searchDirectory(f.FullName);
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
            try
            {
                using (frmAddDoc frmAd = new frmAddDoc())
                {
                    isWorking();
                    frmAd.ShowDialog();
                }
            }
            catch { }
        }

        private void tsmiAdd_Click(object sender, EventArgs e)
        {
            tssbAdd_ButtonClick(sender, e);
        }

        private void tsmiAddMore_Click(object sender, EventArgs e)
        {
            try
            {
                using (Crawler.frmCrawler cr = new Crawler.frmCrawler())
                {
                    isWorking();
                    cr.ShowDialog();
                }
            }
            catch { }
        }

        private void tsbScan_Click(object sender, EventArgs e)
        {

            try
            {
                using (Camera.frmCamera frmScan = new Camera.frmCamera())
                {
                    isWorking();
                    frmScan.ShowDialog();
                }
            }
            catch { }
        }

        private void tsbSetting_Click(object sender, EventArgs e)
        {
            try
            {
                using (frmSettings frmS = new frmSettings())
                {
                    frmS.ShowDialog();
                }
            }
            catch { }
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
                cAccess.ModifyTheType(listDoc.CheckedItems[i].SubItems[0].Text, e.ClickedItem.Text);
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
                cAccess.ModifyTheType(listDoc.CheckedItems[i].SubItems[0].Text, strNewType);
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
                    ls.Add(cAccess.basicDt.Select("ID = " + listDoc.CheckedItems[i].SubItems[0].Text)[0]["LocalPath"].ToString());
                    ////if (listDoc.CheckedItems[i].Checked == true)
                    //for (int row = 0; row < cAccess.basicDt.Rows.Count; row++)
                    //{
                    //    if (listDoc.CheckedItems[i].SubItems[0].Text == cAccess.basicDt.Rows[row]["ID"].ToString())
                    //    {
                    //        ls.Add(cAccess.basicDt.Rows[row]["LocalPath"].ToString());
                    //    }
                    //}
                }
                cPrintFiles cpf = new cPrintFiles(ls);
                //cpf.printFiles();
                Thread th = new Thread(new ThreadStart(cpf.printFiles));
                th.Start();
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
            initialize();
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
            initialize();
        }

        private void tsmiDeleteType_Click(object sender, EventArgs e)
        {
            btnDelType_Click(sender, e);
        }

        #endregion

        //-------------------------------------------------------------

        #region 公文列表事件 listDoc


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
            {
                try
                {
                    var dr = cAccess.basicDt.Select("ID = " + listDoc.SelectedItems[0].SubItems[0].Text);//[0]["LocalPath"].ToString();
                    if (File.Exists(dr[0]["LocalPath"].ToString()))
                        System.Diagnostics.Process.Start(dr[0]["LocalPath"].ToString());
                    else
                        if (MessageBox.Show("文件不存在，是否从来源获取？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                        {//从来源下载
                            if (cSync.GetDoc(dr[0]["DocTitle"].ToString(), dr[0]["Source"].ToString(),
                                  dr[0]["DocType"].ToString(), "", "", "", false))
                            { System.Diagnostics.Process.Start(dr[0]["LocalPath"].ToString()); }
                            else
                            { MessageBox.Show("获取失败！"); }
                        }

                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                //for (int row = 0; row < cAccess.basicDt.Rows.Count; row++)
                //{
                //    if (listDoc.SelectedItems[0].SubItems[0].Text == cAccess.basicDt.Rows[row]["ID"].ToString())
                //    {
                //        try
                //        {
                //            System.Diagnostics.Process.Start(cAccess.basicDt.Select("ID = "
                //                + listDoc.SelectedItems[0].SubItems[0].Text)[0]["LocalPath"].ToString());
                //            System.Diagnostics.Process.Start(cAccess.basicDt.Rows[row]["LocalPath"].ToString());

                //        }
                //        catch { MessageBox.Show("此文件的格式不被支持"); }
                //    }
                //}
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
            {
                try
                {
                    var dr = cAccess.basicDt.Select("ID = " + listDoc.SelectedItems[0].SubItems[0].Text);//[0]["LocalPath"].ToString();
                    if (File.Exists(dr[0]["LocalPath"].ToString()))
                        System.Diagnostics.Process.Start(dr[0]["LocalPath"].ToString());
                    else
                        if (MessageBox.Show("文件不存在，是否从来源获取？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                        {//从来源下载
                            if (cSync.GetDoc(dr[0]["DocTitle"].ToString(), dr[0]["Source"].ToString(),
                                  dr[0]["DocType"].ToString(), "", "", "", false))
                            { System.Diagnostics.Process.Start(dr[0]["LocalPath"].ToString()); }
                            else
                            { MessageBox.Show("获取失败！"); }
                        }

                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
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
                try
                {
                    var dr = cAccess.basicDt.Select("ID = " + listDoc.SelectedItems[0].SubItems[0].Text);//[0]["LocalPath"].ToString();
                    int localint = dr[0]["LocalPath"].ToString().LastIndexOf(@"\");
                    string loacaldirect = dr[0]["LocalPath"].ToString().Substring(0, localint);
                    Process.Start(loacaldirect);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                //for (int row = 0; row < cAccess.basicDt.Rows.Count; row++)
                //{
                //    if (listDoc.SelectedItems[0].SubItems[0].Text == cAccess.basicDt.Rows[row]["ID"].ToString())
                //    {
                //        int localint = cAccess.basicDt.Rows[row]["LocalPath"].ToString().LastIndexOf(@"\");
                //        string loacaldirect = cAccess.basicDt.Rows[row]["LocalPath"].ToString().Substring(0, localint);
                //        Process.Start(loacaldirect);
                //    }
                //}
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

                try
                {
                    var dr = cAccess.basicDt.Select("ID = " + listDoc.SelectedItems[0].SubItems[0].Text);//[0]["LocalPath"].ToString();
                    Process.Start(dr[0]["Source"].ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                //for (int row = 0; row < cAccess.basicDt.Rows.Count; row++)
                //{
                //    if (listDoc.SelectedItems[0].SubItems[0].Text == cAccess.basicDt.Rows[row]["ID"].ToString())
                //    {
                //        try
                //        {
                //            Process.Start(cAccess.basicDt.Rows[row]["Source"].ToString());
                //        }
                //        catch (Exception ex)
                //        {
                //            MessageBox.Show(ex.Message);
                //        }
                //    }
                //}
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
                    cAccess.delect(listDoc.SelectedItems[i].Text);
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
                if (cConfig.paginalItems == 0)
                    return;
            }
            //else if (comboBoxpaginal.Text == cConfig.strAutoSize)
            //{
            //    if (cConfig.paginalItems == -1)
            //        return;
            //}
            else if (cConfig.paginalItems == Convert.ToInt32(comboBoxpaginal.Text))
                return;
            if (comboBoxpaginal.Text == cConfig.strNoLimit)
            {
                cConfig.paginalItems = 0;
                btnPageDown.Enabled = false;
                btnPageUp.Enabled = false;
                textBoxNow.Enabled = false;
            }
            //else if (comboBoxpaginal.Text == cConfig.strAutoSize)
            //{
            //    cConfig.paginalItems =-1;
            //    btnPageDown.Enabled = false;
            //    btnPageUp.Enabled = false;
            //    textBoxNow.Enabled = false;
            //}
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
        static bool isNotSyncing = true;
        private void tssbSync_ButtonClick(object sender, EventArgs e)
        {
            GC.Collect();
            if (string.IsNullOrWhiteSpace(cConfig.FTP_IP))
            {
                if (MessageBox.Show("未设置备份服务器，是否现在设置？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    tsbSetting_Click(sender, e);
                return;
            }
            if (isNotSyncing)
            {
                isNotSyncing = false;
                Thread th = new Thread(new ThreadStart(sync));
                th.Start();
            }
        }

        #region 委托

        //delegate void SetTextCallback(string text);

        //private void SetBtnStartText(string text)
        //{
        //    // InvokeRequired required compares the thread ID of the
        //    // calling thread to the thread ID of the creating thread.
        //    // If these threads are different, it returns true.
        //    if (this.btnStart.InvokeRequired)
        //    {
        //        SetTextCallback d = new SetTextCallback(SetBtnStartText);
        //        this.Invoke(d, new object[] { text });
        //    }
        //    else
        //    {
        //        this.btnStart.Text = text;
        //    }
        //}
        #endregion

        private void sync()
        {
            try
            {
                tsslSyncStatus.Text = "正在同步...";
                //tsslSyncStatus.BackColor = System.Drawing.SystemColors.Highlight;
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

                //------------------------------------------------------------
                this.initialize();
                //------------------------------------------------------------
                tsslSyncStatus.Text = "同步完成!";
                System.Threading.Thread.Sleep(2000);
                Sync.Contrast();

                if (Sync.listNotInFtp.Count > 0)
                    tsslSyncStatus.Text += "有" + Sync.listNotInFtp.Count + "个文件备份失败。请重试！";
                //tsslSyncStatus.BackColor = System.Drawing.SystemColors.Control;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error ： " + ex.Message + "\n" + "（请检查网络是否连接，备份服务器地址是否有错）", "错误");
                tsslSyncStatus.Text = "";
            }
            finally
            {
                isNotSyncing = true;
            }
        }

        private void tsbHelp_Click(object sender, EventArgs e)
        {
            string helpPath = cConfig.TempPath + "\\help.html";
            if (File.Exists(helpPath)) { System.Diagnostics.Process.Start(helpPath); }
            else
            {
                //FileStream fs = new FileStream(help, FileMode.OpenOrCreate, FileAccess.Write);
                ////创建byte数组，装资源 
                //Byte[] b = DMS.Properties.Resources.help;
                //fs.Write(b, 0, b.Length);
                //if (fs != null)
                //    fs.Close();
                try
                {
                    Stream S = new MemoryStream(DMS.Properties.Resources.help);
                    //using (ZipInputStream s = new ZipInputStream(File.OpenRead(zipFilePath)))
                    string rootFile = "";
                    string fileDir = cConfig.TempPath;
                    //读取压缩文件(zip文件)，准备解压缩
                    ZipInputStream s = new ZipInputStream(S);

                    ZipEntry theEntry;
                    string path = fileDir;  //解压出来的文件保存的路径

                    string rootDir = ""; //根目录下的第一个子文件夹的名称
                    while ((theEntry = s.GetNextEntry()) != null)
                    {
                        rootDir = Path.GetDirectoryName(theEntry.Name); //得到根目录下的第一级子文件夹的名称
                        if (rootDir.IndexOf("\\") >= 0)
                        {
                            rootDir = rootDir.Substring(0, rootDir.IndexOf("\\") + 1);
                        }
                        string dir = Path.GetDirectoryName(theEntry.Name); //根目录下的第一级子文件夹的下的文件夹的名称
                        string fileName = Path.GetFileName(theEntry.Name); //根目录下的文件名称
                        if (dir != "" && fileName == "") //创建根目录下的子文件夹,不限制级别
                        {
                            if (!Directory.Exists(fileDir + "\\" + dir))
                            {
                                path = fileDir + "\\" + dir; //在指定的路径创建文件夹
                                Directory.CreateDirectory(path);
                            }
                        }
                        else if (dir == "" && fileName != "") //根目录下的文件
                        {
                            path = fileDir;
                            rootFile = fileName;
                        }
                        else if (dir != "" && fileName != "") //根目录下的第一级子文件夹下的文件
                        {
                            if (dir.IndexOf("\\") > 0) //指定文件保存的路径
                            {
                                path = fileDir + "\\" + dir;
                            }
                        }

                        if (dir == rootDir) //判断是不是需要保存在根目录下的文件
                        {
                            path = fileDir + "\\" + rootDir;
                        }
                        //以下为解压缩zip文件的基本步骤
                        //基本思路就是遍历压缩文件里的所有文件，创建一个相同的文件。
                        if (fileName != String.Empty)
                        {
                            FileStream streamWriter = File.Create(path + "\\" + fileName);

                            int size = 2048;
                            byte[] data = new byte[2048];
                            while (true)
                            {
                                size = s.Read(data, 0, data.Length);
                                if (size > 0)
                                {
                                    streamWriter.Write(data, 0, size);
                                }
                                else
                                {
                                    break;
                                }
                            }

                            streamWriter.Close();
                            //streamWriter.Dispose();
                        }
                    }

                    s.Close();
                    //S.Close();
                    //S.Dispose();
                    System.Diagnostics.Process.Start(helpPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                GC.Collect();
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


        private void tssbMoveType_ButtonClick(object sender, EventArgs e)
        {
            tssbMoveType.ShowDropDown();
        }

        private void listDoc_SizeChanged(object sender, EventArgs e)
        {
            int[] listColumnWidth = CalculateWidth(listDoc.Width);
            if (listColumnWidth[1] > 0)
                listDoc.Columns[1].Width = listColumnWidth[1];
            if (listColumnWidth[6] > 1)
                listDoc.Columns[6].Width = listColumnWidth[6];
        }


        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
            Application.Exit();
        }





    }
}
