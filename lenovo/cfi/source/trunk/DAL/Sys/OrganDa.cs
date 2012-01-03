using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

using Lenovo.CFI.Common.Sys;
using Lenovo.CFI.Common;

namespace Lenovo.CFI.DAL.Sys
{
    public class OrganDa
    {
        public static Organ GetOrganByID(Guid uid)
        {
            Database db = DBHelper.GetDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("Usp_GetSysOrganByID", uid);

            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                if (dataReader.Read())
                {
                    return PopulateOrgan(dataReader);
                }
            }

            return null;
        }

        /// <summary>
        /// 仅有效
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public static List<Organ> GetOrganByPID(Guid pid)
        {
            Database db = DBHelper.GetDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("Usp_GetSysOrganByPID", pid);

            List<Organ> organs = new List<Organ>();

            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    organs.Add(PopulateOrgan(dataReader));
                }
            }

            return organs;
        }

        /// <summary>
        /// 仅有效
        /// </summary>
        /// <returns></returns>
        public static List<Organ> GetOrganAll()
        {
            Database db = DBHelper.GetDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("Usp_GetSysOrgan");

            List<Organ> organs = new List<Organ>();

            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    organs.Add(PopulateOrgan(dataReader));
                }
            }

            return organs;
        }

        public static string GetOrganFullTitle(Guid uid)
        {
            Database db = DBHelper.GetDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("Usp_GetSysOrganFullTitleByID", uid);

            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                if (dataReader.Read())
                {
                    return dataReader.GetString(0);
                }
            }

            return null;
        }


        private static Organ PopulateOrgan(IDataReader dataReader)
        {
            Organ organ = new Organ(dataReader.GetGuid(0));
            organ.Title = dataReader.GetString(1);
            organ.Parent = dataReader.IsDBNull(2) ? null : new Organ(dataReader.GetGuid(2));
            organ.Level = dataReader.GetInt32(3);
            organ.Valid = dataReader.GetBoolean(4);
            organ.BU = dataReader.IsDBNull(5) ? null : dataReader.GetString(5);

            return organ;
        }

        public static void InsertOrgan(Organ organ)
        {
            InsertOrgan(organ, DBHelper.GetDatabase(), null);
        }
        public static void InsertOrgan(Organ organ, TranscationHelper trans)
        {
            InsertOrgan(organ, trans.DataBase, trans.Transaction);
        }
        private static void InsertOrgan(Organ organ, Database db, DbTransaction trans)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("Usp_InsertSysOrgan", 
                organ.ID, organ.Title, organ.Parent.ID, 0, organ.Valid, organ.BU);

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

        public static void UpdateOrgan(Organ organ)
        {
            UpdateOrgan(organ, DBHelper.GetDatabase(), null);
        }
        public static void UpdateOrgan(Organ organ, TranscationHelper trans)
        {
            UpdateOrgan(organ, trans.DataBase, trans.Transaction);
        }
        private static void UpdateOrgan(Organ organ, Database db, DbTransaction trans)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("Usp_UpdateSysOrgan",
                organ.ID, organ.Title, (organ.Parent != null ? organ.Parent.ID : (Guid?)null), 0, organ.Valid, organ.BU);

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
