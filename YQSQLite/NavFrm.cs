using System;
using WeifenLuo.WinFormsUI.Docking;
using System.Xml.Linq;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Text;
using System.Collections;
using System.Drawing;
using System.Threading;
using System.Text.RegularExpressions;

namespace YQSQLite
{
    public partial class NavFrm : DockContent
    {
        private MainFrm mf;


        public NavFrm()
        {
            InitializeComponent();
        }
        public NavFrm(MainFrm f)
        {
            InitializeComponent();
            this.mf = f;

        }


        private void NavFrm_Load(object sender, EventArgs e)
        {
            ReLoadTree();

        }

        #region 鼠标事件
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //取消 点击事件传递。所有数据在本窗口中处理。
            //mf.NodeClick(sender, e);
            //1、判断点击的项是分类项，还是有采集地址的具体项，可以用Leaf项判断。2、如果是分类项直接从库中显示已采所有数据。如果是采集项则进行下一步的更新采集。
            NavUrl navurl = e.Node.Tag as NavUrl;
            if (navurl.Leaf == 0)//根据Leaf可以判断出是否是分类项。是否用数据库中提取
            {
                //先要清空筛选窗体中listview中的项
                mf.SelectFrmListviewClear();
                var q = from p in mf.DS.RssItem.AsEnumerable()
                        where p.ChannelCode.StartsWith(navurl.Code)
                        orderby p.PubDate descending, p.Title
                        select p;
                foreach (var item in q)
                {
                    RssItem rsit = new RssItem();
                    rsit.RssItemID = item.RssItemID;
                    rsit.ChannelCode = item.ChannelCode;
                  //  rsit.Site = item.Site;
                    rsit.Title = item.Title;
                    rsit.Link = item.Link;
                    rsit.PubDate = item.PubDate;
                    rsit.IsRead = item.IsRead;
                    rsit.Content = item.Content;
                    ListViewItem lv = new ListViewItem(new string[] { rsit.Title, rsit.PubDate.ToString("MM-dd HH:mm:ss"), rsit.ChannelCode });
                    lv.Tag = rsit;
                    mf.SelectFrmListViewReload(lv);
                }

            }
            else//有采集RSS的地址，去采集
            {
                //试用多线程
                Thread t = new Thread(new ThreadStart(delegate
                {
                    DownLoadRssItem(navurl);
                }));
                t.IsBackground = true;
                t.Start();
            }
            RequestRss();
        }
        //去采集下载Rss新闻源列表
        private void DownLoadRssItem(NavUrl navurl)
        {
            #region 正常规则
            try
            {
                //加载RSS新闻数据
                XElement rssData = XElement.Load(navurl.Link);

                //取出新闻标题，转成RssItem对象，并暂存到列表控件中
                var itemQuery = from item in rssData.Descendants(XName.Get("item"))
                                select new
                                {
                                    Title = item.Element(XName.Get("title")).Value.Trim(),
                                    Link = item.Element(XName.Get("link")).Value,
                                    PubDate = item.Element(XName.Get("pubDate")).Value
                                };

                foreach (var result in itemQuery)
                {
                    ////查数据库中是否已有相同标题，没有再追加！
                    //if (!(mf.DS.RssItem.Contains(mf.DS.RssItem.FindByTitle(result.Title))))
                    //{
                    //    RssItem it = new RssItem(cn.ParentTx, result.Title.Trim(), result.Link, Convert.ToDateTime(result.PubDate), "未读", "");
                    //    ListViewItem lv = new ListViewItem(new string[] { it.Title, it.PubDate.ToString("MM-dd HH:mm:ss"), cn.ParentTx });
                    //    lv.Tag = it;
                    //    listView1.Items.Add(lv);

                    //    YQDataSet.RssItemRow rssRow = mf.DS.RssItem.AddRssItemRow(cn.ParentTx, result.Title, result.Link, Convert.ToDateTime(result.PubDate), "未读", "");
                    //    mf.rssTap.Update(rssRow);
                    //}


                    //通过Link查找DataSet中是否有相同的网址
                    //查询RssItem表中，与这个频道相同的项中，是否有相同的网址，如果有不采集
                    int f = (from p in mf.DS.RssItem.AsEnumerable() where (p.ChannelCode == navurl.Code && p.Link == result.Link) select p).ToList().Count;
                    if (f == 0)
                    {
                        RssItem it = new RssItem(navurl.Code, result.Title.Trim(), result.Link, Convert.ToDateTime(result.PubDate), "F", "");
                      //  ListViewItem lv = new ListViewItem(new string[] { it.Title, it.PubDate.ToString("MM-dd HH:mm:ss"), cn.ParentTx });
                      //  lv.Tag = it;
                     //   listView1.Items.Add(lv);

                     YQDataSet.RssItemRow ri=  mf.DS.RssItem.NewRssItemRow();
                     ri.ChannelCode = navurl.Code;
                     ri.Title = result.Title.Trim();
                     ri.Link = result.Link;
                     ri.PubDate = Convert.ToDateTime(result.PubDate);
                     ri.IsRead = "F";
                     mf.DS.RssItem.AddRssItemRow(ri);
                      
                    }
                    mf.rssTap.Update(mf.DS.RssItem);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            #endregion
        }
        #endregion

        #region 刷新重采集
        public void RequestRss()
        {
            NavUrl nu = treeView1.SelectedNode.Tag as NavUrl;
            //先采集回Rss列表，通过link比较DataSet中RssItem中是否有相同的Link数据。如果有去重，如果没有→采集→到库→更新表，显示到筛选表中。
            //

            //试用多线程
            Thread t = new Thread(new ThreadStart(delegate
            {

            }));
            t.IsBackground = true;
            t.Start();
        }
        #endregion
        #region 右键菜单

        //编辑导航
        private void 编辑tsm_Click(object sender, EventArgs e)
        {
            NavEidt NE = new NavEidt(mf);
            NE.ShowDialog();
            if (NE.DialogResult == DialogResult.OK)
            {
                ReLoadTree();
            }
        }

        private void 加载ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReLoadTree();
        }

        #endregion

        #region 重新加载treeview
        //
        public void ReLoadTree()
        {
            treeView1.Nodes.Clear();
            //转换成实体类，把数据放在Tag中这样会方便些。
            List<NavUrl> NavUrls = new List<NavUrl>();
            var q = from p in mf.DS.NavUrl.AsEnumerable()
                    select p;
            foreach (YQDataSet.NavUrlRow kind in q)
            {
                NavUrl nu = new NavUrl();
                nu.ID = (int)kind.ID;
                nu.Name = kind.Name;
                nu.Nav_Domain = kind.Nav_Domain;
                nu.PID = (int)kind.PID;
                nu.Code = kind.Code;
                nu.level = (int)kind.level;
                nu.Leaf = (int)kind.Leaf;
                nu.Link = kind.Link;
                nu.Image = (int)kind.Image;
                nu.ItemCount = (int)kind.ItemCount;
                nu.NoReadCount = (int)kind.NoReadCount;
                NavUrls.Add(nu);
            }

            List<TreeNode> LT = GetTreeNodes(NavUrls);
            foreach (TreeNode tn in LT)
            {

                treeView1.Nodes.Add(tn);
            }


        }


        private List<TreeNode> GetTreeNodes(List<NavUrl> NavUrls)
        {
            //1、得到顶层，
            List<TreeNode> listNavurl = new List<TreeNode>();

            foreach (NavUrl u in NavUrls)
            {
                if (u.PID == 0 && u.level == 0)
                {
                    TreeNode tn = new TreeNode();
                    //实现了信息条目的显示。
                    tn.Text = u.Name + "(" + u.NoReadCount.ToString() + "/" + u.ItemCount.ToString() + ")";
                    tn.ImageIndex = tn.SelectedImageIndex = u.Image;
                    tn.Tag = u;
                    //2、递归子层；
                    FindChildNode(tn, u, NavUrls);
                    listNavurl.Add(tn);
                }
            }

            return listNavurl;
        }
        //子层的递归
        private void FindChildNode(TreeNode tnParent, NavUrl u, List<NavUrl> NavUrls)
        {
            foreach (NavUrl n in NavUrls)
            {
                if (n.PID == u.ID)
                {
                    TreeNode tn = new TreeNode();
                    //实现了信息条目的显示。
                    tn.Text = n.Name + "(" + n.NoReadCount.ToString() + "/" + n.ItemCount.ToString() + ")";
                    tn.ImageIndex = tn.SelectedImageIndex = n.Image;
                    tn.Tag = n;
                    //2、递归子层；
                    FindChildNode(tn, n, NavUrls);
                    tnParent.Nodes.Add(tn);
                }
            }


        }

        #endregion

    }


}
