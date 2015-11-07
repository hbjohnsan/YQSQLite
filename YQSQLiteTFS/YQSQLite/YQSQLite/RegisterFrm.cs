using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace YQSQLite
{
    public partial class RegisterFrm : Form
    {
        private MainFrm mf;
        //公钥
        private string DirXML = Application.StartupPath + @"\Xml";

        public RegisterFrm()
        {
            InitializeComponent();
        }
        public RegisterFrm(MainFrm f)
        {
            InitializeComponent();
            mf = f;

        }

        private void RegisterFrm_Load(object sender, EventArgs e)
        {
            RegistryKey rk = Registry.LocalMachine.OpenSubKey("SOFTWARE", true);
            txtName.ReadOnly = true;
            if (rk.GetValue("ZCM") != null)//读取系统的注册码，如果已注册则值值不为空可以使用，并标识已注册，反之则未注册
            {
                txtRegCode.ReadOnly = true;
                txtName.ReadOnly = true;
                txtRegCode.Text = rk.GetValue("ZCM").ToString();
                txtName.Text = Encrypt.DecryptString(rk.GetValue("ZCM").ToString());
                //labJQM.Visible = false;
                btnReg.Enabled = false;
                this.Text = "已注册！";
            }
            
            XElement root = XElement.Load(DirXML + @"\user.xml");
            txtName.Text = root.Element("user").Element("Name").Value;
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {

            DialogResult = DialogResult.Cancel;
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text))//先检测用户输入是否为空
            {

                if (txtRegCode.Text == Encrypt.EncryptString(txtName.Text.Trim()))//再检测用户输入是否和显示的注册码一直
                {
                    RegistryKey rk = Registry.LocalMachine.OpenSubKey("SOFTWARE", true);
                    rk.SetValue("ZCM", txtRegCode.Text);//将注册码写入系统的关于程序信息的注册表下SOFTWARE文件下的"ZCM"名中
                    MessageBox.Show("注册成功！请再次登录！");
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("您输入的注册码不正确，请联系QQ：3174689！");
                }
                //jia();
                //yanzheng();
            }
            else
            {
                MessageBox.Show("请输入用户名！");
            }


        }

      
    }
}