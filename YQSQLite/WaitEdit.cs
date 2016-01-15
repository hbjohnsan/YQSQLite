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
    public partial class WaitEdit : DockContent
    {
        private MainFrm mf;
        public WaitEdit()
        {
            InitializeComponent();
        }
        public WaitEdit(MainFrm f)
        {
            InitializeComponent();
            mf = f; 
            ReLoad();
        }

        private void WaitEdit_Load(object sender, EventArgs e)
        {
           
        }

        public void ReLoad()
        {
            listView1.Items.Clear();
            var q = from p in mf.DS.RssItem.AsEnumerable()
                    where p.IsRead == "W"
                    select p;
            foreach (var it in q)
            {
                ListViewItem lv = new ListViewItem(it.Title);
                lv.Tag =it.RssItemID;
                listView1.Items.Add(lv);
            }
        }

        //加入Rss新闻为预处理
        public void AddRssItem(int ID)
        {
            YQDataSet.RssItemRow ri = mf.DS.RssItem.FindByRssItemID(ID);
            ListViewItem lv = new ListViewItem(ri.Title);
            lv.Tag = ID;
            listView1.Items.Add(lv);
        }
        //移除
        public void RemoveRssItem()
        {
            if (listView1.SelectedItems.Count > 0)
            {
                int id = Int32.Parse(listView1.SelectedItems[0].Tag.ToString());
                YQDataSet.RssItemRow row = mf.DS.RssItem.FindByRssItemID(id);
                row.IsRead = "T";
                mf.rssTap.Update(row);
                listView1.SelectedItems[0].Remove();
            }
        }
        //全部移除
        public void RemoveAll()
        {
            foreach (ListViewItem lv in listView1.Items)
            {
                int id = Int32.Parse(listView1.SelectedItems[0].Tag.ToString());
                YQDataSet.RssItemRow row = mf.DS.RssItem.FindByRssItemID(id);
                row.IsRead = "T";
            }
            mf.SaveRssItemToDB(mf.DS.RssItem);
            listView1.Items.Clear();
        }



        public void listClear()
        {
            listView1.Items.Clear();
        }

      

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                int id = Int32.Parse(listView1.SelectedItems[0].Tag.ToString());
                mf.RssToEditFm(id);
            }
        }
    }
}
