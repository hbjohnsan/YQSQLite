namespace YQSQLite
{
    partial class SelectFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectFrm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnAddAll = new System.Windows.Forms.Button();
            this.btnsSelect = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnRemoveAll = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tpHtmlEdit = new System.Windows.Forms.TabPage();
            this.htmlEditor1 = new Sonic.HtmlEditor.HtmlEditor();
            this.tpRichText = new System.Windows.Forms.TabPage();
            this.rtbText = new System.Windows.Forms.RichTextBox();
            this.tpCode = new System.Windows.Forms.TabPage();
            this.rtbCode = new System.Windows.Forms.RichTextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.site = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.浏览器打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.外部器打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tpHtmlEdit.SuspendLayout();
            this.tpRichText.SuspendLayout();
            this.tpCode.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.listView1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(767, 562);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnAddAll);
            this.panel3.Controls.Add(this.btnsSelect);
            this.panel3.Controls.Add(this.btnRemove);
            this.panel3.Controls.Add(this.btnSelectAll);
            this.panel3.Controls.Add(this.btnRemoveAll);
            this.panel3.Controls.Add(this.btnAdd);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(298, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(24, 554);
            this.panel3.TabIndex = 2;
            // 
            // btnAddAll
            // 
            this.btnAddAll.Image = global::YQSQLite.Properties.Resources.control_double_icon;
            this.btnAddAll.Location = new System.Drawing.Point(0, 192);
            this.btnAddAll.Name = "btnAddAll";
            this.btnAddAll.Size = new System.Drawing.Size(24, 20);
            this.btnAddAll.TabIndex = 0;
            this.btnAddAll.UseVisualStyleBackColor = true;
            this.btnAddAll.Click += new System.EventHandler(this.btnAddAll_Click);
            // 
            // btnsSelect
            // 
            this.btnsSelect.Image = global::YQSQLite.Properties.Resources.no_entry_icon;
            this.btnsSelect.Location = new System.Drawing.Point(0, 356);
            this.btnsSelect.Name = "btnsSelect";
            this.btnsSelect.Size = new System.Drawing.Size(24, 20);
            this.btnsSelect.TabIndex = 0;
            this.btnsSelect.UseVisualStyleBackColor = true;
            this.btnsSelect.Click += new System.EventHandler(this.btnsSelect_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Image = global::YQSQLite.Properties.Resources.Actions_go_previous_icon1;
            this.btnRemove.Location = new System.Drawing.Point(0, 264);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(24, 20);
            this.btnRemove.TabIndex = 0;
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Image = global::YQSQLite.Properties.Resources.no_icon;
            this.btnSelectAll.Location = new System.Drawing.Point(1, 387);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(24, 20);
            this.btnSelectAll.TabIndex = 0;
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.Image = global::YQSQLite.Properties.Resources.control_double_180_icon;
            this.btnRemoveAll.Location = new System.Drawing.Point(1, 295);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(24, 20);
            this.btnRemoveAll.TabIndex = 0;
            this.btnRemoveAll.UseVisualStyleBackColor = true;
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::YQSQLite.Properties.Resources._20_Right_Arrow_icon;
            this.btnAdd.Location = new System.Drawing.Point(0, 160);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(24, 20);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(329, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(434, 554);
            this.panel2.TabIndex = 4;
            // 
            // tabControl2
            // 
            this.tabControl2.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl2.Controls.Add(this.tpHtmlEdit);
            this.tabControl2.Controls.Add(this.tpRichText);
            this.tabControl2.Controls.Add(this.tpCode);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(434, 554);
            this.tabControl2.TabIndex = 7;
            // 
            // tpHtmlEdit
            // 
            this.tpHtmlEdit.Controls.Add(this.htmlEditor1);
            this.tpHtmlEdit.Location = new System.Drawing.Point(4, 4);
            this.tpHtmlEdit.Name = "tpHtmlEdit";
            this.tpHtmlEdit.Padding = new System.Windows.Forms.Padding(3);
            this.tpHtmlEdit.Size = new System.Drawing.Size(426, 528);
            this.tpHtmlEdit.TabIndex = 0;
            this.tpHtmlEdit.Text = "HtmlEdit";
            this.tpHtmlEdit.UseVisualStyleBackColor = true;
            // 
            // htmlEditor1
            // 
            this.htmlEditor1.BodyInnerHTML = null;
            this.htmlEditor1.BodyInnerText = null;
            this.htmlEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.htmlEditor1.EnterToBR = false;
            this.htmlEditor1.HTML = resources.GetString("htmlEditor1.HTML");
            this.htmlEditor1.Location = new System.Drawing.Point(3, 3);
            this.htmlEditor1.Name = "htmlEditor1";
            this.htmlEditor1.ShowToolBar = true;
            this.htmlEditor1.Size = new System.Drawing.Size(420, 522);
            this.htmlEditor1.TabIndex = 0;
            // 
            // tpRichText
            // 
            this.tpRichText.Controls.Add(this.rtbText);
            this.tpRichText.Location = new System.Drawing.Point(4, 4);
            this.tpRichText.Name = "tpRichText";
            this.tpRichText.Size = new System.Drawing.Size(426, 528);
            this.tpRichText.TabIndex = 3;
            this.tpRichText.Text = "RichText";
            this.tpRichText.UseVisualStyleBackColor = true;
            // 
            // rtbText
            // 
            this.rtbText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbText.Location = new System.Drawing.Point(0, 0);
            this.rtbText.Name = "rtbText";
            this.rtbText.Size = new System.Drawing.Size(647, 139);
            this.rtbText.TabIndex = 0;
            this.rtbText.Text = "";
            // 
            // tpCode
            // 
            this.tpCode.Controls.Add(this.rtbCode);
            this.tpCode.Location = new System.Drawing.Point(4, 4);
            this.tpCode.Name = "tpCode";
            this.tpCode.Size = new System.Drawing.Size(426, 528);
            this.tpCode.TabIndex = 2;
            this.tpCode.Text = "Code";
            this.tpCode.UseVisualStyleBackColor = true;
            // 
            // rtbCode
            // 
            this.rtbCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbCode.Location = new System.Drawing.Point(0, 0);
            this.rtbCode.Name = "rtbCode";
            this.rtbCode.Size = new System.Drawing.Size(647, 139);
            this.rtbCode.TabIndex = 0;
            this.rtbCode.Text = "";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.title,
            this.date,
            this.site});
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(4, 4);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(287, 554);
            this.listView1.SmallImageList = this.imageList1;
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvwCustomer_ColumnClick);
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // title
            // 
            this.title.Text = "标题";
            this.title.Width = 280;
            // 
            // date
            // 
            this.date.Text = "发布时间";
            this.date.Width = 100;
            // 
            // site
            // 
            this.site.Text = "网站";
            this.site.Width = 80;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Actions-arrow-down-icon.png");
            this.imageList1.Images.SetKeyName(1, "Actions-arrow-up-icon.png");
            this.imageList1.Images.SetKeyName(2, "Actions-arrow-null-icon.png");
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.浏览器打开ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.外部器打开ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(137, 54);
            // 
            // 浏览器打开ToolStripMenuItem
            // 
            this.浏览器打开ToolStripMenuItem.Name = "浏览器打开ToolStripMenuItem";
            this.浏览器打开ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.浏览器打开ToolStripMenuItem.Text = "浏览器查看";
            this.浏览器打开ToolStripMenuItem.Click += new System.EventHandler(this.浏览器打开ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(133, 6);
            // 
            // 外部器打开ToolStripMenuItem
            // 
            this.外部器打开ToolStripMenuItem.Name = "外部器打开ToolStripMenuItem";
            this.外部器打开ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.外部器打开ToolStripMenuItem.Text = "外部IE查看";
            this.外部器打开ToolStripMenuItem.Click += new System.EventHandler(this.外部器打开ToolStripMenuItem_Click);
            // 
            // SelectFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 562);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "SelectFrm";
            this.Text = "筛选";
            this.Load += new System.EventHandler(this.SelectFrm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tpHtmlEdit.ResumeLayout(false);
            this.tpRichText.ResumeLayout(false);
            this.tpCode.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemoveAll;
        private System.Windows.Forms.Button btnAddAll;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnsSelect;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tpHtmlEdit;
        private Sonic.HtmlEditor.HtmlEditor htmlEditor1;
        private System.Windows.Forms.TabPage tpRichText;
        private System.Windows.Forms.RichTextBox rtbText;
        private System.Windows.Forms.TabPage tpCode;
        private System.Windows.Forms.RichTextBox rtbCode;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 浏览器打开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 外部器打开ToolStripMenuItem;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader title;
        private System.Windows.Forms.ColumnHeader date;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ColumnHeader site;



    }
}