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
    public class ProductFamilyDa
    {
        public static List<ProductFamily> GetAll()
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetSqlStringCommand(String.Format(@"SELECT [Code] ,[Title] ,[BU] ,[MailList] ,[Sort] ,[Optor] ,[OpTime] ,[Deleted] 
FROM {0}", DataDictionaryEntryDa.GetDictionaryTableName(DictionaryName.QiProductFamily)));

            List<ProductFamily> entries = new List<ProductFamily>();

            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    entries.Add(PopulateEntry(dataReader));
                }
            }

            return entries;
        }

        public static void Insert(ProductFamily entry)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetSqlStringCommand(String.Format(@"INSERT INTO {6} VALUES 
(N'{0}', N'{1}', N'{2}', N'{3}', {4}, N'{5}', GETDATE(), 0)",
                entry.Code, entry.Title, entry.BU, entry.MailList, entry.Sort, entry.Updator,
                DataDictionaryEntryDa.GetDictionaryTableName(DictionaryName.QiProductFamily)));

            try
            {
                db.ExecuteNonQuery(dbCommand);
            }
            catch (System.Data.SqlClient.SqlException sex)      // 只捕获SqlException，其余抛出继续传播
            {
                DBHelper.ParseSqlException(sex, false);
            }
        }

        public static void Update(ProductFamily entry)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetSqlStringCommand(String.Format(@"UPDATE {7} 
SET [Title] = N'{1}' ,[BU] = N'{2}' ,[MailList] = N'{3}' ,[Sort] = {4} ,[Optor] = N'{5}',[OpTime] = GETDATE(), [Deleted] = {6}
WHERE [Code] = N'{0}'",
                      entry.Code, entry.TitleT, entry.BUT, entry.MaillistT, entry.SortT, entry.UpdatorT, entry.VisibleT ? 0 : 1,
                DataDictionaryEntryDa.GetDictionaryTableName(DictionaryName.QiProductFamily)));

            try
            {
                db.ExecuteNonQuery(dbCommand);
            }
            catch (System.Data.SqlClient.SqlException sex)      // 只捕获SqlException，其余抛出继续传播
            {
                DBHelper.ParseSqlException(sex, false);
            }
        }

        public static void Delete(ProductFamily entry)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetSqlStringCommand(String.Format(@"DELETE FROM {1} WHERE [Code] = N'{0}'",
                entry.Code, DataDictionaryEntryDa.GetDictionaryTableName(DictionaryName.QiProductFamily)));

            try
            {
                db.ExecuteNonQuery(dbCommand);
            }
            catch (System.Data.SqlClient.SqlException sex)      // 只捕获SqlException，其余抛出继续传播
            {
                DBHelper.ParseSqlException(sex, true);
            }
        }

        private static ProductFamily PopulateEntry(IDataReader dataReader)
        {
            return new ProductFamily(
                dataReader.GetString(0),
                dataReader.GetString(1),
                dataReader.GetInt32(4),
                !dataReader.GetBoolean(7),
                dataReader.GetString(5),
                dataReader.GetDateTime(6),
                dataReader.GetString(2),
                dataReader.GetString(3));
        }
    }
}
