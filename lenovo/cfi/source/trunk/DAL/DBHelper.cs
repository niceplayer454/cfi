using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;

using Lenovo.CFI.Common;
using System.Data;

namespace Lenovo.CFI.DAL
{
    public class DBHelper
    {
        private DBHelper() { }

        /// <summary>
        /// 获取数据库。
        /// </summary>
        /// <returns></returns>
        public static Database GetDatabase()
        {
            return DatabaseFactory.CreateDatabase();
        }

        /// <summary>
        /// 获取数据库连接。
        /// </summary>
        /// <returns></returns>
        public static DbConnection GetConnection()
        {
            return DatabaseFactory.CreateDatabase().CreateConnection();
        }

        /// <summary>
        /// 尝试解析SqlException数据库异常。
        /// </summary>
        /// <param name="sex">SqlException</param>
        /// <param name="delete">是否是删除命令。</param>
        public static void ParseSqlException(System.Data.SqlClient.SqlException sex, bool? delete)
        {
            if (sex.Errors.Count > 0)
            {
                switch (sex.Errors[0].Number)
                {
                    case 547:   // %1! 语句与 %2! %3! 约束 ''%4!'' 冲突。该冲突发生于数据库 ''%6!''，表 ''%8!''%10!%11!%13!。 
                        if (delete.HasValue)
                        {
                            if (delete.Value)
                                throw new DeletingDataUsedException("要删除的数据被其他数据引用：" + sex.Message, sex);
                            else
                                throw new ReferDataNotExistException("引用的数据不存在：" + sex.Message, sex);
                        }
                        else
                            throw new ViolateReferenceException(sex.Message, sex);
                    case 515:   // 无法将 NULL 值插入列 ''%1!''，表 ''%3!''；该列不允许空值。%ls 失败。 
                        throw new DBNotNullException("无法插入空值：" + sex.Message, sex);
                }
            }

            throw sex;
        }

        /// <summary>
        /// 获取当前时间，按照SQL SERVER的方式保留精度
        /// </summary>
        /// <returns>当前时间</returns>
        /// <remarks>准确度为三百分之一秒或 3.33 毫秒。值被圆整到 .000、.003 或 .007 毫秒增量</remarks>
        public static DateTime GetNowForDB()
        {
            return GetStampForDB(DateTime.Now);
        }

        public static DateTime GetStampForDB(DateTime stamp)
        {
            int millisecond = stamp.Millisecond % 10;
            int add = 0;
            switch (millisecond)
            {
                case 2:
                case 5:
                case 9:
                    add = -2;
                    break;
                case 1:
                case 4:
                case 8:
                    add = -1;
                    break;
                case 6:
                    add = -3;
                    break;
            }

            return new DateTime(stamp.Year, stamp.Month, stamp.Day,
                stamp.Hour, stamp.Minute, stamp.Second, stamp.Millisecond + add, DateTimeKind.Local);

        }

        /// <summary>
        /// 获取数据库。
        /// </summary>
        /// <returns></returns>
        public static Database GetCompDatabase()
        {
            return DatabaseFactory.CreateDatabase("diamond");
        }
    }

    /// <summary>
    /// 数据库事务帮助类。
    /// </summary>
    public class TranscationHelper : IDisposable
    {
        private TranscationHelper()
        {
            this.dataBase = DBHelper.GetDatabase();
        }

        /// <summary>
        /// 获取事务帮助器对象。
        /// </summary>
        /// <returns>事务对象。</returns>
        public static TranscationHelper GetInstance()
        {
            return new TranscationHelper();
        }

        private Database dataBase;
        private DbConnection connection;
        private DbTransaction transaction;

        /// <summary>
        /// 获取对应的数据库
        /// </summary>
        internal Database DataBase
        {
            get { return this.dataBase; }
        }

        /// <summary>
        /// 数据库事务
        /// </summary>
        public DbTransaction Transaction
        {
            get { return this.transaction; }
        }

