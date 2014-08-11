using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using System.IO;
using System.Threading;
using DMS.Store;
using DMS.View;
using DMS.Type;
using ZCommon;

namespace DMS
{
    public partial class frmMain : Form
    {
        public static frmMain fm;
        public frmMain()
        {
            InitializeComponent();
            fm = this;
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
                CreateFolder();
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
            //frmAddMoreDoc frmAmd = new frmAddMoreDoc();
            //frmAmd.ShowDialog();
            crawler.frmCrawler cr = new crawler.frmCrawler();
            cr.ShowDialog();
        }

        private void tsbScan_Click(object sender, EventArgs e)
        {
            Camera.frmCamera frmScan = new Camera.frmCamera();
            frmScan.ShowDialog();

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
            try
            {
                if (tscbMove.SelectedIndex >= 0)
                {
                    for (int row = 0; row < cAccess.DtTable.Rows.Count; row++)
                    {
                        if (listDoc.SelectedItems[0].SubItems[0].Text == cAccess.DtTable.Rows[row]["ID"].ToString())
                        {
                            string OldPath,NewPath;
                            OldPath = cConfig.strWorkPath + "\\" + cAccess.DtTable.Rows[row]["DocType"].ToString() + "\\" + cAccess.DtTable.Rows[row]["DocTitle"].ToString() + ".doc";
                            NewPath = cConfig.strWorkPath + "\\" + tscbMove.SelectedItem + "\\" + cAccess.DtTable.Rows[row]["DocTitle"].ToString() + ".doc";
                            File.Move(OldPath, NewPath);//移动相应的word文档到所需类型的目录
                            cAccess.DtTable.Rows[row]["DocType"] = tscbMove.SelectedItem;
                            cAccess.DtAdapter.Update(cAccess.DtTable);

                        }
                    }
                    System.Diagnostics.Debug.WriteLine(tscbMove.SelectedItem.ToString());
                }
            }
            catch
            {
                MessageBox.Show("请选择需更改的公文", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            if (listDocType.SelectedIndex >= 0)
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
            frmNewType frmNewtype = new frmNewType();
            frmNewtype.labNewType.Text = "新增类型";
            frmNewtype.Text = "新增类型";
            frmNewtype.ShowDialog();
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
        }


        private void tsmiChangeType_Click(object sender, EventArgs e)
        {
            if (listDocType.SelectedIndex > 0)
            {
                frmNewType frmNewtype = new frmNewType();
                frmNewtype.labNewType.Text = "修改类型";
                frmNewtype.Text = "修改类型";
                frmNewtype.txtNewType.Text =  listDocType.SelectedItem.ToString();
                frmNewtype.ShowDialog();
            }
        }

        /// <summary>
        /// 更改类型
        /// </summary>
        /// <param name="strNewType"></param>
        public void changeType(string strNewType)
        {
            foreach (ListViewItem lvitem in listDoc.Items)//更改数据库的类型名称
            {
                for (int row = 0; row < cAccess.DtTable.Rows.Count; row++)
                {
                    //System.Diagnostics.Debug.WriteLine(lvitem.SubItems[5].Text);
                    //System.Diagnostics.Debug.WriteLine(cAccess.DtTable.Rows[row]["DocType"].ToString());
                    if (lvitem.SubItems[5].Text == cAccess.DtTable.Rows[row]["DocType"].ToString())
                    {
                        cAccess.DtTable.Rows[row]["DocType"] = strNewType;
                        cAccess.DtAdapter.Update(cAccess.DtTable);
                    }
                }
            }

            int TypeIndex = listDocType.SelectedIndex;
            if (Directory.Exists(cConfig.strWorkPath + "\\" + listDocType.Items[TypeIndex]))//更改相应类型目录名称
            {
                Directory.Move(cConfig.strWorkPath + "\\" + listDocType.Items[TypeIndex], cConfig.strWorkPath + "\\" + strNewType);
            }
            listDocType.Items[TypeIndex] = strNewType;

        }

        private void tsmiDeleteType_Click(object sender, EventArgs e)
        {
            if (listDocType.SelectedIndex > 0)
            {
                if (MessageBox.Show("确定删除该类型？", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (Directory.Exists(cConfig.strWorkPath + "\\" + listDocType.SelectedItem.ToString()))
                    {
                        DirectoryInfo di = new DirectoryInfo(cConfig.strWorkPath + "\\" + listDocType.SelectedItem.ToString());
                        foreach (FileInfo fi in di.GetFiles("*.doc"))//将数据库中的类型变为空白
                        {
                            for (int row = 0; row < cAccess.DtTable.Rows.Count; row++)
                            {
                                if (fi.ToString() == cAccess.DtTable.Rows[row]["DocTitle"].ToString() + ".doc")
                                {
                                    cAccess.DtTable.Rows[row]["DocType"] = "";
                                    cAccess.DtAdapter.Update(cAccess.DtTable);
                                }
                            }

                            string path1, path2;//移动删除类型的目录下的所有word文档
                            path1 = cConfig.strWorkPath + "\\" + listDocType.SelectedItem.ToString() + "\\" + fi.ToString();
                            path2 = cConfig.strWorkPath + "\\" + "未分类" + "\\" + fi.ToString();
                            File.Copy(path1, path2);
                            File.Delete(cConfig.strWorkPath + "\\" + listDocType.SelectedItem.ToString() + "\\" + fi.ToString());
                        }
                        Directory.Delete(cConfig.strWorkPath + "\\" + listDocType.SelectedItem.ToString());
                    }
                    listDocType.Items.RemoveAt(listDocType.SelectedIndex);
                }
            }

            for (int row = 0; row < cAccess.DtTable.Rows.Count; row++)//显示所有类型的公文
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

        #region 创建目录
        private void CreateFolder()
        {
            if (!Directory.Exists(cConfig.strWorkPath))
            {
                Directory.CreateDirectory(cConfig.strWorkPath);//新建“DMS”目录
            }

            if (!Directory.Exists(cConfig.strWorkPath + "\\" + "未分类"))
            {
                Directory.CreateDirectory(cConfig.strWorkPath + "\\" + "未分类");// 新建“未分类”目录
            }

            //List<string> DocType = new List<string>();
            //foreach(string str in listDocType.Items)
            //{
            //    System.Diagnostics.Debug.WriteLine(str);
            //    DocType.Add(str);
            //}
            foreach (string str in DocTypeList)
            {
                if (!Directory.Exists(cConfig.strWorkPath + "\\" + str))
                {
                    Directory.CreateDirectory(cConfig.strWorkPath + "\\" + str);//新建各公文类型目录
                }

            }
        }
        #endregion

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
                     
                        System.Diagnostics.Process.Start( cAccess.DtTable.Rows[row]["LocalPath"].ToString());
                    }
                }
                //tslMove.Enabled = true;
                //tscbMove.Enabled = true;
            }
            
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
