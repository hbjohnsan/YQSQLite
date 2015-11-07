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
        }

        private void WaitEdit_Load(object sender, EventArgs e)
        {
            ReLoad();       
        }

        public void ReLoad()
        {
            listView1.Items.Clear();
            var q = from p in mf.DS.RssItem.AsEnumerable()
                    where p.IsRead == "待处理"
                    select p;
            foreach (var it in q)
            {
                RssItem rssit = new RssItem();
                rssit.Title = it.Title;
                rssit.Site = it.Site;
                rssit.PubDate = it.PubDate;
                rssit.Link = it.Link;
                rssit.Content = it.Content;
                rssit.IsRead = it.IsRead;
                ListViewItem lv = new ListViewItem(it.Title);
                lv.Tag = rssit;
                listView1.Items.Add(lv);
            }
        }

        //加入Rss新闻为预处理
        public void AddRssItem(string title)
        {
            SQLiteDS.RssItemRow row = mf.DS.RssItem.FindByTitle(title);
            RssItem rsit = new RssItem();
            rsit.Site = row.Site;
            rsit.Title = row.Title;
            rsit.PubDate = row.PubDate;
            rsit.Link = row.Link;
            rsit.IsRead = row.Link;
            rsit.Content = row.Content;
           
            ListViewItem lv = new ListViewItem(rsit.Title);
            lv.Tag = rsit;
            listView1.Items.Add(lv);
        }
        //移除
        public void RemoveRssItem()
        {
            if (listView1.SelectedItems.Count > 0)
            {
                RssItem rssit = listView1.SelectedItems[0].Tag as RssItem;
                SQLiteDS.RssItemRow row = mf.DS.RssItem.FindByTitle(rssit.Title);
                row.IsRead = "不处理";
                mf.rssTap.Update(row);
                listView1.SelectedItems[0].Remove();
            }
        }
        //全部移除
        public void RemoveAll()
        {
            foreach (ListViewItem lv in listView1.Items)
            {
                RssItem it = lv.Tag as RssItem;
                SQLiteDS.RssItemRow row = mf.DS.RssItem.FindByTitle(it.Title);
                row.IsRead = "不处理";
            }
            mf.rssTap.Update(mf.DS.RssItem);
            listView1.Items.Clear();
        }

        

        private void listView1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                RssItem rssitem = listView1.SelectedItems[0].Tag as RssItem;
                mf.RssToEditFm(rssitem.Title);
            }
        }
        public void listClear()
        {
            listView1.Items.Clear();
        }
    }
}
