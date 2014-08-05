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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LabATime = new System.Windows.Forms.LinkLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.comboBoxDocType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.labP = new System.Windows.Forms.LinkLabel();
            this.labRTime = new System.Windows.Forms.LinkLabel();
            this.labUrl = new System.Windows.Forms.LinkLabel();
            this.labS = new System.Windows.Forms.Label();
            this.labDocType = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.labName = new System.Windows.Forms.Label();
            this.labProvider = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listDocType = new System.Windows.Forms.ListBox();
            this.labPageAll = new System.Windows.Forms.Label();
            this.btnScan = new System.Windows.Forms.Button();
            this.btnMore = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnPageDown = new System.Windows.Forms.Button();
            this.btnPageUp = new System.Windows.Forms.Button();
            this.textBoxNow = new System.Windows.Forms.TextBox();
            this.labPage = new System.Windows.Forms.Label();
            this.listDoc = new System.Windows.Forms.ListView();
            this.columnHeaderID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderProvider = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDocType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderAddTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnContrary = new System.Windows.Forms.Button();
            this.btnAll = new System.Windows.Forms.Button();
            this.btnMenu = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.LabATime);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.comboBoxDocType);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.labP);
            this.groupBox1.Controls.Add(this.labRTime);
            this.groupBox1.Controls.Add(this.labUrl);
            this.groupBox1.Controls.Add(this.labS);
            this.groupBox1.Controls.Add(this.labDocType);
            this.groupBox1.Controls.Add(this.txtTitle);
            this.groupBox1.Controls.Add(this.labName);
            this.groupBox1.Controls.Add(this.labProvider);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 401);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(910, 145);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "公文详细信息";
            // 
            // LabATime
            // 
            this.LabATime.AutoSize = true;
            this.LabATime.Location = new System.Drawing.Point(289, 50);
            this.LabATime.Name = "LabATime";
            this.LabATime.Size = new System.Drawing.Size(0, 12);
            this.LabATime.TabIndex = 43;
            this.LabATime.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LabATime_LinkClicked);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtNotes);
            this.groupBox2.Location = new System.Drawing.Point(424, 23);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(480, 113);
            this.groupBox2.TabIndex = 41;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "备注";
            // 
            // txtNotes
            // 
            this.txtNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNotes.Location = new System.Drawing.Point(15, 20);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(459, 87);
            this.txtNotes.TabIndex = 11;
            // 
            // comboBoxDocType
            // 
            this.comboBoxDocType.FormattingEnabled = true;
            this.comboBoxDocType.Location = new System.Drawing.Point(77, 47);
            this.comboBoxDocType.Name = "comboBoxDocType";
            this.comboBoxDocType.Size = new System.Drawing.Size(135, 20);
            this.comboBoxDocType.TabIndex = 9;
            this.comboBoxDocType.SelectedIndexChanged += new System.EventHandler(this.comboBoxDocType_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(218, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 42;
            this.label4.Text = "收录时间：";
            // 
            // labP
            // 
            this.labP.AutoSize = true;
            this.labP.Location = new System.Drawing.Point(77, 76);
            this.labP.Name = "labP";
            this.labP.Size = new System.Drawing.Size(0, 12);
            this.labP.TabIndex = 13;
            this.labP.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.labP_LinkClicked);
            // 
            // labRTime
            // 
            this.labRTime.AutoSize = true;
            this.labRTime.Location = new System.Drawing.Point(289, 76);
            this.labRTime.Name = "labRTime";
            this.labRTime.Size = new System.Drawing.Size(0, 12);
            this.labRTime.TabIndex = 12;
            this.labRTime.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.labRTime_LinkClicked);
            // 
            // labUrl
            // 
            this.labUrl.Location = new System.Drawing.Point(77, 99);
            this.labUrl.Name = "labUrl";
            this.labUrl.Size = new System.Drawing.Size(331, 37);
            this.labUrl.TabIndex = 7;
            this.labUrl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.labUrl_LinkClicked);
            // 
            // labS
            // 
            this.labS.AutoSize = true;
            this.labS.Location = new System.Drawing.Point(6, 99);
            this.labS.Name = "labS";
            this.labS.Size = new System.Drawing.Size(65, 12);
            this.labS.TabIndex = 6;
            this.labS.Text = "公文来源：";
            // 
            // labDocType
            // 
            this.labDocType.AutoSize = true;
            this.labDocType.Location = new System.Drawing.Point(6, 50);
            this.labDocType.Name = "labDocType";
            this.labDocType.Size = new System.Drawing.Size(65, 12);
            this.labDocType.TabIndex = 5;
            this.labDocType.Text = "公文类型：";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(77, 20);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(331, 21);
            this.txtTitle.TabIndex = 1;
            // 
            // labName
            // 
            this.labName.AutoSize = true;
            this.labName.Location = new System.Drawing.Point(6, 23);
            this.labName.Name = "labName";
            this.labName.Size = new System.Drawing.Size(65, 12);
            this.labName.TabIndex = 0;
            this.labName.Text = "公文标题：";
            // 
            // labProvider
            // 
            this.labProvider.AutoSize = true;
            this.labProvider.Location = new System.Drawing.Point(6, 76);
            this.labProvider.Name = "labProvider";
            this.labProvider.Size = new System.Drawing.Size(65, 12);
            this.labProvider.TabIndex = 4;
            this.labProvider.Text = "发布单位：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(218, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "发布日期：";
            // 
            // listDocType
            // 
            this.listDocType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listDocType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listDocType.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listDocType.FormattingEnabled = true;
            this.listDocType.ItemHeight = 17;
            this.listDocType.Location = new System.Drawing.Point(12, 79);
            this.listDocType.Name = "listDocType";
            this.listDocType.Size = new System.Drawing.Size(107, 308);
            this.listDocType.TabIndex = 43;
            this.listDocType.SelectedIndexChanged += new System.EventHandler(this.listDocType_SelectedIndexChanged);
            // 
            // labPageAll
            // 
            this.labPageAll.BackColor = System.Drawing.Color.Transparent;
            this.labPageAll.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labPageAll.Location = new System.Drawing.Point(543, 51);
            this.labPageAll.Name = "labPageAll";
            this.labPageAll.Size = new System.Drawing.Size(41, 21);
            this.labPageAll.TabIndex = 51;
            this.labPageAll.Text = "1";
            this.labPageAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(69, 24);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(50, 48);
            this.btnScan.TabIndex = 50;
            this.btnScan.Text = "扫描文档";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // btnMore
            // 
            this.btnMore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMore.Location = new System.Drawing.Point(819, 51);
            this.btnMore.Name = "btnMore";
            this.btnMore.Size = new System.Drawing.Size(107, 21);
            this.btnMore.TabIndex = 49;
            this.btnMore.Text = "打印选择的公文";
            this.btnMore.UseVisualStyleBackColor = true;
            this.btnMore.Click += new System.EventHandler(this.btnMore_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(309, 24);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(301, 21);
            this.txtSearch.TabIndex = 48;
            this.txtSearch.Text = "请输入关键字查找公文";
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            // 
            // btnPageDown
            // 
            this.btnPageDown.Location = new System.Drawing.Point(616, 51);
            this.btnPageDown.Name = "btnPageDown";
            this.btnPageDown.Size = new System.Drawing.Size(54, 21);
            this.btnPageDown.TabIndex = 47;
            this.btnPageDown.Text = "下一页";
            this.btnPageDown.UseVisualStyleBackColor = true;
            // 
            // btnPageUp
            // 
            this.btnPageUp.Location = new System.Drawing.Point(338, 51);
            this.btnPageUp.Name = "btnPageUp";
            this.btnPageUp.Size = new System.Drawing.Size(54, 21);
            this.btnPageUp.TabIndex = 46;
            this.btnPageUp.Text = "上一页";
            this.btnPageUp.UseVisualStyleBackColor = true;
            // 
            // textBoxNow
            // 
            this.textBoxNow.Location = new System.Drawing.Point(451, 51);
            this.textBoxNow.Name = "textBoxNow";
            this.textBoxNow.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBoxNow.Size = new System.Drawing.Size(40, 21);
            this.textBoxNow.TabIndex = 44;
            this.textBoxNow.Text = "1";
            this.textBoxNow.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNow_KeyPress);
            this.textBoxNow.Leave += new System.EventHandler(this.textBoxNow_Leave);
            // 
            // labPage
            // 
            this.labPage.BackColor = System.Drawing.Color.Transparent;
            this.labPage.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labPage.Location = new System.Drawing.Point(398, 51);
            this.labPage.Name = "labPage";
            this.labPage.Size = new System.Drawing.Size(212, 21);
            this.labPage.TabIndex = 45;
            this.labPage.Text = "当前是第        页   共        页";
            this.labPage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // listDoc
            // 
            this.listDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listDoc.CheckBoxes = true;
            this.listDoc.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderID,
            this.columnHeaderName,
            this.columnHeaderTime,
            this.columnHeaderProvider,
            this.columnHeaderAddTime,
            this.columnHeaderDocType});
            this.listDoc.FullRowSelect = true;
            this.listDoc.Location = new System.Drawing.Point(125, 79);
            this.listDoc.Name = "listDoc";
            this.listDoc.Size = new System.Drawing.Size(801, 313);
            this.listDoc.TabIndex = 42;
            this.listDoc.UseCompatibleStateImageBehavior = false;
            this.listDoc.View = System.Windows.Forms.View.Details;
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
            this.columnHeaderName.Width = 285;
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
            // columnHeaderDocType
            // 
            this.columnHeaderDocType.Text = "公文类型";
            this.columnHeaderDocType.Width = 90;
            // 
            // columnHeaderAddTime
            // 
            this.columnHeaderAddTime.Text = "收录时间";
            this.columnHeaderAddTime.Width = 132;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 24);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(51, 48);
            this.btnAdd.TabIndex = 52;
            this.btnAdd.Text = "添加公文";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnContrary
            // 
            this.btnContrary.Location = new System.Drawing.Point(232, 51);
            this.btnContrary.Name = "btnContrary";
            this.btnContrary.Size = new System.Drawing.Size(51, 21);
            this.btnContrary.TabIndex = 54;
            this.btnContrary.Text = "反选";
            this.btnContrary.UseVisualStyleBackColor = true;
            this.btnContrary.Click += new System.EventHandler(this.btnContrary_Click);
            // 
            // btnAll
            // 
            this.btnAll.Location = new System.Drawing.Point(175, 51);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(51, 21);
            this.btnAll.TabIndex = 53;
            this.btnAll.Text = "全选";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnMenu
            // 
            this.btnMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMenu.Location = new System.Drawing.Point(827, 12);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(99, 23);
            this.btnMenu.TabIndex = 55;
            this.btnMenu.Text = "菜单";
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 558);
            this.Controls.Add(this.btnMenu);
            this.Controls.Add(this.btnContrary);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.listDocType);
            this.Controls.Add(this.labPageAll);
            this.Controls.Add(this.btnScan);
            this.Controls.Add(this.btnMore);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnPageDown);
            this.Controls.Add(this.btnPageUp);
            this.Controls.Add(this.textBoxNow);
            this.Controls.Add(this.labPage);
            this.Controls.Add(this.listDoc);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmMain";
            this.Text = "公文管理系统";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel LabATime;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.ComboBox comboBoxDocType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel labP;
        private System.Windows.Forms.LinkLabel labRTime;
        private System.Windows.Forms.LinkLabel labUrl;
        private System.Windows.Forms.Label labS;
        private System.Windows.Forms.Label labDocType;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label labName;
        private System.Windows.Forms.Label labProvider;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listDocType;
        private System.Windows.Forms.Label labPageAll;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.Button btnMore;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnPageDown;
        private System.Windows.Forms.Button btnPageUp;
        private System.Windows.Forms.TextBox textBoxNow;
        private System.Windows.Forms.Label labPage;
        private System.Windows.Forms.ListView listDoc;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader columnHeaderTime;
        private System.Windows.Forms.ColumnHeader columnHeaderProvider;
        private System.Windows.Forms.ColumnHeader columnHeaderAddTime;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnContrary;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.ColumnHeader columnHeaderID;
        private System.Windows.Forms.ColumnHeader columnHeaderDocType;
    }
}

