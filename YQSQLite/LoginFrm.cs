using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using System.Xml;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace YQSQLite
{
    public partial class LoginFrm : Form
    {
        public LoginFrm()
        {
            InitializeComponent();
        }
        private string DirData = Application.StartupPath + @"\Data";
        private string DirXml = Application.StartupPath + @"\Xml";

        private void LoginFrm_Load(object sender, EventArgs e)
        {

            //判断目录是否存在
            if (!Directory.Exists(DirXml))
            {
                Directory.CreateDirectory(DirXml);
            }
            //判断软件环境配置文件是否存在，不存在创新赋值
            if (!File.Exists(DirData + @"\config.dat"))
            {
                configYQ cf = new configYQ();
                cf.uptime = 60;
                cf.isShow = true;
                cf.isupdate = true;
                cf.messagetime = 3;
                cf.savenumb = 100;
                FileStream fs = new FileStream(DirData + @"\config.dat", FileMode.Create);
                try
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, cf);
                }
                catch (SerializationException ei)
                {

                    MessageBox.Show(ei.Message);
                }
                finally
                {
                    fs.Close();
                }
            }

            //第一次找配置文件，没找到，要用户输入用户名密码，并保存XML文件中
            if (!File.Exists(DirXml + @"\user.xml"))
            {
                labCon.Visible = txtCon.Visible = labFristLog.Visible = true;
                ckbRember.Visible = false;
                labFristLog.Text = "首次登录请输入用户名和密码！";

            }
            else//第二次以后，找文件，找到后，比较用户名和密码。
            {
                labCon.Visible = txtCon.Visible = labFristLog.Visible = false;
                labFristLog.Text = "";
                ckbRember.Visible = true;
                XElement xe = XElement.Load(DirXml + @"\user.xml");
                ckbRember.Checked = Convert.ToBoolean(xe.Element("user").Element("Rem").Value);
                if (ckbRember.Checked == true)
                {
                    txtName.Text = xe.Element("user").Element("Name").Value;
                    txtPwd.Text = xe.Element("user").Element("Pwd").Value;
                }
            }



        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (isEmail())
            {


                if (!File.Exists(DirXml + @"\user.xml"))
                {
                    if (txtPwd.Text != txtCon.Text)
                    {
                        MessageBox.Show("两次密码不一致");

                    }
                    if (!string.IsNullOrEmpty(txtName.Text.Trim()) && !string.IsNullOrEmpty(txtPwd.Text.Trim()))
                    {
                        XElement xe = new XElement("root",
                            new XElement("user",
                                new XElement("Name", txtName.Text.Trim()),
                                new XElement("Pwd", txtPwd.Text.Trim()),
                                new XElement("Rem", ckbRember.Checked.ToString())
                                )
                            );
                        xe.Save(DirXml + @"\user.xml");
                        this.DialogResult = DialogResult.OK;
                    }

                }
                else
                {
                    XElement root = XElement.Load(DirXml + @"\user.xml");
                    if ((txtName.Text.Trim() != "") && (txtPwd.Text) != "")
                    {
                        if (ckbRember.Checked == true)
                        {
                            root.Element("user").Element("Rem").Value = ckbRember.Checked.ToString();
                            root.Save(DirXml + @"\user.xml");
                        }
                        if (root.Element("user").Element("Name").Value == txtName.Text && root.Element("user").Element("Pwd").Value == txtPwd.Text)
                        {
                            DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            if (root.Element("user").Element("Name").Value == txtName.Text)
                            {
                                labFristLog.Visible = true;
                                labFristLog.Text = "请输入正确的密码！";
                                txtPwd.Focus();
                            }
                            else
                            {
                                labFristLog.Text = "请输入正确的用户名和密码！";
                                labFristLog.Visible = true;
                            }

                        }
                    }

                }

            }
        }

        private void txtPwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnLogin_Click(sender, e);
            }
        }

        private bool isEmail()
        {
            bool flag = false;
            string strReg = @"^(\w)+(\.\w+)*@(\w)+((\.\w+)+)$";
            Regex reg = new Regex(strReg);
            if (reg.IsMatch(txtName.Text.Trim()))
            {
                flag = true;
            }
            else
            {
                MessageBox.Show("请输入邮箱格式用户名！");
            }
            return flag;
        }


    }
}
