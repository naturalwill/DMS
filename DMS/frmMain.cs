using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Xml.Linq;
using System.IO;
using ADOX;
using System.Threading;

namespace DMS
{
    public partial class frmMain : Form
    {

        public frmMain()
        {
            InitializeComponent();
        }

        #region 字段
        string SearchTips = "请输入关键字查找公文";
        static string connString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Environment.CurrentDirectory + @"\DMS.mdb";
        OleDbConnection conn = new OleDbConnection(connString);
        OleDbCommand cmd;
        OleDbDataAdapter DtAdapter;
        OleDbCommandBuilder CoBuilder;
        DataTable DtTable;
        List<string> DocTypeList;
        
        string PathCurrent;
        string PathNew;
        #endregion

        private void mainForm_Load(object sender, EventArgs e)
        {
            try
            {
                //                if (!(File.Exists(Environment.CurrentDirectory + @"\DMS.mdb")))
                //                {
                //                    ADOX.CatalogClass cat = new ADOX.CatalogClass();
                //                    cat.Create(connString);
                //                    System.Diagnostics.Debug.Write("Database Created Successfully");
                //                    cat = null;
                ////                    conn.Open();
                ////                    string sql = @"CREATE TABLE [OfficialDocument] 
                ////(
                ////[ID] int NOT NULL,
                ////[AddTime] datetime NOT NULL,
                ////[DocTitle] varchar(255) NOT NULL,
                ////[ReleaseDate] datetime,
                ////[Provider] varchar(255),
                ////[Source] varchar(max),
                ////[DocType] varchar(255),
                ////[LocalPath] varchar(max),
                ////[Notes] varchar(max)
                ////)";
                ////                    cmd = new OleDbCommand(sql, conn);
                ////                    cmd.ExecuteNonQuery();
                //                }
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                DtAdapter = new OleDbDataAdapter("Select * From OfficialDocument", conn);
                CoBuilder = new OleDbCommandBuilder(DtAdapter);
                DtTable = new DataTable();
                DtAdapter.Fill(DtTable);
                conn.Close();

                readDocTypeList();
                //saveDocTypeList();

                cConfig.ReadConfig();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region 搜索框
        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == SearchTips) txtSearch.Text = "";
        }
        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
                txtSearch.Text = SearchTips;
            else
            {//执行搜索命令
            }
        }
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                ;//执行搜索命令
        }
        #endregion

        #region 页码
        private void textBoxNow_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                ;//执行“跳转”
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
            //执行“跳转”
        }
        #endregion

        #region 类型列表
        /// <summary>
        /// 储存公文类型列表
        /// </summary>
        private void saveDocTypeList()
        {
            if (DocTypeList == null) return;
            XElement xe = new XElement("DocTypeList");
            for (int i = 0; i < DocTypeList.Count; i++)
            {
                XElement NoteList = new XElement("DocType", DocTypeList[i]);
                xe.Add(NoteList);
            }
            xe.Save(".\\DocTypeList.xml");
            xe.RemoveAll();
        }
        /// <summary>
        /// 读取公文类型列表
        /// </summary>
        private void readDocTypeList()
        {
            if (DocTypeList == null)
                DocTypeList = new List<string>();

            if (File.Exists(".\\DocTypeList.xml"))
            {
                XElement xe = XElement.Load(".\\DocTypeList.xml");
                IEnumerable<XElement> elements = from PInfo in xe.Elements("DocTypeList") select PInfo;
                foreach (XElement element in elements)
                {
                    DocTypeList.Add(element.Element("DocType").Value);
                }
                xe.RemoveAll();
            }

            for (int row = 0; row < DtTable.Rows.Count; row++)
            {
                string str = DtTable.Rows[row]["DocType"].ToString();

                //if (DocTypeList.Count == 0)
                //{
                //    DocTypeList.Add(str);
                //    continue;
                //}

                bool different = true;
                for (int i = 0; i < DocTypeList.Count; i++)
                {
                    if (DocTypeList[i] == str)
                    {
                        different = false;
                        break;
                    }
                }
                if (different)
                    DocTypeList.Add(str);
            }

            listDocType.Items.Add("全部类型");
            foreach (string str in DocTypeList)
            {
                tscbMove.Items.Add(str);
                listDocType.Items.Add(str);
            }
            tscbMove.Items.Add("(新类型)");
            listDocType.SelectedIndex = 0;
        }
        #endregion

        #region 公文显示
        private void listDocType_SelectedIndexChanged(object sender, EventArgs e)
        {
            listDoc.Items.Clear();
            string strSelected = listDocType.SelectedItem.ToString();
            if (strSelected == "全部类型")
            {
                for (int row = 0; row < DtTable.Rows.Count; row++)
                {
                    ListViewItem lvitem = new ListViewItem();

                    lvitem = listDoc.Items.Add(DtTable.Rows[row]["ID"].ToString());
                    lvitem.SubItems.Add(DtTable.Rows[row]["DocTitle"].ToString());
                    lvitem.SubItems.Add(DtTable.Rows[row]["ReleaseDate"].ToString());
                    lvitem.SubItems.Add(DtTable.Rows[row]["Provider"].ToString());
                    lvitem.SubItems.Add(DtTable.Rows[row]["AddTime"].ToString());
                    lvitem.SubItems.Add(DtTable.Rows[row]["DocType"].ToString());
                }
            }
            else
            {
                for (int row = 0; row < DtTable.Rows.Count; row++)
                {
                    if (strSelected == DtTable.Rows[row]["DocType"].ToString())
                    {
                        ListViewItem lvitem = new ListViewItem();
                        lvitem = listDoc.Items.Add(DtTable.Rows[row]["ID"].ToString());
                        lvitem.SubItems.Add(DtTable.Rows[row]["DocTitle"].ToString());
                        lvitem.SubItems.Add(DtTable.Rows[row]["ReleaseDate"].ToString());
                        lvitem.SubItems.Add(DtTable.Rows[row]["Provider"].ToString());
                        lvitem.SubItems.Add(DtTable.Rows[row]["AddTime"].ToString());
                        lvitem.SubItems.Add(DtTable.Rows[row]["DocType"].ToString());
                    }
                }
            }

        }

        private void listDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (listDoc.SelectedItems.Count > 0)
            //{
            //    //for (int row = 0; row < DtTable.Rows.Count; row++)
            //    //{
            //    //    if (listDoc.SelectedItems[0].SubItems[0].Text == DtTable.Rows[row]["ID"].ToString())
            //    //    {
            //    //        txtTitle.Text = DtTable.Rows[row]["DocTitle"].ToString();
            //    //        labRTime.Text = DtTable.Rows[row]["ReleaseDate"].ToString();
            //    //        labP.Text = DtTable.Rows[row]["Provider"].ToString();
            //    //        comboBoxDocType.Text = PathCurrent = DtTable.Rows[row]["DocType"].ToString();
            //    //        labUrl.Text = DtTable.Rows[row]["Source"].ToString();
            //    //        txtNotes.Text = DtTable.Rows[row]["Notes"].ToString();
            //    //        LabATime.Text = DtTable.Rows[row]["AddTime"].ToString();
            //    //    }
            //    //}
            //    tslMove.Enabled = true;
            //    tscbMove.Enabled = true;
            //}
            //else
            //{
            //    tslMove.Enabled = false;
            //    tscbMove.Enabled = false;
            //}
            this.tipListDoc.SetToolTip(listDoc, "备注：123");
        }


        private void listDoc_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (listDoc.CheckedItems.Count>0)
            {
                tsbPrint.Enabled = true;
                tslMove.Enabled = true;
                tscbMove.Enabled = true;
            }
            else
            {
                tslMove.Enabled = false;
                tscbMove.Enabled = false;
                tsbPrint.Enabled = false;
            }
        }

        #endregion

        #region 批量操作


        private void btnAll_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem tempItem in listDoc.Items)//循环遍历listView控件中的每一项
            {
                tempItem.Checked = true;
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

        #region
        //#region combobox选择类型
        //private void comboBoxDocType_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //System.Diagnostics.Debug.WriteLine(comboBoxDocType.SelectedIndex);
        //    //System.Diagnostics.Debug.WriteLine(comboBoxDocType.SelectedItem);
        //    try
        //    {
        //        if (comboBoxDocType.SelectedIndex >= 0)
        //        {
        //            for (int row = 0; row < DtTable.Rows.Count; row++)
        //            {
        //                if (listDoc.SelectedItems[0].SubItems[0].Text == DtTable.Rows[row]["ID"].ToString())
        //                {
        //                    DtTable.Rows[row]["DocType"] = comboBoxDocType.SelectedItem;
        //                    DtAdapter.Update(DtTable);
        //                    //System.Diagnostics.Debug.WriteLine(DtTable.Rows[row]["DocType"]);
        //                }
        //            }

        //            PathCurrent = cConfig.strWorkPath + "\\" + PathCurrent + "\\" + txtTitle.Text;
        //            PathNew = cConfig.strWorkPath + "\\" + comboBoxDocType.SelectedItem + "\\" + txtTitle.Text;
        //            if (PathCurrent != PathNew)
        //                File.Move(PathCurrent, PathNew);
        //        }
        //    }
        //    catch
        //    {
        //        MessageBox.Show("请选择文件");
        //    }
        //}
        //#endregion

        //#region 发布日期分类
        //private void LabATime_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    listDoc.Items.Clear();
        //    int div = LabATime.Text.IndexOf(' ');
        //    for (int i = 0; i < DtTable.Rows.Count; i++)
        //    {

        //        if (LabATime.Text.Substring(0, div) == DtTable.Rows[i]["AddTime"].ToString().Substring(0, div))
        //        {
        //            ListViewItem lvi = new ListViewItem();
        //            lvi = listDoc.Items.Add(DtTable.Rows[i]["ID"].ToString());
        //            lvi.SubItems.Add(DtTable.Rows[i]["DocTitle"].ToString());
        //            lvi.SubItems.Add(DtTable.Rows[i]["ReleaseDate"].ToString());
        //            lvi.SubItems.Add(DtTable.Rows[i]["Provider"].ToString());
        //            lvi.SubItems.Add(DtTable.Rows[i]["AddTime"].ToString());
        //            lvi.SubItems.Add(DtTable.Rows[i]["Doctype"].ToString());
        //        }
        //    }
        //}
        //#endregion

        //#region 收录时间分类
        //private void labRTime_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    listDoc.Items.Clear();
        //    int div = labRTime.Text.IndexOf(' ');
        //    for (int i = 0; i < DtTable.Rows.Count; i++)
        //    {
        //        if (labRTime.Text.Substring(0, div) == DtTable.Rows[i]["ReleaseDate"].ToString().Substring(0, div))
        //        {
        //            ListViewItem lvi = new ListViewItem();
        //            lvi = listDoc.Items.Add(DtTable.Rows[i]["ID"].ToString());
        //            lvi.SubItems.Add(DtTable.Rows[i]["DocTitle"].ToString());
        //            lvi.SubItems.Add(DtTable.Rows[i]["ReleaseDate"].ToString());
        //            lvi.SubItems.Add(DtTable.Rows[i]["Provider"].ToString());
        //            lvi.SubItems.Add(DtTable.Rows[i]["AddTime"].ToString());
        //            lvi.SubItems.Add(DtTable.Rows[i]["Doctype"].ToString());
        //        }
        //    }
        //}
        //#endregion

        //#region 发布单位分类
        //private void labP_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    listDoc.Items.Clear();
        //    for (int i = 0; i < DtTable.Rows.Count; i++)
        //    {
        //        if (labP.Text == DtTable.Rows[i]["Provider"].ToString())
        //        {
        //            ListViewItem lvi = new ListViewItem();
        //            lvi = listDoc.Items.Add(DtTable.Rows[i]["ID"].ToString());
        //            lvi.SubItems.Add(DtTable.Rows[i]["DocTitle"].ToString());
        //            lvi.SubItems.Add(DtTable.Rows[i]["ReleaseDate"].ToString());
        //            lvi.SubItems.Add(DtTable.Rows[i]["Provider"].ToString());
        //            lvi.SubItems.Add(DtTable.Rows[i]["AddTime"].ToString());
        //            lvi.SubItems.Add(DtTable.Rows[i]["Doctype"].ToString());
        //        }
        //    }
        //}
        //#endregion

        //#region 链接浏览器
        //private void labUrl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    try
        //    {
        //        // Change the color of the link text by setting LinkVisited 
        //        // to true.
        //        labUrl.LinkVisited = true;
        //        //Call the Process.Start method to open the default browser 
        //        //with a URL:
        //        System.Diagnostics.Process.Start(labUrl.Text);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Unable to open link that was clicked.\n" + ex.Message);
        //    }
        //}
        //#endregion
        #endregion

        #region 工具栏

        private void tssbAdd_ButtonClick(object sender, EventArgs e)
        {
            frmAddDoc frmAd = new frmAddDoc();
            frmAd.ShowDialog();
        }

        private void tsbScan_Click(object sender, EventArgs e)
        {
            frmScan frmS = new frmScan();
            frmS.ShowDialog();
        }

        private void tsbSetting_Click(object sender, EventArgs e)
        {
            frmSettings frmS = new frmSettings();
            frmS.ShowDialog();
        }

        private void tsbPrint_Click(object sender, EventArgs e)
        {
            //List<string> files = new List<string>();

            string files = "";
            if (listDoc.CheckedItems.Count > 0)
            {
                for (int i = 0; i < listDoc.CheckedItems.Count; i++)
                {
                    //if (listDoc.CheckedItems[i].Checked == true)
                    for (int row = 0; row < DtTable.Rows.Count; row++)
                    {
                        if (listDoc.CheckedItems[i].SubItems[0].Text == DtTable.Rows[row]["ID"].ToString())
                        {
                            files += DtTable.Rows[row]["LocalPath"].ToString() + "|";
                        }
                    }
                }
                PrintFiles.paths = files;
                Thread th = new Thread(new ThreadStart(PrintFiles.printFiles));
            }

        }
        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private void tsmiAddMore_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }









    }
}
