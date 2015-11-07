using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using ScrapySharp.Extensions;

namespace YQSQLite
{
    public partial class BrowserFrm : DockContent
    {

        //可打开的最多网页数
        //private const int num = 50;
        //private WebBrowser[] web = new WebBrowser[num];
        private readonly string homeurl = "http://news.baidu.com";
        //在对话窗体中传的值
        public string url;

        public BrowserFrm()
        {
            InitializeComponent();
        }

        private void BrowserFrm_Load(object sender, EventArgs e)
        {
            combUrl.Text = homeurl;
            //for (int i = 0; i < num; i++)
            //{
            //    web[i] = new WebBrowser();
            //    web[i].Dock = DockStyle.Fill;
            //    web[i].ScriptErrorsSuppressed = true;
            //    //定义新窗口事件，取消在IE中打开
            //    web[i].NewWindow += new CancelEventHandler(wbBrowser_NewWindow);
            //    web[i].DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(DocumentCompleted);
            //}
            WebBrowser wb = new WebBrowser();
            wb.Dock = DockStyle.Fill;
            wb.NewWindow += new CancelEventHandler(wbBrowser_NewWindow);
            wb.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(DocumentCompleted);
            tabControl1.TabPages[0].Controls.Add(wb);
            wb.Navigate(new Uri(homeurl));
        }

        #region 加载网页完成后的事件，多次用到
        /// <summary>
        /// 加载网页完成后的事件，多次用到
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser w = sender as WebBrowser;
            if (w.ReadyState != WebBrowserReadyState.Complete)
                return; //解决由于WebBrowser的ReadyState状态不同导致

            if (e.Url.ToString() != w.Url.ToString())
                return; //解决点击超链接跳转引起的多次事


            if (w.ReadyState == WebBrowserReadyState.Complete)
            {
                rtbCode.Clear();
                combUrl.Text = w.Url.ToString();
                tabControl1.SelectedTab.Text = tabControl1.SelectedIndex.ToString();

                //加入显示页面源码功能                
                System.IO.StreamReader getReader = new System.IO.StreamReader(w.DocumentStream, System.Text.Encoding.GetEncoding(w.Document.Encoding));
                string gethtml = getReader.ReadToEnd();
                rtbCode.AppendText(gethtml);
            }
        }
        #endregion

        #region 导航工具栏
        //点击导航到
        private void btnGoTo_Click(object sender, EventArgs e)
        {
            Navigate(combUrl.Text);

        }
        //点击到主页
        private void btnHome_Click(object sender, EventArgs e)
        {
            WebBrowser wb = tabControl1.SelectedTab.Controls[0] as WebBrowser;
            wb.Navigate(homeurl);

        }
        //点击回退
        private void btnGoBack_Click(object sender, EventArgs e)
        {
            WebBrowser wb = tabControl1.SelectedTab.Controls[0] as WebBrowser;
            wb.GoBack();
        }
        //点击前进
        private void btnForward_Click(object sender, EventArgs e)
        {
            WebBrowser wb = tabControl1.SelectedTab.Controls[0] as WebBrowser;
            wb.GoForward();
        }
        //点击刷新
        private void btnRefurbish_Click(object sender, EventArgs e)
        {
            WebBrowser wb = tabControl1.SelectedTab.Controls[0] as WebBrowser;
            wb.Refresh();
        }
        #endregion

