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
        OleDbDataAdapter DtAdapter;
        OleDbCommandBuilder CoBuilder;
        DataTable DtTable;
        List<string> DocTypeList;
        int pageQuantity=17;//每页显示的数量
        #endregion

        private void mainForm_Load(object sender, EventArgs e)
        {
            conn.Open();
            DtAdapter = new OleDbDataAdapter("Select * From OfficialDocument", conn);
            CoBuilder = new OleDbCommandBuilder(DtAdapter);
            DtTable = new DataTable();
            DtAdapter.Fill(DtTable);
            conn.Close();

            readDocTypeList();
            //saveDocTypeList();
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
                comboBoxDocType.Items.Add(str);
                listDocType.Items.Add(str);
            }
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
                        lvitem.SubItems.Add(DtTable.Rows[row]["DocType"].ToString());
                    }
                }
            }

        }

        private void listDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listDoc.SelectedItems.Count > 0)
                for (int row = 0; row < DtTable.Rows.Count; row++)
                {
                    if (listDoc.SelectedItems[0].SubItems[0].Text == DtTable.Rows[row]["ID"].ToString())
                    {
                        txtTitle.Text = DtTable.Rows[row]["DocTitle"].ToString();
                        labRTime.Text = DtTable.Rows[row]["ReleaseDate"].ToString();
                        labP.Text = DtTable.Rows[row]["Provider"].ToString();
                        comboBoxDocType.Text = DtTable.Rows[row]["DocType"].ToString();
                        labUrl.Text = DtTable.Rows[row]["Source"].ToString();
                        txtNotes.Text = DtTable.Rows[row]["Notes"].ToString();
                        LabATime.Text = DtTable.Rows[row]["AddTime"].ToString();
                    }
                }
        }
        #endregion

        #region 批量操作
        private void btnMore_Click(object sender, EventArgs e)
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
            }
            cDms.printFiles(files);
        }

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

        private void button1_Click(object sender, EventArgs e)
        {
            frmSettings frmS = new frmSettings();
            frmS.ShowDialog();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddDoc frmAd = new frmAddDoc();
            frmAd.ShowDialog();
        }
    }
}
