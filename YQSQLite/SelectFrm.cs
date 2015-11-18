using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using System.Xml.Linq;
using System.Windows.Forms.VisualStyles;
using HtmlAgilityPack;
using ScrapySharp.Extensions;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections;

namespace YQSQLite
{
    public partial class SelectFrm : DockContent
    {
        #region 定义
        private MainFrm mf;
        private ListViewColumnSorter lvwColumnSorter;

        //构造函数

        public SelectFrm()
        {
            InitializeComponent();


        }
        public SelectFrm(MainFrm f)
        {
            InitializeComponent();
            mf = f;
            lvwColumnSorter = new ListViewColumnSorter();
        }
        #endregion

        #region 窗体加载
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectFrm_Load(object sender, EventArgs e)
        {

            // listBox1.DisplayMember = "title";

        }
        #endregion

        #region Rss导航新闻列表事件
        /// <summary>
        /// Rss导航新闻列表事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void NavNodeClik(object sender, TreeNodeMouseClickEventArgs e)
        {
            NavUrl navurl = e.Node.Tag as NavUrl;
           

            if (navurl.Link != null)
            {
                //listView1.Items.Clear();
                //Thread t = new Thread(new ParameterizedThreadStart(CaijiRule));
                //object cn = new clNode(e.Node.Parent.Text, navurl.Link, e.Node.Text);
                //t.IsBackground = true;
                //t.Start(cn);
                //CaijiRule(new clNode(e.Node.Parent.Text, navurl.Link, e.Node.Text));
            }

        }
        //定义委托
        //private delegate void delCaijiRule(clNode e);


        //采集规则
        //private void CaijiRule(object e)
        //{
        //    //clNode cn = e as clNode;
        //    if (this.InvokeRequired == false)
        //    {
        //        #region 新浪规则
        //        //判断新浪sina网站的Url需要截取
        //        // if (cn.Name.Contains("sina"))
        //        //if (cn.Link.Contains("sina.com.cn"))
        //        //{
        //        //    //加载RSS新闻数据
        //        //    Regex regex = new Regex(@"(?<=[=]).*");
        //        //    //http://go.rss.sina.com.cn/redirect.php?url=http://tech.sina.com.cn/it/2013-11-16/09198919884.shtml
        //        //    XElement rssData = XElement.Load(cn.Link);

        //        //    //取出新闻标题，转成RssItem对象，并暂存到列表控件中
        //        //    var itemQuery = from item in rssData.Descendants(XName.Get("item"))
        //        //                    select new
        //        //                    {
        //        //                        Title = item.Element(XName.Get("title")).Value.Trim(),
        //        //                        Link = regex.Match(item.Element(XName.Get("link")).Value).ToString(),
        //        //                        PubDate = item.Element(XName.Get("pubDate")).Value
        //        //                    };
        //        //    foreach (var result in itemQuery)
        //        //    {

        //        //        //查数据库中是否已有相同标题，没有再追加！
        //        //        //if (!(mf.DS.RssItem.Contains(mf.DS.RssItem.FindByTitle(resuslt.Title))))
        //        //        //{
        //        //        //    RssItem it = new RssItem(cn.ParentTx, result.Title.Trim(), result.Link, Convert.ToDateTime(result.PubDate), "未读", "");
        //        //        //    ListViewItem lv = new ListViewItem(new string[] { it.Title, it.PubDate.ToString("MM-dd HH:mm:ss"), cn.ParentTx });
        //        //        //    lv.Tag = it;
        //        //        //    listView1.Items.Add(lv);

        //        //        //    YQDataSet.RssItemRow rssRow = mf.DS.RssItem.AddRssItemRow(cn.ParentTx, result.Title, result.Link, Convert.ToDateTime(result.PubDate), "未读", "");
        //        //        //    mf.rssTap.Update(rssRow);
        //        //        //}

        //        //    }
        //        //}
        //        #endregion

        //        #region 网易规则
        //        //判断163的RSS,提取url时址址数据在guid中
        //        ////163网易
        //        ////http://news.163.com/13/1114/02/9DK05PBU0001124J.html
        //        ////http://news.163.com/13/1114/02/9DK05PBU0001124J_all.html
        //        //if (cn.Name.Contains("163"))
        //        //{
        //        //    //加载RSS新闻数据
        //        //    //string s1 = "http://news.163.com/13/1114/02/9DK05PBU0001124J.html";
        //        //    //string s = s1.Insert(s1.LastIndexOf('.'),"_all");
        //        //    //MessageBox.Show(s);

