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
    public class DataDictionaryEntryDa
    {
        public static List<DataDictionaryEntry> GetAll(DictionaryName dicName)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetSqlStringCommand(String.Format(@"SELECT [Code] ,[Title] ,[Sort] ,[Optor] ,[OpTime] ,[Deleted] FROM {0}",
                GetDictionaryTableName(dicName)));

            List<DataDictionaryEntry> entries = new List<DataDictionaryEntry>();

            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    entries.Add(PopulateEntry(dataReader));
                }
            }

            return entries;
        }

        public static string GetDictionaryTableName(DictionaryName dicName)
        {
            switch (dicName)
            {
                case DictionaryName.SysBu:
                    return "SysBu";

                case DictionaryName.QiProductFamily:
                    return "DicQiFamily";
                case DictionaryName.QiAttachCategory:
                    return "DicQiAttachCategory";
                case DictionaryName.QiProblemType:
                    return "DicQiProblemType";
                case DictionaryName.QiRootCause1:
                    return "DicQiRootCause1";
                case DictionaryName.QiRootCause2:
                    return "DicQiRootCause2";
                case DictionaryName.QiRootCause3:
                    return "DicQiRootCause3";
                case DictionaryName.QiCloseLoopCategory:
                    return "DicCloseLoopCategory";
                case DictionaryName.QiCloseLoopDepartment:
                    return "DicCloseLoopDepartment";

                case DictionaryName.RcMailGroup:
                    return "DicRcMailGroup";

                case DictionaryName.EwgInitIssueStatus:
                    return "DicEwgInitIssueStatus";
                case DictionaryName.EwgMeetingTeam:
                    return "DicEwgMeetingTeam";
                case DictionaryName.EwgFolder:
                    return "DicEwgFolder";
                case DictionaryName.EwgInitIssuePhase:
                    return "DicEwgInitIssuePhase";

                case DictionaryName.LeDept:
                    return "DicLeDept";
                case DictionaryName.LeProblemSource:
                    return "DicLeProblemSource";
                case DictionaryName.LeProblemFactory:
                    return "DicLeProblemFactory";
                case DictionaryName.LePart:
                    return "DicLePart";
            }

            return null;
        }

        public static void Insert(DataDictionaryEntry entry, DictionaryName dicName)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetSqlStringCommand(String.Format(@"INSERT INTO {4} VALUES (N'{0}', N'{1}', {2}, '{3}', GETDATE(), 0)",
                entry.Code, entry.Title, entry.Sort, entry.Updator,
                GetDictionaryTableName(dicName)));

            try
            {
                db.ExecuteNonQuery(dbCommand);
            }
            catch (System.Data.SqlClient.SqlException sex)      // 只捕获SqlException，其余抛出继续传播
            {
                DBHelper.ParseSqlException(sex, false);
            }
        }

        public static void Update(DataDictionaryEntry entry, DictionaryName dicName)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetSqlStringCommand(String.Format(@"UPDATE {5} 
SET [Title] = '{1}' ,[Sort] = {2} ,[Optor] = '{3}',[OpTime] = GETDATE(), [Deleted] = {4}
WHERE [Code] = N'{0}'", entry.Code, entry.TitleT, entry.SortT, entry.UpdatorT, entry.VisibleT ? 0 : 1,
                GetDictionaryTableName(dicName)));

            try
            {
                db.ExecuteNonQuery(dbCommand);
            }
            catch (System.Data.SqlClient.SqlException sex)      // 只捕获SqlException，其余抛出继续传播
            {
                DBHelper.ParseSqlException(sex, false);
            }
        }

        public static void Delete(DataDictionaryEntry entry, DictionaryName dicName)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetSqlStringCommand(String.Format(@"DELETE FROM {1} WHERE [Code] = N'{0}'",
                entry.Code, GetDictionaryTableName(dicName)));

            try
            {
                db.ExecuteNonQuery(dbCommand);
            }
            catch (System.Data.SqlClient.SqlException sex)      // 只捕获SqlException，其余抛出继续传播
            {
                DBHelper.ParseSqlException(sex, true);
            }
        }

        private static DataDictionaryEntry PopulateEntry(IDataReader dataReader)
        {
            return new DataDictionaryEntry(
                dataReader.GetString(0),
                dataReader.GetString(1),
                dataReader.GetInt32(2),
                !dataReader.GetBoolean(5),
                dataReader.GetString(3),
                dataReader.GetDateTime(4));
        }
    }

}
