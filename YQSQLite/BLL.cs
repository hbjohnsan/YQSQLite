using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Syndication;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Net;


namespace YQSQLite
{
    public class BLL
    {

        //通用解析RSS方法
        protected void ShowRSS(string rssURI)
        {
          
            
            SyndicationFeed sf = SyndicationFeed.Load(XmlReader.Create(rssURI));

            //textBox1.Text += "title:" + sf.Title.Text + "\r\n";
            //if (sf.Links.Count > 0)
            //    textBox1.Text += "Link:" + sf.Links[0].Uri.ToString() + "\r\n";
            //if (sf.Authors.Count > 0 && !string.IsNullOrEmpty(sf.Authors[0].Uri))
            //    textBox1.Text += "Link:" + sf.Authors[0].Uri.ToString() + "\r\n";
            //textBox1.Text += "pubDate:" + sf.LastUpdatedTime.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n";

            foreach (SyndicationItem it in sf.Items)
            {
                //textBox1.Text += "\r\n-----------------------------------------------------\r\n";
                ////textBox1.Text += "title:" + it.Title.Text + "\r\n";
                //if (it.Links.Count > 0)
                //    textBox1.Text += "Link:" + it.Links[0].Uri.ToString() + "\r\n";
                //textBox1.Text += "PubDate:" + it.PublishDate.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n";
                //if (it.Summary != null)
                //    textBox1.Text += "Summary:" + it.Summary.Text + "\r\n";
                //if (it.Content != null)
                //    textBox1.Text += "Content:" + ((TextSyndicationContent)it.Content).Text + "\r\n";
                //Application.DoEvents();
            }

            

        }

        /// <summary>
        /// 反序列化
        /// </summary>
        public static T Deserialize<T>(string xmlContent)
        {
            XmlSerializer xs = new XmlSerializer(typeof(T));
            using (StringReader strReader = new StringReader(xmlContent))
            {
                XmlReader xmlReader = XmlReader.Create(strReader);
                return (T)xs.Deserialize(xmlReader);
            }
        }
    }
}
