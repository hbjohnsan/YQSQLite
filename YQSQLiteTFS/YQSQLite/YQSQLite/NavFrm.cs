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
            // _downlaoddelegate = new DownLoadDelegate(download);
        }


        private void NavFrm_Load(object sender, EventArgs e)
        {
            //todo:NavFrm查找/data/目录中Nav.xml文件，有而加载到node
            if (!File.Exists(mf.DirXml + @"\Nav.xml"))
            {
                SaveTOXml();
            }
            UpdateAllNews();
        }

        #region 下载Xml文件方法
        //定义委托
        private delegate void DownLoadDelegate(string url, string filename);
        private DownLoadDelegate _downlaoddelegate;
        /// <summary>
        /// 文件下载
        /// </summary>
        /// <param name="url"></param>
        /// <param name="filemane"></param>
        private void download(string url, string filemane)
        {
            System.Net.WebClient wc = new System.Net.WebClient();
            wc.DownloadFile(url, filemane);
        }
        private void dlNode()
        {
            showNode(treeView1.Nodes);
        }
        private void showNode(TreeNodeCollection node)
        {
            foreach (TreeNode n in node)
            {
                if (n.GetNodeCount(false) == 0)
                {
                    if (n.Tag != null)
                    {
                        Thread thread = new Thread(new ThreadStart(delegate
                        {
                            this.BeginInvoke(_downlaoddelegate, n.Tag.ToString(), mf.DirData + @"\" + n.Name + ".xml");
                        }));
                        thread.IsBackground = true;
                        thread.Start();
                    }
                }
                showNode(n.Nodes);
            }

        }
        #endregion

        #region Linq方法实现TreeViewToXml
        //保存
        private void SaveTOXml()
        {
            XDeclaration dec = new XDeclaration("1.0", "utf-8", "yes");
            XDocument xml = new XDocument(dec);

            XElement root = new XElement("Tree");

            foreach (TreeNode node in treeView1.Nodes)
            {
                XElement e = CreateElements(node);
                root.Add(e);
            }
            xml.Add(root);
            xml.Save(mf.DirXml + @"\Nav.xml");
        }

        private XElement CreateElements(TreeNode node)
        {
            XElement root = CreateElement(node);
            foreach (TreeNode n in node.Nodes)
            {
                XElement e = CreateElements(n);
                root.Add(e);
            }
            return root;
        }

        private XElement CreateElement(TreeNode node)
        {
            return new XElement("Node",
                new XAttribute("Name", node.Name),
                new XAttribute("Text", node.Text),
                new XAttribute("ImageIndex", node.ImageIndex),
                new XAttribute("SelectedImageIndex", node.SelectedImageIndex),
               new XElement("site", node.Tag));
        }
        #endregion

        #region Xml加载到TreeView
        private void ReLoadTree()
        {
            treeView1.Nodes.Clear();
            //todo:不会。
        }

        #endregion

        #region 鼠标事件
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            mf.NodeClick(sender, e);
        }


        /// <summary>
        /// 双击修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //if (e.Button == MouseButtons.Left)
            //{
            //    Point ClickPoint = new Point(e.X, e.Y);
            //    TreeNode CurrentNode = treeView1.GetNodeAt(ClickPoint);
            //    if (CurrentNode != null)//判断你点的是不是一个节点
            //    {
            //        treeView1.SelectedNode = CurrentNode;//选中这个节点
            //        treeView1.LabelEdit = true;
            //        treeView1.SelectedNode.BeginEdit();
            //    }
            //}
        }

        #endregion

        #region 右键菜单
        //添加节点
        private void addTreeNode_Click(object sender, EventArgs e)
        {

            treeView1.SelectedNode.Nodes.Add("新建子节点");

        }
        //删除节点
        private void deleteTreeNode_Click(object sender, EventArgs e)
        {

            treeView1.SelectedNode.Remove();


        }
        //增加根节点
        private void addRootTreeNode_Click(object sender, EventArgs e)
        {

            treeView1.Nodes.Add("新建根节点");

        }
        //保存
        private void SaveXml_Click(object sender, EventArgs e)
        {

        }

        private void 加载ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReLoadTree();
        }
        #endregion

        #region 多线程采集Rss和多线程采集正文。
        private int ChannalCount = 0;
        private TreeNode TreadAllNode = new TreeNode();
        private int beforImageIndex;
        private int beforSelectImageIndex;
        delegate void TreadAllDelegate();
        /// <summary>
        /// 显示状态栏更新信息
        /// </summary>
        public void TreadAllSetNode1()
        {
            if (TreadAllNode != null)
            {

                mf.EidtStatus("正在更新：" + TreadAllNode.FullPath + "(已更新" + ChannalCount.ToString() + "个)");
                ChannalCount++;
                //TreadAllNode.ImageIndex = 5;
                //TreadAllNode.SelectedImageIndex = 5;
            }


        }
        public void TreadAllSetNode2()
        {
            int beforimage=TreadAllNode.ImageIndex;
            int beforindex=TreadAllNode.SelectedImageIndex;

            if (TreadAllNode.Tag == null)
                return;
            //if (TreadAllNode.FirstNode=="")
            //{
            //    TreadAllNode.ImageIndex = 18;
            //    TreadAllNode.SelectedImageIndex = 18;
            //}
            //else
            //{
            //    TreadAllNode.ImageIndex = 0;
            //    TreadAllNode.SelectedImageIndex = 0;
            //}



        }
        /// <summary>
        /// 获取当前节点的下一个树节点
        /// </summary>
        void GetNextNode()
        {
            if (TreadAllNode != null)
            {
                if (TreadAllNode.FirstNode != null && TreadAllNode.Tag != null)
                {
                    TreadAllNode = TreadAllNode.FirstNode;
                }
                else if (TreadAllNode.NextNode != null && TreadAllNode.Tag != null)
                {
                    TreadAllNode = TreadAllNode.NextNode;
                }
                else
                {
                    TreeNode tnode;
                    tnode = TreadAllNode;
                    while (!(tnode != null && tnode.NextNode != null && TreadAllNode.Tag != null))
                    {
                        tnode = tnode.Parent;
                        if (tnode == null)
                            break;
                    }
                    if (tnode == null)
                    {
                        TreadAllNode = tnode;
                    }
                    else
                    {
                        TreadAllNode = tnode.NextNode;
                    }
                }
                if (TreadAllNode == null)
                {
                    mf.EidtStatus("更新完毕" + "(共" + ChannalCount.ToString() + "个频道)");
                }
            }
        }
        //todo:设计思路
        //一、排除5天前的新闻。用户可以自由设计排除天数。为减少数据库容量，不处理的新闻正文为空。
        //二、5个线程自动下载表中正文为空的新闻，加入到表中。下载成功背景为绿色        
        /// <summary>
        /// 启用3个线程下载Rss.xml列表，无重复的添加到表中。并显示更新了多少条新闻,并限制5天以内的新闻，不限条数。
        /// </summary>
        private void UpdateAllNews()
        {
            //todo:多线程把xml下载到本地。放在data下。遍历treeview1下，保存为node.name+xml
            //XElement xe = XElement.Load(mf.DirXml + @"\Nav.xml");
            //IEnumerable<XElement> Nodes = from node in xe.Descendants("site")
            //                              select node;
            //foreach (XElement it in Nodes)
            //{
            //    if (!string.IsNullOrEmpty(it.Value))
            //    {

            //        Thread thread = new Thread(new ThreadStart(delegate
            //    {
            //        this.BeginInvoke(_downlaoddelegate, it.Value, mf.DirData + @"\" + it.Attribute("Name").Value + ".xml");
            //    }));
            //        thread.Start();

            //    }
            //}
            //-----------------------------------
            //Thread t = new Thread(new ThreadStart(dlNode));
            //t.IsBackground = true;
            //t.Start();
            //------------------------------------ 
            object oo = new object();
            lock (oo)
            {
                ChannalCount = 0;
                TreadAllNode = treeView1.TopNode;
                Thread m_thread = new Thread(new ThreadStart(BeginThread));
                m_thread.SetApartmentState(ApartmentState.STA);
                m_thread.Start();
            }

        }
        /// <summary>
        /// 开始线程遍历
        /// </summary>
        private void BeginThread()
        {
            try
            {
                TreadAllDelegate T1 = new TreadAllDelegate(GetNextNode);
                TreadAllDelegate T2 = new TreadAllDelegate(TreadAllSetNode1);
                TreadAllDelegate T3 = new TreadAllDelegate(TreadAllSetNode2);
                this.Invoke(T1, null);
               
                while (TreadAllNode != null)
                {

                    clNode c = (clNode)TreadAllNode;
                    if (c.Tag != null)
                    {
                        this.Invoke(T2, null);
                        CaijiRule(c);
                    }

                    this.Invoke(T3, null);
                    this.Invoke(T1, null);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {

            }

        }
        #endregion
        //采集规则
        private void CaijiRule(object e)
        {
            clNode cn = e as clNode;
            #region 新浪规则
            //判断新浪sina网站的Url需要截取
            // if (cn.Name.Contains("sina"))
            if (cn.Link.Contains("sina.com.cn"))
            {
                //加载RSS新闻数据
                Regex regex = new Regex(@"(?<=[=]).*");
                //http://go.rss.sina.com.cn/redirect.php?url=http://tech.sina.com.cn/it/2013-11-16/09198919884.shtml
                XElement rssData = XElement.Load(cn.Link);

                //取出新闻标题，转成RssItem对象，并暂存到列表控件中
                var itemQuery = from item in rssData.Descendants(XName.Get("item"))
                                select new
                                {
                                    Title = item.Element(XName.Get("title")).Value.Trim(),
                                    Link = regex.Match(item.Element(XName.Get("link")).Value).ToString(),
                                    PubDate = item.Element(XName.Get("pubDate")).Value
                                };
                foreach (var result in itemQuery)
                {

                    //查数据库中是否已有相同标题，没有再追加！
                    if (!(mf.DS.RssItem.Contains(mf.DS.RssItem.FindByTitle(result.Title))))
                    {
                        RssItem it = new RssItem(cn.ParentTx, result.Title.Trim(), result.Link, Convert.ToDateTime(result.PubDate), "未读", "");
                        ListViewItem lv = new ListViewItem(new string[] { it.Title, it.PubDate.ToString("MM-dd HH:mm:ss"), cn.ParentTx });
                        lv.Tag = it;


                        SQLiteDS.RssItemRow rssRow = mf.DS.RssItem.AddRssItemRow(cn.ParentTx, result.Title, result.Link, Convert.ToDateTime(result.PubDate), "未读", "");
                        mf.rssTap.Update(rssRow);
                    }

                }
            }
            #endregion

            #region 网易规则
            //判断163的RSS,提取url时址址数据在guid中
            ////163网易
            ////http://news.163.com/13/1114/02/9DK05PBU0001124J.html
            ////http://news.163.com/13/1114/02/9DK05PBU0001124J_all.html
            if (cn.Name.Contains("163"))
            {
                //加载RSS新闻数据
                //string s1 = "http://news.163.com/13/1114/02/9DK05PBU0001124J.html";
                //string s = s1.Insert(s1.LastIndexOf('.'),"_all");
                //MessageBox.Show(s);

                XElement rssData = XElement.Load(cn.Link);

                //取出新闻标题，转成RssItem对象，并暂存到列表控件中
                var itemQuery = from item in rssData.Descendants(XName.Get("item"))
                                select new
                                {
                                    Title = item.Element(XName.Get("title")).Value.Trim(),
                                    Link = item.Element(XName.Get("guid")).Value,
                                    PubDate = item.Element(XName.Get("pubDate")).Value
                                };
                foreach (var result in itemQuery)
                {

                    //查数据库中是否已有相同标题，没有再追加！
                    if (!(mf.DS.RssItem.Contains(mf.DS.RssItem.FindByTitle(result.Title))))
                    {
                        RssItem it = new RssItem(cn.ParentTx, result.Title.Trim(), (result.Link.Insert(result.Link.LastIndexOf("."), "_all")), Convert.ToDateTime(result.PubDate), "未读", "");
                        ListViewItem lv = new ListViewItem(new string[] { it.Title, it.PubDate.ToString("MM-dd HH:mm:ss"), cn.ParentTx });
                        lv.Tag = it;
                      
                        SQLiteDS.RssItemRow rssRow = mf.DS.RssItem.AddRssItemRow(cn.ParentTx, result.Title, (result.Link.Insert(result.Link.LastIndexOf("."), "_all")), Convert.ToDateTime(result.PubDate), "未读", "");
                        mf.rssTap.Update(rssRow);
                    }

                }
            }
            #endregion

            #region 新华网规则
            if (cn.Name.Contains("xinhuanet"))
            {
                //加载RSS新闻数据
                XElement rssData = XElement.Load(cn.Link);

                //看来只能用正规截取了！
                //<link>http://news.xinhuanet.com/shuhua/2013-11/16/c_125712954.htm</link> 
                //Sat,16-Nov-2013 11:33:12 GMT 
                //<description>
                Regex regex = new Regex(@"(?<=<\/link>)(.*?)(?=<description>)");
                //想到的办法：一是通过xelement对象，正规取得；二是在源码中加入pubDate标签。
                //取出新闻标题，转成RssItem对象，并暂存到列表控件中
                #region test
                //var i = rssData.Descendants(XName.Get("item")).First();
                //MessageBox.Show(i.ToString());//保留了xelement格式。
                //去除标题的a标签。
                Regex regTitle = new Regex(@"</?.+?>");
                //去除连接中的双引号                       
                //string s="\"http://news.xinhuanet.com/edu/2013-10/11/c_125515383.htm\"";
                //MessageBox.Show(s.Replace("\"", ""));
                #endregion
                var itemQuery = from item in rssData.Descendants(XName.Get("item"))
                                select new
                                {
                                    Title = regTitle.Replace(item.Element(XName.Get("title")).Value.Trim(), ""),
                                    Link = item.Element(XName.Get("link")).Value.Replace("\"", ""),
                                    PubDate = regex.Match(item.ToString()).ToString()
                                    //PubDate = item.Element(XName.Get("pubDate")).Value

                                };

                foreach (var result in itemQuery)
                {



                    //查数据库中是否已有相同标题，没有再追加！
                    if (!(mf.DS.RssItem.Contains(mf.DS.RssItem.FindByTitle(result.Title))))
                    {
                        RssItem it = new RssItem(cn.ParentTx, result.Title.Trim(), result.Link, Convert.ToDateTime(result.PubDate), "未读", "");
                        ListViewItem lv = new ListViewItem(new string[] { it.Title, it.PubDate.ToString("MM-dd HH:mm:ss"), cn.ParentTx });
                        lv.Tag = it;
                     

                        SQLiteDS.RssItemRow rssRow = mf.DS.RssItem.AddRssItemRow(cn.ParentTx, result.Title, result.Link, Convert.ToDateTime(result.PubDate), "未读", "");
                        mf.rssTap.Update(rssRow);
                    }

                }
            }
            #endregion

            #region FT中文
            //加入全文采集规则 http://www.ftchinese.com/story/001053357?full=y
            if (cn.Name.Contains("ftchinese"))
            {

                XElement rssData = XElement.Load(cn.Link);

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

                    //查数据库中是否已有相同标题，没有再追加！
                    if (!(mf.DS.RssItem.Contains(mf.DS.RssItem.FindByTitle(result.Title + "?full=y"))))
                    {
                        RssItem it = new RssItem(cn.ParentTx, result.Title.Trim(), (result.Link + "?full=y"), Convert.ToDateTime(result.PubDate), "未读", "");
                        ListViewItem lv = new ListViewItem(new string[] { it.Title, it.PubDate.ToString("MM-dd HH:mm:ss"), cn.ParentTx });
                        lv.Tag = it;
                        
                        SQLiteDS.RssItemRow rssRow = mf.DS.RssItem.AddRssItemRow(cn.ParentTx, result.Title, (result.Link + "?full=y"), Convert.ToDateTime(result.PubDate), "未读", "");
                        mf.rssTap.Update(rssRow);
                    }

                }
            }
            #endregion

            else
            {
                #region 正常规则
                try
                {
                    //加载RSS新闻数据
                    XElement rssData = XElement.Load(cn.Link);

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
                        //查数据库中是否已有相同标题，没有再追加！
                        if (!(mf.DS.RssItem.Contains(mf.DS.RssItem.FindByTitle(result.Title))))
                        {
                            RssItem it = new RssItem(cn.ParentTx, result.Title.Trim(), result.Link, Convert.ToDateTime(result.PubDate), "未读", "");
                            ListViewItem lv = new ListViewItem(new string[] { it.Title, it.PubDate.ToString("MM-dd HH:mm:ss"), cn.ParentTx });
                            lv.Tag = it;
                            
                            SQLiteDS.RssItemRow rssRow = mf.DS.RssItem.AddRssItemRow(cn.ParentTx, result.Title, result.Link, Convert.ToDateTime(result.PubDate), "未读", "");
                            mf.rssTap.Update(rssRow);
                        }

                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                #endregion
            }
        }

    }


}
