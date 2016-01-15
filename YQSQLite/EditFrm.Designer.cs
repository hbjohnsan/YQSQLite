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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditFrm));
            this.gboxSendTo = new System.Windows.Forms.GroupBox();
            this.ckbZX = new System.Windows.Forms.CheckBox();
            this.ckbSheng = new System.Windows.Forms.CheckBox();
            this.ckbShi = new System.Windows.Forms.CheckBox();
            this.ckbXiang = new System.Windows.Forms.CheckBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.gboxLB = new System.Windows.Forms.GroupBox();
            this.rabYQ = new System.Windows.Forms.RadioButton();
            this.rabXC = new System.Windows.Forms.RadioButton();
            this.rabWM = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labSourc = new System.Windows.Forms.Label();
            this.btnZiCai = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.labLink = new System.Windows.Forms.Label();
            this.labUpTime = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.htmlEditor1 = new Sonic.HtmlEditor.HtmlEditor();
            this.gboxSendTo.SuspendLayout();
            this.gboxLB.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // gboxSendTo
            // 
            this.gboxSendTo.Controls.Add(this.ckbZX);
            this.gboxSendTo.Controls.Add(this.ckbSheng);
            this.gboxSendTo.Controls.Add(this.ckbShi);
            this.gboxSendTo.Controls.Add(this.ckbXiang);
            this.gboxSendTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gboxSendTo.Location = new System.Drawing.Point(0, 0);
            this.gboxSendTo.Name = "gboxSendTo";
            this.gboxSendTo.Size = new System.Drawing.Size(385, 47);
            this.gboxSendTo.TabIndex = 55;
            this.gboxSendTo.TabStop = false;
            // 
            // ckbZX
            // 
            this.ckbZX.AutoSize = true;
            this.ckbZX.Location = new System.Drawing.Point(58, 19);
            this.ckbZX.Name = "ckbZX";
            this.ckbZX.Size = new System.Drawing.Size(48, 16);
            this.ckbZX.TabIndex = 46;
            this.ckbZX.Text = "中宣";
            this.ckbZX.UseVisualStyleBackColor = true;
            // 
            // ckbSheng
            // 
            this.ckbSheng.AutoSize = true;
            this.ckbSheng.Checked = true;
            this.ckbSheng.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbSheng.Location = new System.Drawing.Point(112, 19);
            this.ckbSheng.Name = "ckbSheng";
            this.ckbSheng.Size = new System.Drawing.Size(36, 16);
            this.ckbSheng.TabIndex = 42;
            this.ckbSheng.Text = "省";
            this.ckbSheng.UseVisualStyleBackColor = true;
            // 
            // ckbShi
            // 
            this.ckbShi.AutoSize = true;
            this.ckbShi.Checked = true;
            this.ckbShi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbShi.Location = new System.Drawing.Point(154, 19);
            this.ckbShi.Name = "ckbShi";
            this.ckbShi.Size = new System.Drawing.Size(36, 16);
            this.ckbShi.TabIndex = 44;
            this.ckbShi.Text = "市";
            this.ckbShi.UseVisualStyleBackColor = true;
            // 
            // ckbXiang
            // 
            this.ckbXiang.AutoSize = true;
            this.ckbXiang.Location = new System.Drawing.Point(196, 19);
            this.ckbXiang.Name = "ckbXiang";
            this.ckbXiang.Size = new System.Drawing.Size(36, 16);
            this.ckbXiang.TabIndex = 45;
            this.ckbXiang.Text = "县";
            this.ckbXiang.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(652, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(55, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "待报";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.Location = new System.Drawing.Point(591, 12);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(55, 23);
            this.btnRemove.TabIndex = 0;
            this.btnRemove.Text = "移除";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // gboxLB
            // 
            this.gboxLB.Controls.Add(this.rabYQ);
            this.gboxLB.Controls.Add(this.rabXC);
            this.gboxLB.Controls.Add(this.rabWM);
            this.gboxLB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gboxLB.Location = new System.Drawing.Point(0, 0);
            this.gboxLB.Name = "gboxLB";
            this.gboxLB.Size = new System.Drawing.Size(358, 47);
            this.gboxLB.TabIndex = 54;
            this.gboxLB.TabStop = false;
            // 
            // rabYQ
            // 
            this.rabYQ.AutoSize = true;
            this.rabYQ.Checked = true;
            this.rabYQ.Location = new System.Drawing.Point(51, 19);
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
            this.rabXC.Location = new System.Drawing.Point(149, 19);
            this.rabXC.Name = "rabXC";
            this.rabXC.Size = new System.Drawing.Size(71, 16);
            this.rabXC.TabIndex = 40;
            this.rabXC.Text = "宣传信息";
            this.rabXC.UseVisualStyleBackColor = true;
            // 
            // rabWM
            // 
            this.rabWM.AutoSize = true;
            this.rabWM.Location = new System.Drawing.Point(246, 19);
            this.rabWM.Name = "rabWM";
            this.rabWM.Size = new System.Drawing.Size(47, 16);
            this.rabWM.TabIndex = 41;
            this.rabWM.Text = "外媒";
            this.rabWM.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.labSourc);
            this.groupBox1.Controls.Add(this.btnZiCai);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.btnRemove);
            this.groupBox1.Controls.Add(this.linkLabel1);
            this.groupBox1.Controls.Add(this.labLink);
            this.groupBox1.Controls.Add(this.labUpTime);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtTitle);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(747, 103);
            this.groupBox1.TabIndex = 51;
            this.groupBox1.TabStop = false;
            // 
            // labSourc
            // 
            this.labSourc.AutoSize = true;
            this.labSourc.Location = new System.Drawing.Point(321, 17);
            this.labSourc.Name = "labSourc";
            this.labSourc.Size = new System.Drawing.Size(41, 12);
            this.labSourc.TabIndex = 39;
            this.labSourc.Text = "来源：";
            // 
            // btnZiCai
            // 
            this.btnZiCai.Location = new System.Drawing.Point(15, 12);
            this.btnZiCai.Name = "btnZiCai";
            this.btnZiCai.Size = new System.Drawing.Size(66, 23);
            this.btnZiCai.TabIndex = 38;
            this.btnZiCai.Text = "新建自采";
            this.btnZiCai.UseVisualStyleBackColor = true;
            this.btnZiCai.Click += new System.EventHandler(this.btnZiCai_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(53, 74);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(65, 12);
            this.linkLabel1.TabIndex = 34;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "linkLabel1";
            // 
            // labLink
            // 
            this.labLink.AutoSize = true;
            this.labLink.Location = new System.Drawing.Point(10, 74);
            this.labLink.Name = "labLink";
            this.labLink.Size = new System.Drawing.Size(41, 12);
            this.labLink.TabIndex = 33;
            this.labLink.Text = "地址：";
            // 
            // labUpTime
            // 
            this.labUpTime.AutoSize = true;
            this.labUpTime.Location = new System.Drawing.Point(107, 17);
            this.labUpTime.Name = "labUpTime";
            this.labUpTime.Size = new System.Drawing.Size(41, 12);
            this.labUpTime.TabIndex = 29;
            this.labUpTime.Text = "时间：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "题目：";
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitle.Location = new System.Drawing.Point(55, 41);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(683, 21);
            this.txtTitle.TabIndex = 5;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainer1.Location = new System.Drawing.Point(0, 103);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gboxLB);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gboxSendTo);
            this.splitContainer1.Size = new System.Drawing.Size(747, 47);
            this.splitContainer1.SplitterDistance = 358;
            this.splitContainer1.TabIndex = 56;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.htmlEditor1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 150);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(747, 384);
            this.groupBox3.TabIndex = 57;
            this.groupBox3.TabStop = false;
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
            this.htmlEditor1.Size = new System.Drawing.Size(741, 364);
            this.htmlEditor1.TabIndex = 1;
            // 
            // EditFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 534);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "EditFrm";
            this.Text = "编辑";
            this.gboxSendTo.ResumeLayout(false);
            this.gboxSendTo.PerformLayout();
            this.gboxLB.ResumeLayout(false);
            this.gboxLB.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label labLink;
        private System.Windows.Forms.Label labUpTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Button btnZiCai;
        private System.Windows.Forms.Label labSourc;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox3;
        private Sonic.HtmlEditor.HtmlEditor htmlEditor1;
    }
}