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
    public partial class WaitSendFrm : DockContent
    {
        private MainFrm mf;
        public WaitSendFrm()
        {
            InitializeComponent();
        }
        public WaitSendFrm(MainFrm f)
        {
            InitializeComponent();
            mf = f;
        }
        private void WaitSendFrm_Load(object sender, EventArgs e)
        {
            ReLoad();
        }

        private delegate void delListload();
        public void ReLoad()
        {
            if (listView1.InvokeRequired == false)
            {
                listView1.Items.Clear();
                var q = from p in mf.DS.upsend.AsEnumerable()
                        where p.EmailSend == "待报送" || p.WebSend == "待报送"
                        select p;
                foreach (var item in q)
                {
                    upsend up = new upsend();
                    up.Site = item.Site;
                    up.Title = item.Title;
                    up.UpTime = item.UpTime;
                    up.Link = item.Link;
                    up.Content = item.Content;
                    up.EmailSend = item.EmailSend;
                    up.WebSend = item.WebSend;
                    up.ContKind = item.ContKind;
                    up.WillSend = item.WillSend;
                    ListViewItem lv = new ListViewItem(item.Title);
                    lv.Tag = up;
                    listView1.Items.Add(lv);
                }

            }
            else
            {
                delListload dl = new delListload(ReLoad);
                listView1.Invoke(dl);
            }

        }

        private void listView1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count!=0)
            {
                mf.EditWaitSendUp(listView1.SelectedItems[0].Tag as upsend);
            }
        }


    }
}
