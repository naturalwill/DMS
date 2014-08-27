namespace Crawler
{
    partial class frmCrawler
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCrawler));
            this.btnContrary = new System.Windows.Forms.Button();
            this.btnAll = new System.Windows.Forms.Button();
            this.makeWord = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listDoc = new System.Windows.Forms.ListView();
            this.labPageAll = new System.Windows.Forms.Label();
            this.btnPageDown = new System.Windows.Forms.Button();
            this.btnPageUp = new System.Windows.Forms.Button();
            this.txtPageNow = new System.Windows.Forms.TextBox();
            this.labPage = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnMax = new System.Windows.Forms.Button();
            this.btnMin = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnContrary
            // 
            this.btnContrary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnContrary.BackColor = System.Drawing.Color.Transparent;
            this.btnContrary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContrary.Location = new System.Drawing.Point(74, 401);
            this.btnContrary.Name = "btnContrary";
            this.btnContrary.Size = new System.Drawing.Size(56, 25);
            this.btnContrary.TabIndex = 40;
            this.btnContrary.Text = "反选";
            this.btnContrary.UseVisualStyleBackColor = false;
            this.btnContrary.Click += new System.EventHandler(this.btnContrary_Click);
            // 
            // btnAll
            // 
            this.btnAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAll.BackColor = System.Drawing.Color.Transparent;
            this.btnAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAll.Location = new System.Drawing.Point(8, 401);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(60, 25);
            this.btnAll.TabIndex = 39;
            this.btnAll.Text = "全选";
            this.btnAll.UseVisualStyleBackColor = false;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // makeWord
            // 
            this.makeWord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.makeWord.BackColor = System.Drawing.Color.Transparent;
            this.makeWord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.makeWord.Location = new System.Drawing.Point(670, 401);
            this.makeWord.Name = "makeWord";
            this.makeWord.Size = new System.Drawing.Size(100, 25);
            this.makeWord.TabIndex = 38;
            this.makeWord.Text = "生成Word文档";
            this.makeWord.UseVisualStyleBackColor = false;
            this.makeWord.Click += new System.EventHandler(this.makeWord_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.BackColor = System.Drawing.Color.Transparent;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Location = new System.Drawing.Point(670, 13);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 27);
            this.btnUpdate.TabIndex = 30;
            this.btnUpdate.Text = "更新公文列表";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtURL
            // 
            this.txtURL.AllowDrop = true;
            this.txtURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtURL.Location = new System.Drawing.Point(47, 17);
            this.txtURL.Name = "txtURL";
            this.txtURL.ReadOnly = true;
            this.txtURL.Size = new System.Drawing.Size(617, 21);
            this.txtURL.TabIndex = 29;
            this.txtURL.Text = "http://oa.gdmc.edu.cn:8083/ggxx_new/list_bm.jsp?notemplate=&classcode=704&boardid" +
    "=704&pageno=1";
            this.txtURL.Enter += new System.EventHandler(this.txtURL_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 28;
            this.label2.Text = "Url：";
            // 
            // listDoc
            // 
            this.listDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listDoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listDoc.CheckBoxes = true;
            this.listDoc.FullRowSelect = true;
            this.listDoc.Location = new System.Drawing.Point(8, 46);
            this.listDoc.Name = "listDoc";
            this.listDoc.Size = new System.Drawing.Size(762, 349);
            this.listDoc.TabIndex = 31;
            this.listDoc.UseCompatibleStateImageBehavior = false;
            this.listDoc.View = System.Windows.Forms.View.Details;
            // 
            // labPageAll
            // 
            this.labPageAll.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labPageAll.BackColor = System.Drawing.Color.Transparent;
            this.labPageAll.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labPageAll.Location = new System.Drawing.Point(397, 403);
            this.labPageAll.Name = "labPageAll";
            this.labPageAll.Size = new System.Drawing.Size(41, 21);
            this.labPageAll.TabIndex = 69;
            this.labPageAll.Text = "1";
            this.labPageAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPageDown
            // 
            this.btnPageDown.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnPageDown.BackColor = System.Drawing.Color.Transparent;
            this.btnPageDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPageDown.Location = new System.Drawing.Point(470, 401);
            this.btnPageDown.Name = "btnPageDown";
            this.btnPageDown.Size = new System.Drawing.Size(52, 25);
            this.btnPageDown.TabIndex = 68;
            this.btnPageDown.Text = "下一页";
            this.btnPageDown.UseVisualStyleBackColor = false;
            this.btnPageDown.Click += new System.EventHandler(this.btnPageDown_Click);
            // 
            // btnPageUp
            // 
            this.btnPageUp.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnPageUp.BackColor = System.Drawing.Color.Transparent;
            this.btnPageUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPageUp.Location = new System.Drawing.Point(192, 401);
            this.btnPageUp.Name = "btnPageUp";
            this.btnPageUp.Size = new System.Drawing.Size(54, 25);
            this.btnPageUp.TabIndex = 67;
            this.btnPageUp.Text = "上一页";
            this.btnPageUp.UseVisualStyleBackColor = false;
            this.btnPageUp.Click += new System.EventHandler(this.btnPageUp_Click);
            // 
            // txtPageNow
            // 
            this.txtPageNow.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtPageNow.Location = new System.Drawing.Point(305, 403);
            this.txtPageNow.Name = "txtPageNow";
            this.txtPageNow.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPageNow.Size = new System.Drawing.Size(40, 21);
            this.txtPageNow.TabIndex = 65;
            this.txtPageNow.Text = "1";
            this.txtPageNow.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPageNow_KeyPress);
            this.txtPageNow.Leave += new System.EventHandler(this.txtPageNow_Leave);
            // 
            // labPage
            // 
            this.labPage.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labPage.BackColor = System.Drawing.Color.Transparent;
            this.labPage.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labPage.Location = new System.Drawing.Point(252, 403);
            this.labPage.Name = "labPage";
            this.labPage.Size = new System.Drawing.Size(212, 21);
            this.labPage.TabIndex = 66;
            this.labPage.Text = "当前是第        页   共        页";
            this.labPage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.labPageAll);
            this.groupBox1.Controls.Add(this.listDoc);
            this.groupBox1.Controls.Add(this.btnPageDown);
            this.groupBox1.Controls.Add(this.txtURL);
            this.groupBox1.Controls.Add(this.btnPageUp);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.txtPageNow);
            this.groupBox1.Controls.Add(this.makeWord);
            this.groupBox1.Controls.Add(this.labPage);
            this.groupBox1.Controls.Add(this.btnAll);
            this.groupBox1.Controls.Add(this.btnContrary);
            this.groupBox1.Location = new System.Drawing.Point(12, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 432);
            this.groupBox1.TabIndex = 70;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(295, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 20);
            this.label1.TabIndex = 71;
            this.label1.Text = "办公网公文批量下载器";
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
            this.btnClose.Location = new System.Drawing.Point(763, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(25, 25);
            this.btnClose.TabIndex = 89;
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
            this.btnMax.Location = new System.Drawing.Point(728, 12);
            this.btnMax.Name = "btnMax";
            this.btnMax.Size = new System.Drawing.Size(25, 25);
            this.btnMax.TabIndex = 88;
            this.btnMax.UseVisualStyleBackColor = false;
            this.btnMax.Visible = false;
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
            this.btnMin.Location = new System.Drawing.Point(697, 12);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(25, 25);
            this.btnMin.TabIndex = 87;
            this.btnMin.UseVisualStyleBackColor = false;
            this.btnMin.Click += new System.EventHandler(this.btnMin_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.Transparent;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 478);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 90;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslStatus
            // 
            this.tsslStatus.Name = "tsslStatus";
            this.tsslStatus.Size = new System.Drawing.Size(62, 17);
            this.tsslStatus.Text = "tsslStatus";
            // 
            // frmCrawler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnMax);
            this.Controls.Add(this.btnMin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 500);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "frmCrawler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnContrary;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Button makeWord;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView listDoc;
        private System.Windows.Forms.Label labPageAll;
        private System.Windows.Forms.Button btnPageDown;
        private System.Windows.Forms.Button btnPageUp;
        private System.Windows.Forms.TextBox txtPageNow;
        private System.Windows.Forms.Label labPage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMax;
        private System.Windows.Forms.Button btnMin;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslStatus;
    }
}

