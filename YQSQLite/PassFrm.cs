using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace YQSQLite
{
    public partial class PassFrm : Form
    {
        private MainFrm mf;
        public PassFrm()
        {
            InitializeComponent();
        }
        public PassFrm(MainFrm f)
        {
            InitializeComponent();
            mf = f;
        }

        private void PassFrm_Load(object sender, EventArgs e)
        {
            XElement xe = XElement.Load(mf.DirXml+ @"\user.xml");
            txtOldName.Text = xe.Element("user").Element("Name").Value;
            txtOldPwd.Text = xe.Element("user").Element("Pwd").Value;
        }
        private void btnCancle_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if ((txtNewName.Text) != "" && (txtNewPwd.Text) != "")
            {
                XElement xe = XElement.Load(mf.DirXml + @"\user.xml");
                xe.Element("user").Element("Name").Value = txtNewName.Text;
                xe.Element("user").Element("Pwd").Value = txtNewPwd.Text;
                xe.Save(Application.StartupPath + @"\user.xml");
                MessageBox.Show("修改成功！");
                DialogResult = DialogResult.OK;
            }

        }

        private void txtNewPwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnOK_Click(sender, e);
            }
        }
    }
}
