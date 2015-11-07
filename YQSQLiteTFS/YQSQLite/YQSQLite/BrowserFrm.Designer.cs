namespace YQSQLite
{
    partial class BrowserFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BrowserFrm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.combUrl = new System.Windows.Forms.ComboBox();
            this.btnGoTo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRefurbish = new System.Windows.Forms.Button();
            this.btnForward = new System.Windows.Forms.Button();
            this.btnGoBack = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tpHtmlEdit = new System.Windows.Forms.TabPage();
            this.htmlEditor1 = new Sonic.HtmlEditor.HtmlEditor();
            this.tpRichText = new System.Windows.Forms.TabPage();
            this.rtbText = new System.Windows.Forms.RichTextBox();
            this.tpCode = new System.Windows.Forms.TabPage();
            this.rtbCode = new System.Windows.Forms.RichTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnRemove = new System.Windows.Forms.Button();
            this.txtReCont = new System.Windows.Forms.TextBox();
            this.txtContFlag = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCut = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tpHtmlEdit.SuspendLayout();
            this.tpRichText.SuspendLayout();
            this.tpCode.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.combUrl);
            this.panel1.Controls.Add(this.btnGoTo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnRefurbish);
            this.panel1.Controls.Add(this.btnForward);
            this.panel1.Controls.Add(this.btnGoBack);
            this.panel1.Controls.Add(this.btnHome);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(663, 28);
            this.panel1.TabIndex = 1;
            // 
            // combUrl
            // 
            this.combUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.combUrl.FormattingEnabled = true;
            this.combUrl.Location = new System.Drawing.Point(287, 4);
            this.combUrl.Name = "combUrl";
            this.combUrl.Size = new System.Drawing.Size(310, 20);
            this.combUrl.TabIndex = 2;
            // 
            // btnGoTo
            // 
            this.btnGoTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGoTo.Image = global::YQSQLite.Properties.Resources.Button_Next_icon;
            this.btnGoTo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGoTo.Location = new System.Drawing.Point(603, 2);
            this.btnGoTo.Name = "btnGoTo";
            this.btnGoTo.Size = new System.Drawing.Size(57, 23);
            this.btnGoTo.TabIndex = 0;
            this.btnGoTo.Text = "GO！";
            this.btnGoTo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGoTo.UseVisualStyleBackColor = true;
            this.btnGoTo.Click += new System.EventHandler(this.btnGoTo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(239, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "网址：";
            // 
            // btnRefurbish
            // 
            this.btnRefurbish.Image = global::YQSQLite.Properties.Resources.reload_icon;
            this.btnRefurbish.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefurbish.Location = new System.Drawing.Point(180, 3);
            this.btnRefurbish.Name = "btnRefurbish";
            this.btnRefurbish.Size = new System.Drawing.Size(53, 23);
            this.btnRefurbish.TabIndex = 0;
            this.btnRefurbish.Text = "刷新";
            this.btnRefurbish.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefurbish.UseVisualStyleBackColor = true;
            this.btnRefurbish.Click += new System.EventHandler(this.btnRefurbish_Click);
            // 
            // btnForward
            // 
            this.btnForward.Image = global::YQSQLite.Properties.Resources.Actions_go_next_icon;
            this.btnForward.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnForward.Location = new System.Drawing.Point(122, 3);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(52, 23);
            this.btnForward.TabIndex = 0;
            this.btnForward.Text = "前进";
            this.btnForward.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnForward.UseVisualStyleBackColor = true;
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
            // 
            // btnGoBack
            // 
            this.btnGoBack.Image = global::YQSQLite.Properties.Resources.Actions_go_previous_icon;
            this.btnGoBack.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGoBack.Location = new System.Drawing.Point(62, 3);
            this.btnGoBack.Name = "btnGoBack";
            this.btnGoBack.Size = new System.Drawing.Size(54, 23);
            this.btnGoBack.TabIndex = 0;
            this.btnGoBack.Text = "回退";
            this.btnGoBack.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGoBack.UseVisualStyleBackColor = true;
            this.btnGoBack.Click += new System.EventHandler(this.btnGoBack_Click);
            // 
            // btnHome
            // 
            this.btnHome.Image = global::YQSQLite.Properties.Resources.Actions_go_home_icon;
            this.btnHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHome.Location = new System.Drawing.Point(3, 2);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(53, 23);
            this.btnHome.TabIndex = 0;
            this.btnHome.Text = "主页";
            this.btnHome.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tabControl2, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.tabControl1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 28);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(663, 429);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // tabControl2
            // 
            this.tabControl2.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl2.Controls.Add(this.tpHtmlEdit);
            this.tabControl2.Controls.Add(this.tpRichText);
            this.tabControl2.Controls.Add(this.tpCode);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(4, 273);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(655, 152);
            this.tabControl2.TabIndex = 6;
            // 
            // tpHtmlEdit
            // 
            this.tpHtmlEdit.Controls.Add(this.htmlEditor1);
            this.tpHtmlEdit.Location = new System.Drawing.Point(4, 4);
            this.tpHtmlEdit.Name = "tpHtmlEdit";
            this.tpHtmlEdit.Padding = new System.Windows.Forms.Padding(3);
            this.tpHtmlEdit.Size = new System.Drawing.Size(647, 126);
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
            this.htmlEditor1.Size = new System.Drawing.Size(641, 120);
            this.htmlEditor1.TabIndex = 0;
            // 
            // tpRichText
            // 
            this.tpRichText.Controls.Add(this.rtbText);
            this.tpRichText.Location = new System.Drawing.Point(4, 4);
            this.tpRichText.Name = "tpRichText";
            this.tpRichText.Size = new System.Drawing.Size(647, 126);
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
            this.tpCode.Size = new System.Drawing.Size(647, 126);
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tabControl1.Location = new System.Drawing.Point(4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(655, 231);
            this.tabControl1.TabIndex = 5;
            this.tabControl1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tabControl1_MouseClick);
            this.tabControl1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tabControl1_MouseDoubleClick);
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(647, 205);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(647, 205);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "新建";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnCut);
            this.panel2.Controls.Add(this.btnRemove);
            this.panel2.Controls.Add(this.txtReCont);
            this.panel2.Controls.Add(this.txtContFlag);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(4, 242);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(655, 24);
            this.panel2.TabIndex = 7;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(572, 0);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 11;
            this.btnRemove.Text = "排除";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // txtReCont
            // 
            this.txtReCont.Location = new System.Drawing.Point(417, 0);
            this.txtReCont.Name = "txtReCont";
            this.txtReCont.Size = new System.Drawing.Size(142, 21);
            this.txtReCont.TabIndex = 10;
            // 
            // txtContFlag
            // 
            this.txtContFlag.Location = new System.Drawing.Point(77, 0);
            this.txtContFlag.Name = "txtContFlag";
            this.txtContFlag.Size = new System.Drawing.Size(132, 21);
            this.txtContFlag.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(346, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "正文排除：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "正文定位：";
            // 
            // btnCut
            // 
            this.btnCut.Location = new System.Drawing.Point(215, -1);
            this.btnCut.Name = "btnCut";
            this.btnCut.Size = new System.Drawing.Size(75, 23);
            this.btnCut.TabIndex = 12;
            this.btnCut.Text = "截取";
            this.btnCut.UseVisualStyleBackColor = true;
            this.btnCut.Click += new System.EventHandler(this.btnCut_Click);
            // 
            // BrowserFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 457);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "BrowserFrm";
            this.Text = "浏览器";
            this.Load += new System.EventHandler(this.BrowserFrm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tpHtmlEdit.ResumeLayout(false);
            this.tpRichText.ResumeLayout(false);
            this.tpCode.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox combUrl;
        private System.Windows.Forms.Button btnGoTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRefurbish;
        private System.Windows.Forms.Button btnForward;
        private System.Windows.Forms.Button btnGoBack;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tpHtmlEdit;
        private Sonic.HtmlEditor.HtmlEditor htmlEditor1;
        private System.Windows.Forms.TabPage tpRichText;
        private System.Windows.Forms.RichTextBox rtbText;
        private System.Windows.Forms.TabPage tpCode;
        private System.Windows.Forms.RichTextBox rtbCode;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.TextBox txtReCont;
        private System.Windows.Forms.TextBox txtContFlag;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCut;
    }
}