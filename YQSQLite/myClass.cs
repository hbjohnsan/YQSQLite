using System;
using System.Collections.Generic;
using System.Data;
using System.Management;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Windows.Forms;
using System.Net;
using System.Runtime.InteropServices;





namespace YQSQLite
{
    public delegate void UpdataListView(ListViewItem lv);
    public class caiji
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string WebSer { get; set; }
        public string Channels { get; set; }
        public string UpTime { get; set; }
        public string Sourc { get; set; }
        public string content { get; set; }
        public string IsRead { get; set; }
        public string Link { get; set; }
        public DateTime CjTime { get; set; }
    }
    public class cpcuse
    {
        public int Id { get; set; }
        public string Rank { get; set; }
        public string Term { get; set; }
        public string KanWu { get; set; }
        public DateTime UseTime { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime InTime { get; set; }

    }
    public class upsend
    {
        public string Site { get; set; }
        public string Title { get; set; }
        public DateTime UpTime { get; set; }
        public string Link { get; set; }
        public string Content { get; set; }
        public string EmailSend { get; set; }
        public string WebSend { get; set; }
        public string ContKind { get; set; }
        public string WillSend { get; set; }
    }
    public class sendto
    {
        public int Id { get; set; }
        public string RankName { get; set; }
        public string Rank { get; set; }
        public string Kind { get; set; }
        public string Email { get; set; }
        public string ReTitle { get; set; }
        public string addlink { get; set; }


    }
    public class rules
    {
        public int RuleID { get; set; }
        public string Rule_site { get; set; }
        public string Rule_Domain { get; set; }
        public string ContFlag { get; set; }
        public string RemoveFlag { get; set; }
        public rules() { }
        public rules(string rule_site, string urlflag, string contflag, string removeflag)
        {
            this.Rule_site = rule_site;
            this.Rule_Domain = urlflag;
            this.ContFlag = contflag;
            this.RemoveFlag = removeflag;
        }
        public rules(int ruleid, string rule_site, string urlflag, string contflag, string removeflag)
        {
            this.RuleID = ruleid;
            this.Rule_site = rule_site;
            this.Rule_Domain = urlflag;
            this.ContFlag = contflag;
            this.RemoveFlag = removeflag;
        }
    }
    public class RssItem
    {
        public int RssItemID { get; set; }
        public string ChannelCode { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public DateTime PubDate { get; set; }
        public string IsRead { get; set; }
        public string Content { get; set; }
        public RssItem() { } 
        public RssItem( string channelcode, string title, string link, DateTime pubdate, string isread, string content)
        {
           
            this.ChannelCode = channelcode;
            this.Title = title;
            this.Link = link;
            this.PubDate = pubdate;
            this.IsRead = isread;
            this.Content = content;
        }
        public RssItem( int rssitemid, string channelcode, string title, string link, DateTime pubdate, string isread, string content)
        {
            
            this.RssItemID = rssitemid;
            this.ChannelCode = channelcode;
            this.Title = title;
            this.Link = link;
            this.PubDate = pubdate;
            this.IsRead = isread;
            this.Content = content;
        }

    }
    public class NavUrl
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string Nav_Domain { get; set; }
        public int PID { get; set; }
        public string Code { get; set; }
        public int Level { get; set; }
        public string Leaf { get;set;}
        public string Link { get; set; }
        public int Image { get; set; }
        public int NoReadCount { get; set; }
        public int ItemCount { get; set; }


    }
    //系统配置类
    [Serializable()]
    public class configYQ
    {
        /// <summary>
        /// rss更新频率
        /// </summary>
        public int uptime { get; set; }
        /// <summary>
        /// rss频道保存条目
        /// </summary>
        public int savenumb { get; set; }
        /// <summary>
        /// 开启是否立即更新
        /// </summary>
        public bool isupdate { get; set; }
        /// <summary>
        /// 消息更新速度
        /// </summary>
        public int messagetime { get; set; }
        /// <summary>
        /// 是否显示消息框
        /// </summary>
        public bool isShow { get; set; }


    }
   




    public class caijiComparer : IEqualityComparer<caiji>
    {
        public bool Equals(caiji x, caiji y)
        {
            return x.Title.Equals(y.Title);
        }
        public int GetHashCode(caiji obj)
        {
            return 0;
        }
    }


    //RssItem比较器
    public class DataTableRowCompare : IEqualityComparer<DataRow>
    {

        #region IEqualityComparer<DataRow> 成员

        public bool Equals(DataRow x, DataRow y)
        {
            return (x.Field<string>("Title") == y.Field<string>("Title"));
        }

        public int GetHashCode(DataRow obj)
        {
            return obj.ToString().GetHashCode();
        }

        #endregion
    }

    #region  第一种加解密方法
    /// <summary>
    /// 加密类
    /// </summary>
    public static class Register
    {
        /// <summary>
        /// 时间：2012-11-11
        /// 作者：黄雪峰
        /// 功能：用于获得Mac地址、CUP、硬盘编号、生成机器码、注册码
        /// </summary>

        #region Members
        public static int[] intCode = new int[126];
        public static int[] mNumber = new int[24];
        public static char[] mChar = new char[24];
        #endregion

        #region Methods

        /// <summary>
        /// 获取本机的Mac地址
        /// </summary>
        /// <returns></returns>
        public static string GetMac()
        {
            string mac = "";

            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                if ((bool)mo["IPEnabled"])
                {
                    mac = mo["MacAddress"].ToString();
                    break;
                }
            }
            return mac;
        }

        /// <summary>
        /// 获取硬盘序列号
        /// </summary>
        /// <returns></returns>
        public static string GetHD()
        {
            string hd = "";
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObject disk = new ManagementObject("win32_logicaldisk.deviceid=\"c:\"");
            disk.Get();
            hd = disk.GetPropertyValue("VolumeSerialNumber").ToString();
            return hd;
        }

        /// <summary>
        /// 获取CPU号
        /// </summary>
        /// <returns></returns>
        public static string GetCPU()
        {
            string cpu = "";
            ManagementClass mc = new ManagementClass("win32_Processor");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                cpu = mo["ProcessorId"].ToString();
            }
            return cpu;
        }

        /// <summary>
        /// 生成机器码
        /// </summary>
        /// <returns></returns>
        public static string GetMachineNumber()
        {
            string s = "";
            //原来方法，用网卡和硬盘号
            //string yString = GetMac() + GetHD();
            //新方法用硬盘和CPU号
            string yString = GetCPU() + GetHD();
            string[] rNumber = new string[24];
            Random r = new Random();
            for (int i = 0; i < 24; i++)
            {
                rNumber[i] = yString.Substring(r.Next(0, yString.Length), 1);
                s += rNumber[i];
            }
            return s;
        }

        /// <summary>
        /// 初始化数组
        /// </summary>
        public static void InitCode()
        {
            Random r = new Random();
            for (int i = 0; i < intCode.Length; i++)
            {
                intCode[i] = r.Next(0, 9);
            }
        }

        /// <summary>
        /// 生成注册码
        /// </summary>
        /// <returns></returns>
        public static string GetRegisterNumber()
        {
            string machineNumber = GetMachineNumber();
            string registerNumber = "";
            for (int i = 0; i < 24; i++)
            {
                mChar[i] = Convert.ToChar(machineNumber.Substring(i, 1));
            }
            for (int i = 0; i < 24; i++)
            {
                mNumber[i] = intCode[Convert.ToInt32(mChar[i])] + Convert.ToInt32(mChar[i]);
            }
            for (int i = 0; i < mNumber.Length; i++)
            {
                if (mNumber[i] >= 48 && mNumber[i] <= 57)
                {
                    registerNumber += (Char)mNumber[i];
                }
                else if (mNumber[i] >= 65 && mNumber[i] <= 90)
                {
                    registerNumber += (Char)mNumber[i];
                }
                else if (mNumber[i] >= 97 && mNumber[i] <= 122)
                {
                    registerNumber += (Char)mNumber[i];
                }
                else
                {
                    if (mNumber[i] > 122)
                    {
                        registerNumber += (Char)(mNumber[i] - 10);
                    }
                    else
                    {
                        registerNumber += (Char)(mNumber[i] - 9);
                    }
                }
            }
            return registerNumber;
        }

        #endregion
    }
    /// <summary>
    /// 解密类   想用用户名和密码取代机器码的注册方式
    /// </summary>
    public static class DESReg
    {
        //默认密钥向量
        private static byte[] Keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xFE };
        /// <summary>
        /// DES加密字符串
        /// </summary>
        /// <param name="encryptString">待加密的字符串</param>
        /// <param name="encryptKey">加密密钥，要求为8位</param>
        /// <returns>加密成功返回加密的字符中，失败返回源串</returns>
        public static string EncryptDES(string encryptString, string encryptKey)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));//转换为字节
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
                DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();//实例化数据加密
                MemoryStream mStream = new MemoryStream();//实例化内存流
                //将数据流链接到加密转的流
                CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Convert.ToBase64String(mStream.ToArray());
            }
            catch
            {

                return encryptString;
            }
        }
        /// <summary>
        /// DES解密字符串
        /// </summary>
        /// <param name="decryptString">待解密的字符串</param>
        /// <param name="decryptKey">解密密钥，要求为8位，和加密密钥相同</param>
        /// <returns>解密成功返回解密的字条串，失败返源串</returns>
        public static string DecryptDES(string decryptString, string decryptKey)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(decryptKey);
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Convert.FromBase64String(decryptString);
                DESCryptoServiceProvider DCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(mStream.ToArray());

            }
            catch
            {

                return decryptString;
            }

        }

    }

    #endregion

    #region 第二种加解密方法
    /// <summary>
    /// 加解密类
    /// </summary>
    public static class Encrypt
    {
        #region "定义加密字串变量"
        private static SymmetricAlgorithm mCSP = new DESCryptoServiceProvider();  //声明对称算法变量
        private const string CIV = "Mi9l/+7Zujhy12se6Yjy111A";  //初始化向量
        private const string CKEY = "jkHuIy9D/9i="; //密钥（常量）
        //private string CKEY = Register.GetCPU().ToString();
        #endregion
        /// <summary>
        /// 实例化
        /// </summary>
        //public Encrypt()
        //{
        //    mCSP;  //定义访问数据加密标准 (DES) 算法的加密服务提供程序 (CSP) 版本的包装对象,此类是SymmetricAlgorithm的派生类
        //}

        /// <summary>
        /// 加密字符串
        /// </summary>
        /// <param name="Value">需加密的字符串</param>
        /// <returns></returns>
        public static string EncryptString(string Value)
        {
            ICryptoTransform ct; //定义基本的加密转换运算
            MemoryStream ms; //定义内存流
            CryptoStream cs; //定义将内存流链接到加密转换的流
            byte[] byt;
            //CreateEncryptor创建(对称数据)加密对象
            ct = mCSP.CreateEncryptor(Convert.FromBase64String(CKEY), Convert.FromBase64String(CIV)); //用指定的密钥和初始化向量创建对称数据加密标准
            byt = Encoding.UTF8.GetBytes(Value); //将Value字符转换为UTF-8编码的字节序列
            ms = new MemoryStream(); //创建内存流
            cs = new CryptoStream(ms, ct, CryptoStreamMode.Write); //将内存流链接到加密转换的流
            cs.Write(byt, 0, byt.Length); //写入内存流
            cs.FlushFinalBlock(); //将缓冲区中的数据写入内存流，并清除缓冲区
            cs.Close(); //释放内存流
            return Convert.ToBase64String(ms.ToArray()); //将内存流转写入字节数组并转换为string字符
        }

        /// <summary>
        /// 解密字符串
        /// </summary>
        /// <param name="Value">要解密的字符串</param>
        /// <returns>string</returns>
        public static string DecryptString(string Value)
        {
            ICryptoTransform ct; //定义基本的加密转换运算
            MemoryStream ms; //定义内存流
            CryptoStream cs; //定义将数据流链接到加密转换的流
            byte[] byt;
            ct = mCSP.CreateDecryptor(Convert.FromBase64String(CKEY), Convert.FromBase64String(CIV)); //用指定的密钥和初始化向量创建对称数据解密标准
            byt = Convert.FromBase64String(Value); //将Value(Base 64)字符转换成字节数组
            ms = new MemoryStream();
            cs = new CryptoStream(ms, ct, CryptoStreamMode.Write);
            cs.Write(byt, 0, byt.Length);
            cs.FlushFinalBlock();
            cs.Close();
            return Encoding.UTF8.GetString(ms.ToArray()); //将字节数组中的所有字符解码为一个字符串
        }
    }

    #endregion

    //这就是个主要的cookie的自定义类.
    public class MainCookie
    {
        private static string cookie = string.Empty;

        public static string Cookie
        {
            get { return MainCookie.cookie; }
            set { MainCookie.cookie = value; }
        }
        private static CookieContainer cc = new CookieContainer();

        public static CookieContainer Cc
        {
            get { return MainCookie.cc; }
            set { MainCookie.cc = value; }
        }

        //记得引用命名空间. 使用这俩API只有一个目的.!对方如果设置有httponly那么webBrowser得到的也不是完整的cookie,那么就从api去获取吧..
        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool InternetGetCookieEx(string pchURL, string pchCookieName, StringBuilder pchCookieData, ref System.UInt32 pcchCookieData, int dwFlags, IntPtr lpReserved);

        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int InternetSetCookieEx(string lpszURL, string lpszCookieName, string lpszCookieData, int dwFlags, IntPtr dwReserved);
        public static string GetCookies(string url)
        {
            uint datasize = 256;
            StringBuilder cookieData = new StringBuilder((int)datasize);
            if (!InternetGetCookieEx(url, null, cookieData, ref datasize, 0x2000, IntPtr.Zero))
            {
                if (datasize < 0)
                    return null;


                cookieData = new StringBuilder((int)datasize);
                if (!InternetGetCookieEx(url, null, cookieData, ref datasize, 0x00002000, IntPtr.Zero))
                    return null;
            }
            return cookieData.ToString();
        }
    }



}