        //        //    XElement rssData = XElement.Load(cn.Link);

        //        //    //取出新闻标题，转成RssItem对象，并暂存到列表控件中
        //        //    var itemQuery = from item in rssData.Descendants(XName.Get("item"))
        //        //                    select new
        //        //                    {
        //        //                        Title = item.Element(XName.Get("title")).Value.Trim(),
        //        //                        Link = item.Element(XName.Get("guid")).Value,
        //        //                        PubDate = item.Element(XName.Get("pubDate")).Value
        //        //                    };
        //        //    foreach (var result in itemQuery)
        //        //    {

        //        //        //查数据库中是否已有相同标题，没有再追加！
        //        //        if (!(mf.DS.RssItem.Contains(mf.DS.RssItem.FindByTitle(result.Title))))
        //        //        {
        //        //            RssItem it = new RssItem(cn.ParentTx, result.Title.Trim(), (result.Link.Insert(result.Link.LastIndexOf("."), "_all")), Convert.ToDateTime(result.PubDate), "未读", "");
        //        //            ListViewItem lv = new ListViewItem(new string[] { it.Title, it.PubDate.ToString("MM-dd HH:mm:ss"), cn.ParentTx });
        //        //            lv.Tag = it;
        //        //            listView1.Items.Add(lv);
        //        //            YQDataSet.RssItemRow rssRow = mf.DS.RssItem.AddRssItemRow(cn.ParentTx, result.Title, (result.Link.Insert(result.Link.LastIndexOf("."), "_all")), Convert.ToDateTime(result.PubDate), "未读", "");
        //        //            mf.rssTap.Update(rssRow);
        //        //        }

        //        //    }
        //        //}
        //        #endregion

        //        #region 新华网规则
        //        //if (cn.Name.Contains("xinhuanet"))
        //        //{
        //        //    //加载RSS新闻数据
        //        //    XElement rssData = XElement.Load(cn.Link);

        //        //    //看来只能用正规截取了！
        //        //    //<link>http://news.xinhuanet.com/shuhua/2013-11/16/c_125712954.htm</link> 
        //        //    //Sat,16-Nov-2013 11:33:12 GMT 
        //        //    //<description>
        //        //    Regex regex = new Regex(@"(?<=<\/link>)(.*?)(?=<description>)");
        //        //    //想到的办法：一是通过xelement对象，正规取得；二是在源码中加入pubDate标签。
        //        //    //取出新闻标题，转成RssItem对象，并暂存到列表控件中
        //        //    #region test
        //        //    //var i = rssData.Descendants(XName.Get("item")).First();
        //        //    //MessageBox.Show(i.ToString());//保留了xelement格式。
        //        //    //去除标题的a标签。
        //        //    Regex regTitle = new Regex(@"</?.+?>");
        //        //    //去除连接中的双引号                       
        //        //    //string s="\"http://news.xinhuanet.com/edu/2013-10/11/c_125515383.htm\"";
        //        //    //MessageBox.Show(s.Replace("\"", ""));
        //        //    #endregion
        //        //    var itemQuery = from item in rssData.Descendants(XName.Get("item"))
        //        //                    select new
        //        //                    {
        //        //                        Title = regTitle.Replace(item.Element(XName.Get("title")).Value.Trim(), ""),
        //        //                        Link = item.Element(XName.Get("link")).Value.Replace("\"", ""),
        //        //                        PubDate = regex.Match(item.ToString()).ToString()
        //        //                        //PubDate = item.Element(XName.Get("pubDate")).Value

        //        //                    };

        //        //    foreach (var result in itemQuery)
        //        //    {



        //        //        //查数据库中是否已有相同标题，没有再追加！
        //        //        if (!(mf.DS.RssItem.Contains(mf.DS.RssItem.FindByTitle(result.Title))))
        //        //        {
        //        //            RssItem it = new RssItem(cn.ParentTx, result.Title.Trim(), result.Link, Convert.ToDateTime(result.PubDate), "未读", "");
        //        //            ListViewItem lv = new ListViewItem(new string[] { it.Title, it.PubDate.ToString("MM-dd HH:mm:ss"), cn.ParentTx });
        //        //            lv.Tag = it;
        //        //            listView1.Items.Add(lv);

