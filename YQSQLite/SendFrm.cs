using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using System.Net.Mail;
using System.Net;
using System.Threading;
using zoyobar.shared.panzer.web.ib;

namespace YQSQLite
{
    public partial class SendFrm : DockContent
    {
        private MainFrm mf;
        private string address, displayname, host, user, pwd;

        private List<upsend> listEmail = new List<upsend>();
        private List<upsend> listWeb = new List<upsend>();

        public SendFrm()
        {
            InitializeComponent();
        }
        public SendFrm(MainFrm f)
        {
            InitializeComponent();
            mf = f;
        }
        #region 主窗体加载
        private void SendFrm_Load(object sender, EventArgs e)
        {

            var qEmail = from p in mf.DS.upsend.AsEnumerable()
                         where p.EmailSend == "待报送"
                         select p;
            var qWeb = from p in mf.DS.upsend.AsEnumerable()
                       where p.WebSend == "待报送"
                       select p;
            #region 取得待发送数组
            foreach (var db in qEmail)
            {
                upsend us = new upsend();
                us.Title = db.Title;
                us.Content = db.Content;
                us.UpTime = db.UpTime;
                us.Site = db.Site;
                us.Link = db.Link;
                us.EmailSend = db.EmailSend;
                us.WebSend = db.WebSend;
                us.ContKind = db.ContKind;
                us.WillSend = db.WillSend;
                listEmail.Add(us);
            }
            foreach (var db in qEmail)
            {
                upsend us = new upsend();
                us.Title = db.Title;
                us.Content = db.Content;
                us.UpTime = db.UpTime;
                us.Site = db.Site;
                us.Link = db.Link;
                us.EmailSend = db.EmailSend;
                us.WebSend = db.WebSend;
                us.ContKind = db.ContKind;
                us.WillSend = db.WillSend;
                listWeb.Add(us);
            }

            #endregion

            #region 初始化，显示lab标签

            labwillSend.Text += qEmail.Count().ToString();
            labWebwill.Text += qWeb.Count().ToString();
            #endregion

            #region 取得发送邮箱配置信息
            var config = from p in mf.DS.server.AsEnumerable()
                         select p;
            foreach (var item in config)
            {
                host = item.smtp;
                user = item.user;
                pwd = item.pwd;
                displayname = item.showname;
                address = user + "@" + host.Remove(0, 5);
            }
            #endregion

            #region web加载
            webBrowser1.Navigate("http://219.142.64.12/login.aspx");
            #endregion

            #region 没有待发邮件，“邮件发送”不可用

            if (listEmail.Count == 0)
            {
                btnSend.Enabled = false;
            }
            if (listWeb.Count == 0)
            {
                btnWebSend.Enabled = false;
            }

            #endregion
        }
        #endregion

        #region email 发送配置
        public bool send(upsend us)
        {
            bool flag = false;
            try
            {
                MailMessage msg = new MailMessage();
                var Qsendto = from p in mf.DS.sendto.AsEnumerable()
                              where p.Kind == us.ContKind
                              select p;
                foreach (var ma in Qsendto)
                {
                    if (us.WillSend.IndexOf(ma.Rank) >= 0)
                    {
                        msg.To.Add(ma.Email);//一次发送到多个邮箱
                    }


                }

                msg.From = new MailAddress(address, displayname, Encoding.UTF8);
                //加入标题前缀
                msg.Subject = Qsendto.First().ReTitle + us.Title;
                msg.IsBodyHtml = true;
                //外媒加入连接地址
                if (us.ContKind == "外媒")
                {
                    msg.Body = us.Link + us.Content;
                }
                else
                {
                    msg.Body = us.Content;
                }


                SmtpClient client = new SmtpClient(host);
                client.Credentials = new NetworkCredential(address, pwd);
                client.Send(msg);

                flag = true;
            }
            catch (SmtpException ex)
            {

                MessageBox.Show(ex.ToString());
            }

            return flag;


        }
        #endregion

