namespace DMS.Forms
{
    partial class frmAddDoc
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtRemindMessage = new System.Windows.Forms.TextBox();
            this.btnLocal = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.labelURL = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtProvider = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            this.labName = new System.Windows.Forms.Label();
            this.labDocType = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.comboBoxDocType = new System.Windows.Forms.ComboBox();
            this.btnMin = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lalelhead = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtRemindMessage
            // 
            this.txtRemindMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRemindMessage.Location = new System.Drawing.Point(6, 20);
            this.txtRemindMessage.Multiline = true;
            this.txtRemindMessage.Name = "txtRemindMessage";
            this.txtRemindMessage.Size = new System.Drawing.Size(522, 144);
            this.txtRemindMessage.TabIndex = 0;
            // 
            // btnLocal
            // 
            this.btnLocal.BackColor = System.Drawing.SystemColors.Window;
            this.btnLocal.FlatAppearance.BorderSize = 0;
            this.btnLocal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLocal.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLocal.Location = new System.Drawing.Point(478, 31);
            this.btnLocal.Name = "btnLocal";
            this.btnLocal.Size = new System.Drawing.Size(56, 23);
            this.btnLocal.TabIndex = 56;
            this.btnLocal.Text = "浏览";
            this.btnLocal.UseVisualStyleBackColor = false;
            this.btnLocal.Click += new System.EventHandler(this.btnLocal_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.Window;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(490, 361);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 60;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(82, 108);
            this.txtDate.Multiline = true;
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(149, 19);
            this.txtDate.TabIndex = 11;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.SystemColors.Window;
            this.btnOK.Enabled = false;
            this.btnOK.FlatAppearance.BorderSize = 0;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(404, 361);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 59;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // labelURL
            // 
            this.labelURL.AutoSize = true;
            this.labelURL.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelURL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelURL.Location = new System.Drawing.Point(11, 31);
            this.labelURL.Name = "labelURL";
            this.labelURL.Size = new System.Drawing.Size(65, 12);
            this.labelURL.TabIndex = 6;
            this.labelURL.Text = "公文地址：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtRemindMessage);
            this.groupBox2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox2.Location = new System.Drawing.Point(9, 143);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(534, 170);
            this.groupBox2.TabIndex = 58;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "备注信息";
            // 
            // txtURL
            // 
            this.txtURL.AllowDrop = true;
            this.txtURL.Location = new System.Drawing.Point(82, 31);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(385, 21);
            this.txtURL.TabIndex = 5;
            this.txtURL.TextChanged += new System.EventHandler(this.txtURL_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtProvider);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnLocal);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.txtDate);
            this.groupBox1.Controls.Add(this.labelURL);
            this.groupBox1.Controls.Add(this.txtURL);
            this.groupBox1.Controls.Add(this.labelDate);
            this.groupBox1.Controls.Add(this.labName);
            this.groupBox1.Controls.Add(this.labDocType);
            this.groupBox1.Controls.Add(this.txtTitle);
            this.groupBox1.Controls.Add(this.comboBoxDocType);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox1.Location = new System.Drawing.Point(12, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(553, 321);
            this.groupBox1.TabIndex = 57;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "公文信息";
            // 
            // txtProvider
            // 
            this.txtProvider.Location = new System.Drawing.Point(348, 111);
            this.txtProvider.Multiline = true;
            this.txtProvider.Name = "txtProvider";
            this.txtProvider.Size = new System.Drawing.Size(150, 19);
            this.txtProvider.TabIndex = 59;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(277, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 60;
            this.label1.Text = "发布单位：";
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelDate.Location = new System.Drawing.Point(11, 111);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(65, 12);
            this.labelDate.TabIndex = 50;
            this.labelDate.Text = "发布日期：";
            // 
            // labName
            // 
            this.labName.AutoSize = true;
            this.labName.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labName.Location = new System.Drawing.Point(11, 59);
            this.labName.Name = "labName";
            this.labName.Size = new System.Drawing.Size(65, 12);
            this.labName.TabIndex = 42;
            this.labName.Text = "公文标题：";
            // 
            // labDocType
            // 
            this.labDocType.AutoSize = true;
            this.labDocType.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labDocType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labDocType.Location = new System.Drawing.Point(11, 87);
            this.labDocType.Name = "labDocType";
            this.labDocType.Size = new System.Drawing.Size(65, 12);
            this.labDocType.TabIndex = 44;
            this.labDocType.Text = "公文类型：";
            // 
            // txtTitle
            // 
            this.txtTitle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTitle.Location = new System.Drawing.Point(82, 56);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(385, 21);
            this.txtTitle.TabIndex = 43;
            this.txtTitle.TextChanged += new System.EventHandler(this.txtTitle_TextChanged);
            // 
            // comboBoxDocType
            // 
            this.comboBoxDocType.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBoxDocType.FormattingEnabled = true;
            this.comboBoxDocType.Location = new System.Drawing.Point(82, 84);
            this.comboBoxDocType.Name = "comboBoxDocType";
            this.comboBoxDocType.Size = new System.Drawing.Size(149, 20);
            this.comboBoxDocType.TabIndex = 45;
            // 
            // btnMin
            // 
            this.btnMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMin.BackColor = System.Drawing.Color.Transparent;
            this.btnMin.BackgroundImage = global::DMS.Properties.Resources.min;
            this.btnMin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMin.FlatAppearance.BorderSize = 0;
            this.btnMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMin.ForeColor = System.Drawing.Color.Black;
            this.btnMin.Location = new System.Drawing.Point(494, 5);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(20, 20);
            this.btnMin.TabIndex = 85;
            this.btnMin.UseVisualStyleBackColor = false;
            this.btnMin.Click += new System.EventHandler(this.btnMin_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImage = global::DMS.Properties.Resources.close;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnClose.Location = new System.Drawing.Point(538, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(20, 20);
            this.btnClose.TabIndex = 87;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lalelhead
            // 
            this.lalelhead.AutoSize = true;
            this.lalelhead.Font = new System.Drawing.Font("黑体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lalelhead.Location = new System.Drawing.Point(232, 9);
            this.lalelhead.Name = "lalelhead";
            this.lalelhead.Size = new System.Drawing.Size(89, 19);
            this.lalelhead.TabIndex = 88;
            this.lalelhead.Text = "添加公文";
            // 
            // frmAddDoc
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(578, 392);
            this.Controls.Add(this.lalelhead);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnMin);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddDoc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmAddDoc";
            this.Load += new System.EventHandler(this.frmAddDoc_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRemindMessage;
        private System.Windows.Forms.Button btnLocal;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label labelURL;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.Label labName;
        private System.Windows.Forms.Label labDocType;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.ComboBox comboBoxDocType;
        private System.Windows.Forms.TextBox txtProvider;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMin;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lalelhead;


    }
}