        //        //            YQDataSet.RssItemRow rssRow = mf.DS.RssItem.AddRssItemRow(cn.ParentTx, result.Title, result.Link, Convert.ToDateTime(result.PubDate), "未读", "");
        //        //            mf.rssTap.Update(rssRow);
        //        //        }

        //        //    }
        //        //}
        //        #endregion

        //        #region FT中文
        //        //加入全文采集规则 http://www.ftchinese.com/story/001053357?full=y
        //        //if (cn.Name.Contains("ftchinese"))
        //        //{

        //        //    XElement rssData = XElement.Load(cn.Link);

        //        //    //取出新闻标题，转成RssItem对象，并暂存到列表控件中
        //        //    var itemQuery = from item in rssData.Descendants(XName.Get("item"))
        //        //                    select new
        //        //                    {
        //        //                        Title = item.Element(XName.Get("title")).Value.Trim(),
        //        //                        Link = item.Element(XName.Get("link")).Value,
        //        //                        PubDate = item.Element(XName.Get("pubDate")).Value
        //        //                    };
        //        //    foreach (var result in itemQuery)
        //        //    {

        //        //        //查数据库中是否已有相同标题，没有再追加！
        //        //        //if (!(mf.DS.RssItem.Contains(mf.DS.RssItem.FindByTitle(result.Title + "?full=y"))))
        //        //        //{
        //        //        //    RssItem it = new RssItem(cn.ParentTx, result.Title.Trim(), (result.Link + "?full=y"), Convert.ToDateTime(result.PubDate), "未读", "");
        //        //        //    ListViewItem lv = new ListViewItem(new string[] { it.Title, it.PubDate.ToString("MM-dd HH:mm:ss"), cn.ParentTx });
        //        //        //    lv.Tag = it;
        //        //        //    listView1.Items.Add(lv);

        //        //        //    YQDataSet.RssItemRow rssRow = mf.DS.RssItem.AddRssItemRow(cn.ParentTx, result.Title, (result.Link + "?full=y"), Convert.ToDateTime(result.PubDate), "未读", "");
        //        //        //    mf.rssTap.Update(rssRow);
        //        //        //}

        //        //    }
        //        //}
        //        #endregion

        //        //else
        //        //{
        //            #region 正常规则
        //            //try
        //            //{
        //            //    //加载RSS新闻数据
        //            //    XElement rssData = XElement.Load(cn.Link);

        //            //    //取出新闻标题，转成RssItem对象，并暂存到列表控件中
        //            //    var itemQuery = from item in rssData.Descendants(XName.Get("item"))
        //            //                    select new
        //            //                    {
        //            //                        Title = item.Element(XName.Get("title")).Value.Trim(),
        //            //                        Link = item.Element(XName.Get("link")).Value,
        //            //                        PubDate = item.Element(XName.Get("pubDate")).Value
        //            //                    };

        //            //    foreach (var result in itemQuery)
        //            //    {
        //            //        //查数据库中是否已有相同标题，没有再追加！
        //            //        if (!(mf.DS.RssItem.Contains(mf.DS.RssItem.FindByTitle(result.Title))))
        //            //        {
        //            //            RssItem it = new RssItem(cn.ParentTx, result.Title.Trim(), result.Link, Convert.ToDateTime(result.PubDate), "未读", "");
        //            //            ListViewItem lv = new ListViewItem(new string[] { it.Title, it.PubDate.ToString("MM-dd HH:mm:ss"), cn.ParentTx });
        //            //            lv.Tag = it;
        //            //            listView1.Items.Add(lv);

        //            //            YQDataSet.RssItemRow rssRow = mf.DS.RssItem.AddRssItemRow(cn.ParentTx, result.Title, result.Link, Convert.ToDateTime(result.PubDate), "未读", "");
        //            //            mf.rssTap.Update(rssRow);
        //            //        }

        //            //    }


