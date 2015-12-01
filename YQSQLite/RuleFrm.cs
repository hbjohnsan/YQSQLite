using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace YQSQLite
{
    public partial class RuleFrm : DockContent
    {
        private MainFrm mf;
        public RuleFrm()
        {
            InitializeComponent();
        }
        public RuleFrm(MainFrm f)
        {
            InitializeComponent();
            mf = f;
        }

        private void RuleFrm_Load(object sender, EventArgs e)
        {
            reload();
        }

        public void reload()
        {
            listView1.Items.Clear();
            var q = from p in mf.DS.Rule.AsEnumerable()
                    select p;
            foreach (var i in q)
            {
                ListViewItem lv = new ListViewItem(new string[] {i.RuleID.ToString(),i.Rule_site, i.Rule_Domain, i.ContFlag, i.RemoveFlag });
                listView1.Items.Add(lv);
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text == "添加")
            {
                YQDataSet.RuleRow rw = mf.DS.Rule.AddRuleRow(txtSiteName.Text.Trim(), txtUrlFlag.Text.Trim(), txtContFlag.Text.Trim(), txtRemove.Text.Trim());
                mf.ruleTap.Update(rw);
                clear();
                reload();
            }
            if (btnAdd.Text == "修改")
            {
                YQDataSet.RuleRow rw = mf.DS.Rule.FindByRuleID(Int32.Parse(labID.Text));
                rw.Rule_site = txtSiteName.Text;
                rw.Rule_Domain = txtUrlFlag.Text;
                rw.ContFlag = txtContFlag.Text;
                rw.RemoveFlag = txtRemove.Text;
                mf.ruleTap.Update(rw);
                clear();
                reload();
                btnAdd.Text = "添加";
            }
        }


        private void clear()
        {
            txtSiteName.Text = "";
            txtUrlFlag.Text = "";
            txtContFlag.Text = "";
            txtRemove.Text = "";
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ruleEdit();
        }
        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ruleEdit();
        }

        private void ruleEdit()
        {
            if (listView1.SelectedItems.Count > 0)
            {
                labID.Text = listView1.SelectedItems[0].SubItems[0].Text;
                txtSiteName.Text = listView1.SelectedItems[0].SubItems[1].Text;
                txtUrlFlag.Text = listView1.SelectedItems[0].SubItems[2].Text;
                txtContFlag.Text = listView1.SelectedItems[0].SubItems[3].Text;
                txtRemove.Text = listView1.SelectedItems[0].SubItems[4].Text;
                btnAdd.Text = "修改";
            }
        }


        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                YQDataSet.RuleRow rw = mf.DS.Rule.FindByRuleID(Int32.Parse(labID.Text));
                rw.Delete();
                mf.ruleTap.Update(rw);
                listView1.SelectedItems[0].Remove();
                reload();
            }
        }
    }
}
