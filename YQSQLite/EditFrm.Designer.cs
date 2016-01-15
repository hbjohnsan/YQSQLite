namespace YQSQLite
{
    partial class EditFrm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditFrm));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.新建自采ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.htmlEditor1 = new Sonic.HtmlEditor.HtmlEditor();
            this.gboxSendTo = new System.Windows.Forms.GroupBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.ckbZX = new System.Windows.Forms.CheckBox();
            this.ckbSheng = new System.Windows.Forms.CheckBox();
            this.ckbXiang = new System.Windows.Forms.CheckBox();
            this.ckbShi = new System.Windows.Forms.CheckBox();
            this.gboxLB = new System.Windows.Forms.GroupBox();
            this.rabYQ = new System.Windows.Forms.RadioButton();
            this.rabXC = new System.Windows.Forms.RadioButton();
            this.rabWM = new System.Windows.Forms.RadioButton();
            this.gboxLY = new System.Windows.Forms.GroupBox();
            this.rabSourc = new System.Windows.Forms.RadioButton();
            this.rabZiCai = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.labLink = new System.Windows.Forms.Label();
            this.labUpTime = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gboxSendTo.SuspendLayout();
            this.gboxLB.SuspendLayout();
            this.gboxLY.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建自采ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 26);
            // 
            // 新建自采ToolStripMenuItem
            // 
            this.新建自采ToolStripMenuItem.Name = "新建自采ToolStripMenuItem";
            this.新建自采ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.新建自采ToolStripMenuItem.Text = "新建自采";
            this.新建自采ToolStripMenuItem.Click += new System.EventHandler(this.新建自采ToolStripMenuItem_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.htmlEditor1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 219);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(947, 349);
            this.groupBox2.TabIndex = 52;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "内容";
            // 
            // htmlEditor1
            // 
            this.htmlEditor1.BodyInnerHTML = null;
            this.htmlEditor1.BodyInnerText = null;
            this.htmlEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.htmlEditor1.EnterToBR = false;
            this.htmlEditor1.HTML = resources.GetString("htmlEditor1.HTML");
            this.htmlEditor1.Location = new System.Drawing.Point(3, 17);
            this.htmlEditor1.Name = "htmlEditor1";
            this.htmlEditor1.ShowToolBar = true;
            this.htmlEditor1.Size = new System.Drawing.Size(941, 329);
            this.htmlEditor1.TabIndex = 0;
            // 
            // gboxSendTo
            // 
            this.gboxSendTo.Controls.Add(this.btnAdd);
            this.gboxSendTo.Controls.Add(this.btnRemove);
            this.gboxSendTo.Controls.Add(this.ckbZX);
            this.gboxSendTo.Controls.Add(this.ckbSheng);
            this.gboxSendTo.Controls.Add(this.ckbXiang);
            this.gboxSendTo.Controls.Add(this.ckbShi);
            this.gboxSendTo.Dock = System.Windows.Forms.DockStyle.Top;
            this.gboxSendTo.Location = new System.Drawing.Point(0, 169);
            this.gboxSendTo.Name = "gboxSendTo";
            this.gboxSendTo.Size = new System.Drawing.Size(947, 50);
            this.gboxSendTo.TabIndex = 55;
            this.gboxSendTo.TabStop = false;
            this.gboxSendTo.Text = "发送到";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(835, 20);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(55, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "待报";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.Location = new System.Drawing.Point(755, 20);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(55, 23);
            this.btnRemove.TabIndex = 0;
            this.btnRemove.Text = "移除";
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // ckbZX
            // 
            this.ckbZX.AutoSize = true;
            this.ckbZX.Location = new System.Drawing.Point(12, 24);
            this.ckbZX.Name = "ckbZX";
            this.ckbZX.Size = new System.Drawing.Size(48, 16);
            this.ckbZX.TabIndex = 46;
            this.ckbZX.Text = "中宣";
            this.ckbZX.UseVisualStyleBackColor = true;
            // 
            // ckbSheng
            // 
            this.ckbSheng.AutoSize = true;
            this.ckbSheng.Location = new System.Drawing.Point(66, 24);
            this.ckbSheng.Name = "ckbSheng";
            this.ckbSheng.Size = new System.Drawing.Size(36, 16);
            this.ckbSheng.TabIndex = 42;
            this.ckbSheng.Text = "省";
            this.ckbSheng.UseVisualStyleBackColor = true;
            // 
            // ckbXiang
            // 
            this.ckbXiang.AutoSize = true;
            this.ckbXiang.Location = new System.Drawing.Point(150, 24);
            this.ckbXiang.Name = "ckbXiang";
            this.ckbXiang.Size = new System.Drawing.Size(36, 16);
            this.ckbXiang.TabIndex = 45;
            this.ckbXiang.Text = "县";
            this.ckbXiang.UseVisualStyleBackColor = true;
            // 
            // ckbShi
            // 
            this.ckbShi.AutoSize = true;
            this.ckbShi.Location = new System.Drawing.Point(108, 24);
            this.ckbShi.Name = "ckbShi";
            this.ckbShi.Size = new System.Drawing.Size(36, 16);
            this.ckbShi.TabIndex = 44;
            this.ckbShi.Text = "市";
            this.ckbShi.UseVisualStyleBackColor = true;
            // 
            // gboxLB
            // 
            this.gboxLB.Controls.Add(this.rabYQ);
            this.gboxLB.Controls.Add(this.rabXC);
            this.gboxLB.Controls.Add(this.rabWM);
            this.gboxLB.Dock = System.Windows.Forms.DockStyle.Top;
            this.gboxLB.Location = new System.Drawing.Point(0, 125);
            this.gboxLB.Name = "gboxLB";
            this.gboxLB.Size = new System.Drawing.Size(947, 44);
            this.gboxLB.TabIndex = 54;
            this.gboxLB.TabStop = false;
            this.gboxLB.Text = "类别";
            // 
            // rabYQ
            // 
            this.rabYQ.AutoSize = true;
            this.rabYQ.Location = new System.Drawing.Point(58, 16);
            this.rabYQ.Name = "rabYQ";
            this.rabYQ.Size = new System.Drawing.Size(71, 16);
            this.rabYQ.TabIndex = 39;
            this.rabYQ.TabStop = true;
            this.rabYQ.Text = "舆情信息";
            this.rabYQ.UseVisualStyleBackColor = true;
            // 
            // rabXC
            // 
            this.rabXC.AutoSize = true;
            this.rabXC.Location = new System.Drawing.Point(156, 16);
            this.rabXC.Name = "rabXC";
            this.rabXC.Size = new System.Drawing.Size(71, 16);
            this.rabXC.TabIndex = 40;
            this.rabXC.TabStop = true;
            this.rabXC.Text = "宣传信息";
            this.rabXC.UseVisualStyleBackColor = true;
            // 
            // rabWM
            // 
            this.rabWM.AutoSize = true;
            this.rabWM.Location = new System.Drawing.Point(253, 16);
            this.rabWM.Name = "rabWM";
            this.rabWM.Size = new System.Drawing.Size(47, 16);
            this.rabWM.TabIndex = 41;
            this.rabWM.TabStop = true;
            this.rabWM.Text = "外媒";
            this.rabWM.UseVisualStyleBackColor = true;
            // 
            // gboxLY
            // 
            this.gboxLY.Controls.Add(this.rabSourc);
            this.gboxLY.Controls.Add(this.rabZiCai);
            this.gboxLY.Dock = System.Windows.Forms.DockStyle.Top;
            this.gboxLY.Location = new System.Drawing.Point(0, 90);
            this.gboxLY.Name = "gboxLY";
            this.gboxLY.Size = new System.Drawing.Size(947, 35);
            this.gboxLY.TabIndex = 53;
            this.gboxLY.TabStop = false;
            this.gboxLY.Text = "来源";
            // 
            // rabSourc
            // 
            this.rabSourc.AutoSize = true;
            this.rabSourc.Location = new System.Drawing.Point(58, 12);
            this.rabSourc.Name = "rabSourc";
            this.rabSourc.Size = new System.Drawing.Size(47, 16);
            this.rabSourc.TabIndex = 37;
            this.rabSourc.TabStop = true;
            this.rabSourc.Text = "网站";
            this.rabSourc.UseVisualStyleBackColor = true;
            // 
            // rabZiCai
            // 
            this.rabZiCai.AutoSize = true;
            this.rabZiCai.Location = new System.Drawing.Point(141, 12);
            this.rabZiCai.Name = "rabZiCai";
            this.rabZiCai.Size = new System.Drawing.Size(47, 16);
            this.rabZiCai.TabIndex = 36;
            this.rabZiCai.TabStop = true;
            this.rabZiCai.Text = "自采";
            this.rabZiCai.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.linkLabel1);
            this.groupBox1.Controls.Add(this.labLink);
            this.groupBox1.Controls.Add(this.labUpTime);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtTitle);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(947, 90);
            this.groupBox1.TabIndex = 51;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "信息";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(53, 61);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(65, 12);
            this.linkLabel1.TabIndex = 34;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "linkLabel1";
            // 
            // labLink
            // 
            this.labLink.AutoSize = true;
            this.labLink.Location = new System.Drawing.Point(12, 61);
            this.labLink.Name = "labLink";
            this.labLink.Size = new System.Drawing.Size(41, 12);
            this.labLink.TabIndex = 33;
            this.labLink.Text = "地址：";
            // 
            // labUpTime
            // 
            this.labUpTime.AutoSize = true;
            this.labUpTime.Location = new System.Drawing.Point(12, 17);
            this.labUpTime.Name = "labUpTime";
            this.labUpTime.Size = new System.Drawing.Size(41, 12);
            this.labUpTime.TabIndex = 29;
            this.labUpTime.Text = "时间：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "题目：";
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitle.Location = new System.Drawing.Point(55, 32);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(883, 21);
            this.txtTitle.TabIndex = 5;
            // 
            // EditFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 568);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gboxSendTo);
            this.Controls.Add(this.gboxLB);
            this.Controls.Add(this.gboxLY);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "EditFrm";
            this.Text = "编辑";
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.gboxSendTo.ResumeLayout(false);
            this.gboxSendTo.PerformLayout();
            this.gboxLB.ResumeLayout(false);
            this.gboxLB.PerformLayout();
            this.gboxLY.ResumeLayout(false);
            this.gboxLY.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 新建自采ToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox2;
        private Sonic.HtmlEditor.HtmlEditor htmlEditor1;
        private System.Windows.Forms.GroupBox gboxSendTo;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.CheckBox ckbZX;
        private System.Windows.Forms.CheckBox ckbSheng;
        private System.Windows.Forms.CheckBox ckbXiang;
        private System.Windows.Forms.CheckBox ckbShi;
        private System.Windows.Forms.GroupBox gboxLB;
        private System.Windows.Forms.RadioButton rabYQ;
        private System.Windows.Forms.RadioButton rabXC;
        private System.Windows.Forms.RadioButton rabWM;
        private System.Windows.Forms.GroupBox gboxLY;
        private System.Windows.Forms.RadioButton rabSourc;
        private System.Windows.Forms.RadioButton rabZiCai;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label labLink;
        private System.Windows.Forms.Label labUpTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTitle;
    }
}