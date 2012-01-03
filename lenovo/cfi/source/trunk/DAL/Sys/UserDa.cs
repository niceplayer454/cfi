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
    public class UserDa
    {
        #region  User

        public static User GetUserByUID(Guid uid)
        {
            Database db = DBHelper.GetDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("Usp_GetSysUserByID", uid);

            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                if (dataReader.Read())
                {
                    return PopulateUser(dataReader);
                }
            }

            return null;
        }

        public static User GetUserByItCode(string itcode)
        {
            Database db = DBHelper.GetDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("Usp_GetSysUserByItCode", itcode.ToLower());

            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                if (dataReader.Read())
                {
                    return PopulateUser(dataReader);
                }
            }

            return null;
        }

        public static List<User> GetUserByItCode(params string[] itcodes)
        {
            Database db = DBHelper.GetDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("Usp_GetSysUserByItCodes", InHelper.ConvertToInStr(itcodes));

            List<User> users = new List<User>();
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    users.Add(PopulateUser(dataReader));
                }
            }

            return users;
        }

        // 如果已经是经理，就不再获取其经理
        public static List<User> GetUserManager(params string[] itcodes)
        {
            Database db = DBHelper.GetDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("Usp_GetSysUserManagerByItCodes", InHelper.ConvertToInStr(itcodes));

            List<User> users = new List<User>();
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    users.Add(PopulateUser(dataReader));
                }
            }

            return users;
        }

        public static List<User> GetUserAll()
        {
            Database db = DBHelper.GetDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("Usp_GetSysUserAll");

            List<User> users = new List<User>();
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    users.Add(PopulateUser(dataReader));
                }
            }

            return users;
        }

        public static List<User> GetUser(string itcode, Guid? organ, string superior, bool? disabled)
        {
            Database db = DBHelper.GetDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("Usp_GetSysUser", itcode, organ, superior, disabled);

            List<User> users = new List<User>();
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    users.Add(PopulateUser(dataReader));
                }
            }

            return users;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bu"></param>
        /// <param name="role"></param>
        /// <param name="department">可空</param>
        /// <returns></returns>
        public static List<User> GetUserWithBuRole(string bu, int role, string department)
        {
            Database db = DBHelper.GetDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("Usp_GetSysUserWithRole", bu, role, department);

            List<User> users = new List<User>();
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    users.Add(PopulateUser(dataReader));
                }
            }

            return users;
        }


        private static User PopulateUser(IDataReader dataReader)
        {
            User user = new User(dataReader.GetString(0), dataReader.GetGuid(1));

            user.FirstName = dataReader.GetString(2);
            user.LastName = dataReader.GetString(3);
            user.AbbrName = dataReader.IsDBNull(4) ? null : dataReader.GetString(4);
            user.Password = dataReader.GetString(5);
            user.Organ = new Organ(dataReader.GetGuid(6));
            user.Superior = new UserBase(dataReader.GetString(7));
            user.Phone = dataReader.IsDBNull(8) ? null : dataReader.GetString(8);
            user.CreateTime = dataReader.GetDateTime(9);
            user.Disabled = dataReader.GetBoolean(10);
            user.ResetPwdCode = dataReader.IsDBNull(11) ? null : dataReader.GetString(11);
            user.DefaultBu = dataReader.IsDBNull(12) ? null : dataReader.GetString(12);
            user.Department = dataReader.IsDBNull(13) ? null : dataReader.GetString(13);
            user.DelegateUser = dataReader.GetString(14);

            return user;
        }


        public static void InsertUser(User user)
        {
            InsertUser(user, DBHelper.GetDatabase(), null);
        }
        public static void InsertUser(User user, TranscationHelper trans)
        {
            InsertUser(user, trans.DataBase, trans.Transaction);
        }
        private static void InsertUser(User user, Database db, DbTransaction trans)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("Usp_InsertSysUser", 
                user.ItCode, user.UID, user.FirstName, user.LastName, user.AbbrName,
                user.Password, user.Organ.ID, user.SuperiorItCode, user.Phone, 
                user.CreateTime, user.Disabled, user.ResetPwdCode, user.DefaultBu,
                user.Department);

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

        public static void UpdateUser(User user)
        {
            UpdateUser(user, DBHelper.GetDatabase(), null);
        }
        public static void UpdateUser(User user, TranscationHelper trans)
        {
            UpdateUser(user, trans.DataBase, trans.Transaction);
        }
        private static void UpdateUser(User user, Database db, DbTransaction trans)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("Usp_UpdateSysUser",
                user.ItCode, user.FirstName, user.LastName, user.AbbrName,
                user.Password, user.Organ.ID, user.Superior.ItCode, user.Phone,
                user.CreateTime, user.Disabled, user.ResetPwdCode, user.DefaultBu,
                user.Department);

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



        public static void UpdateDefaultBu(string itcode, string bu)
        {
            UpdateDefaultBu(itcode, bu, DBHelper.GetDatabase(), null);
        }
        public static void UpdateDefaultBu(string itcode, string bu, TranscationHelper trans)
        {
            UpdateDefaultBu(itcode, bu, trans.DataBase, trans.Transaction);
        }
        private static void UpdateDefaultBu(string itcode, string bu, Database db, DbTransaction trans)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("Usp_UpdateSysUserDefaultBu", itcode, bu);

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

        public static void UpdateUserDelegate(string itcode, string delegateUser)
        {
            UpdateUserDelegate(itcode, delegateUser, DBHelper.GetDatabase(), null);
        }
        public static void UpdateUserDelegate(string itcode, string delegateUser, TranscationHelper trans)
        {
            UpdateUserDelegate(itcode, delegateUser, trans.DataBase, trans.Transaction);
        }
        private static void UpdateUserDelegate(string itcode, string delegateUser, Database db, DbTransaction trans)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("Usp_UpdateSysUserDelegate", itcode, delegateUser);

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


        #endregion

        // Role
        public static List<UserRole> GetUserRole(string user, int? role, string bu)
        {
            Database db = DBHelper.GetDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("Usp_GetSysUserRole", user, role, bu);

            List<UserRole> roles = new List<UserRole>();
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                }
            }

            return roles;
        }

        public static void InsertUserRole(UserRole role)
        {
            InsertUserRole(role, DBHelper.GetDatabase(), null);
        }
        public static void InsertUserRole(UserRole role, TranscationHelper trans)
        {
            InsertUserRole(role, trans.DataBase, trans.Transaction);
        }
        private static void InsertUserRole(UserRole role, Database db, DbTransaction trans)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("Usp_InsertSysUserRole");

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

        public static void DeleteUserRole(UserRole role)
        {
            DeleteUserRole(role, DBHelper.GetDatabase(), null);
        }
        public static void DeleteUserRole(UserRole role, TranscationHelper trans)
        {
            DeleteUserRole(role, trans.DataBase, trans.Transaction);
        }
        private static void DeleteUserRole(UserRole role, Database db, DbTransaction trans)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("Usp_DeleteSysUserRole");

            try
            {
                if (trans == null)
                    db.ExecuteNonQuery(dbCommand);
                else
                    db.ExecuteNonQuery(dbCommand, trans);
            }
            catch (System.Data.SqlClient.SqlException sex)      // 只捕获SqlException，其余抛出继续传播
            {
                DBHelper.ParseSqlException(sex, true);
            }
        }
    }
}