        private void btnSend_Click(object sender, EventArgs e)
        {
            //已成功：邮箱测试成功，无待发邮件，按键不可用


            #region 多线程
            //启用多线程必备的三个条件：1、多线程类；2、多线程的委托；3、方法
            //多线程的委托
            ThreadStart ts = new ThreadStart(willSendEmail);
            //多线程类
            Thread T = new Thread(ts);
            //多线程方法            
            T.IsBackground = true;
            T.Start();

            #endregion

        }

        #region 使用代理类更改已报送条数
        //定义一个代理
        private delegate void DispLabHasSendNum(int index);
        //定义一个函数，用于向窗体上的lab更改显示值
        private void labNum(int index)
        {
            if (this.labhasSend.InvokeRequired == false)
            {
                //如果调用该函数的线程和控件labhasSend位于同一个线程内，显示lab
                labhasSend.Text = "已发:" + index;
            }
            else
            {
                //如果调用该函数的呼控件不在同一个线程，通过使用Invoke的方法，让子线程告诉窗体线程来完成相应的控件操作
                DispLabHasSendNum dlhs = new DispLabHasSendNum(labNum);
                //使用控件labhasSend的Invoke方法执行dlhs代理（其类型是DispLabHasSendNum）
                this.labhasSend.Invoke(dlhs, index);
            }
        }

        private void labwebNum(int index)
        {
            if (this.labWebHas.InvokeRequired == false)
            {
                labWebHas.Text += index;
            }
            else
            {
                DispLabHasSendNum dh = new DispLabHasSendNum(labwebNum);
                this.labWebHas.Invoke(dh, index);

            }
        }
        #endregion

        private void willSendEmail()
        {
            for (int i = 0; i < listEmail.Count; i++)
            {
                //labNum(i + 1);使用代理类修改窗体值成功！！非常高兴。                
                if (send(listEmail[i]))
                {
                    #region  更改lab显示
                    labNum(i + 1);
                    #endregion
                }
                //只修改内存数据！！！！
                mf.DS.upsend.FindByTitle(listEmail[i].Title).EmailSend = "已报送";

                //太快认为垃圾.QQ邮箱每分钟最多接收60个邮件，需要进程延长发送邮箱的间隔
                Thread.Sleep(2000);

                #region 数据修改
                //重新加载listview
                mf.WaitSendFmReload();
                #endregion
            }
            // 最后一次性提交数据库
            mf.upsendTap.Update(mf.DS.upsend);

        }


        private void btnWebSend_Click(object sender, EventArgs e)
        {
            ThreadStart webTS = new ThreadStart(willWebSend);
            Thread TS = new Thread(webTS);
            TS.IsBackground = true;
            TS.Start();
        }

        private void willWebSend()
        {


            IEBrowser ie = new IEBrowser(this.webBrowser1);
            //  ie.InstallTrace();
            ie.Navigate("http://219.142.64.12/Admin/oamis/inforReport.apsx");
            webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(mywebBrowser_DocumentCompleted);
            ie.IEFlow.Wait(new UrlCondition("wait", "http://219.142.64.12/Admin/oamis/inforReport.apsx", zoyobar.shared.panzer.StringCompareMode.StartWith));
        }

