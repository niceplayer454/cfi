﻿using System;
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
    public class QiRootCause3Da
    {
        public static List<QiRootCause3> GetAll()
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetSqlStringCommand(String.Format(@"SELECT [Code] ,[Title] ,[Sort] ,[Optor] ,[OpTime] ,[Deleted] ,[Cause2] 
FROM {0}", DataDictionaryEntryDa.GetDictionaryTableName(DictionaryName.QiRootCause3)));

            List<QiRootCause3> entries = new List<QiRootCause3>();

            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    entries.Add(PopulateEntry(dataReader));
                }
            }

            return entries;
        }

        public static void Insert(QiRootCause3 entry)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetSqlStringCommand(String.Format(@"INSERT INTO {5} VALUES 
(N'{0}', N'{1}', {2}, '{3}', GETDATE(), 0, '{4}')",
                entry.Code, entry.Title, entry.Sort, entry.Updator, entry.RootCause2,
                DataDictionaryEntryDa.GetDictionaryTableName(DictionaryName.QiRootCause3)));

            try
            {
                db.ExecuteNonQuery(dbCommand);
            }
            catch (System.Data.SqlClient.SqlException sex)      // 只捕获SqlException，其余抛出继续传播
            {
                DBHelper.ParseSqlException(sex, false);
            }
        }

        public static void Update(QiRootCause3 entry)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetSqlStringCommand(String.Format(@"UPDATE {6} 
SET [Title] = '{1}' ,[Sort] = {2} ,[Optor] = '{3}',[OpTime] = GETDATE(), [Deleted] = {4}, [Cause2] = '{5}'
WHERE [Code] = N'{0}'",
                      entry.Code, entry.TitleT, entry.SortT, entry.UpdatorT, entry.VisibleT ? 0 : 1, entry.PCodeT,
                DataDictionaryEntryDa.GetDictionaryTableName(DictionaryName.QiRootCause3)));

            try
            {
                db.ExecuteNonQuery(dbCommand);
            }
            catch (System.Data.SqlClient.SqlException sex)      // 只捕获SqlException，其余抛出继续传播
            {
                DBHelper.ParseSqlException(sex, false);
            }
        }

        public static void Delete(QiRootCause3 entry)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetSqlStringCommand(String.Format(@"DELETE FROM {1} WHERE [Code] = N'{0}'",
                entry.Code, DataDictionaryEntryDa.GetDictionaryTableName(DictionaryName.QiRootCause3)));

            try
            {
                db.ExecuteNonQuery(dbCommand);
            }
            catch (System.Data.SqlClient.SqlException sex)      // 只捕获SqlException，其余抛出继续传播
            {
                DBHelper.ParseSqlException(sex, true);
            }
        }

        private static QiRootCause3 PopulateEntry(IDataReader dataReader)
        {
            return new QiRootCause3(
                dataReader.GetString(0),
                dataReader.GetString(6),
                dataReader.GetString(1),
                dataReader.GetInt32(2),
                !dataReader.GetBoolean(5),
                dataReader.GetString(3),
                dataReader.GetDateTime(4));
        }

    }
}
