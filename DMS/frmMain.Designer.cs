namespace DMS
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.tsmiAddMore = new System.Windows.Forms.ToolStripMenuItem();
            this.listDoc = new System.Windows.Forms.ListView();
            this.columnHeaderID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderProvider = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderAddTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDocType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmsListDoc = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiLook = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLocation = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFindSource = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbScan = new System.Windows.Forms.ToolStripButton();
            this.tsmiAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnContrary = new System.Windows.Forms.Button();
            this.tssbAdd = new System.Windows.Forms.ToolStripSplitButton();
            this.btnAll = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.ToolStripTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tslMove = new System.Windows.Forms.ToolStripLabel();
            this.tscbMove = new System.Windows.Forms.ToolStripComboBox();
            this.tsbPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSetting = new System.Windows.Forms.ToolStripButton();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.tsbAbout = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tipListDoc = new System.Windows.Forms.ToolTip(this.components);
            this.listDocType = new System.Windows.Forms.ListBox();
            this.cmsType = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiAddType = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiChangeType = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteType = new System.Windows.Forms.ToolStripMenuItem();
            this.labPageAll = new System.Windows.Forms.Label();
            this.btnPageDown = new System.Windows.Forms.Button();
            this.btnPageUp = new System.Windows.Forms.Button();
            this.textBoxNow = new System.Windows.Forms.TextBox();
            this.labPage = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxpaginal = new System.Windows.Forms.ComboBox();
            this.cmsListDoc.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.cmsType.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsmiAddMore
            // 
            this.tsmiAddMore.Name = "tsmiAddMore";
            this.tsmiAddMore.Size = new System.Drawing.Size(148, 22);
            this.tsmiAddMore.Text = "批量添加公文";
            this.tsmiAddMore.Click += new System.EventHandler(this.tsmiAddMore_Click);
            // 
            // listDoc
            // 
            this.listDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listDoc.BackColor = System.Drawing.SystemColors.Menu;
            this.listDoc.CheckBoxes = true;
            this.listDoc.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderID,
            this.columnHeaderName,
            this.columnHeaderTime,
            this.columnHeaderProvider,
            this.columnHeaderAddTime,
            this.columnHeaderDocType});
            this.listDoc.ContextMenuStrip = this.cmsListDoc;
            this.listDoc.FullRowSelect = true;
            this.listDoc.Location = new System.Drawing.Point(125, 46);
            this.listDoc.Name = "listDoc";
            this.listDoc.Size = new System.Drawing.Size(801, 408);
            this.listDoc.TabIndex = 58;
            this.listDoc.UseCompatibleStateImageBehavior = false;
            this.listDoc.View = System.Windows.Forms.View.Details;
            this.listDoc.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listDoc_ItemChecked);
            this.listDoc.SelectedIndexChanged += new System.EventHandler(this.listDoc_SelectedIndexChanged);
            // 
            // columnHeaderID
            // 
            this.columnHeaderID.Text = "";
            this.columnHeaderID.Width = 20;
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "公文标题";
            this.columnHeaderName.Width = 266;
            // 
            // columnHeaderTime
            // 
            this.columnHeaderTime.Text = "发布时间";
            this.columnHeaderTime.Width = 132;
            // 
            // columnHeaderProvider
            // 
            this.columnHeaderProvider.Text = "发布单位";
            this.columnHeaderProvider.Width = 117;
            // 
            // columnHeaderAddTime
            // 
            this.columnHeaderAddTime.Text = "收录时间";
            this.columnHeaderAddTime.Width = 132;
            // 
            // columnHeaderDocType
            // 
            this.columnHeaderDocType.Text = "公文类型";
            this.columnHeaderDocType.Width = 90;
            // 
            // cmsListDoc
            // 
            this.cmsListDoc.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiLook,
            this.tsmiLocation,
            this.tsmiFindSource,
            this.toolStripSeparator4,
            this.tsmiDelete,
            this.toolStripSeparator3,
            this.tsmiInfo});
            this.cmsListDoc.Name = "cmsListDoc";
            this.cmsListDoc.Size = new System.Drawing.Size(149, 126);
            // 
            // tsmiLook
            // 
            this.tsmiLook.Name = "tsmiLook";
            this.tsmiLook.Size = new System.Drawing.Size(148, 22);
            this.tsmiLook.Text = "查看公文";
            this.tsmiLook.Click += new System.EventHandler(this.tsmiLook_Click);
            // 
            // tsmiLocation
            // 
            this.tsmiLocation.Name = "tsmiLocation";
            this.tsmiLocation.Size = new System.Drawing.Size(148, 22);
            this.tsmiLocation.Text = "打开公文位置";
            this.tsmiLocation.Click += new System.EventHandler(this.tsmiLocation_Click);
            // 
            // tsmiFindSource
            // 
            this.tsmiFindSource.Name = "tsmiFindSource";
            this.tsmiFindSource.Size = new System.Drawing.Size(148, 22);
            this.tsmiFindSource.Text = "查看公文来源";
            this.tsmiFindSource.Click += new System.EventHandler(this.tsmiFindSource_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(145, 6);
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(148, 22);
            this.tsmiDelete.Text = "删除公文";
            this.tsmiDelete.Click += new System.EventHandler(this.tsmiDelete_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(145, 6);
            // 
            // tsmiInfo
            // 
            this.tsmiInfo.Name = "tsmiInfo";
            this.tsmiInfo.Size = new System.Drawing.Size(148, 22);
            this.tsmiInfo.Text = "属性";
            this.tsmiInfo.Click += new System.EventHandler(this.tsmiInfo_Click);
            // 
            // tsbScan
            // 
            this.tsbScan.Image = ((System.Drawing.Image)(resources.GetObject("tsbScan.Image")));
            this.tsbScan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbScan.Name = "tsbScan";
            this.tsbScan.Size = new System.Drawing.Size(92, 38);
            this.tsbScan.Text = "扫描文档";
            this.tsbScan.Click += new System.EventHandler(this.tsbScan_Click);
            // 
            // tsmiAdd
            // 
            this.tsmiAdd.Name = "tsmiAdd";
            this.tsmiAdd.Size = new System.Drawing.Size(148, 22);
            this.tsmiAdd.Text = "添加公文";
            this.tsmiAdd.Click += new System.EventHandler(this.tsmiAdd_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 41);
            // 
            // btnContrary
            // 
            this.btnContrary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnContrary.Location = new System.Drawing.Point(182, 460);
            this.btnContrary.Name = "btnContrary";
            this.btnContrary.Size = new System.Drawing.Size(51, 21);
            this.btnContrary.TabIndex = 66;
            this.btnContrary.Text = "反选";
            this.btnContrary.UseVisualStyleBackColor = true;
            this.btnContrary.Click += new System.EventHandler(this.btnContrary_Click);
            // 
            // tssbAdd
            // 
            this.tssbAdd.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAdd,
            this.tsmiAddMore});
            this.tssbAdd.Image = ((System.Drawing.Image)(resources.GetObject("tssbAdd.Image")));
            this.tssbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tssbAdd.Name = "tssbAdd";
            this.tssbAdd.Size = new System.Drawing.Size(104, 38);
            this.tssbAdd.Text = "添加公文";
            this.tssbAdd.ButtonClick += new System.EventHandler(this.tssbAdd_ButtonClick);
            // 
            // btnAll
            // 
            this.btnAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAll.Location = new System.Drawing.Point(125, 460);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(51, 21);
            this.btnAll.TabIndex = 65;
            this.btnAll.Text = "全选";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Margin = new System.Windows.Forms.Padding(1, 8, 1, 8);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(150, 25);
            this.txtSearch.Text = "搜索公文";
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssbAdd,
            this.tsbScan,
            this.tsbDelete,
            this.toolStripSeparator1,
            this.txtSearch,
            this.toolStripSeparator5,
            this.tslMove,
            this.tscbMove,
            this.tsbPrint,
            this.toolStripSeparator2,
            this.tsbSetting,
            this.tsbClose,
            this.tsbAbout});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(934, 41);
            this.toolStrip1.TabIndex = 67;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbDelete
            // 
            this.tsbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDelete.Enabled = false;
            this.tsbDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbDelete.Image")));
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(36, 38);
            this.tsbDelete.Text = "删除公文";
            this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 41);
            // 
            // tslMove
            // 
            this.tslMove.Enabled = false;
            this.tslMove.Name = "tslMove";
            this.tslMove.Size = new System.Drawing.Size(56, 38);
            this.tslMove.Text = "移动至：";
            // 
            // tscbMove
            // 
            this.tscbMove.Enabled = false;
            this.tscbMove.Margin = new System.Windows.Forms.Padding(1, 8, 1, 8);
            this.tscbMove.Name = "tscbMove";
            this.tscbMove.Size = new System.Drawing.Size(121, 25);
            this.tscbMove.SelectedIndexChanged += new System.EventHandler(this.tscbMove_SelectedIndexChanged);
            //this.tscbMove.Click += new System.EventHandler(this.tscbMove_Click);
            // 
            // tsbPrint
            // 
            this.tsbPrint.BackColor = System.Drawing.SystemColors.Control;
            this.tsbPrint.Enabled = false;
            this.tsbPrint.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrint.Image")));
            this.tsbPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrint.Name = "tsbPrint";
            this.tsbPrint.Size = new System.Drawing.Size(116, 38);
            this.tsbPrint.Text = "打印选中公文";
            this.tsbPrint.Click += new System.EventHandler(this.tsbPrint_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 41);
            // 
            // tsbSetting
            // 
            this.tsbSetting.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSetting.Image = ((System.Drawing.Image)(resources.GetObject("tsbSetting.Image")));
            this.tsbSetting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSetting.Name = "tsbSetting";
            this.tsbSetting.Size = new System.Drawing.Size(36, 38);
            this.tsbSetting.Text = "设置";
            this.tsbSetting.Click += new System.EventHandler(this.tsbSetting_Click);
            // 
            // tsbClose
            // 
            this.tsbClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbClose.Image = ((System.Drawing.Image)(resources.GetObject("tsbClose.Image")));
            this.tsbClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(36, 38);
            this.tsbClose.Text = "退出";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // tsbAbout
            // 
            this.tsbAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAbout.Image = ((System.Drawing.Image)(resources.GetObject("tsbAbout.Image")));
            this.tsbAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAbout.Name = "tsbAbout";
            this.tsbAbout.Size = new System.Drawing.Size(36, 38);
            this.tsbAbout.Text = "关于";
            this.tsbAbout.Click += new System.EventHandler(this.tsbAbout_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 486);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(934, 22);
            this.statusStrip1.TabIndex = 68;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tipListDoc
            // 
            this.tipListDoc.ToolTipTitle = "备注：";
            // 
            // listDocType
            // 
            this.listDocType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listDocType.BackColor = System.Drawing.SystemColors.Menu;
            this.listDocType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listDocType.ContextMenuStrip = this.cmsType;
            this.listDocType.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listDocType.FormattingEnabled = true;
            this.listDocType.ItemHeight = 17;
            this.listDocType.Location = new System.Drawing.Point(12, 46);
            this.listDocType.Name = "listDocType";
            this.listDocType.Size = new System.Drawing.Size(107, 410);
            this.listDocType.TabIndex = 59;
            this.listDocType.SelectedIndexChanged += new System.EventHandler(this.listDocType_SelectedIndexChanged);
            // 
            // cmsType
            // 
            this.cmsType.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAddType,
            this.tsmiChangeType,
            this.tsmiDeleteType});
            this.cmsType.Name = "cmsType";
            this.cmsType.Size = new System.Drawing.Size(125, 70);
            // 
            // tsmiAddType
            // 
            this.tsmiAddType.Name = "tsmiAddType";
            this.tsmiAddType.Size = new System.Drawing.Size(124, 22);
            this.tsmiAddType.Text = "增加类型";
            this.tsmiAddType.Click += new System.EventHandler(this.tsmiAddType_Click);
            // 
            // tsmiChangeType
            // 
            this.tsmiChangeType.Name = "tsmiChangeType";
            this.tsmiChangeType.Size = new System.Drawing.Size(124, 22);
            this.tsmiChangeType.Text = "修改类型";
            this.tsmiChangeType.Click += new System.EventHandler(this.tsmiChangeType_Click);
            // 
            // tsmiDeleteType
            // 
            this.tsmiDeleteType.Name = "tsmiDeleteType";
            this.tsmiDeleteType.Size = new System.Drawing.Size(124, 22);
            this.tsmiDeleteType.Text = "删除类型";
            this.tsmiDeleteType.Click += new System.EventHandler(this.tsmiDeleteType_Click);
            // 
            // labPageAll
            // 
            this.labPageAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labPageAll.BackColor = System.Drawing.Color.Transparent;
            this.labPageAll.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labPageAll.Location = new System.Drawing.Point(547, 460);
            this.labPageAll.Name = "labPageAll";
            this.labPageAll.Size = new System.Drawing.Size(41, 21);
            this.labPageAll.TabIndex = 64;
            this.labPageAll.Text = "1";
            this.labPageAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPageDown
            // 
            this.btnPageDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPageDown.Location = new System.Drawing.Point(620, 460);
            this.btnPageDown.Name = "btnPageDown";
            this.btnPageDown.Size = new System.Drawing.Size(54, 21);
            this.btnPageDown.TabIndex = 63;
            this.btnPageDown.Text = "下一页";
            this.btnPageDown.UseVisualStyleBackColor = true;
            this.btnPageDown.Click += new System.EventHandler(this.btnPageDown_Click);
            // 
            // btnPageUp
            // 
            this.btnPageUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPageUp.Location = new System.Drawing.Point(342, 460);
            this.btnPageUp.Name = "btnPageUp";
            this.btnPageUp.Size = new System.Drawing.Size(54, 21);
            this.btnPageUp.TabIndex = 62;
            this.btnPageUp.Text = "上一页";
            this.btnPageUp.UseVisualStyleBackColor = true;
            this.btnPageUp.Click += new System.EventHandler(this.btnPageUp_Click);
            // 
            // textBoxNow
            // 
            this.textBoxNow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNow.Location = new System.Drawing.Point(455, 460);
            this.textBoxNow.Name = "textBoxNow";
            this.textBoxNow.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBoxNow.Size = new System.Drawing.Size(40, 21);
            this.textBoxNow.TabIndex = 60;
            this.textBoxNow.Text = "1";
            this.textBoxNow.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNow_KeyPress);
            this.textBoxNow.Leave += new System.EventHandler(this.textBoxNow_Leave);
            // 
            // labPage
            // 
            this.labPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labPage.BackColor = System.Drawing.Color.Transparent;
            this.labPage.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labPage.Location = new System.Drawing.Point(402, 460);
            this.labPage.Name = "labPage";
            this.labPage.Size = new System.Drawing.Size(212, 21);
            this.labPage.TabIndex = 61;
            this.labPage.Text = "当前是第        页   共        页";
            this.labPage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(711, 464);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 69;
            this.label1.Text = "每页显示的数目：";
            // 
            // comboBoxpaginal
            // 
            this.comboBoxpaginal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxpaginal.FormattingEnabled = true;
            this.comboBoxpaginal.Items.AddRange(new object[] {
            "10",
            "15",
            "20",
            "30",
            "50",
            "无限制"});
            this.comboBoxpaginal.Location = new System.Drawing.Point(818, 460);
            this.comboBoxpaginal.Name = "comboBoxpaginal";
            this.comboBoxpaginal.Size = new System.Drawing.Size(60, 20);
            this.comboBoxpaginal.TabIndex = 70;
            this.comboBoxpaginal.Text = "20";
            this.comboBoxpaginal.SelectedIndexChanged += new System.EventHandler(this.comboBoxpaginal_SelectedIndexChanged);
            this.comboBoxpaginal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBoxpaginal_KeyPress);
            this.comboBoxpaginal.Leave += new System.EventHandler(this.comboBoxpaginal_Leave);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 508);
            this.Controls.Add(this.comboBoxpaginal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listDoc);
            this.Controls.Add(this.btnContrary);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.listDocType);
            this.Controls.Add(this.labPageAll);
            this.Controls.Add(this.btnPageDown);
            this.Controls.Add(this.btnPageUp);
            this.Controls.Add(this.textBoxNow);
            this.Controls.Add(this.labPage);
            this.Name = "frmMain";
            this.Text = "公文管理系统";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.cmsListDoc.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.cmsType.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem tsmiAddMore;
        private System.Windows.Forms.ListView listDoc;
        private System.Windows.Forms.ColumnHeader columnHeaderID;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader columnHeaderTime;
        private System.Windows.Forms.ColumnHeader columnHeaderProvider;
        private System.Windows.Forms.ColumnHeader columnHeaderAddTime;
        private System.Windows.Forms.ColumnHeader columnHeaderDocType;
        private System.Windows.Forms.ContextMenuStrip cmsListDoc;
        private System.Windows.Forms.ToolStripMenuItem tsmiLook;
        private System.Windows.Forms.ToolStripMenuItem tsmiLocation;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem tsmiInfo;
        private System.Windows.Forms.ToolStripButton tsbScan;
        private System.Windows.Forms.ToolStripMenuItem tsmiAdd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Button btnContrary;
        private System.Windows.Forms.ToolStripSplitButton tssbAdd;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.ToolStripTextBox txtSearch;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripLabel tslMove;
        private System.Windows.Forms.ToolStripComboBox tscbMove;
        private System.Windows.Forms.ToolStripButton tsbPrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbSetting;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.ToolStripButton tsbAbout;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolTip tipListDoc;
        private System.Windows.Forms.ListBox listDocType;
        private System.Windows.Forms.Label labPageAll;
        private System.Windows.Forms.Button btnPageDown;
        private System.Windows.Forms.Button btnPageUp;
        private System.Windows.Forms.TextBox textBoxNow;
        private System.Windows.Forms.Label labPage;
        private System.Windows.Forms.ToolStripMenuItem tsmiFindSource;
        private System.Windows.Forms.ContextMenuStrip cmsType;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddType;
        private System.Windows.Forms.ToolStripMenuItem tsmiChangeType;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxpaginal;
    }
}

