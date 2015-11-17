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
    public partial class NavEidt : Form
    {
        private MainFrm mf;
        private DialogResult dr;

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

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            rabSun.Enabled = true;
            txtFNodeText.Text = e.Node.Text;
            NavUrl nu = e.Node.Tag as NavUrl;
            txtFatherID.Text = nu.PID.ToString();
            txtThisCode.Text = nu.Code;
            nudThislevel.Value = nu.level;

            //判断层级
            switch (nu.level)
            {
                case 0://顶层
                    //让子叶不能添加子节点。只有三级节点。
                    rabYes.Checked = rabSun.Checked = true;
                    //自动化判断新增中的级深。
                    nudNewlevel.Value = nu.level + 1;
                    labID.Text = txtID.Text = nu.ID.ToString();
                    ShowCode(nu.Code, nu.level);
                    break;
                case 1://中间
                    //让子叶不能添加子节点。只有三级节点。
                    rabYes.Checked = rabSun.Checked = true;
                    //自动化判断新增中的级深。
                    nudNewlevel.Value = nu.level + 1;
                    labID.Text = txtID.Text = nu.ID.ToString();
                    ShowCode(nu.Code, nu.level);
                    break;

                case 2://底层
                    rabNo.Checked = rabSame.Checked = true;
                    //让子叶不能添加子节点。只有三级节点。
                    txtID.Text = nu.PID.ToString();
                    //让三级不能加子级。
                    rabSun.Enabled = false;
                   
                    break;
                default:
                    
                    break;

            }

            txtThisUrl.Text = nu.Link;
            //记录ID值

            //标签，按键开关
            btnEdit.Enabled = txtThisCode.ReadOnly = txtThisUrl.ReadOnly = nudThislevel.ReadOnly = txtFatherID.ReadOnly = true;



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
                        txtNewCode.Text = "0" + (num.Max() + 1).ToString();
                    }
                    else
                    {
                        txtNewCode.Text = (num.Max() + 1).ToString();
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
                        num4.Add(Int32.Parse(c.Code.Substring(2,2)));
                    }
                    if (num4.Max() < 9)
                    {
                        txtNewCode.Text = code.Substring(0, 2) + "0" + (num4.Max() + 1).ToString();
                    }
                    else
                    {
                        txtNewCode.Text = code.Substring(0, 2) + (num4.Max() + 1).ToString();
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
            //标签，按键开关
            btnEdit.Enabled = txtThisCode.ReadOnly = txtThisUrl.ReadOnly = nudThislevel.ReadOnly = txtFatherID.ReadOnly = false;
        }
        //保存
        private void btnSave_Click(object sender, EventArgs e)
        {
            int id = int.Parse(labelxx.Text);
            SQLiteDS.NavUrlRow nur = mf.DS.NavUrl.FindByID(id);
            nur.Name = txtFNodeText.Text.Trim();
            nur.PID = Int32.Parse(txtID.Text);
            nur.Code = txtThisCode.Text.Trim();
            nur.level = (int)nudThislevel.Value;
            nur.Leaf = rabYes.Checked ? 0 : 1;
            nur.Link = txtThisUrl.Text.Trim();
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
            SQLiteDS.NavUrlRow nr = mf.DS.NavUrl.NewNavUrlRow();
            nr.Name = txtNodeName.Text.Trim();
            nr.Code = txtNewCode.Text.Trim();
            nr.level = (int)nudNewlevel.Value;
            nr.Leaf = rabNewYes.Checked ? 0 : 1;
            nr.Link = txtNewUrl.Text.Trim();

            if (lvImageList.SelectedItems.Count > 0)
            {
                nr.Image = lvImageList.SelectedItems[0].Index;
            }
            else
            {
                nr.Image = 0;
            }



            if (rabSun.Checked == true)
            {
                nr.PID = int.Parse(labelxx.Text);
            }
            if (rabSame.Checked == true)
            {

            }
            //加入到内在中的表
            mf.DS.NavUrl.AddNavUrlRow(nr);
            //到数据库。
            mf.navurlTap.Update(mf.DS.NavUrl);
            txtNodeName.Text = txtNewCode.Text = txtNewUrl.Text = "";
            LoadTreeView();

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Dispose();


        }

        private void rabSame_CheckedChanged(object sender, EventArgs e)
        {
            if (rabSame.Checked == true)
            {
                txtID.Text = txtFatherID.Text;
                nudNewlevel.Value = nudThislevel.Value;
            }
        }

        private void rabSun_CheckedChanged(object sender, EventArgs e)
        {
            if (rabSun.Checked == true)
            {
                txtID.Text = labID.Text;
            }
        }

    }
}