        /// <summary>
        /// 开始。
        /// </summary>
        public void BeginTrans(IsolationLevel isolationLevel)
        {
            connection = DataBase.CreateConnection();
            connection.Open();
            transaction = connection.BeginTransaction(isolationLevel);
        }
        /// <summary>
        /// 开始。
        /// </summary>
        public void BeginTrans()
        {
            connection = DataBase.CreateConnection();
            connection.Open();
            transaction = connection.BeginTransaction();
        }
        /// <summary>
        /// 提交。
        /// </summary>
        public void CommitTrans()
        {
            Transaction.Commit();
            connection.Close();
        }
        /// <summary>
        /// 回滚。
        /// </summary>
        public void RollTrans()
        {
            Transaction.Rollback();
            connection.Close();
        }


        private bool disposed = false;

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (connection != null)
                    connection.Close();
            }
            disposed = true;
        }

        /// <summary>
        /// ~
        /// </summary>
        ~TranscationHelper()
        {
            Dispose(false);
        }
    }

    /// <summary>
    /// Boolen值与int值转换帮助类。
    /// true -- 0
    /// false -- 1
    /// </summary>
    internal class BoolHelper
    {
        /// <summary>
        /// 将bool值转换为int
        /// </summary>
        /// <param name="b">bool值。</param>
        /// <returns>对应的int值。</returns>
        public static int ConvertBoolToInt(bool b)
        {
            return (b) ? 0 : 1;
        }

        /// <summary>
        /// 将bool值转换为int
        /// </summary>
        /// <param name="b">bool值。</param>
        /// <returns>对应的int值。</returns>
        public static int? ConvertBoolToInt(bool? b)
        {
            return b.HasValue ? ((b.Value) ? 0 : 1) : (int?)null;
        }

        /// <summary>
        /// 将int值转换为bool
        /// </summary>
        /// <param name="i">int值。</param>
        /// <returns>对应的bool值。</returns>
        public static bool ConvertIntToBool(int i)
        {
            return (i == 0);
        }
    }

    internal class InHelper
    {
        public static string ConvertToInStr(params int[] ids)
        {
            if (ids == null || ids.Length == 0) return String.Empty;

            return ConvertToInStrPrivate(ids);
        }

        public static string ConvertToInStr(List<int> ids)
        {
            if (ids == null || ids.Count == 0) return String.Empty;

            return ConvertToInStrPrivate(ids);
        }

        private static string ConvertToInStrPrivate(IEnumerable<int> ids)
        {
            StringBuilder sbIds = new StringBuilder();
            foreach (int id in ids)
            {
                sbIds.Append(id.ToString()).Append(",");
            }
            sbIds.Remove(sbIds.Length - 1, 1);
            return sbIds.ToString();
        }

        public static string ConvertToInStr(List<Guid> ids)
        {
            if (ids == null || ids.Count == 0) return String.Empty;

            StringBuilder sbIds = new StringBuilder();
            foreach (Guid id in ids)
            {
                sbIds.Append("'").Append(id).Append("',");
            }
            sbIds.Remove(sbIds.Length - 1, 1);
            return sbIds.ToString();
        }

        public static string ConvertToInStr(params string[] codes)
        {
            if (codes == null || codes.Length == 0) return String.Empty;

            StringBuilder sbIds = new StringBuilder();
            foreach (string code in codes)
            {
                sbIds.Append("'").Append(code).Append("',");
            }
            sbIds.Remove(sbIds.Length - 1, 1);
            return sbIds.ToString();
        }

        /// <summary>
        /// 使用;号分隔；注意空返回NULL
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static string ConvertToInStrForSplit(ICollection<int> ids, bool end)
        {
            if (ids == null || ids.Count == 0) return null; // String.Empty;

            StringBuilder sbIds = new StringBuilder();
            foreach (int id in ids)
            {
                sbIds.Append(id.ToString()).Append(";");
            }
            if (!end) sbIds.Remove(sbIds.Length - 1, 1);
            return sbIds.ToString();
        }

        /// <summary>
        /// 使用;号分隔；注意空返回NULL
        /// </summary>
        /// <param name="codes"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static string ConvertToInStrForSplit(ICollection<string> codes, bool end)
        {
            if (codes == null || codes.Count == 0) return null; // String.Empty;

            StringBuilder sbIds = new StringBuilder();
            foreach (string code in codes)
            {
                if (code != null)
                    sbIds.Append(code).Append(";");
                else
                    sbIds.Append(";");
            }
            if (!end) sbIds.Remove(sbIds.Length - 1, 1);
            return sbIds.ToString();
        }
    }
}
