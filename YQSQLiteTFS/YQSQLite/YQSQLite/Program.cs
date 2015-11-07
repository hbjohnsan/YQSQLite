using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace YQSQLite
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            int num = UpdaterHelper.CheckNewFiles();
            if (num > 0)
            {
                if (System.Windows.Forms.MessageBox.Show(string.Format("发现新版本，只有更新后才能使用！", num), "更新提示", MessageBoxButtons.OK, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    UpdaterHelper.RunUpdater();
                }
                return;
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                LoginFrm lgfrm = new LoginFrm();
                if (lgfrm.ShowDialog() == DialogResult.OK)//表示当f1的DialogResult等于Ok时主程序才开始运行，所以在Form1中登录成功时要将Dialogresult设为OK
                {
                    Application.Run(new MainFrm());
                }
            }

        }
    }
}
