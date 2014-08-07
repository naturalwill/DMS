using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using System.IO;
using System.Threading;
using DMS.Common;
using DMS.Store;
using DMS.Operate;
using DMS.View;

namespace DMS
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        #region 字段
        string SearchTips = "搜索公文";

        #endregion

        #region 窗体加载

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                cAccess.load();

                readDocTypeList();
                //saveDocTypeList();

                cConfig.ReadConfig();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 工具栏事件

        private void tssbAdd_ButtonClick(object sender, EventArgs e)
        {
            frmAddDoc frmAd = new frmAddDoc();
            frmAd.ShowDialog();
        }

        private void tsmiAdd_Click(object sender, EventArgs e)
        {
            frmAddDoc frmAd = new frmAddDoc();
            frmAd.ShowDialog();
        }

        private void tsmiAddMore_Click(object sender, EventArgs e)
        {
            frmAddMoreDoc frmAmd = new frmAddMoreDoc();
            frmAmd.ShowDialog();
        }

        private void tsbScan_Click(object sender, EventArgs e)
        {
            frmScan frmS = new frmScan();
            frmS.ShowDialog();
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {

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

        private void tscbMove_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tsbPrint_Click(object sender, EventArgs e)
        {
            string files = "";
            if (listDoc.CheckedItems.Count > 0)
            {
                for (int i = 0; i < listDoc.CheckedItems.Count; i++)
                {
                    //if (listDoc.CheckedItems[i].Checked == true)
                    for (int row = 0; row < cAccess.DtTable.Rows.Count; row++)
                    {
                        if (listDoc.CheckedItems[i].SubItems[0].Text == cAccess.DtTable.Rows[row]["ID"].ToString())
                        {
                            files += cAccess.DtTable.Rows[row]["LocalPath"].ToString() + "|";
                        }
                    }
                }
                cPrintFiles.paths = files;
                Thread th = new Thread(new ThreadStart(cPrintFiles.printFiles));
            }
        }

        private void tsbSetting_Click(object sender, EventArgs e)
        {
            frmSettings frmS = new frmSettings();
            frmS.ShowDialog();
        }

        private void tsbAbout_Click(object sender, EventArgs e)
        {
            frmAboutBox frmAb = new frmAboutBox();
            frmAb.ShowDialog();
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region 类型列表

        private void listDocType_SelectedIndexChanged(object sender, EventArgs e)
        {
            listDoc.Items.Clear();
            string strSelected = listDocType.SelectedItem.ToString();
            if (strSelected == "全部类型")
            {
                for (int row = 0; row < cAccess.DtTable.Rows.Count; row++)
                {
                    ListViewItem lvitem = new ListViewItem();

                    lvitem = listDoc.Items.Add(cAccess.DtTable.Rows[row]["ID"].ToString());
                    lvitem.SubItems.Add(cAccess.DtTable.Rows[row]["DocTitle"].ToString());
                    lvitem.SubItems.Add(cAccess.DtTable.Rows[row]["ReleaseDate"].ToString());
                    lvitem.SubItems.Add(cAccess.DtTable.Rows[row]["Provider"].ToString());
                    lvitem.SubItems.Add(cAccess.DtTable.Rows[row]["AddTime"].ToString());
                    lvitem.SubItems.Add(cAccess.DtTable.Rows[row]["DocType"].ToString());
                }
            }
            else
            {
                for (int row = 0; row < cAccess.DtTable.Rows.Count; row++)
                {
                    if (strSelected == cAccess.DtTable.Rows[row]["DocType"].ToString())
                    {
                        ListViewItem lvitem = new ListViewItem();
                        lvitem = listDoc.Items.Add(cAccess.DtTable.Rows[row]["ID"].ToString());
                        lvitem.SubItems.Add(cAccess.DtTable.Rows[row]["DocTitle"].ToString());
                        lvitem.SubItems.Add(cAccess.DtTable.Rows[row]["ReleaseDate"].ToString());
                        lvitem.SubItems.Add(cAccess.DtTable.Rows[row]["Provider"].ToString());
                        lvitem.SubItems.Add(cAccess.DtTable.Rows[row]["AddTime"].ToString());
                        lvitem.SubItems.Add(cAccess.DtTable.Rows[row]["DocType"].ToString());
                    }
                }
            }
        }

        #region 类型列表方法

        List<string> DocTypeList;

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

            for (int row = 0; row < cAccess.DtTable.Rows.Count; row++)
            {
                string str = cAccess.DtTable.Rows[row]["DocType"].ToString();

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

        #region cmsType
        private void tsmiAddType_Click(object sender, EventArgs e)
        {

        }

        private void tsmiChangeType_Click(object sender, EventArgs e)
        {

        }

        private void tsmiDeleteType_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #endregion

        #region 公文列表

        private void listDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            string notes = "";
            if (listDoc.SelectedItems.Count > 0)
            {
                for (int row = 0; row < cAccess.DtTable.Rows.Count; row++)
                {
                    if (listDoc.SelectedItems[0].SubItems[0].Text == cAccess.DtTable.Rows[row]["ID"].ToString())
                    {
                        //txtTitle.Text = cAccess.DtTable.Rows[row]["DocTitle"].ToString();
                        //labRTime.Text = cAccess.DtTable.Rows[row]["ReleaseDate"].ToString();
                        //labP.Text = cAccess.DtTable.Rows[row]["Provider"].ToString();
                        //comboBoxDocType.Text = PathCurrent = cAccess.DtTable.Rows[row]["DocType"].ToString();
                        //labUrl.Text = cAccess.DtTable.Rows[row]["Source"].ToString();
                        //txtNotes.Text = cAccess.DtTable.Rows[row]["Notes"].ToString();
                        //LabATime.Text = cAccess.DtTable.Rows[row]["AddTime"].ToString();
                        notes = cAccess.DtTable.Rows[row]["Notes"].ToString();
                    }
                }
                //tslMove.Enabled = true;
                //tscbMove.Enabled = true;
            }
            else
            {
                //tslMove.Enabled = false;
                //tscbMove.Enabled = false;
            }

            this.tipListDoc.SetToolTip(listDoc, notes);
        }

        private void listDoc_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (listDoc.CheckedItems.Count > 0)
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


        #region cmsDocList
        private void tsmiLook_Click(object sender, EventArgs e)
        {

        }

        private void tsmiLocation_Click(object sender, EventArgs e)
        {

        }

        private void tsmiFindSource_Click(object sender, EventArgs e)
        {

        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {

        }

        private void tsmiInfo_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region 批量选择

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

        #region 分页

        private void btnPageUp_Click(object sender, EventArgs e)
        {

        }

        private void btnPageDown_Click(object sender, EventArgs e)
        {

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

        #region 每页显示数目

        private void comboBoxpaginal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxpaginal.Text == "无限制")
                cConfig.paginalItems = 0;
            else
                cConfig.paginalItems = Convert.ToInt32(comboBoxpaginal.Text);
        }

        private void comboBoxpaginal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                cConfig.paginalItems = Convert.ToInt32(comboBoxpaginal.Text);
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
            cConfig.paginalItems = Convert.ToInt32(comboBoxpaginal.Text);
        }

        #endregion

        #endregion


    }
}
