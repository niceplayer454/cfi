using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

using Lenovo.CFI.Common;

namespace Lenovo.CFI.DAL.Sys
{
    public class AttachmentDa
    {
        public static Attachment GetAttachmentByID(Guid id)
        {
            Database db = DBHelper.GetDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("Usp_GetAttachmentByID", id);

            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                if (dataReader.Read())
                {
                    return PopulateAttachment(dataReader);
                }
            }

            return null;
        }

        public static List<Attachment> GetAttachmentByID(List<Guid> ids)
        {
            Database db = DBHelper.GetDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("Usp_GetAttachmentByIDs", InHelper.ConvertToInStr(ids));

            List<Attachment> attaches = new List<Attachment>();

            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    attaches.Add(PopulateAttachment(dataReader));
                }
            }

            return attaches;
        }

        private static Attachment PopulateAttachment(IDataReader dataReader)
        {
            Attachment attach = new Attachment(dataReader.GetGuid(0), 
                dataReader.GetString(1), dataReader.GetString(2),
                dataReader.GetString(3), dataReader.GetDateTime(4),
                dataReader.IsDBNull(5) ? null : dataReader.GetString(5));

            return attach;
        }


        public static void InsertAttach(Attachment attach)
        {
            InsertAttach(attach, DBHelper.GetDatabase(), null);
        }
        public static void InsertAttach(Attachment attach, TranscationHelper trans)
        {
            InsertAttach(attach, trans.DataBase, trans.Transaction);
        }
        private static void InsertAttach(Attachment attach, Database db, DbTransaction trans)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("Usp_InsertAttachment",
                attach.UID, attach.Title, attach.Path, attach.Create.User, attach.Create.Time, attach.Note);

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

        public static void DeleteAttach(Guid id)
        {
            DeleteAttach(id, DBHelper.GetDatabase(), null);
        }
        public static void DeleteAttach(Guid id, TranscationHelper trans)
        {
            DeleteAttach(id, trans.DataBase, trans.Transaction);
        }
        private static void DeleteAttach(Guid id, Database db, DbTransaction trans)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("Usp_DeleteAttachment", id);

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
