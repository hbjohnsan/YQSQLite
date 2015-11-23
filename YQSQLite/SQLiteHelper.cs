using System;
using System.Configuration;
using System.Data.SQLite;
using System.Data;
using System.Windows.Forms;

namespace YQSQLite
{
    /// <summary>
    /// 静态帮助类，用于事务更新。
    /// </summary>
    public static class SQLiteHelper
    {
        private static string connStr = ConfigurationManager.ConnectionStrings["YQConnectionString"].ConnectionString.ToString();
        /// <summary>
        /// 带参数的，事务执行。
        /// </summary>
        /// <param name="dt">需要操作的表</param>
        /// <param name="commandText">QL命令字符串</param>
        /// <param name="commandParameters">参数</param>
        /// <returns></returns>
        public static int TransExecuteNonQuery(DataTable dt, string commandText, SQLiteParameter[] commandParameters)
        {
            //加入了详细的任务列表
            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                int result = 0;
                conn.Open();
                using (System.Data.SQLite.SQLiteTransaction trans = conn.BeginTransaction())
                {
                    using (SQLiteCommand cmd = new SQLiteCommand(conn))
                    {
                        cmd.Transaction = trans;
                        cmd.CommandText = commandText;
                        if (commandParameters != null)
                        {
                            cmd.Parameters.AddRange(commandParameters);
                        }

                        try
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                result = cmd.ExecuteNonQuery();
                            }


                            trans.Commit();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            trans.Rollback();

                        }
                    }
                }
                return result;
            }
        }
        /// <summary>
        /// 不带参数的事务执行
        /// </summary>
        /// <param name="dt">需要操作的表</param>
        /// <param name="commandText">SQL命令字符串</param>
        /// <returns></returns>
        public static int TransExecuteNonQuery(DataTable dt, string commandText)
        {
            //加入了详细的任务列表
            using (SQLiteConnection conn = new SQLiteConnection(connStr))
            {
                int result = 0;
                conn.Open();
                using (System.Data.SQLite.SQLiteTransaction trans = conn.BeginTransaction())
                {
                    using (SQLiteCommand cmd = new SQLiteCommand(conn))
                    {
                        cmd.Transaction = trans;
                        cmd.CommandText = commandText;

                        try
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                result = cmd.ExecuteNonQuery();
                            }


                            trans.Commit();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            trans.Rollback();

                        }
                    }
                }
                return result;
            }
        }
    }
}
