using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace YQSQLite
{
    public partial class ConfigFrm : Form
    {
        private MainFrm mf;

        public ConfigFrm()
        {
            InitializeComponent();
        }
        public ConfigFrm(MainFrm f)
        {
            InitializeComponent();
            mf = f;
        }

        private void ConfigFrm_Load(object sender, EventArgs e)
        {
            Reload();


            labID.Visible = false;
            var q = from p in mf.DS.server.AsEnumerable()
                    select p;
            foreach (var item in q)
            {
               
                cmbSmtp.Text = item.smtp;
                txtUser.Text = item.user;
                txtPwd.Text = item.pwd;
                txtShowName.Text = item.showname;
            }

            btnEidt.Enabled = false;
            rabNo.Checked = true;
        }

        public void Reload()
        {
            listView1.Items.Clear();

            var q = from p in mf.DS.sendto.AsEnumerable()
                    select p;
            foreach (var item in q)
            {
                ListViewItem it = new ListViewItem(new string[] { "", "", "", "", "", "", "" });
                it.SubItems[0].Text = item.Id.ToString();
                it.SubItems[1].Text = item.RankName;
                it.SubItems[2].Text = item.Rank;
                it.SubItems[3].Text = item.Kind;
                it.SubItems[4].Text = item.Email;
                it.SubItems[5].Text = item.ReTitle;
                it.SubItems[6].Text = item.addlink;

                listView1.Items.Add(it);
            }
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string id = listView1.SelectedItems[0].SubItems[0].Text;
            string rankName = listView1.SelectedItems[0].SubItems[1].Text;
            string rank = listView1.SelectedItems[0].SubItems[2].Text;
            string kind = listView1.SelectedItems[0].SubItems[3].Text;
            string email = listView1.SelectedItems[0].SubItems[4].Text;
            string retitle = listView1.SelectedItems[0].SubItems[5].Text;
            string adlink = listView1.SelectedItems[0].SubItems[6].Text;

            btnEidt.Enabled = true;
            btnAdd.Enabled = false;
            labID.Text = id;
            txtRankName.Text = rankName;
            cmbRank.Text = rank;
            cmbKind.Text = kind;
            txtEmail.Text = email;
            txtReTitle.Text = retitle;
            if (adlink == "是")
            {
                rabYes.Checked = true;
            }
            else
            {
                rabNo.Checked = true;
            }

        }

        private void 删除ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            listView1.SelectedItems[0].Remove();
            mf.DS.sendto.FindById(id).Delete();
            mf.sendtoTap.Update(mf.DS.sendto);

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SQLiteDS.serverRow serverow = mf.DS.server.First();
            serverow.smtp = cmbSmtp.Text.Trim();
            serverow.user = txtUser.Text.Trim();
            serverow.pwd = txtPwd.Text.Trim();
            serverow.showname = txtShowName.Text.Trim();
            mf.serverTap.Update(serverow);
            this.DialogResult = DialogResult.OK;
        }

        private void btnCanncle_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if ((cmbRank.Text != "") && (cmbKind.Text != "") && (cmbSmtp.Text != ""))
            {
                string straddlink = rabYes.Checked ? "是" : "否";
                SQLiteDS.sendtoRow sr = mf.DS.sendto.AddsendtoRow(txtRankName.Text, cmbRank.Text, cmbKind.Text, txtEmail.Text, txtReTitle.Text, straddlink);
                //更新到库
                mf.sendtoTap.Update(sr);
                //更新DS,消除用dispose,比clear更快，消了再填充
                mf.sendtoTap.Dispose();
                mf.sendtoTap.Fill(mf.DS.sendto);
                Reload();

                txtRankName.Text = "";
                cmbRank.Text = "";
                cmbKind.Text = "";
                txtEmail.Text = "";
                txtReTitle.Text = "";
            }
            else
            {
                MessageBox.Show("信息不能为空！");
            }


        }


        private void btnEidt_Click(object sender, EventArgs e)
        {
           SQLiteDS.sendtoRow srs = mf.DS.sendto.FindById(Int32.Parse(labID.Text));
            srs.RankName = txtRankName.Text;
            srs.Rank = cmbRank.Text;
            srs.Kind = cmbKind.Text;
            srs.Email = txtEmail.Text;
            srs.ReTitle = txtReTitle.Text;
            srs.addlink = rabYes.Checked ? "是" : "否";
            mf.sendtoTap.Update(srs);
            Reload();

            txtRankName.Text = "";
            cmbRank.Text = "";
            cmbKind.Text = "";
            txtEmail.Text = "";
            txtReTitle.Text = "";

            btnEidt.Enabled = false;
            btnAdd.Enabled = true;
        }
    }
}