        //            //}
        //            //catch (Exception ex)
        //            //{
        //            //    MessageBox.Show(ex.ToString());
        //            //}
        //            #endregion
        //        }
        //    }
        //    //else
        //    //{
        //    //    //delCaijiRule delcj = new delCaijiRule(CaijiRule);
        //    //    //this.BeginInvoke(delcj, e);
        //    //}
        //}
        #endregion
        //todo:采集评论

        #region 采集信息事件
        //加入
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //if (listBox1.SelectedItems.Count > 0)
            if (listView1.SelectedItems.Count > 0)
            {
                for (int i = 0; i < listView1.SelectedItems.Count; i++)
                {
                    // RssItem rssitem = listBox1.SelectedItems[0] as RssItem;
                    RssItem rssitem = listView1.SelectedItems[0].Tag as RssItem;
                    YQDataSet.RssItemRow rssrow = mf.DS.RssItem.FindByRssItemID(rssitem.RssItemID);
                    rssrow.IsRead = "W";            //待处理 变为 W
                    rssrow.Content = htmlEditor1.HTML;
                    mf.NewsAdd(rssitem.RssItemID);
                    // listBox1.Items.Remove(rssitem);
                    listView1.SelectedItems[0].Remove();
                    mf.rssTap.Update(mf.DS.RssItem.FindByRssItemID(rssitem.RssItemID));
                    htmlEditor1.HTML = "";
                }
            }
        }
        //全加
        private void btnAddAll_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lv in listView1.Items)
            {
                RssItem ri = lv.Tag as RssItem;
                ri.IsRead = "W";
                mf.NewsAdd(ri.RssItemID);
            }
            mf.rssTap.Update(mf.DS.RssItem);
            listView1.Items.Clear();
        }
        //移除
        private void btnRemove_Click(object sender, EventArgs e)
        {
            mf.NewsRemove();
        }
        //全部移除
        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            mf.RemoveAll();
        }
        //不选
        private void btnsSelect_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                RssItem rssitem = listView1.SelectedItems[0].Tag as RssItem;
                YQDataSet.RssItemRow rssrow = mf.DS.RssItem.FindByRssItemID(rssitem.RssItemID);
                rssrow.IsRead = "T";    //已读变为 T
                listView1.SelectedItems[0].Remove();
                mf.rssTap.Update(mf.DS.RssItem.FindByRssItemID(rssitem.RssItemID));
            }
        }
        //全不选
        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lv in listView1.Items)
            {
                RssItem ri = lv.Tag as RssItem;
                YQDataSet.RssItemRow rssrow = mf.DS.RssItem.FindByRssItemID(ri.RssItemID);
                rssrow.IsRead = "T";
            }
            mf.rssTap.Update(mf.DS.RssItem);
            listView1.Items.Clear();
        }

        #endregion

        #region 新闻列表点击，得到正文
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //不做点一次，采集一次了。把内容一次全部采集到库

            //if (listView1.SelectedItems.Count != 0)
            //{
            //    listView1.SelectedItems[0].BackColor = Color.Bisque;
            //    RssItem it = listView1.SelectedItems[0].Tag as RssItem;
            //    //初始化
            //    rtbCode.Clear();
            //    rtbText.Clear();
            //    htmlEditor1.HTML = "";
            //    DownContent(it.Link);
            //}
        }
        //定义不同网站，不同的正文定义，和排除部分源码标记
        private void DownContent(string link)
        {

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
                            CastCont(link, item.ContFlag, delflag);
                        }
                        else
                        {
                            CastCont(link, item.ContFlag);
                        }
                    }
                }
            }

        }
        //截取正文内容部分方法的重构，
        private void CastCont(string link, string FlagCont)
        {
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
            rtbCode.Text = html;
            var reCont = Nodes.CssSelect(FlagCont);
            foreach (var doc in reCont)
            {
                htmlEditor1.HTML = doc.InnerHtml;
                rtbText.Text = doc.InnerText;

            }
        }
        private void CastCont(string link, string FlagCont, string[] DelFlag)
        {
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
            rtbCode.Text = html;
            var reCont = Nodes.CssSelect(FlagCont);
            foreach (var doc in reCont)
            {
                for (int i = 0; i < DelFlag.Length; i++)
                {
                    foreach (var Del in reCont.CssSelect(DelFlag[i]).ToArray())
                        Del.Remove();
                }
                htmlEditor1.HTML = doc.InnerHtml;
                rtbText.Text = doc.InnerText;

            }
        }
        #endregion

        private void 浏览器打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                RssItem rssitem = listView1.SelectedItems[0].Tag as RssItem;
                mf.OpenUrl(rssitem.Link);
            }
        }

        private void 外部器打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (listView1.SelectedItems.Count > 0)
            {
                RssItem rssitem = listView1.SelectedItems[0].Tag as RssItem;

                //System.Diagnostics.Process.Start("IExplore.exe", "http://www.baidu.com");
                //需要指定IExplore.exe，不然将使用系统默认浏览器打开，比如可能是Firefox
                System.Diagnostics.Process.Start(rssitem.Link);
            }
        }

        public void listClear()
        {
            listView1.Items.Clear();
        }


        #region listView排序功能
        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvwCustomer_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            this.listView1.Columns[lvwColumnSorter.SortColumn].ImageIndex = 2;
            if (listView1.Items.Count > 0)
            {
                //设置listView1的排序器
                this.listView1.ListViewItemSorter = lvwColumnSorter;
                listView1.Columns[e.Column].ImageIndex = 1;
                if (e.Column == lvwColumnSorter.SortColumn)
                {
                    // 检查点击的列是不是现在的排序列.
                    if (lvwColumnSorter.Order == SortOrder.Ascending)
                    {
                        // 重新设置此列的排序方法.
                        lvwColumnSorter.Order = SortOrder.Descending;
                        listView1.Columns[e.Column].ImageIndex = 0;
                    }
                    else
                    {
                        // 设置排序列，默认为正向排序
                        lvwColumnSorter.Order = SortOrder.Ascending;
                        listView1.Columns[e.Column].ImageIndex = 1;
                    }
                }
                else
                {
                    lvwColumnSorter.SortColumn = e.Column;
                    lvwColumnSorter.Order = SortOrder.Ascending;
                    listView1.Columns[e.Column].ImageIndex = 0;
                }
                // 用新的排序方法对ListView排序
                this.listView1.Sort();
            }


        }
        /// <summary>
        /// 对ListView的列进行比较排序
        /// </summary>
        public class ListViewColumnSorter : IComparer
        {
            private int ColumnToSort;  //指定按照哪列排序
            private SortOrder OrderOfSort;  //指定排序的方式
            private CaseInsensitiveComparer ObjectCompare;  //声明CaaseInsensitiveComparer类对象
            public ListViewColumnSorter()  //构造函数
            {
                ColumnToSort = 0;  //默认按第一列排序
                OrderOfSort = SortOrder.None;  //排序
                ObjectCompare = new CaseInsensitiveComparer();  //初始化CaseInsensitiveComparer类对象
            }
            //重写IComparer接口
            //返回比较的结果:如果x=y返回0；如果x>y返回1；如果x<y返回-1
            public int Compare(object x, object y)
            {
                int compareResult;
                ListViewItem listViewX, listViewY;
                //将比较对象转换为ListViewItem对象
                listViewX = (ListViewItem)x;
                listViewY = (ListViewItem)y;
                //比较
                compareResult = ObjectCompare.Compare(listViewX.SubItems[ColumnToSort].Text, listViewY.SubItems[ColumnToSort].Text);
                // 返回比较的结果
                if (OrderOfSort == SortOrder.Ascending)
                {
                    // 因为是正序排序，所以直接返回结果
                    return compareResult;
                }
                else if (OrderOfSort == SortOrder.Descending)
                {
                    // 如果是反序排序，所以要取负值再返回
                    return (-compareResult);
                }
                else
                {
                    return 0;
                }
            }
            /// 获取并设置按照哪一列排序. 
            public int SortColumn
            {
                set
                {
                    ColumnToSort = value;
                }
                get
                {
                    return ColumnToSort;
                }
            }
            /// 获取并设置排序方式.
            public SortOrder Order
            {
                set
                {
                    OrderOfSort = value;
                }
                get
                {
                    return OrderOfSort;
                }
            }
        }
        #endregion

        #region 导步更新ListView
        public void ReloadLiatView(ListViewItem it)
        {
            this.Invoke(new ThreadStart(delegate
            {
               
                listView1.Items.Add(it);
            }));
            
        }
        #endregion
    }
}
