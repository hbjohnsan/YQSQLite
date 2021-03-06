﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using System.Threading;

namespace YQSQLite
{
    public partial class EditFrm : DockContent
    {
        private MainFrm mf;
        private string contSite = "";//来源
        private string contKind = "";//类别
       private int RssitemID;
        private StringBuilder stWillSendTO = new StringBuilder();//报送到

        public EditFrm()
        {
            InitializeComponent();
        }
        public EditFrm(MainFrm f)
        {
            InitializeComponent();
            mf = f;
        }

        private void EditFrm_Load(object sender, EventArgs e)
        {
            rabYQ.Checked = true;
            ckbZX.Checked = true;
            ckbSheng.Checked = true;
            ckbShi.Checked = true;
        }

        #region 接收到待处理窗体方法
        /// <summary>
        /// 接收到待处理窗体方法
        /// </summary>
        /// <param name="rssit"></param>
        public void EditRssItem(int ID)//RssItem it)
        {
            RssitemID = ID;
            btnRemove.Enabled = true;
            btnAdd.Text = "待报";
            //rabSourc.Checked = true;

            
            YQDataSet.RssItemRow row = mf.DS.RssItem.FindByRssItemID(ID);
            this.Invoke(new ThreadStart(delegate
            {
                txtTitle.Text = row.Title;
                linkLabel1.Text = row.Link;
                labUpTime.Text = String.Format("{0:G}", row.PubDate);
                labSourc.Text = row.SiteName;
                htmlEditor1.HTML = row.Content;
               // webBrowser1.Navigate(row.Link);

            }));
           
        }

        #endregion

        #region 使用代理
        //定义一个代理
        // private delegate void DelReLoadRssItem(string title);
        //多线程处理吧！
        private void ReLoadRssItem(string title)
        {

        }
        //待报送窗体修改内容
        public void ReloadUpsendItem(upsend up)
        {

            btnRemove.Enabled = false;
            // htmlEditor1.HTML = "";
            btnRemove.Enabled = true;
            btnAdd.Text = "修改";
            //rabSourc.Checked = true;

            txtTitle.Text = up.Title;
            linkLabel1.Text = up.Link;
            labUpTime.Text = up.UpTime.ToString();
            
                labSourc.Text = up.Site;
           

            htmlEditor1.HTML = up.Content;


        }
        #endregion

        #region 待报和修改按键事件
        //待报和修改按键事件
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text != string.Empty)//&& !(mf.DS.upsend.Contains(mf.DS.upsend.FindByTitle(txtTitle.Text.Trim()))))
            {
                if (btnAdd.Text == "待报")
                {
                    stWillSendTO.Clear();
                    getContrlText();
                    //如果是自采，时间是当前计算机时间
                    YQDataSet.upsendRow row;
                    if (contSite == "自采")
                    {
                        row = mf.DS.upsend.AddupsendRow(contSite, txtTitle.Text.Trim(), DateTime.Now, linkLabel1.Text, htmlEditor1.HTML, "待报送", "待报送", contKind, stWillSendTO.ToString());
                        //更新到库
                        mf.upsendTap.Update(row);
                        //重新加载“待报送”                     
                        mf.WaitSendFmReload();
                        //清空数值
                        txtClear();
                    }
                    else
                    {
                        row = mf.DS.upsend.AddupsendRow(contSite, txtTitle.Text.Trim(), Convert.ToDateTime(labUpTime.Text), linkLabel1.Text, htmlEditor1.HTML, "待报送", "待报送", contKind, stWillSendTO.ToString());
                        YQDataSet.RssItemRow rssrow = mf.DS.RssItem.FindByRssItemID(RssitemID);// (txtTitle.Text.Trim());
                        rssrow.IsRead = "T";
                        mf.rssTap.Update(rssrow);
                        //更新到库
                        mf.upsendTap.Update(row);
                        //重新加载“预选”
                        mf.WaitEditFmReLoad();
                        //重新加载“待报送”
                        mf.WaitSendFmReload();
                        //清空数值
                        txtClear();
                    }


                }
                if (btnAdd.Text == "修改")
                {
                    stWillSendTO.Clear();
                    getContrlText();

                    YQDataSet.upsendRow row = mf.DS.upsend.FindByTitle(txtTitle.Text.Trim());
                    row.Title = txtTitle.Text.Trim();
                    row.UpTime = Convert.ToDateTime(labUpTime.Text);
                    row.Content = htmlEditor1.HTML;
                    row.Link = linkLabel1.Text;
                    row.Site = contSite;
                    row.ContKind = contKind;
                    row.WillSend = stWillSendTO.ToString();
                    //更新upsend表
                    mf.upsendTap.Update(row);
                    //显示更改后的列表
                    mf.WaitSendFmReload();
                    txtClear();
                }
            }
            else
            {
                MessageBox.Show("标题不能为空！");
            }
        }
        #endregion

        #region 取得单选和多选框值
        private void getContrlText()
        {
            //来源
            //foreach (Control ctr in gboxLY.Controls)
            //{
            //    RadioButton rb = ctr as RadioButton;
            //    if (rb.Checked)
            //    {
            //        contSite = rb.Text;
            //    }
            //}

            //类别
            foreach (Control ctr in gboxLB.Controls)
            {
                RadioButton rb = ctr as RadioButton;
                if (rb.Checked)
                {
                    contKind = rb.Text;
                }
            }
            //报送对象
            foreach (Control ctr in gboxSendTo.Controls)
            {

                if (ctr is CheckBox)
                {
                    CheckBox ck = ctr as CheckBox;
                    if (ck.Checked)
                    {
                        stWillSendTO.Append(ck.Text);
                    }
                }
            }
        }
        #endregion

        #region 清空复位窗体值
        public void txtClear()
        {
            txtTitle.Text = "";
            htmlEditor1.HTML = "";
            labSourc.Text = "网站";           
            linkLabel1.Text = "";           
            labUpTime.Text = "";
        }
        #endregion
        //移除
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text != string.Empty)
            {
                getContrlText();
                //如果是自采，时间是当前计算机时间
                YQDataSet.upsendRow row;
                if (contSite == "自采")
                {
                    row = mf.DS.upsend.FindByTitle(txtTitle.Text.Trim());
                    row.Delete();
                    //更新到库
                    mf.upsendTap.Update(mf.DS.upsend);
                    //重新加载“待报送”                     
                    mf.WaitSendFmReload();
                    //清空数值
                    txtClear();
                }
                else
                {
                    row = mf.DS.upsend.FindByTitle(txtTitle.Text.Trim());
                    if (row != null)
                    {
                        row.Delete();
                    }

                    YQDataSet.RssItemRow rssrow = mf.DS.RssItem.FindByRssItemID(RssitemID);
                    //如果Rss新闻表被清空，移除时会出错！
                    if (rssrow != null)
                    {
                        rssrow.IsRead = "T";
                        mf.rssTap.Update(rssrow);
                    }


                    //更新到库
                    mf.upsendTap.Update(mf.DS.upsend);
                    //重新加载“预选”
                    mf.WaitEditFmReLoad();
                    //重新加载“待报送”
                    mf.WaitSendFmReload();
                    //清空数值
                    txtClear();
                }
            }
        }

        
        //外部浏览器打开
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("IExplore.exe", linkLabel1.Text);
        }
        //新建自采
        private void btnZiCai_Click(object sender, EventArgs e)
        {
            txtClear();
            btnAdd.Text = "待报";
            labSourc.Text = "自采";
            labUpTime.Text = DateTime.Now.ToString();
        }

       
    }
}
