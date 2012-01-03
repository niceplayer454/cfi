using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

using Lenovo.CFI.Common.Dic;

namespace Lenovo.CFI.DAL.Dic
{
    public class QiAttachCategoryDa
    {
        public static List<QiAttachCategory> GetAll()
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetSqlStringCommand(String.Format(@"SELECT [Code] ,[Title] ,[Purpose] ,[Sort] ,[Optor] ,[OpTime] ,[Deleted] 
FROM {0}", DataDictionaryEntryDa.GetDictionaryTableName(DictionaryName.QiAttachCategory)));

            List<QiAttachCategory> entries = new List<QiAttachCategory>();

            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    entries.Add(PopulateEntry(dataReader));
                }
            }

            return entries;
        }

        public static void Insert(QiAttachCategory entry)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetSqlStringCommand(String.Format(@"INSERT INTO {5} VALUES 
(N'{0}', N'{1}', {2}, {3}, N'{4}', GETDATE(), 0)",
                entry.Code, entry.Title, entry.ReportAttach ? "1" : "0", entry.Sort, entry.Updator,
                DataDictionaryEntryDa.GetDictionaryTableName(DictionaryName.QiAttachCategory)));

            try
            {
                db.ExecuteNonQuery(dbCommand);
            }
            catch (System.Data.SqlClient.SqlException sex)      // 只捕获SqlException，其余抛出继续传播
            {
                DBHelper.ParseSqlException(sex, false);
            }
        }

        public static void Update(QiAttachCategory entry)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetSqlStringCommand(String.Format(@"UPDATE {6} 
SET [Title] = N'{1}' ,[Purpose] = {2} ,[Sort] = {3} ,[Optor] = N'{4}',[OpTime] = GETDATE(), [Deleted] = {5}
WHERE [Code] = N'{0}'",
                      entry.Code, entry.TitleT, entry.ReportAttachT ? "1" : "0", entry.SortT, entry.UpdatorT, entry.VisibleT ? 0 : 1,
                DataDictionaryEntryDa.GetDictionaryTableName(DictionaryName.QiAttachCategory)));

            try
            {
                db.ExecuteNonQuery(dbCommand);
            }
            catch (System.Data.SqlClient.SqlException sex)      // 只捕获SqlException，其余抛出继续传播
            {
                DBHelper.ParseSqlException(sex, false);
            }
        }

        public static void Delete(QiAttachCategory entry)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetSqlStringCommand(String.Format(@"DELETE FROM {1} WHERE [Code] = N'{0}'",
                entry.Code, DataDictionaryEntryDa.GetDictionaryTableName(DictionaryName.QiAttachCategory)));

            try
            {
                db.ExecuteNonQuery(dbCommand);
            }
            catch (System.Data.SqlClient.SqlException sex)      // 只捕获SqlException，其余抛出继续传播
            {
                DBHelper.ParseSqlException(sex, true);
            }
        }

        private static QiAttachCategory PopulateEntry(IDataReader dataReader)
        {
            return new QiAttachCategory(
                dataReader.GetString(0),
                dataReader.GetString(1),
                dataReader.GetInt32(3),
                !dataReader.GetBoolean(6),
                dataReader.GetString(4),
                dataReader.GetDateTime(5),
                dataReader.GetInt32(2) == 1);
        }

    }
}
