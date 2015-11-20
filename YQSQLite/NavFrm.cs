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
using HtmlAgilityPack;
using ScrapySharp.Extensions;
using System.Threading.Tasks;


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
          
            //先要清空筛选窗体中listview中的项
            mf.SelectFrmListviewClear();
            //1、判断点击的项是分类项，还是有采集地址的具体项，可以用Leaf项判断。
            //2、如果是分类项直接从库中显示已采所有数据,如果是采集项则进行下一步的更新采集。
            NavUrl navurl = e.Node.Tag as NavUrl;
            switch (navurl.Leaf)
            {
                case 0:     //是分类项，从DS中显示内容
                    ReloadSelectFrmListView(navurl);
                    break;
                case 1:    //是有RSS地址的项
                    if ((from p in mf.DS.RssItem.AsEnumerable() where p.ChannelCode == navurl.Code select p.RssItemID).Count() > 0)
                    {
                        //如果库中有部分内容，则显示
                        ReloadSelectFrmListView(navurl);
                    }
                    //去采集
                    DownLoadRssItem(navurl);
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 重新加载SelectFrmListView
        /// <summary>
        /// 重新加载SelectFrmListView
        /// </summary>
        /// <param name="navurl"></param>
        private void ReloadSelectFrmListView(NavUrl navurl)
        {
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
        #endregion

        #region 去采集下载Rss新闻源列表
        private void DownLoadRssItem(NavUrl navurl)
        {
            /*
             * 采集分有RSS采集，等8类。Rss采集只是其中一类。
             * Rss采集中《新华网》采规则又有不同，需要单独取出。
             * 
             */
            switch (navurl.Code.Substring(0, 2))//取出大项分类01－08，
            {
                case "01"://此项为Rss采集
                    switch (navurl.Code.Substring(0, 4))//判断特殊规则，如新华网
                    {
                        case "0108"://新闻网、百度新闻订阅

                            break;
                        default://正常内容rss2.0
                            Nomal_GetRssXml(navurl);
                            break;
                    }
                    break;
                case "02"://网站新闻
                    break;
                case "03"://论坛
                    break;
                case "04"://博客
                    break;
                case "05"://微博
                    break;
                case "06"://微信
                    break;
                case "07"://客户端
                    break;
                case "08"://外网
                    break;
                default:

                    break;
            }



        }
        #endregion


        #region 正常规则
        private void Nomal_GetRssXml(NavUrl navurl)
        {
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
                //用于标记本次新采集了多少条。

                foreach (var result in itemQuery)
                {

                    //通过Link查找DataSet中是否有相同的网址
                    //查询RssItem表中，与这个频道相同的项中，是否有相同的网址，如果有不采集  加上网站去重，用title
                    int f = (from p in mf.DS.RssItem.AsEnumerable() where (p.Link == result.Link || p.Title == result.Title) select p).ToList().Count;
                    //取得最大ID值+1; 
                    int maxId;
                    if ((from rs in mf.DS.RssItem.AsEnumerable() select rs.RssItemID).Count() == 0)
                    {
                        maxId = 1;
                    }
                    else
                    {
                        maxId = (from rs in mf.DS.RssItem.AsEnumerable() select rs.RssItemID).Max() + 1;
                    }

                    if (f == 0)
                    {
                        RssItem it = new RssItem(maxId, navurl.Code, result.Title.Trim(), result.Link, Convert.ToDateTime(result.PubDate), "F", "");

                        ListViewItem lv = new ListViewItem(new string[] { it.Title, it.PubDate.ToString("MM-dd HH:mm:ss"), navurl.Code });
                        lv.Tag = it;
                        mf.SelectFrmListViewReload(lv);
                        //方法二：在DataSet中添加行，然后一次提交到库
                        mf.DS.RssItem.AddRssItemRow(it.RssItemID, it.ChannelCode, it.Title, it.Link, it.PubDate, it.IsRead, it.Content);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            //统计RssItem表中的数量，更新NavUrl中的ItemCount和NoReadCount数量
        
            //需要更新RSS统计
            Thread th = new Thread(new ThreadStart(delegate
            { 
                mf.CountNum_RssItem2NavUrl();
          
                UpdataNodeText(navurl);
                //连点数据出错，
                // mf.rssTap.Update(mf.DS.RssItem);
               
            }));
            th.IsBackground = true;
            th.Start();
        }
        #endregion


        //采集方法
        private string GetSiteContent(string link)
        {
            string reContent = "";
            Uri u = new Uri(link);

            var q = from p in mf.DS.Rule.AsEnumerable()
                    select new { url = p.Rule_Domain };
            var qall = from p in mf.DS.Rule.AsEnumerable()
                       select p;
            foreach (var site in q)
            {
                if (u.Host.Contains(site.url))
                {
                    foreach (var item in qall)
                    {
                        if (item.ContFlag != "")
                        {
                            string[] delflag = item.RemoveFlag.Split(new char[] { ',' });
                            reContent = CastCont(link, item.ContFlag, delflag);
                        }
                        else
                        {
                            reContent = CastCont(link, item.ContFlag);
                        }
                    }
                }
            }
            return reContent;
        }

        //截取正文内容部分方法的重构，
        private string CastCont(string link, string FlagCont)
        {
            string reContent = "";
            #region 使用HttpHelper取得源码
            HttpHelper http = new HttpHelper();
            HttpItem item = new HttpItem()
            {
                URL = link
            };
            HttpResult result = http.GetHtml(item);
            string html = result.Html;
            #endregion
            #region 使用HtmlAgilityPack解析源码
            HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
            htmlDocument.LoadHtml(html);
            var Nodes = htmlDocument.DocumentNode;
            #endregion
            //初始化
            // rtbCode.Text = html;
            var reCont = Nodes.CssSelect(FlagCont);
            foreach (var doc in reCont)
            {
                // htmlEditor1.HTML = doc.InnerHtml;
                // rtbText.Text = doc.InnerText;
                reContent = doc.InnerText;
            }
            return reContent;
        }
        private string CastCont(string link, string FlagCont, string[] DelFlag)
        {
            string reContent = "";
            #region 使用HttpHelper取得源码
            HttpHelper http = new HttpHelper();
            HttpItem item = new HttpItem()
            {
                URL = link
            };
            HttpResult result = http.GetHtml(item);
            string html = result.Html;
            #endregion
            #region 使用HtmlAgilityPack解析源码
            HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
            htmlDocument.LoadHtml(html);
            var Nodes = htmlDocument.DocumentNode;
            #endregion
            //初始化
            //rtbCode.Text = html;
            var reCont = Nodes.CssSelect(FlagCont);
            foreach (var doc in reCont)
            {
                for (int i = 0; i < DelFlag.Length; i++)
                {
                    foreach (var Del in reCont.CssSelect(DelFlag[i]).ToArray())
                        Del.Remove();
                }
                //htmlEditor1.HTML = doc.InnerHtml;
                //rtbText.Text = doc.InnerText;
                reContent += doc.InnerText;
            }
            return reContent;
        }



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

        #region 异步扫行选中的Node的text值 用于显示已有多少条数据和有多少条未读
        public void UpdataNodeText(NavUrl nv)
        {
            this.Invoke(new ThreadStart(delegate
            {

                #region 简单的方法，通过查找父节点，来更改。
                YQDataSet.NavUrlRow nur = mf.DS.NavUrl.FindByID(nv.ID);
                treeView1.SelectedNode.Text = nv.Name + "(" + nur.NoReadCount + "/" + nur.ItemCount + ")";

                //更新node的父显示
                NavUrl pnu = treeView1.SelectedNode.Parent.Tag as NavUrl;
                YQDataSet.NavUrlRow pnur = mf.DS.NavUrl.FindByID(pnu.ID);
                treeView1.SelectedNode.Parent.Text = pnur.Name + "(" + pnur.NoReadCount + "/" + pnur.ItemCount + ")";

                //再一级的父目录
                NavUrl Gpnu = treeView1.SelectedNode.Parent.Parent.Tag as NavUrl;
                YQDataSet.NavUrlRow Gpnur = mf.DS.NavUrl.FindByID(Gpnu.ID);
                treeView1.SelectedNode.Parent.Parent.Text = pnur.Name + "(" + Gpnur.NoReadCount + "/" + Gpnur.ItemCount + ")";
                #endregion

                #region 通过Code值，搜索treeview节点更改。
                //for (int i = 0; i < treeView1.Nodes.Count; i++)
                //{
                //    string sort2code = nv.Code.Substring(0, 2);
                //    NavUrl nav = treeView1.Nodes[i].Tag as NavUrl;
                //    if (treeView1.Nodes[i].Tag)
                //    {

                //    }
                //}
                //  Parallel.For(0, treeView1.Nodes.Count, (i) => { treeView1.Nodes[i].Tag});
                #endregion
            }));
        }
        #endregion



    }


}
