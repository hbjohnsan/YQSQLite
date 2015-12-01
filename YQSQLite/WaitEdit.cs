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
                    where p.IsRead == "W"
                    select p;
            foreach (var it in q)
            {
                RssItem rssit = new RssItem();
                rssit.Title = it.Title;
                rssit.ChannelCode = it.ChannelCode;
                rssit.PubDate = Convert.ToDateTime(it.PubDate);
                rssit.Link = it.Link;
                rssit.Content = it.Content;
                rssit.IsRead = it.IsRead;
                ListViewItem lv = new ListViewItem(it.Title);
                lv.Tag = rssit;
                listView1.Items.Add(lv);
            }
        }

        //加入Rss新闻为预处理
        public void AddRssItem(RssItem item)
        {
            ListViewItem lv = new ListViewItem(item.Title);
            lv.Tag = item;
            listView1.Items.Add(lv);
        }
        //移除
        public void RemoveRssItem()
        {
            if (listView1.SelectedItems.Count > 0)
            {
                RssItem rssit = listView1.SelectedItems[0].Tag as RssItem;
                YQDataSet.RssItemRow row = mf.DS.RssItem.FindByRssItemID(rssit.RssItemID);
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
                RssItem it = lv.Tag as RssItem;
                YQDataSet.RssItemRow row = mf.DS.RssItem.FindByRssItemID(it.RssItemID);
                row.IsRead = "T";
            }
            mf.SaveRssItemToDB(mf.DS.RssItem);
            listView1.Items.Clear();
        }


        
        public void listClear()
        {
            listView1.Items.Clear();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RssItem rssitem = listView1.SelectedItems[0].Tag as RssItem;
            mf.RssToEditFm(rssitem);

        }
    }
}
