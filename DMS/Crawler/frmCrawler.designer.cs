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
            this.SuspendLayout();
            // 
            // btnContrary
            // 
            this.btnContrary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnContrary.Location = new System.Drawing.Point(91, 420);
            this.btnContrary.Name = "btnContrary";
            this.btnContrary.Size = new System.Drawing.Size(60, 23);
            this.btnContrary.TabIndex = 40;
            this.btnContrary.Text = "反选";
            this.btnContrary.UseVisualStyleBackColor = true;
            this.btnContrary.Click += new System.EventHandler(this.btnContrary_Click);
            // 
            // btnAll
            // 
            this.btnAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAll.Location = new System.Drawing.Point(25, 420);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(60, 23);
            this.btnAll.TabIndex = 39;
            this.btnAll.Text = "全选";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // makeWord
            // 
            this.makeWord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.makeWord.Location = new System.Drawing.Point(679, 420);
            this.makeWord.Name = "makeWord";
            this.makeWord.Size = new System.Drawing.Size(107, 24);
            this.makeWord.TabIndex = 38;
            this.makeWord.Text = "生成Word文档";
            this.makeWord.UseVisualStyleBackColor = true;
            this.makeWord.Click += new System.EventHandler(this.makeWord_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Location = new System.Drawing.Point(694, 33);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(92, 21);
            this.btnUpdate.TabIndex = 30;
            this.btnUpdate.Text = "更新公文列表";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtURL
            // 
            this.txtURL.AllowDrop = true;
            this.txtURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtURL.Location = new System.Drawing.Point(27, 33);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(661, 21);
            this.txtURL.TabIndex = 29;
            this.txtURL.Text = "http://oa.gdmc.edu.cn:8083/ggxx_new/list_bm.jsp?notemplate=&classcode=704&boardid" +
    "=704&pageno=1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 18);
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
            this.listDoc.CheckBoxes = true;
            this.listDoc.FullRowSelect = true;
            this.listDoc.Location = new System.Drawing.Point(27, 60);
            this.listDoc.Name = "listDoc";
            this.listDoc.Size = new System.Drawing.Size(759, 354);
            this.listDoc.TabIndex = 31;
            this.listDoc.UseCompatibleStateImageBehavior = false;
            this.listDoc.View = System.Windows.Forms.View.Details;
            // 
            // labPageAll
            // 
            this.labPageAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labPageAll.BackColor = System.Drawing.Color.Transparent;
            this.labPageAll.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labPageAll.Location = new System.Drawing.Point(416, 423);
            this.labPageAll.Name = "labPageAll";
            this.labPageAll.Size = new System.Drawing.Size(41, 21);
            this.labPageAll.TabIndex = 69;
            this.labPageAll.Text = "1";
            this.labPageAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPageDown
            // 
            this.btnPageDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPageDown.Location = new System.Drawing.Point(489, 423);
            this.btnPageDown.Name = "btnPageDown";
            this.btnPageDown.Size = new System.Drawing.Size(54, 21);
            this.btnPageDown.TabIndex = 68;
            this.btnPageDown.Text = "下一页";
            this.btnPageDown.UseVisualStyleBackColor = true;
            this.btnPageDown.Click += new System.EventHandler(this.btnPageDown_Click);
            // 
            // btnPageUp
            // 
            this.btnPageUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPageUp.Location = new System.Drawing.Point(211, 423);
            this.btnPageUp.Name = "btnPageUp";
            this.btnPageUp.Size = new System.Drawing.Size(54, 21);
            this.btnPageUp.TabIndex = 67;
            this.btnPageUp.Text = "上一页";
            this.btnPageUp.UseVisualStyleBackColor = true;
            this.btnPageUp.Click += new System.EventHandler(this.btnPageUp_Click);
            // 
            // txtPageNow
            // 
            this.txtPageNow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtPageNow.Location = new System.Drawing.Point(324, 423);
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
            this.labPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labPage.BackColor = System.Drawing.Color.Transparent;
            this.labPage.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labPage.Location = new System.Drawing.Point(271, 423);
            this.labPage.Name = "labPage";
            this.labPage.Size = new System.Drawing.Size(212, 21);
            this.labPage.TabIndex = 66;
            this.labPage.Text = "当前是第        页   共        页";
            this.labPage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmCrawler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 454);
            this.Controls.Add(this.labPageAll);
            this.Controls.Add(this.btnPageDown);
            this.Controls.Add(this.btnPageUp);
            this.Controls.Add(this.txtPageNow);
            this.Controls.Add(this.labPage);
            this.Controls.Add(this.btnContrary);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.makeWord);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listDoc);
            this.Name = "frmCrawler";
            this.Text = "批量下载器";
            this.Load += new System.EventHandler(this.frmMain_Load);
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
    }
}