        private void mywebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (webBrowser1.ReadyState == WebBrowserReadyState.Complete)
            {
                for (int i = 0; i < listWeb.Count; i++)
                {

                    #region 用IEBrowser方法执行JS

                    IEBrowser ie = new IEBrowser(this.webBrowser1);
                    ie.InstallTrace();
                    string js = "function myfn(tit,sou,con){" +
                                    "document.getElementById('InforReport1_txtTitle').value=tit;" +
                                    "document.getElementById('InforReport1_txtInfoFrom').value=sou;" +
                                    "editor.html(con);" +
                                    "" + "}";
                    ie.InstallScript(js);
                    webBrowser1.Document.InvokeScript("myfn", new string[] { listWeb[i].Title, listWeb[i].Site, listWeb[i].Content });
                    HtmlElement WebSumbit = webBrowser1.Document.All["InforReport1_btn"];
                    WebSumbit.InvokeMember("Click");
                    //更改lab显示
                    labwebNum(i + 1);
                    Thread.Sleep(2000);
                    //标记已上报
                    mf.DS.upsend.FindByTitle(listWeb[i].Title).WebSend = "已报送";
                    //重新加载listview
                    mf.WaitSendFmReload();

                    #endregion
                }
            }

        }
        //http://www.sufeinet.com/forum.php?mod=viewthread&tid=6976&extra=page%3D1&page=1&
        private void btnlogin_Click(object sender, EventArgs e)
        {
            string loginUrl = "http://219.142.64.12/login.aspx";

            IEBrowser ie = new IEBrowser(webBrowser1);
            ie.Navigate(loginUrl);
            ie.IEFlow.Wait(new UrlCondition("wait", loginUrl, zoyobar.shared.panzer.StringCompareMode.StartWith));


            MainCookie Cc = new MainCookie();

            string str = MainCookie.GetCookies(loginUrl); //获取得到的cookie

            string[] strs = str.Split(';');   //将cookie字符串处理成Cookie对象
            for (int i = 0; i < strs.Length; i++)
            {
                try
                {
                    Cookie ck = new Cookie();
                    ck.Name = strs[i].Split('=')[0].Trim();
                    ck.Value = strs[i].Split('=')[1].Trim();
                    ck.Domain = webBrowser1.Document.Domain;
                    mf.cc.Add(ck);     //这里的cc 是CookieContainer,这里我定义到了主窗体中。 如果处理成CookieCollection 也可,方法是一样的.这样自己构造一个cookie集合,.
                }
                catch
                {

                }
            }
            //由于构造静态变量,变量被申明以后是存在共享空间中,直到整个程序结束才被释放,所以拿来传递窗体间的值再合适不过.也不用写繁琐的委托.当然如果你明白该怎样处理委托,那么可以任选一种方法..
            MainCookie.Cc = mf.cc;
            MainCookie.Cookie = str;
            //既然已经得到了cookie,那么就做你想做的事情去吧...
            //   this.Dispose();
            //    MessageBox.Show(str.ToString());//这个截取后4位可以得到验证码。不用自己手动识别了，呵呵~~~

            //截取文本后四位
            HtmlElement name = webBrowser1.Document.GetElementById("UserLogin2_txtEmailName");
            HtmlElement pwd = webBrowser1.Document.GetElementById("UserLogin2_txtPassword");
            HtmlElement CheckCode = webBrowser1.Document.GetElementById("UserLogin2_txtDatabase");
            HtmlElement subm = webBrowser1.Document.GetElementById("UserLogin2_ImgCmdLogin");
            
            name.Focus();
            name.SetAttribute("value", "hbjohnsan@qq.com");
            pwd.Focus();
            pwd.SetAttribute("value", "770716");
            CheckCode.Focus();
            CheckCode.SetAttribute("value", webBrowser1.Document.Cookie.Substring(webBrowser1.Document.Cookie.Length - 4));
            

            subm.Focus();
            //subm.SetAttribute("onclick", "javascript:return true;");

            //todo：验证码变了，也要变
            //ie.InstallTrace();
            //string js = "function CheckData(){return true;}";
            //ie.InstallScript(js);
            //webBrowser1.Document.InvokeScript("Passfn");
            subm.InvokeMember("click");
           // MessageBox.Show(str.ToString());

            //此处用图象识别功能吧！
            //todo:web登录信息保存了xml以后更改
            //string code = webBrowser1.Document.Cookie;

            //if (!string.IsNullOrEmpty(code))
            //{
            //    //填入验证框
            //    HtmlElement chekcode = webBrowser1.Document.GetElementById("UserLogin2_txtDatabase");
            //    chekcode.Focus();
            //    chekcode.SetAttribute("value", code.Substring(66, 4));
            //    //模拟提交
            //    HtmlElement subm = webBrowser1.Document.GetElementById("UserLogin2_ImgCmdLogin");
            //    subm.Focus();
            //    subm.InvokeMember("click");
            //}
        }

    }
}