        #region 单击最后个tabpage新建Tab页
        /// <summary>
        /// 单击最后个tabpage新建Tab页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            int n = tabControl1.TabCount;
            if (tabControl1.SelectedIndex == n - 1)
            {
                WebBrowser webb = new WebBrowser();
                webb.Url = new Uri(combUrl.Text.Trim());
                webb.Dock = DockStyle.Fill;
                webb.ScriptErrorsSuppressed = true;
                TabPage p = new TabPage();
                p.Controls.Add(webb);
                tabControl1.TabPages.Insert(n - 1, p);
                tabControl1.SelectedTab = p;
                webb.NewWindow += new CancelEventHandler(wbBrowser_NewWindow);
                webb.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(DocumentCompleted);

            }
        }
        #endregion

        #region 双击移除tabpage
        /// <summary>
        /// 双击移除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (tabControl1.TabPages.Count > 2)
            {

                this.tabControl1.TabPages.Remove(this.tabControl1.SelectedTab);
            }

        }
        #endregion

        #region 自建导航类
        /// <summary>
        /// 自建导航类
        /// </summary>
        /// <param name="address"></param>
        private void Navigate(string address)
        {
            if (string.IsNullOrEmpty(address))
            {
                address = homeurl;
            }

            if (address.Equals("about:blak"))
            {
                address = homeurl;
            }

            if (!address.StartsWith("http://") && !address.StartsWith("https://"))
            {
                if (IsChina(address))
                {
                    //设置百度搜索
                    address = "http://www.baidu.com/s?wd=" + address;
                }
                else
                {
                    address = "http://" + address;
                }

            }
            try
            {
                WebBrowser wb = tabControl1.SelectedTab.Controls[0] as WebBrowser;
                wb.Navigate(new Uri(address));

            }
            catch (System.UriFormatException)
            {

                return;
            }

        }
        #endregion

        #region 判断是否为汉字
        /// <summary>
        /// 判断是否为汉字
        /// </summary>
        /// <param name="CString"></param>
        /// <returns></returns>
        public bool IsChina(string CString)
        {
            bool BoolValue = false;
            for (int i = 0; i < CString.Length; i++)
            {
                if (Convert.ToInt32(Convert.ToChar(CString.Substring(i, 1))) < Convert.ToInt32(Convert.ToChar(128)))
                {
                    BoolValue = false;
                }
                else
                {
                    BoolValue = true;
                }
            }
            return BoolValue;
        }
        #endregion

        #region 按回车导航新地址
        /// <summary>
        /// 按回车导航新地址
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void combUrl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnGoTo_Click(sender, e);
        }
        #endregion

        #region 本窗口打开新地址
        /// <summary>
        /// 本窗口打开新地址
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void wbBrowser_NewWindow(object sender, System.ComponentModel.CancelEventArgs e)
        {

            int n = tabControl1.TabCount;

            WebBrowser webb = new WebBrowser();
            webb.Dock = DockStyle.Fill;
            webb.ScriptErrorsSuppressed = true;

            TabPage p = new TabPage();
            p.Controls.Add(webb);
            tabControl1.TabPages.Insert(n - 1, p);
            tabControl1.SelectedTab = p;

            try
            {
                WebBrowser s = sender as WebBrowser;
                Uri a = new Uri(s.Document.ActiveElement.GetAttribute("href"));
                webb.Url = a;
            }
            catch (Exception ee)
            {

                throw ee;
            }


            webb.NewWindow += new CancelEventHandler(wbBrowser_NewWindow);
            webb.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(DocumentCompleted);
            e.Cancel = true;

        }
        #endregion

        #region 正文采集配置
        //截取正文部分
        private void btnCut_Click(object sender, EventArgs e)
        {
            HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
            htmlDocument.LoadHtml(rtbCode.Text);
            var Nodes = htmlDocument.DocumentNode;
            var reCont = Nodes.CssSelect(txtContFlag.Text);

            foreach (var doc in reCont)
            {
                htmlEditor1.HTML = doc.InnerHtml;
                rtbText.Text = doc.InnerText;
                rtbCode.Text = doc.InnerHtml;
            }

        }
        //排除正文多余部分
        private void btnTest_Click(object sender, EventArgs e)
        {
            HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
            htmlDocument.LoadHtml(rtbCode.Text);
            var Nodes = htmlDocument.DocumentNode;

            string[] ReAll = txtReCont.Text.Split(new Char[] { ',' });
            for (int i = 0; i < ReAll.Length; i++)
            {
                foreach (var Del in Nodes.CssSelect(ReAll[i]))
                    Del.Remove();
            }
            htmlEditor1.HTML = RemoveHTMLComments(Nodes.InnerHtml);
            rtbText.Text = Nodes.InnerText;
            rtbCode.Text = RemoveHTMLComments(Nodes.InnerHtml);
        }
        //去除注册<!--  -->
        private string RemoveHTMLComments(string input)
        {
            string output = string.Empty;
            string[] temp = System.Text.RegularExpressions.Regex.Split(input, "<!--");
            foreach (string s in temp)
            {
                string str = string.Empty;
                if (!s.Contains("-->"))
                {
                    str = s;
                }
                else
                {
                    str = s.Substring(s.IndexOf("-->") + 3);
                }
                if (str.Trim() != string.Empty)
                {
                    output = output + str.Trim();
                }
            }
            return output;
        }
        #endregion

        #region 外部调用打开新地址
        public void OpenNewUrl(string url)
        {
            int n = tabControl1.TabCount;
            WebBrowser webb = new WebBrowser();
            webb.Dock = DockStyle.Fill;
            webb.ScriptErrorsSuppressed = true;

            TabPage p = new TabPage();
            p.Controls.Add(webb);
            tabControl1.TabPages.Insert(n - 1, p);
            tabControl1.SelectedTab = p;

            try
            {               
                Uri a = new Uri(url);
                webb.Url = a;
            }
            catch (Exception ee)
            {

                throw ee;
            }

            webb.NewWindow += new CancelEventHandler(wbBrowser_NewWindow);
            webb.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(DocumentCompleted);
           
        }
        #endregion
    }
}
