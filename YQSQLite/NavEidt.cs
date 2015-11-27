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
            txtFNodeText.ReadOnly = btnEdit.Enabled = txtThisCode.ReadOnly = txtThisUrl.ReadOnly = txtLeaf.ReadOnly = txtFatherID.ReadOnly = true;
            btnSave.Enabled = false;
        }
        private void AllEna()
        {
            nudLevel.ReadOnly = txtDomain.ReadOnly = txtFNodeText.ReadOnly = btnEdit.Enabled = txtThisCode.ReadOnly = txtThisUrl.ReadOnly = txtLeaf.ReadOnly = txtFatherID.ReadOnly = false;

        }
        //自动计算Code值。
        private void ShowCode(string code, int level)
        {

            switch (code.Length)
            {
                case 2://2位是顶层
                    var Qcode = from p in mf.DS.NavUrl
                                where p.level == level
                                select p;
                    List<int> num = new List<int>();
                    foreach (var item in Qcode)
                    {
                        num.Add(Int32.Parse(item.Code));
                    }
                    if (num.Max() < 9)//小于9的，只有一位；
                    {
                        //txtNewCode.Text = "0" + (num.Max() + 1).ToString();
                    }
                    else
                    {
                        // txtNewCode.Text = (num.Max() + 1).ToString();
                    }

                    break;
                case 4://4位中间层
                    string mCode = code.Substring(0, 2);
                    var Qcode4 = from p in mf.DS.NavUrl
                                 where p.Code.StartsWith(mCode) && p.level == level //StartsWith这里使用这个，不是是.Contains
                                 select p;
                    List<int> num4 = new List<int>();
                    foreach (var c in Qcode4)
                    {
                        num4.Add(Int32.Parse(c.Code.Substring(2, 2)));
                    }
                    if (num4.Max() < 9)
                    {
                        //        txtNewCode.Text = code.Substring(0, 2) + "0" + (num4.Max() + 1).ToString();
                    }
                    else
                    {
                        //        txtNewCode.Text = code.Substring(0, 2) + (num4.Max() + 1).ToString();
                    }
                    break;
                case 6://底层

                    break;
                default:
                    break;
            }
            var q = from p in mf.DS.NavUrl.AsEnumerable()
                    where p.Code.Contains(code)//Like语句。
                    select p;

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
        }
        //删除
        private void btnDel_Click(object sender, EventArgs e)
        {

        }
        //新增
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            //注意MF中NavUrl表的重新填充，及NavFrm中的数据绑定--dialogResult.OK后数据重新从库中绑定了。
            //新建一个具体的对象，然后把该对象行，加入到内存表中就OK了，最后可到库一下。转了很长时间的的圈子一下明白了。呵呵~
            YQDataSet.NavUrlRow nr = mf.DS.NavUrl.NewNavUrlRow();
            nr.Name = txtFNodeText.Text.Trim();
            nr.Code = txtThisCode.Text.Trim();
            nr.level = (int)nudLevel.Value;
            nr.Leaf = txtLeaf.Text;
            nr.Link = txtThisUrl.Text.Trim();

            if (lvImageList.SelectedItems.Count > 0)
            {
                nr.Image = lvImageList.SelectedItems[0].Index;
            }
            else
            {
                nr.Image = 0;
            }



            //加入到内在中的表
            //mf.DS.NavUrl.AddNavUrlRow(nr);
            ////到数据库。
            //mf.navurlTap.Update(mf.DS.NavUrl);
            //txtFNodeText.Text = txtThisCode.Text = txtThisUrl.Text = "";
            //LoadTreeView();

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Dispose();


        }



    }
}
