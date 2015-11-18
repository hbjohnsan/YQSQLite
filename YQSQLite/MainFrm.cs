using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using Microsoft.Win32;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Net;
using System.Threading;

namespace YQSQLite
{
    public partial class MainFrm : Form
    {
        #region 自定义字段
        private NavFrm navFm;
        private SelectFrm selectFm;
        private WaitEdit waiteditFm;
        private WaitSendFrm waitsendFm;
        private RuleFrm ruleFm;

        private EditFrm editFm;
        private SendFrm sendFm;
        private DataFrm dataFm;
        private TotalFrm totalFm;
        private PassFrm passFm;
        private RegisterFrm registerFm;
        private ConfigFrm configFm;
        private BrowserFrm browserFm;
        private HasSendFrm hassendfm;
        private RssConfigFrm rssconfigfm;

        public string DirData = Application.StartupPath + @"\Data\";
        public string DirXml = Application.StartupPath + @"\Xml\";
        public configYQ configyq;

        public YQDataSet DS;
        public YQDataSetTableAdapters.cpcuseTableAdapter cpcTap;
        public YQDataSetTableAdapters.RssItemTableAdapter rssTap;
        public YQDataSetTableAdapters.upsendTableAdapter upsendTap;
        public YQDataSetTableAdapters.sendtoTableAdapter sendtoTap;
        public YQDataSetTableAdapters.serverTableAdapter serverTap;
        public YQDataSetTableAdapters.RuleTableAdapter ruleTap;
        public YQDataSetTableAdapters.NavUrlTableAdapter navurlTap;

        public CookieContainer cc = new CookieContainer();
        //检测系统是否注册
        public bool ZC = false;
        #endregion
        public MainFrm()
        {
            InitializeComponent();
            #region 数据填充
            DS = new YQDataSet();
            cpcTap = new YQDataSetTableAdapters.cpcuseTableAdapter();
            rssTap = new YQDataSetTableAdapters.RssItemTableAdapter();
            upsendTap = new YQDataSetTableAdapters.upsendTableAdapter();
            sendtoTap = new YQDataSetTableAdapters.sendtoTableAdapter();
            serverTap = new YQDataSetTableAdapters.serverTableAdapter();
            ruleTap = new YQDataSetTableAdapters.RuleTableAdapter();
            navurlTap = new YQDataSetTableAdapters.NavUrlTableAdapter();

            cpcTap.Fill(DS.cpcuse);
            rssTap.Fill(DS.RssItem);
            upsendTap.Fill(DS.upsend);
            sendtoTap.Fill(DS.sendto);
            serverTap.Fill(DS.server);
            ruleTap.Fill(DS.Rule);
            navurlTap.Fill(DS.NavUrl);
            #endregion
            //用多线程实现统计信息条数
            Thread th = new Thread(new ThreadStart(delegate
            {
                CountNum_RssItem2NavUrl();
            }));
            th.IsBackground = true;
            th.Start();

            //LoginFrm lgfrm = new LoginFrm();
            //if (lgfrm.ShowDialog() != DialogResult.OK)//表示当f1的DialogResult等于Ok时主程序才开始运行，所以在Form1中登录成功时要将Dialogresult设为OK
            //{
            //    Application.Exit();
            //}
        }

        #region 窗体加载
        private void MainFrm_Load(object sender, EventArgs e)
        {
            #region 显示窗体
            navFm = new NavFrm(this);
            selectFm = new SelectFrm(this);
            waiteditFm = new WaitEdit(this);
            waitsendFm = new WaitSendFrm(this);
            ruleFm = new RuleFrm(this);
            hassendfm = new HasSendFrm(this);

            navFm.Show(dockPanel, DockState.DockLeft);
            ruleFm.Show(navFm.Pane, DockAlignment.Bottom, 0.5);
            selectFm.Show(dockPanel);
            waiteditFm.Show(dockPanel, DockState.DockRight);
            waitsendFm.Show(waiteditFm.Pane, DockAlignment.Bottom, 0.5);
            hassendfm.Show(waitsendFm.Pane, DockAlignment.Bottom, 0.5);
            #endregion

            Thread ts = new Thread(new ThreadStart(delegate
            {
                GetConfig();
            }));
            ts.Start();
            
            //Thread t = new Thread(new ThreadStart(delegate
            //{
                Reg();
            //}));
            //t.Start();

        }
        //取得配置文件
        private void GetConfig()
        {
            FileStream fs = new FileStream(DirData + @"\config.dat", FileMode.Open);
            configyq = new configYQ();
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                configyq = (configYQ)formatter.Deserialize(fs);

            }
            catch (SerializationException se)
            {

                MessageBox.Show(se.Message);
            }
            finally
            {
                fs.Close();
            }
        }
        #endregion

