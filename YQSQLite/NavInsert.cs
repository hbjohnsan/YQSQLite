using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YQSQLite
{
    public partial class NavInsert : Form
    {
        private MainFrm mf;
        public NavInsert()
        {
            InitializeComponent();
        }
        public NavInsert(MainFrm f)
        {
            InitializeComponent();
            this.mf = f;
        }
        //新增
        private void btnSave_Click(object sender, EventArgs e)
        {
            //注意MF中NavUrl表的重新填充，及NavFrm中的数据绑定--dialogResult.OK后数据重新从库中绑定了。
            //新建一个具体的对象，然后把该对象行，加入到内存表中就OK了，最后可到库一下。转了很长时间的的圈子一下明白了。呵呵~
            YQDataSet.NavUrlRow nr = mf.DS.NavUrl.NewNavUrlRow();
            nr.PID = int.Parse(txtFatherID.Text.Trim());
            nr.Name = txtFNodeText.Text.Trim();
            nr.Nav_Domain = txtDomain.Text.Trim();
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



            //加入到内存中的表
            mf.DS.NavUrl.AddNavUrlRow(nr);
            //到数据库。
            mf.navurlTap.Update(nr);
           
            LoadTreeView();
            txtFNodeText.Text = "";
            txtDomain.Text = "";
            txtThisUrl.Text = "";

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }
        //自动计算Code值。
        private string ShowCode(string code, int level)
        {
            string txtcode = "";
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
                        txtcode = "0" + (num.Max() + 1).ToString();
                    }
                    else
                    {
                        txtcode = (num.Max() + 1).ToString();
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
                        txtcode = code.Substring(0, 2) + "0" + (num4.Max() + 1).ToString();
                    }
                    else
                    {
                        txtcode = code.Substring(0, 2) + (num4.Max() + 1).ToString();
                    }
                    break;
                case 6://底层
                    string lCode = code.Substring(0, 4);
                    var Qcode6 = from p in mf.DS.NavUrl
                                 where p.Code.StartsWith(lCode) && p.level == level //StartsWith这里使用这个，不是是.Contains
                                 select p;
                    List<int> num6 = new List<int>();
                    foreach (var c in Qcode6)
                    {
                        num6.Add(Int32.Parse(c.Code.Substring(4, 2)));
                    }
                    if (num6.Max() < 9)
                    {
                        txtcode = code.Substring(0, 4) + "0" + (num6.Max() + 1).ToString();
                    }
                    else
                    {
                        txtcode = code.Substring(0, 4) + (num6.Max() + 1).ToString();
                    }
                    break;
                default:
                    break;
            }
            return txtcode;

        }

        private void NavInsert_Load(object sender, EventArgs e)
        {
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
            rabTJ.Checked = true;

            NavUrl nu = e.Node.Tag as NavUrl;
            labJID.Text = nu.ID.ToString();//开于记录当前ID
            labIDType.Text = (nu.Level != 3) ? "当前节点可增加子节点和同级节点，请选择！" : "当前节点只可增加同级节点";
            if (nu.Level == 3)
            {
                rabZJ.Enabled = false;
            }
            else
            {
                rabZJ.Enabled = true;
            }

            ShowSameJ(nu);//显示同级


        }
        //增加同级节点，新节点的数据
        private void ShowSameJ(NavUrl nu)
        {
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

            //以下四种需要计算
            txtFatherID.Text = nu.PID.ToString();
            nudLevel.Value = (int)nu.Level;
            txtLeaf.Text = nu.Leaf;
            //需要计算  默认为同级节点
            txtThisCode.Text = ShowCode(nu.Code, nu.Level);
        }
        //单选按键变化时
        private void radioButton_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(labJID.Text);
            YQDataSet.NavUrlRow nur = mf.DS.NavUrl.FindByID(id);
            NavUrl nu = new NavUrl();
            nu.ID = nur.ID;
            nu.PID = nur.PID;
            nu.Code = nur.Code;
            nu.Level = nur.level;
            nu.Leaf = nur.Leaf;
            nu.Image = nur.Image;

            if (rabTJ.Checked == true)//增加同级
            {
                ShowSameJ(nu);//显示同级
            }
            else  //增加子级节点  主是新大分类中的子分类
            {
                ShowSubJ(nu);
            }

        }
        //增加子级节点，该新子级节点的数据
        private void ShowSubJ(NavUrl nu)
        {
            /*
             * 需要做的：
             * 1、层级+1，不大于3.
             * 2、PID等于自己IDave
             * 3、Level〈3为F，否则为T
             * 4、计算Code值 
             * 
             * 上面已经禁了是层级为3的项。所以只能判断为2和4项了。
             */
            txtFatherID.Text = nu.ID.ToString();
            nudLevel.Value = nu.Level + 1;

            //计算Code的值
            var qcode = from p in mf.DS.NavUrl.AsEnumerable()
                        where p.Code.StartsWith(nu.Code) && p.level == nu.Level + 1
                        select p;
            List<int> num = new List<int>();
            foreach (var item in qcode)
            {
                num.Add(Int32.Parse(item.Code));
            }
            if (num.Count == 0)//没有记录时。
            {
                txtThisCode.Text = nu.Code + "01";
            }
            else
            {


                if (num.Max() < 9)//小于9的，只有一位；
                {
                    txtThisCode.Text = nu.Code + "0" + (num.Max() + 1).ToString();
                }
                else
                {
                    txtThisCode.Text = (num.Max() + 1).ToString();
                }
            }

            switch (nu.Code.Length)
            {
                case 2://此处节点为2级的
                    txtLeaf.Text = nu.Leaf;
                    txtDomain.Enabled = false;
                    txtThisUrl.Enabled = false;
                    break;
                case 4://此处节点为3级的，即信RSS地址的
                    txtLeaf.Text = "T";
                    txtDomain.Enabled = true;
                    txtThisUrl.Enabled = true;

                    break;
                case 6:  //此处为不能增加子节点了。否则会很多层级。
                    break;
                default:
                    break;
            }
        }
    }
}
