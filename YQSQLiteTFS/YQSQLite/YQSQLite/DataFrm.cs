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
    public partial class DataFrm : DockContent
    {
        private MainFrm mf;
        public DataFrm()
        {
            InitializeComponent();
        }
        public DataFrm(MainFrm f)
        {
            InitializeComponent();
            mf = f;
        }

        private void DataFrm_Load(object sender, EventArgs e)
        {
            cmbTime.Text = DateTime.Now.ToString();

            ReLoad();
        }
        private void ReLoad()
        {
            listView1.Items.Clear();
            var q = from p in mf.DS.cpcuse.AsEnumerable()
                    select p;
            if (mf.ZC)
            {
                foreach (var i in q)
                {
                    ListViewItem li = new ListViewItem(i.Title);
                    li.Tag = i.Id;
                    listView1.Items.Add(li);
                }
            }
            else
            {
                for (int i = 0; i < 30; i++)
                {
                    DataRow rw = mf.DS.cpcuse.Rows[i];
                    cpcuse cpc = new cpcuse();
                    cpc.Id = Int32.Parse(rw[0].ToString());
                    //cpc.Rank = rw[1].ToString();
                    //cpc.Term = rw[2].ToString(); ;
                    //cpc.KanWu = rw[3].ToString();
                    //cpc.UseTime = Convert.ToDateTime(rw[4].ToString());
                    cpc.Title = rw[5].ToString();
                    //cpc.InTime = Convert.ToDateTime(rw[6].ToString());
                    ListViewItem li = new ListViewItem(cpc.Title);
                    li.Tag = cpc.Id;
                    listView1.Items.Add(li);
                }
            }

            labTotal.Text = "共有：" + listView1.Items.Count.ToString() + "条";
        }



        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            int tagid = Int32.Parse(listView1.SelectedItems[0].Tag.ToString());
            labID.Text = tagid.ToString();
            var q = from p in mf.DS.cpcuse.AsEnumerable()
                    where p.Id == tagid
                    select p;
            foreach (var it in q)
            {
                cmbTime.Text = it.UseTime.ToString();
                cmbKw.Text = it.KanWu;
                cmbQs.Text = it.Term;
                txtTitle.Text = it.Title;
                htmlEditor1.HTML = it.Content;
                if (it.Rank == "中宣")
                {
                    rabZX.Checked = true;
                }
                if (it.Rank == "省")
                {

                    rabSheng.Checked = true;
                }
                if (it.Rank == "市")
                {
                    rabShi.Checked = true;
                }
                if (it.Rank == "县")
                {
                    rabXian.Checked = true;
                }
            }


        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定删除？删除后数据无法回复！", "删除", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SQLiteDS.cpcuseRow cpcrow = mf.DS.cpcuse.FindById(Int32.Parse(labID.Text));
                mf.DS.cpcuse.Rows.Remove(cpcrow);
                mf.cpcTap.Update(cpcrow);
                ReLoad();
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定提交修改？", "修改", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string mrank = "";

                foreach (Control item in groupBox1.Controls)
                {
                    RadioButton ra = item as RadioButton;
                    if (ra.Checked)
                    {
                        mrank = ra.Text;
                    }
                }
                SQLiteDS.cpcuseRow cr = mf.DS.cpcuse.FindById(Int32.Parse(labID.Text));
                cr.Rank = mrank;
                cr.UseTime = Convert.ToDateTime(cmbTime.Text);
                cr.Term = cmbQs.Text;
                cr.KanWu = cmbKw.Text;
                cr.Title = txtTitle.Text;
                cr.Content = htmlEditor1.HTML;
                mf.cpcTap.Update(cr);
                ReLoad();
            }
            txtTitle.Text = "";
            htmlEditor1.HTML = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string sRank = "";
            foreach (Control item in groupBox1.Controls)
            {
                RadioButton ra = item as RadioButton;
                if (ra.Checked)
                {
                    sRank = ra.Text;
                }
            }
            // mf.cpcuseTap.InsertQuery(sRank, Convert.ToDateTime(cmbTime.Text), cmbQs.Text, txtTitle.Text, htmlEditor1.HTML, cmbKw.Text);
            SQLiteDS.cpcuseRow cr = mf.DS.cpcuse.NewcpcuseRow();
            cr.Rank = sRank;
            cr.UseTime = Convert.ToDateTime(cmbTime.Text);
            cr.Term = cmbQs.Text;
            cr.KanWu = cmbKw.Text;
            cr.Title = txtTitle.Text;
            cr.Content = htmlEditor1.HTML;

            mf.cpcTap.Update(cr);
            mf.DS.cpcuse.Dispose();
            mf.cpcTap.Fill(mf.DS.cpcuse);

            txtTitle.Text = "";
            htmlEditor1.HTML = "";
            ReLoad();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DataRow[] dr = mf.DS.cpcuse.Select("Title like '%" + txtSearch.Text.Trim() + "%'");
            listView1.Items.Clear();
            foreach (var item in dr)
            {
                ListViewItem li = new ListViewItem(item[5].ToString());
                li.Tag = item[0].ToString();
                listView1.Items.Add(li);

            }
            labTotal.Text = "共有：" + listView1.Items.Count.ToString() + "条";
        }

        private void rab_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Text == "全部")
            {
                listView1.Items.Clear();
                var q = from p in mf.DS.cpcuse.AsEnumerable()
                        select p;
                foreach (var i in q)
                {
                    ListViewItem li = new ListViewItem(i.Title);
                    li.Tag = i.Id;
                    listView1.Items.Add(li);
                }
                labTotal.Text = "共有：" + listView1.Items.Count.ToString() + "条";
            }
            else
            {
                ShowRank("rank ='" + ((RadioButton)sender).Text + "'");
            }

        }

        private void ShowRank(string ss)
        {
            listView1.Items.Clear();
            DataRow[] rw = mf.DS.cpcuse.Select(ss);

            foreach (var item in rw)
            {
                ListViewItem lt = new ListViewItem(item[4].ToString());
                lt.Tag = item[0].ToString();
                listView1.Items.Add(lt);
            }
            labTotal.Text = "共有：" + listView1.Items.Count.ToString() + "条";
        }

    }
}