        #region 写入注册表项，判断是否已注册
        private void Reg()
        {
            RegistryKey rk = Registry.LocalMachine.OpenSubKey("SOFTWARE", true);
            if (rk.GetValue("ZCM") != null)//读取系统的注册码，如果已注册则值值不为空可以使用，并标识已注册，反之则未注册
            {
                this.Text += "(已注册)";
                // 注册ToolStripMenuItem.Enabled = false;
                ZC = true;
                return;
            }
            this.Text += "(试用版 未注册）";
            int count = (int)rk.GetValue("Count", 0);//未注册时获取用户试用的次数，如果是首次使用则赋值为0

            // tabc.Visible = false;//因为是使用版，所以有很多 功能无法使用，这里演示将tabControl的visible属性设置为false来演示这种效果
            if (count < 30)//默认试用次数为30次，小于30次时仍可试用，反之则直接结束运行
            {
                rk.SetValue("Count", count + 1);//需要更新注册表中用来记录登录次数的值，每试用一次，该值就增加一，等大于等于30时，程序试用结束，直接退出
                count = 30 - count;
                MessageBox.Show("您试用的是试用版！还有" + count + "次试用机会，请先注册再使用！");
            }
            else
            {
                MessageBox.Show("不好意思，请已经超出试用次数！请注册后再使用！");
                Application.Exit();
            }
        } 
        #endregion

        #region 中间调用方法
        //统计RssItem表中的数量，更新NavUrl中的ItemCount和NoReadCount数量
        public void CountNum_RssItem2NavUrl()
        {
            var navs = from p in DS.NavUrl.AsEnumerable()
                       select p;

            foreach (var nv in navs)
            {
                nv.ItemCount = (from q in DS.RssItem.AsEnumerable()
                                where q.ChannelCode.StartsWith(nv.Code)
                                select q).Count();
                nv.NoReadCount = (from s in DS.RssItem.AsEnumerable()
                                  where (s.IsRead == "F" && s.ChannelCode.StartsWith(nv.Code))
                                  select s).Count();
            }
            //todo:DataSet中统计比较后，还更新数据。采集时要实时更新项。
            navurlTap.Update(DS.NavUrl);
        }

        //导航列表点击事件
        //public void NodeClick(object sender, TreeNodeMouseClickEventArgs e)
        //{
        //    if (selectFm == null || selectFm.IsDisposed)
        //    {
        //        selectFm = new SelectFrm(this);
        //        selectFm.Show(dockPanel);
        //    }
        //    selectFm.Activate();
        //    selectFm.NavNodeClik(sender, e);
        //}
        //SelectFrom窗体的数据重载
        public void SelectFrmListViewReload(ListViewItem li)
        {
            selectFm.ReloadLiatView(li);
        }
        public void SelectFrmListviewClear()
        {
            selectFm.listClear();
        }

        //新闻列表选择加入待处理窗体
        public void NewsAdd(int Rssitemid)
        {
            waiteditFm.AddRssItem(Rssitemid);
        }
        //待处理窗体移除新闻
        public void RemoveAll()
        {
            waiteditFm.RemoveRssItem();
        }
        //待处理窗体全部移除新闻
        public void NewsRemove()
        {
            waiteditFm.RemoveAll();
        }

        //到编辑窗体编辑“待处理” 项
        public void RssToEditFm(int rssitemid)
        {
            //判断打开窗口
            if (editFm == null || editFm.IsDisposed)
            {
                editFm = new EditFrm(this);
                editFm.Show(dockPanel);
            }
            editFm.Activate();
            editFm.EditRssItem(rssitemid);
        }

        //待处理窗体重新加载
        public void WaitEditFmReLoad()
        {
            waiteditFm.ReLoad();
        }
        //
        public void WaitSendFmReload()
        {
            waitsendFm.ReLoad();
        }
        //待报送重新编辑
        internal void EditWaitSendUp(upsend upsend)
        {
            if (editFm == null || editFm.IsDisposed)
            {
                editFm = new EditFrm(this);
                editFm.Show(dockPanel);
            }
            editFm.Activate();
            editFm.ReloadUpsendItem(upsend);
        }

        //在浏览器中打开指定文章
        public void OpenUrl(string url)
        {
            if (browserFm == null || browserFm.IsDisposed)
            {
                browserFm = new BrowserFrm();
                browserFm.Show(dockPanel);
                browserFm.Activate();
            }
            browserFm.Activate();
            browserFm.OpenNewUrl(url);
        }

        //状态栏修改
        public void EidtStatus(string text)
        {
            statusStrip1.Text = text;
        }

        #endregion

