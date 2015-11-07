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
    public partial class HasSendFrm : DockContent
    {
        private MainFrm mf;
        public HasSendFrm()
        {
            InitializeComponent();
        }
        public HasSendFrm(MainFrm f)
        {
            InitializeComponent();
            mf = f;
        }

        private void HasSendFrm_Load(object sender, EventArgs e)
        {
            var q = from p in mf.DS.upsend.AsEnumerable()
                    where p.EmailSend == "已报送" || p.WebSend == "已报送"
                    select p;
            foreach (var i in q)
            {
                ListViewItem lv = new ListViewItem(new string[] {i.Title,i.EmailSend,i.WebSend });
                listView1.Items.Add(lv);
            }
        }
    }
}
