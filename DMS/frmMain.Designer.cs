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
            this.cmsListDoc = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiLook = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLocation = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFindSource = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.btnContrary = new System.Windows.Forms.Button();
            this.btnAll = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslSyncStatus = new System.Windows.Forms.ToolStripStatusLabel();
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.labto = new System.Windows.Forms.Label();
            this.dateEnd = new System.Windows.Forms.DateTimePicker();
            this.dateStart = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tipListDocType = new System.Windows.Forms.ToolTip(this.components);
            this.scBody = new System.Windows.Forms.SplitContainer();
            this.btnAddType = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDelType = new System.Windows.Forms.Button();
            this.listDocType = new System.Windows.Forms.ListBox();
            this.listDoc = new System.Windows.Forms.ListView();
            this.columnHeaderID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderProvider = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderAddTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDocType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderNotes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tssbAdd = new System.Windows.Forms.ToolStripSplitButton();
            this.tsmiAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddMore = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbScan = new System.Windows.Forms.ToolStripButton();
            this.tssbMoveType = new System.Windows.Forms.ToolStripSplitButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tsbPrint = new System.Windows.Forms.ToolStripButton();
            this.tssbSync = new System.Windows.Forms.ToolStripButton();
            this.tsbSetting = new System.Windows.Forms.ToolStripButton();
            this.tsbHelp = new System.Windows.Forms.ToolStripButton();
            this.tsbAbout = new System.Windows.Forms.ToolStripButton();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnMax = new System.Windows.Forms.Button();
            this.btnMin = new System.Windows.Forms.Button();
            this.pBody = new System.Windows.Forms.Panel();
            this.picHead = new System.Windows.Forms.PictureBox();
            this.cmsListDoc.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.cmsType.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scBody)).BeginInit();
            this.scBody.Panel1.SuspendLayout();
            this.scBody.Panel2.SuspendLayout();
            this.scBody.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.pBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHead)).BeginInit();
            this.SuspendLayout();
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
            // btnContrary
            // 
            this.btnContrary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnContrary.BackColor = System.Drawing.SystemColors.Window;
            this.btnContrary.FlatAppearance.BorderSize = 0;
            this.btnContrary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContrary.Location = new System.Drawing.Point(60, 359);
            this.btnContrary.Name = "btnContrary";
            this.btnContrary.Size = new System.Drawing.Size(51, 21);
            this.btnContrary.TabIndex = 66;
            this.btnContrary.Text = "反选";
            this.btnContrary.UseVisualStyleBackColor = false;
            this.btnContrary.Click += new System.EventHandler(this.btnContrary_Click);
            // 
            // btnAll
            // 
            this.btnAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAll.BackColor = System.Drawing.SystemColors.Window;
            this.btnAll.FlatAppearance.BorderSize = 0;
            this.btnAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAll.Location = new System.Drawing.Point(3, 359);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(51, 21);
            this.btnAll.TabIndex = 65;
            this.btnAll.Text = "全选";
            this.btnAll.UseVisualStyleBackColor = false;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Transparent;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslStatus,
            this.tsslSyncStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 532);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(793, 22);
            this.statusStrip1.TabIndex = 68;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslStatus
            // 
            this.tsslStatus.Name = "tsslStatus";
            this.tsslStatus.Size = new System.Drawing.Size(62, 17);
            this.tsslStatus.Text = "tsslStatus";
            // 
            // tsslSyncStatus
            // 
            this.tsslSyncStatus.ForeColor = System.Drawing.Color.Red;
            this.tsslSyncStatus.Name = "tsslSyncStatus";
            this.tsslSyncStatus.Size = new System.Drawing.Size(69, 17);
            this.tsslSyncStatus.Text = "SyncStatus";
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
            this.labPageAll.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labPageAll.BackColor = System.Drawing.Color.Transparent;
            this.labPageAll.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labPageAll.Location = new System.Drawing.Point(333, 359);
            this.labPageAll.Name = "labPageAll";
            this.labPageAll.Size = new System.Drawing.Size(43, 21);
            this.labPageAll.TabIndex = 64;
            this.labPageAll.Text = "1";
            this.labPageAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPageDown
            // 
            this.btnPageDown.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnPageDown.BackColor = System.Drawing.SystemColors.Window;
            this.btnPageDown.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnPageDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPageDown.Location = new System.Drawing.Point(409, 359);
            this.btnPageDown.Name = "btnPageDown";
            this.btnPageDown.Size = new System.Drawing.Size(54, 21);
            this.btnPageDown.TabIndex = 63;
            this.btnPageDown.Text = "下一页";
            this.btnPageDown.UseVisualStyleBackColor = false;
            this.btnPageDown.Click += new System.EventHandler(this.btnPageDown_Click);
            // 
            // btnPageUp
            // 
            this.btnPageUp.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnPageUp.BackColor = System.Drawing.SystemColors.Window;
            this.btnPageUp.FlatAppearance.BorderSize = 0;
            this.btnPageUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPageUp.Location = new System.Drawing.Point(131, 359);
            this.btnPageUp.Name = "btnPageUp";
            this.btnPageUp.Size = new System.Drawing.Size(54, 21);
            this.btnPageUp.TabIndex = 62;
            this.btnPageUp.Text = "上一页";
            this.btnPageUp.UseVisualStyleBackColor = false;
            this.btnPageUp.Click += new System.EventHandler(this.btnPageUp_Click);
            // 
            // textBoxNow
            // 
            this.textBoxNow.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.textBoxNow.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxNow.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxNow.Location = new System.Drawing.Point(243, 361);
            this.textBoxNow.Name = "textBoxNow";
            this.textBoxNow.Size = new System.Drawing.Size(40, 16);
            this.textBoxNow.TabIndex = 60;
            this.textBoxNow.Text = "1";
            this.textBoxNow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxNow.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNow_KeyPress);
            this.textBoxNow.Leave += new System.EventHandler(this.textBoxNow_Leave);
            // 
            // labPage
            // 
            this.labPage.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labPage.BackColor = System.Drawing.Color.Transparent;
            this.labPage.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labPage.Location = new System.Drawing.Point(191, 359);
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
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(469, 361);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 14);
            this.label1.TabIndex = 69;
            this.label1.Text = "每页显示的数目：";
            // 
            // comboBoxpaginal
            // 
            this.comboBoxpaginal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxpaginal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxpaginal.FormattingEnabled = true;
            this.comboBoxpaginal.Location = new System.Drawing.Point(592, 359);
            this.comboBoxpaginal.Name = "comboBoxpaginal";
            this.comboBoxpaginal.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.comboBoxpaginal.Size = new System.Drawing.Size(60, 20);
            this.comboBoxpaginal.TabIndex = 70;
            this.comboBoxpaginal.Text = "20";
            this.comboBoxpaginal.SelectedIndexChanged += new System.EventHandler(this.comboBoxpaginal_SelectedIndexChanged);
            this.comboBoxpaginal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBoxpaginal_KeyPress);
            this.comboBoxpaginal.Leave += new System.EventHandler(this.comboBoxpaginal_Leave);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.BackColor = System.Drawing.SystemColors.Window;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearch.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSearch.Location = new System.Drawing.Point(8, 1);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(0);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(369, 16);
            this.txtSearch.TabIndex = 50;
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            // 
            // labto
            // 
            this.labto.AutoSize = true;
            this.labto.BackColor = System.Drawing.Color.Transparent;
            this.labto.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labto.Location = new System.Drawing.Point(156, -1);
            this.labto.Name = "labto";
            this.labto.Size = new System.Drawing.Size(26, 26);
            this.labto.TabIndex = 80;
            this.labto.Text = "~";
            // 
            // dateEnd
            // 
            this.dateEnd.Location = new System.Drawing.Point(187, 3);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Size = new System.Drawing.Size(149, 21);
            this.dateEnd.TabIndex = 79;
            this.dateEnd.CloseUp += new System.EventHandler(this.dateEnd_CloseUp);
            // 
            // dateStart
            // 
            this.dateStart.CalendarFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dateStart.Location = new System.Drawing.Point(3, 3);
            this.dateStart.Name = "dateStart";
            this.dateStart.Size = new System.Drawing.Size(147, 21);
            this.dateStart.TabIndex = 78;
            this.dateStart.Value = new System.DateTime(2014, 1, 1, 0, 0, 0, 0);
            this.dateStart.CloseUp += new System.EventHandler(this.dateStart_CloseUp);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dateStart);
            this.panel1.Controls.Add(this.dateEnd);
            this.panel1.Controls.Add(this.labto);
            this.panel1.Location = new System.Drawing.Point(9, 110);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(340, 28);
            this.panel1.TabIndex = 81;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnClear);
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Controls.Add(this.txtSearch);
            this.panel2.Location = new System.Drawing.Point(355, 113);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(430, 21);
            this.panel2.TabIndex = 82;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.BackColor = System.Drawing.Color.Transparent;
            this.btnClear.BackgroundImage = global::DMS.Properties.Resources.clear;
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Location = new System.Drawing.Point(383, -1);
            this.btnClear.Margin = new System.Windows.Forms.Padding(0);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(21, 21);
            this.btnClear.TabIndex = 52;
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Visible = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.BackgroundImage = global::DMS.Properties.Resources.search;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Location = new System.Drawing.Point(408, -1);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(0);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(21, 21);
            this.btnSearch.TabIndex = 51;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // scBody
            // 
            this.scBody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scBody.Location = new System.Drawing.Point(9, 144);
            this.scBody.Name = "scBody";
            // 
            // scBody.Panel1
            // 
            this.scBody.Panel1.BackColor = System.Drawing.Color.Transparent;
            this.scBody.Panel1.Controls.Add(this.btnAddType);
            this.scBody.Panel1.Controls.Add(this.label2);
            this.scBody.Panel1.Controls.Add(this.btnDelType);
            this.scBody.Panel1.Controls.Add(this.listDocType);
            // 
            // scBody.Panel2
            // 
            this.scBody.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.scBody.Panel2.Controls.Add(this.listDoc);
            this.scBody.Panel2.Controls.Add(this.btnPageUp);
            this.scBody.Panel2.Controls.Add(this.label1);
            this.scBody.Panel2.Controls.Add(this.btnContrary);
            this.scBody.Panel2.Controls.Add(this.comboBoxpaginal);
            this.scBody.Panel2.Controls.Add(this.btnAll);
            this.scBody.Panel2.Controls.Add(this.textBoxNow);
            this.scBody.Panel2.Controls.Add(this.labPageAll);
            this.scBody.Panel2.Controls.Add(this.labPage);
            this.scBody.Panel2.Controls.Add(this.btnPageDown);
            this.scBody.Size = new System.Drawing.Size(776, 385);
            this.scBody.SplitterDistance = 115;
            this.scBody.TabIndex = 1;
            // 
            // btnAddType
            // 
            this.btnAddType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddType.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddType.BackgroundImage")));
            this.btnAddType.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddType.FlatAppearance.BorderSize = 0;
            this.btnAddType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddType.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddType.Location = new System.Drawing.Point(6, 356);
            this.btnAddType.Name = "btnAddType";
            this.btnAddType.Size = new System.Drawing.Size(25, 25);
            this.btnAddType.TabIndex = 81;
            this.btnAddType.UseVisualStyleBackColor = true;
            this.btnAddType.Click += new System.EventHandler(this.btnAddType_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 20);
            this.label2.TabIndex = 84;
            this.label2.Text = "公文类型";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDelType
            // 
            this.btnDelType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelType.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDelType.BackgroundImage")));
            this.btnDelType.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDelType.FlatAppearance.BorderSize = 0;
            this.btnDelType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelType.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDelType.Location = new System.Drawing.Point(85, 356);
            this.btnDelType.Name = "btnDelType";
            this.btnDelType.Size = new System.Drawing.Size(25, 25);
            this.btnDelType.TabIndex = 83;
            this.btnDelType.UseVisualStyleBackColor = true;
            this.btnDelType.Click += new System.EventHandler(this.btnDelType_Click);
            // 
            // listDocType
            // 
            this.listDocType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listDocType.BackColor = System.Drawing.SystemColors.Window;
            this.listDocType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listDocType.ContextMenuStrip = this.cmsType;
            this.listDocType.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listDocType.FormattingEnabled = true;
            this.listDocType.ItemHeight = 17;
            this.listDocType.Location = new System.Drawing.Point(3, 26);
            this.listDocType.Name = "listDocType";
            this.listDocType.Size = new System.Drawing.Size(107, 323);
            this.listDocType.TabIndex = 59;
            this.listDocType.SelectedIndexChanged += new System.EventHandler(this.listDocType_SelectedIndexChanged);
            // 
            // listDoc
            // 
            this.listDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listDoc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listDoc.CheckBoxes = true;
            this.listDoc.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderID,
            this.columnHeaderName,
            this.columnHeaderTime,
            this.columnHeaderProvider,
            this.columnHeaderAddTime,
            this.columnHeaderDocType,
            this.columnHeaderNotes});
            this.listDoc.ContextMenuStrip = this.cmsListDoc;
            this.listDoc.FullRowSelect = true;
            this.listDoc.Location = new System.Drawing.Point(3, 3);
            this.listDoc.Name = "listDoc";
            this.listDoc.ShowItemToolTips = true;
            this.listDoc.Size = new System.Drawing.Size(649, 350);
            this.listDoc.TabIndex = 58;
            this.listDoc.UseCompatibleStateImageBehavior = false;
            this.listDoc.View = System.Windows.Forms.View.Details;
            this.listDoc.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listDoc_ItemChecked);
            this.listDoc.SizeChanged += new System.EventHandler(this.listDoc_SizeChanged);
            this.listDoc.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listDoc_MouseClick);
            this.listDoc.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listDoc_MouseDoubleClick);
            // 
            // columnHeaderID
            // 
            this.columnHeaderID.Text = "";
            this.columnHeaderID.Width = 20;
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "公文标题";
            this.columnHeaderName.Width = 143;
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
            // columnHeaderNotes
            // 
            this.columnHeaderNotes.Width = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssbAdd,
            this.tsbScan,
            this.tssbMoveType,
            this.tsbDelete,
            this.tsbPrint,
            this.tssbSync,
            this.tsbSetting,
            this.tsbHelp,
            this.tsbAbout});
            this.toolStrip1.Location = new System.Drawing.Point(10, 68);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(718, 39);
            this.toolStrip1.TabIndex = 67;
            // 
            // tssbAdd
            // 
            this.tssbAdd.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAdd,
            this.tsmiAddMore});
            this.tssbAdd.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tssbAdd.Image = ((System.Drawing.Image)(resources.GetObject("tssbAdd.Image")));
            this.tssbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tssbAdd.Name = "tssbAdd";
            this.tssbAdd.Size = new System.Drawing.Size(85, 36);
            this.tssbAdd.Text = "添加";
            this.tssbAdd.ButtonClick += new System.EventHandler(this.tssbAdd_ButtonClick);
            // 
            // tsmiAdd
            // 
            this.tsmiAdd.Name = "tsmiAdd";
            this.tsmiAdd.Size = new System.Drawing.Size(204, 24);
            this.tsmiAdd.Text = "添加公文";
            this.tsmiAdd.Click += new System.EventHandler(this.tsmiAdd_Click);
            // 
            // tsmiAddMore
            // 
            this.tsmiAddMore.Name = "tsmiAddMore";
            this.tsmiAddMore.Size = new System.Drawing.Size(204, 24);
            this.tsmiAddMore.Text = "批量下载器（定制）";
            this.tsmiAddMore.Click += new System.EventHandler(this.tsmiAddMore_Click);
            // 
            // tsbScan
            // 
            this.tsbScan.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tsbScan.Image = ((System.Drawing.Image)(resources.GetObject("tsbScan.Image")));
            this.tsbScan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbScan.Name = "tsbScan";
            this.tsbScan.Size = new System.Drawing.Size(101, 36);
            this.tsbScan.Text = "扫描文档";
            this.tsbScan.Click += new System.EventHandler(this.tsbScan_Click);
            // 
            // tssbMoveType
            // 
            this.tssbMoveType.Image = ((System.Drawing.Image)(resources.GetObject("tssbMoveType.Image")));
            this.tssbMoveType.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tssbMoveType.Name = "tssbMoveType";
            this.tssbMoveType.Size = new System.Drawing.Size(92, 36);
            this.tssbMoveType.Text = "移动到";
            this.tssbMoveType.ButtonClick += new System.EventHandler(this.tssbMoveType_ButtonClick);
            this.tssbMoveType.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tssbMoveType_DropDownItemClicked);
            // 
            // tsbDelete
            // 
            this.tsbDelete.Enabled = false;
            this.tsbDelete.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tsbDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbDelete.Image")));
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(73, 36);
            this.tsbDelete.Text = "删除";
            this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
            // 
            // tsbPrint
            // 
            this.tsbPrint.BackColor = System.Drawing.Color.Transparent;
            this.tsbPrint.Enabled = false;
            this.tsbPrint.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tsbPrint.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrint.Image")));
            this.tsbPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrint.Name = "tsbPrint";
            this.tsbPrint.Size = new System.Drawing.Size(73, 36);
            this.tsbPrint.Text = "打印";
            this.tsbPrint.Click += new System.EventHandler(this.tsbPrint_Click);
            // 
            // tssbSync
            // 
            this.tssbSync.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tssbSync.Image = ((System.Drawing.Image)(resources.GetObject("tssbSync.Image")));
            this.tssbSync.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tssbSync.Name = "tssbSync";
            this.tssbSync.Size = new System.Drawing.Size(73, 36);
            this.tssbSync.Text = "同步";
            this.tssbSync.Click += new System.EventHandler(this.tssbSync_ButtonClick);
            // 
            // tsbSetting
            // 
            this.tsbSetting.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tsbSetting.Image = ((System.Drawing.Image)(resources.GetObject("tsbSetting.Image")));
            this.tsbSetting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSetting.Name = "tsbSetting";
            this.tsbSetting.Size = new System.Drawing.Size(77, 36);
            this.tsbSetting.Text = "设置 ";
            this.tsbSetting.Click += new System.EventHandler(this.tsbSetting_Click);
            // 
            // tsbHelp
            // 
            this.tsbHelp.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tsbHelp.Image = ((System.Drawing.Image)(resources.GetObject("tsbHelp.Image")));
            this.tsbHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbHelp.Name = "tsbHelp";
            this.tsbHelp.Size = new System.Drawing.Size(73, 36);
            this.tsbHelp.Text = "帮助";
            this.tsbHelp.Click += new System.EventHandler(this.tsbHelp_Click);
            // 
            // tsbAbout
            // 
            this.tsbAbout.Image = ((System.Drawing.Image)(resources.GetObject("tsbAbout.Image")));
            this.tsbAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAbout.Name = "tsbAbout";
            this.tsbAbout.Size = new System.Drawing.Size(68, 36);
            this.tsbAbout.Text = "关于";
            this.tsbAbout.Click += new System.EventHandler(this.tsbAbout_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImage = global::DMS.Properties.Resources.close;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnClose.Location = new System.Drawing.Point(758, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(27, 27);
            this.btnClose.TabIndex = 86;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMax
            // 
            this.btnMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMax.BackColor = System.Drawing.Color.Transparent;
            this.btnMax.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMax.BackgroundImage")));
            this.btnMax.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMax.FlatAppearance.BorderSize = 0;
            this.btnMax.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMax.Location = new System.Drawing.Point(725, 9);
            this.btnMax.Name = "btnMax";
            this.btnMax.Size = new System.Drawing.Size(27, 27);
            this.btnMax.TabIndex = 85;
            this.btnMax.UseVisualStyleBackColor = false;
            this.btnMax.Click += new System.EventHandler(this.btnMax_Click);
            // 
            // btnMin
            // 
            this.btnMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMin.BackColor = System.Drawing.Color.Transparent;
            this.btnMin.BackgroundImage = global::DMS.Properties.Resources.min;
            this.btnMin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMin.FlatAppearance.BorderSize = 0;
            this.btnMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMin.ForeColor = System.Drawing.Color.Black;
            this.btnMin.Location = new System.Drawing.Point(692, 9);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(27, 27);
            this.btnMin.TabIndex = 84;
            this.btnMin.UseVisualStyleBackColor = false;
            this.btnMin.Click += new System.EventHandler(this.btnMin_Click);
            // 
            // pBody
            // 
            this.pBody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pBody.BackColor = System.Drawing.SystemColors.Control;
            this.pBody.Controls.Add(this.picHead);
            this.pBody.Controls.Add(this.toolStrip1);
            this.pBody.Controls.Add(this.scBody);
            this.pBody.Controls.Add(this.panel1);
            this.pBody.Controls.Add(this.statusStrip1);
            this.pBody.Controls.Add(this.btnClose);
            this.pBody.Controls.Add(this.btnMax);
            this.pBody.Controls.Add(this.panel2);
            this.pBody.Controls.Add(this.btnMin);
            this.pBody.Location = new System.Drawing.Point(3, 3);
            this.pBody.Name = "pBody";
            this.pBody.Size = new System.Drawing.Size(793, 554);
            this.pBody.TabIndex = 88;
            this.pBody.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pBody_MouseDown);
            this.pBody.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pBody_MouseMove);
            this.pBody.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pBody_MouseUp);
            // 
            // picHead
            // 
            this.picHead.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picHead.BackgroundImage")));
            this.picHead.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picHead.Image = ((System.Drawing.Image)(resources.GetObject("picHead.Image")));
            this.picHead.Location = new System.Drawing.Point(14, 3);
            this.picHead.Name = "picHead";
            this.picHead.Size = new System.Drawing.Size(298, 62);
            this.picHead.TabIndex = 88;
            this.picHead.TabStop = false;
            this.picHead.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picHead_MouseDown);
            this.picHead.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picHead_MouseMove);
            this.picHead.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picHead_MouseUp);
            // 
            // frmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(800, 562);
            this.Controls.Add(this.pBody);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 560);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "公文管理系统";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.cmsListDoc.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.cmsType.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.scBody.Panel1.ResumeLayout(false);
            this.scBody.Panel2.ResumeLayout(false);
            this.scBody.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scBody)).EndInit();
            this.scBody.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.pBody.ResumeLayout(false);
            this.pBody.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHead)).EndInit();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Button btnContrary;
        private System.Windows.Forms.ToolStripSplitButton tssbAdd;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripButton tsbPrint;
        private System.Windows.Forms.ToolStripButton tsbSetting;
        private System.Windows.Forms.StatusStrip statusStrip1;
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
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripStatusLabel tsslStatus;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label labto;
        private System.Windows.Forms.DateTimePicker dateEnd;
        private System.Windows.Forms.DateTimePicker dateStart;
        private System.Windows.Forms.Button btnAddType;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ToolStripStatusLabel tsslSyncStatus;
        private System.Windows.Forms.ToolStripButton tsbHelp;
        private System.Windows.Forms.SplitContainer scBody;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ToolStripButton tssbSync;
        private System.Windows.Forms.ToolTip tipListDocType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDelType;
        private System.Windows.Forms.Button btnMin;
        private System.Windows.Forms.Button btnMax;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ToolStripButton tsbAbout;
        private System.Windows.Forms.ToolStripSplitButton tssbMoveType;
        private System.Windows.Forms.Panel pBody;
        private System.Windows.Forms.PictureBox picHead;
        private System.Windows.Forms.ColumnHeader columnHeaderNotes;
    }
}

