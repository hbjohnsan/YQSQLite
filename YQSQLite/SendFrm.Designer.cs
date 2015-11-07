namespace YQSQLite
{
    partial class SendFrm
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labWebwill = new System.Windows.Forms.Label();
            this.labWebHas = new System.Windows.Forms.Label();
            this.btnlogin = new System.Windows.Forms.Button();
            this.btnWebSend = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labwillSend = new System.Windows.Forms.Label();
            this.labhasSend = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labWebwill);
            this.groupBox2.Controls.Add(this.labWebHas);
            this.groupBox2.Controls.Add(this.btnlogin);
            this.groupBox2.Controls.Add(this.btnWebSend);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(340, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(331, 37);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Web";
            // 
            // labWebwill
            // 
            this.labWebwill.AutoSize = true;
            this.labWebwill.Location = new System.Drawing.Point(5, 17);
            this.labWebwill.Name = "labWebwill";
            this.labWebwill.Size = new System.Drawing.Size(41, 12);
            this.labWebwill.TabIndex = 2;
            this.labWebwill.Text = "待发：";
            // 
            // labWebHas
            // 
            this.labWebHas.AutoSize = true;
            this.labWebHas.Location = new System.Drawing.Point(87, 17);
            this.labWebHas.Name = "labWebHas";
            this.labWebHas.Size = new System.Drawing.Size(41, 12);
            this.labWebHas.TabIndex = 2;
            this.labWebHas.Text = "已发：";
            // 
            // btnlogin
            // 
            this.btnlogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnlogin.Location = new System.Drawing.Point(156, 11);
            this.btnlogin.Name = "btnlogin";
            this.btnlogin.Size = new System.Drawing.Size(75, 23);
            this.btnlogin.TabIndex = 1;
            this.btnlogin.Text = "自动登录";
            this.btnlogin.UseVisualStyleBackColor = true;
            this.btnlogin.Click += new System.EventHandler(this.btnlogin_Click);
            // 
            // btnWebSend
            // 
            this.btnWebSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWebSend.Location = new System.Drawing.Point(247, 11);
            this.btnWebSend.Name = "btnWebSend";
            this.btnWebSend.Size = new System.Drawing.Size(75, 23);
            this.btnWebSend.TabIndex = 1;
            this.btnWebSend.Text = "网页上报";
            this.btnWebSend.UseVisualStyleBackColor = true;
            this.btnWebSend.Click += new System.EventHandler(this.btnWebSend_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labwillSend);
            this.groupBox1.Controls.Add(this.labhasSend);
            this.groupBox1.Controls.Add(this.btnSend);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(331, 37);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "邮件";
            // 
            // labwillSend
            // 
            this.labwillSend.AutoSize = true;
            this.labwillSend.Location = new System.Drawing.Point(1, 17);
            this.labwillSend.Name = "labwillSend";
            this.labwillSend.Size = new System.Drawing.Size(41, 12);
            this.labwillSend.TabIndex = 2;
            this.labwillSend.Text = "待发：";
            // 
            // labhasSend
            // 
            this.labhasSend.AutoSize = true;
            this.labhasSend.Location = new System.Drawing.Point(79, 17);
            this.labhasSend.Name = "labhasSend";
            this.labhasSend.Size = new System.Drawing.Size(41, 12);
            this.labhasSend.TabIndex = 2;
            this.labhasSend.Text = "已发：";
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Location = new System.Drawing.Point(250, 11);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 0;
            this.btnSend.Text = "邮件发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(674, 43);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.webBrowser1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(674, 350);
            this.panel1.TabIndex = 1;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(674, 350);
            this.webBrowser1.TabIndex = 0;
            // 
            // SendFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 393);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "SendFrm";
            this.Text = "上报";
            this.Load += new System.EventHandler(this.SendFrm_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labWebwill;
        private System.Windows.Forms.Label labWebHas;
        private System.Windows.Forms.Button btnlogin;
        private System.Windows.Forms.Button btnWebSend;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labwillSend;
        private System.Windows.Forms.Label labhasSend;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.WebBrowser webBrowser1;
    }
}