        #region 菜单、工具栏命令
        private void 筛选ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //判断打开窗口
            if (selectFm == null || selectFm.IsDisposed)
            {
                selectFm = new SelectFrm(this);
                selectFm.Show(dockPanel);

            }
            selectFm.Activate();
        }

        private void 编辑ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //判断打开窗口
            if (editFm == null || editFm.IsDisposed)
            {
                editFm = new EditFrm(this);
                editFm.Show(dockPanel);
            }
            editFm.Activate();
        }

        private void 上报ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //判断打开窗口
            if (sendFm == null || sendFm.IsDisposed)
            {
                sendFm = new SendFrm(this);
                sendFm.Show(dockPanel);

            }
            sendFm.Activate();
        }

        private void 资料ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //判断打开窗口
            if (dataFm == null || dataFm.IsDisposed)
            {
                dataFm = new DataFrm(this);
                dataFm.Show(dockPanel);

            }
            dataFm.Activate();
        }

        private void 统计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //判断打开窗口
            if (totalFm == null || totalFm.IsDisposed)
            {
                totalFm = new TotalFrm(this);
                totalFm.Show(dockPanel);

            }
            totalFm.Activate();
        }

        private void 导航ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //判断打开窗口
            if (navFm == null || navFm.IsDisposed)
            {
                navFm = new NavFrm(this);
                navFm.Show(dockPanel, DockState.DockLeft);

            }
            navFm.Activate();
        }

        private void 待处理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //判断打开窗口
            if (waiteditFm == null || waiteditFm.IsDisposed)
            {
                waiteditFm = new WaitEdit(this);
                waiteditFm.Show(dockPanel, DockState.DockRight);

            }
            waiteditFm.Activate();

        }

        private void 待报送ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //判断打开窗口
            if (waitsendFm == null || waitsendFm.IsDisposed)
            {
                waitsendFm = new WaitSendFrm(this);
                waitsendFm.Show(waiteditFm.Pane, DockAlignment.Bottom, 0.5);

            }
            waitsendFm.Activate();
        }

        private void 已报送toolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (hassendfm == null || hassendfm.IsDisposed)
            {
                hassendfm = new HasSendFrm(this);
                hassendfm.Show(waitsendFm.Pane, DockAlignment.Bottom, 0.5);
            }
            hassendfm.Activate();
        }

        private void 系统配置ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //判断打开窗口
            if (configFm == null || configFm.IsDisposed)
            {
                configFm = new ConfigFrm(this);

            }
            configFm.ShowDialog();
        }

        private void 注册ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //判断打开窗口
            if (registerFm == null || registerFm.IsDisposed)
            {
                registerFm = new RegisterFrm(this);
            }
            registerFm.ShowDialog();
        }

        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //判断打开窗口
            if (passFm == null || passFm.IsDisposed)
            {
                passFm = new PassFrm(this);
            }
            passFm.ShowDialog();
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutFrm aboutFm = new AboutFrm();
            aboutFm.ShowDialog();
        }

        private void 工具栏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip1.Visible = 工具栏ToolStripMenuItem.Checked = !工具栏ToolStripMenuItem.Checked;
        }

        private void 状态栏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip1.Visible = 状态栏ToolStripMenuItem.Checked = !状态栏ToolStripMenuItem.Checked;
        }

        private void 采集规则ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //判断打开窗口
            if (ruleFm == null || ruleFm.IsDisposed)
            {
                ruleFm = new RuleFrm(this);
                ruleFm.Show(navFm.Pane, DockAlignment.Bottom, 0.5);
                ruleFm.Activate();
            }
            ruleFm.Activate();
        }

        private void 浏览器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (browserFm == null || browserFm.IsDisposed)
            {
                browserFm = new BrowserFrm();
                browserFm.Show(dockPanel);
                browserFm.Activate();
            }
            browserFm.Activate();
        }
        private void 清空Rss新闻ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (YQDataSet.RssItemRow row in DS.RssItem.Rows)
            {
                row.Delete();
            }
            rssTap.Update(DS.RssItem);
            selectFm.listClear();
            waiteditFm.listClear();

        }
        private void rss配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rssconfigfm == null || rssconfigfm.IsDisposed)
            {
                rssconfigfm = new RssConfigFrm(this);
            }
            rssconfigfm.ShowDialog();
        }
        private void 退出ToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        #endregion

        #region 托盘功能
        //最小化
        private void MainFrm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                NormalToMinimized();
            }
        }

        private void NormalToMinimized()
        {
            this.WindowState = FormWindowState.Minimized;
            this.Visible = false;
            this.notifyIcon1.Visible = true;
        }


        private void MinimizedToNormal()
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;

        }
        //单击显示窗体
        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MinimizedToNormal();
            }
        }
        #endregion

        //主窗体关闭时再更新所有数据？？？
      

        private void MainFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            cpcTap.Update(DS.cpcuse);
            rssTap.Update(DS.RssItem);
            upsendTap.Update(DS.upsend);
            sendtoTap.Update(DS.sendto);
            serverTap.Update(DS.server);
            ruleTap.Update(DS.Rule);
            navurlTap.Update(DS.NavUrl);
        }
    }
}
