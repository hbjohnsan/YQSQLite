namespace YQSQLite
{
    partial class DataFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataFrm));
            this.htmlEditor1 = new Sonic.HtmlEditor.HtmlEditor();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.cmbQs = new System.Windows.Forms.ComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.labTotal = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rabAll = new System.Windows.Forms.RadioButton();
            this.rabKxian = new System.Windows.Forms.RadioButton();
            this.rabKshi = new System.Windows.Forms.RadioButton();
            this.rabKsheng = new System.Windows.Forms.RadioButton();
            this.rabKzx = new System.Windows.Forms.RadioButton();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.labID = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbKw = new System.Windows.Forms.ComboBox();
            this.cmbTime = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rabXian = new System.Windows.Forms.RadioButton();
            this.rabShi = new System.Windows.Forms.RadioButton();
            this.rabSheng = new System.Windows.Forms.RadioButton();
            this.rabZX = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // htmlEditor1
            // 
            this.htmlEditor1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.htmlEditor1.BodyInnerHTML = null;
            this.htmlEditor1.BodyInnerText = null;
            this.htmlEditor1.EnterToBR = false;
            this.htmlEditor1.HTML = resources.GetString("htmlEditor1.HTML");
            this.htmlEditor1.Location = new System.Drawing.Point(6, 94);
            this.htmlEditor1.Name = "htmlEditor1";
            this.htmlEditor1.ShowToolBar = true;
            this.htmlEditor1.Size = new System.Drawing.Size(619, 334);
            this.htmlEditor1.TabIndex = 3;
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitle.Location = new System.Drawing.Point(51, 67);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(563, 21);
            this.txtTitle.TabIndex = 2;
            // 
            // cmbQs
            // 
            this.cmbQs.FormattingEnabled = true;
            this.cmbQs.Location = new System.Drawing.Point(285, 20);
            this.cmbQs.Name = "cmbQs";
            this.cmbQs.Size = new System.Drawing.Size(121, 20);
            this.cmbQs.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox6);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox5);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox4);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.labID);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(896, 559);
            this.splitContainer1.SplitterDistance = 251;
            this.splitContainer1.TabIndex = 1;
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.labTotal);
            this.groupBox6.Location = new System.Drawing.Point(3, 517);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(245, 39);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "统计";
            // 
            // labTotal
            // 
            this.labTotal.AutoSize = true;
            this.labTotal.Location = new System.Drawing.Point(23, 18);
            this.labTotal.Name = "labTotal";
            this.labTotal.Size = new System.Drawing.Size(41, 12);
            this.labTotal.TabIndex = 0;
            this.labTotal.Text = "label5";
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.listView1);
            this.groupBox5.Location = new System.Drawing.Point(3, 89);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(245, 422);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "信息";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.title});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(3, 17);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(239, 402);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
            // 
            // title
            // 
            this.title.Text = "标题";
            this.title.Width = 1000;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.rabAll);
            this.groupBox4.Controls.Add(this.rabKxian);
            this.groupBox4.Controls.Add(this.rabKshi);
            this.groupBox4.Controls.Add(this.rabKsheng);
            this.groupBox4.Controls.Add(this.rabKzx);
            this.groupBox4.Controls.Add(this.txtSearch);
            this.groupBox4.Location = new System.Drawing.Point(3, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(245, 71);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "查询";
            // 
            // rabAll
            // 
            this.rabAll.AutoSize = true;
            this.rabAll.Checked = true;
            this.rabAll.Location = new System.Drawing.Point(189, 44);
            this.rabAll.Name = "rabAll";
            this.rabAll.Size = new System.Drawing.Size(47, 16);
            this.rabAll.TabIndex = 4;
            this.rabAll.TabStop = true;
            this.rabAll.Text = "全部";
            this.rabAll.UseVisualStyleBackColor = true;
            this.rabAll.CheckedChanged += new System.EventHandler(this.rab_CheckedChanged);
            // 
            // rabKxian
            // 
            this.rabKxian.AutoSize = true;
            this.rabKxian.Location = new System.Drawing.Point(148, 44);
            this.rabKxian.Name = "rabKxian";
            this.rabKxian.Size = new System.Drawing.Size(35, 16);
            this.rabKxian.TabIndex = 3;
            this.rabKxian.Text = "县";
            this.rabKxian.UseVisualStyleBackColor = true;
            this.rabKxian.CheckedChanged += new System.EventHandler(this.rab_CheckedChanged);
            // 
            // rabKshi
            // 
            this.rabKshi.AutoSize = true;
            this.rabKshi.Location = new System.Drawing.Point(108, 44);
            this.rabKshi.Name = "rabKshi";
            this.rabKshi.Size = new System.Drawing.Size(35, 16);
            this.rabKshi.TabIndex = 3;
            this.rabKshi.Text = "市";
            this.rabKshi.UseVisualStyleBackColor = true;
            this.rabKshi.CheckedChanged += new System.EventHandler(this.rab_CheckedChanged);
            // 
            // rabKsheng
            // 
            this.rabKsheng.AutoSize = true;
            this.rabKsheng.Location = new System.Drawing.Point(67, 44);
            this.rabKsheng.Name = "rabKsheng";
            this.rabKsheng.Size = new System.Drawing.Size(35, 16);
            this.rabKsheng.TabIndex = 2;
            this.rabKsheng.Text = "省";
            this.rabKsheng.UseVisualStyleBackColor = true;
            this.rabKsheng.CheckedChanged += new System.EventHandler(this.rab_CheckedChanged);
            // 
            // rabKzx
            // 
            this.rabKzx.AutoSize = true;
            this.rabKzx.Location = new System.Drawing.Point(14, 44);
            this.rabKzx.Name = "rabKzx";
            this.rabKzx.Size = new System.Drawing.Size(47, 16);
            this.rabKzx.TabIndex = 1;
            this.rabKzx.Text = "中宣";
            this.rabKzx.UseVisualStyleBackColor = true;
            this.rabKzx.CheckedChanged += new System.EventHandler(this.rab_CheckedChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(8, 16);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(232, 21);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // labID
            // 
            this.labID.AutoSize = true;
            this.labID.Location = new System.Drawing.Point(576, 0);
            this.labID.Name = "labID";
            this.labID.Size = new System.Drawing.Size(41, 12);
            this.labID.TabIndex = 1;
            this.labID.Text = "label5";
            this.labID.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnDel);
            this.groupBox3.Controls.Add(this.btnEdit);
            this.groupBox3.Controls.Add(this.btnAdd);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(0, 512);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(641, 47);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "操作";
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(226, 16);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 0;
            this.btnDel.Text = "删除";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(364, 16);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 0;
            this.btnEdit.Text = "修改";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(494, 16);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.htmlEditor1);
            this.groupBox2.Controls.Add(this.txtTitle);
            this.groupBox2.Controls.Add(this.cmbKw);
            this.groupBox2.Controls.Add(this.cmbQs);
            this.groupBox2.Controls.Add(this.cmbTime);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(3, 69);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(631, 434);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "信息";
            // 
            // cmbKw
            // 
            this.cmbKw.FormattingEnabled = true;
            this.cmbKw.Location = new System.Drawing.Point(493, 20);
            this.cmbKw.Name = "cmbKw";
            this.cmbKw.Size = new System.Drawing.Size(121, 20);
            this.cmbKw.TabIndex = 1;
            // 
            // cmbTime
            // 
            this.cmbTime.FormattingEnabled = true;
            this.cmbTime.Location = new System.Drawing.Point(51, 20);
            this.cmbTime.Name = "cmbTime";
            this.cmbTime.Size = new System.Drawing.Size(121, 20);
            this.cmbTime.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(446, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "刊物：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(238, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "期数：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "题目：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "时间：";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.rabXian);
            this.groupBox1.Controls.Add(this.rabShi);
            this.groupBox1.Controls.Add(this.rabSheng);
            this.groupBox1.Controls.Add(this.rabZX);
            this.groupBox1.Location = new System.Drawing.Point(3, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(631, 51);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "信息级别";
            // 
            // rabXian
            // 
            this.rabXian.AutoSize = true;
            this.rabXian.Location = new System.Drawing.Point(342, 20);
            this.rabXian.Name = "rabXian";
            this.rabXian.Size = new System.Drawing.Size(35, 16);
            this.rabXian.TabIndex = 0;
            this.rabXian.TabStop = true;
            this.rabXian.Text = "县";
            this.rabXian.UseVisualStyleBackColor = true;
            // 
            // rabShi
            // 
            this.rabShi.AutoSize = true;
            this.rabShi.Location = new System.Drawing.Point(268, 20);
            this.rabShi.Name = "rabShi";
            this.rabShi.Size = new System.Drawing.Size(35, 16);
            this.rabShi.TabIndex = 0;
            this.rabShi.TabStop = true;
            this.rabShi.Text = "市";
            this.rabShi.UseVisualStyleBackColor = true;
            // 
            // rabSheng
            // 
            this.rabSheng.AutoSize = true;
            this.rabSheng.Location = new System.Drawing.Point(195, 20);
            this.rabSheng.Name = "rabSheng";
            this.rabSheng.Size = new System.Drawing.Size(35, 16);
            this.rabSheng.TabIndex = 0;
            this.rabSheng.TabStop = true;
            this.rabSheng.Text = "省";
            this.rabSheng.UseVisualStyleBackColor = true;
            // 
            // rabZX
            // 
            this.rabZX.AutoSize = true;
            this.rabZX.Location = new System.Drawing.Point(108, 20);
            this.rabZX.Name = "rabZX";
            this.rabZX.Size = new System.Drawing.Size(47, 16);
            this.rabZX.TabIndex = 0;
            this.rabZX.TabStop = true;
            this.rabZX.Text = "中宣";
            this.rabZX.UseVisualStyleBackColor = true;
            // 
            // DataFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 559);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "DataFrm";
            this.Text = "资料";
            this.Load += new System.EventHandler(this.DataFrm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Sonic.HtmlEditor.HtmlEditor htmlEditor1;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.ComboBox cmbQs;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label labTotal;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader title;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rabAll;
        private System.Windows.Forms.RadioButton rabKxian;
        private System.Windows.Forms.RadioButton rabKshi;
        private System.Windows.Forms.RadioButton rabKsheng;
        private System.Windows.Forms.RadioButton rabKzx;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label labID;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbKw;
        private System.Windows.Forms.ComboBox cmbTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rabXian;
        private System.Windows.Forms.RadioButton rabShi;
        private System.Windows.Forms.RadioButton rabSheng;
        private System.Windows.Forms.RadioButton rabZX;
    }
}