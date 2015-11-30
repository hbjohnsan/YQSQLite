using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace YQSQLite
{
    public partial class NavEidt : Form
    {
        private MainFrm mf;
        //private DialogResult dr;

        public NavEidt()
        {
            InitializeComponent();
        }
        public NavEidt(MainFrm f)
        {
            InitializeComponent();
            mf = f;
        }


        private void NavEidt_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“yQDataSet.NavUrl”中。您可以根据需要移动或删除它。
            //   this.navUrlTableAdapter.Fill(this.yQDataSet.NavUrl);
            LoadTreeView();


        }

        #region 加载TreeView
        private void LoadTreeView()
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
                nu.Level = (int)kind.level;
                nu.Leaf = kind.Leaf;
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
                if (u.PID == 0 && u.Level == 1)
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

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            NavUrl nu = e.Node.Tag as NavUrl;
            labMyID.Text = nu.ID.ToString();
            txtFNodeText.Text = nu.Name;
            //域名
            txtDomain.Text = nu.Nav_Domain;
            txtFatherID.Text = nu.PID.ToString();
            txtThisCode.Text = nu.Code;
            nudLevel.Value = (int)nu.Level;
            txtLeaf.Text = nu.Leaf;
            txtThisUrl.Text = nu.Link;

            lvImageList.Items[nu.Image].Selected = true;
            foreach (ListViewItem item in lvImageList.Items)
            {
                if (item.Selected == true)
                {
                    item.BackColor = Color.Blue;
                }
                else
                {
                    item.BackColor = Color.White;
                }
            }

        }
        //全禁
        private void AllDis()
        {
         txtDomain.ReadOnly= nudLevel.ReadOnly=  txtFNodeText.ReadOnly =  txtThisCode.ReadOnly = txtThisUrl.ReadOnly = txtLeaf.ReadOnly = txtFatherID.ReadOnly = true;
            
            btnSave.Enabled = false;
        }
        private void AllEna()
        {
            nudLevel.ReadOnly = txtDomain.ReadOnly = txtFNodeText.ReadOnly =  txtThisCode.ReadOnly = txtThisUrl.ReadOnly = txtLeaf.ReadOnly = txtFatherID.ReadOnly = false;

        }


        //编辑
        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            AllEna();
            //标签，按键开关

        }
        //保存
        private void btnSave_Click(object sender, EventArgs e)
        {
            int id = int.Parse(labMyID.Text);
            YQDataSet.NavUrlRow nur = mf.DS.NavUrl.FindByID(id);
            nur.Name = txtFNodeText.Text.Trim();
            nur.PID = Int32.Parse(txtFatherID.Text);
            nur.Code = txtThisCode.Text.Trim();
            nur.level = (int)nudLevel.Value;
            nur.Leaf = txtLeaf.Text;
            nur.Link = txtThisUrl.Text.Trim();
            nur.Image = lvImageList.SelectedItems[0].Index;
            mf.navurlTap.Update(nur);
            //重新加载本窗口中treeview
            LoadTreeView();
           
            AllDis();
        }
        //删除
        private void btnDel_Click(object sender, EventArgs e)
        {
            //需要删除ItemRss中的数据
            int id = int.Parse(labMyID.Text);
            YQDataSet.NavUrlRow nur = mf.DS.NavUrl.FindByID(id);
            var q = from p in mf.DS.RssItem.AsEnumerable()
                    where p.ChannelCode.StartsWith(nur.Code)
                    select p;
            foreach (var item in q)
            {
                item.Delete();
            }
            nur.Delete();
            mf.navurlTap.Update(mf.DS.NavUrl);
            mf.rssTap.Update(mf.DS.RssItem);
        }
     

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }



    }
}
