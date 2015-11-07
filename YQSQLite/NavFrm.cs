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
            mf.NodeClick(sender, e);
        }




        #endregion

        #region 右键菜单

        //编辑导航
        private void 编辑tsm_Click(object sender, EventArgs e)
        {
            NavEidt NE = new NavEidt(mf);            
            NE.ShowDialog();
            if (NE.DialogResult==DialogResult.OK)
            {
                ReLoadTree();
            }
        }

        private void 加载ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReLoadTree();
        }
        //重新加载treeview
        public void ReLoadTree()
        {
            treeView1.Nodes.Clear();
            //转换成实体类，把数据放在Tag中这样会方便些。
            List<NavUrl> NavUrls = new List<NavUrl>();
            var q = from p in mf.DS.NavUrl.AsEnumerable()
                    select p;
            foreach (SQLiteDS.NavUrlRow kind in q)
            {
                NavUrl nu = new NavUrl();
                nu.ID = (int)kind.ID;
                nu.Name = kind.Name;
                nu.PID = (int)kind.PID;
                nu.Code = kind.Code;
                nu.level = (int)kind.level;
                nu.Leaf = (int)kind.Leaf;
                nu.Link = kind.Link;
                nu.Image = (int)kind.Image;
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
                    tn.Text = u.Name;
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
                    tn.Text = n.Name;
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
