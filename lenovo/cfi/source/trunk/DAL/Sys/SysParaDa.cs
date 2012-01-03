using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;


namespace Lenovo.CFI.DAL.Sys
{
    public class SysParaDa
    {
        public static string GetSysPara(string key, string bu)
        {
            Database db = DBHelper.GetDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("Usp_GetSysPara", key, bu);

            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                if (dataReader.Read())
                {
                    return dataReader.GetString(0);
                }
            }

            return null;
        }

        public static Dictionary<string, string> GetSysParas(string key)
        {
            Database db = DBHelper.GetDatabase();

            Dictionary<string, string> paras = new Dictionary<string, string>();

            DbCommand dbCommand = db.GetStoredProcCommand("Usp_GetSysParaByKey", key);

            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    paras.Add(dataReader.GetString(0), dataReader.GetString(1));
                }
            }

            return paras;
        }

        public static void SaveSysPara(string key, string bu, string value)
        {
            SaveSysPara(key, bu, value, DBHelper.GetDatabase(), null);
        }
        public static void SaveSysPara(string key, string bu, string value, TranscationHelper trans)
        {
            SaveSysPara(key, bu, value, trans.DataBase, trans.Transaction);
        }
        private static void SaveSysPara(string key, string bu, string value, Database db, DbTransaction trans)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("Usp_UpdateSysPara", key, bu, value);

            try
            {
                if (trans == null)
                    db.ExecuteNonQuery(dbCommand);
                else
                    db.ExecuteNonQuery(dbCommand, trans);
            }
            catch (System.Data.SqlClient.SqlException sex)      // 只捕获SqlException，其余抛出继续传播
            {
                DBHelper.ParseSqlException(sex, false);
            }
        }
    }
}
