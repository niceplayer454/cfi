using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

using Lenovo.CFI.Common;
using Lenovo.CFI.Common.Mail;
using System.Net.Mail;

namespace Lenovo.CFI.DAL.Mail
{
    public class MessageDa
    {
        /// <summary>
        /// 向邮件队列插入邮件。
        /// </summary>
        /// <param name="mail">邮件对象。</param>
        public static void InsertMaillQueue(Message mail)
        {
            InsertMaillQueue(mail, DBHelper.GetDatabase(), null);
        }
        public static void InsertMaillQueue(Message mail, TranscationHelper trans)
        {
            InsertMaillQueue(mail, trans.DataBase, trans.Transaction);
        }
        private static void InsertMaillQueue(Message mail, Database db, DbTransaction trans)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("Usp_InsertMailQueue",
                mail.UID,
                mail.System,
                mail.From,
                mail.To,
                mail.CC,
                mail.BCC,
                mail.ReplyTo,
                mail.Sender,
                (int)mail.Priority,
                mail.Subject,
                mail.Body,
                mail.CreateTime,
                mail.Status);
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


        /// <summary>
        /// 更新邮件队列中的邮件(邮件状态)。
        /// </summary>
        /// <param name="mail">邮件对象。</param>
        public static void UpdateMaillQueue(Message mail)
        {
            UpdateMaillQueue(mail, DBHelper.GetDatabase(), null);
        }
        public static void UpdateMaillQueue(Message mail, TranscationHelper trans)
        {
            UpdateMaillQueue(mail, trans.DataBase, trans.Transaction);
        }
        private static void UpdateMaillQueue(Message mail, Database db, DbTransaction trans)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("Usp_UpdateMailQueue", mail.UID, mail.Status);

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


        /// <summary>
        /// 删除邮件队列中的邮件。
        /// </summary>
        /// <param name="mailUID">邮件标识(UID)。</param>
        public static void DeleteMaillQueue(Guid uid)
        {
            DeleteMaillQueue(uid, DBHelper.GetDatabase(), null);
        }
        public static void DeleteMaillQueue(Guid uid, TranscationHelper trans)
        {
            DeleteMaillQueue(uid, trans.DataBase, trans.Transaction);
        }
        private static void DeleteMaillQueue(Guid uid, Database db, DbTransaction trans)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("Usp_DeleteMaillQueue", uid);

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


        /// <summary>
        /// 获取邮件队列中的邮件。
        /// </summary>
        /// <param name="appID">应用系统标识(UID)。null表示不限制。</param>
        /// <param name="state">邮件状态。null表示不限制。</param>
        /// <returns>邮件对象列表。不存在返回元素个数为0的列表。按创建时间倒序排序。</returns>
        public static List<Message> GetMailQueue(Guid? appID, bool includeAttach)
        {
            Database db = DBHelper.GetDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("Usp_GetMailQueue", appID, includeAttach);

            List<Message> messages = new List<Message>();
            Dictionary<Guid, Message> messagesDic = new Dictionary<Guid, Message>();

            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    Message message = PopulateMail(dataReader);
                    messages.Add(message);
                    messagesDic.Add(message.UID, message);
                }

                if (includeAttach && dataReader.NextResult())
                {
                    while (dataReader.Read())
                    {
                        Attach attach = PopulateAttach(dataReader);
                        messagesDic[attach.MailID].Attaches.Add(attach);
                    }
                }
            }

            return messages;
        }

        /// <summary>
        /// 根据邮件标识(UID)获取邮件队列中的邮件。
        /// </summary>
        /// <param name="uid">邮件标识(UID)。</param>
        /// <returns>邮件对象。不存在返回null。</returns>
        public static Message GetMailQueueByID(Guid uid)
        {
            Database db = DBHelper.GetDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("Usp_GetMailQueueByID", uid);

            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    return PopulateMail(dataReader);
                }
            }

            return null;
        }

        private static Message PopulateMail(IDataReader dataReader)
        {
            Message mail = new Message();
            mail.UID = dataReader.GetGuid(0);
            if (dataReader.IsDBNull(1))
                mail.System = null;
            else
                mail.System = dataReader.GetGuid(1);
            mail.From = dataReader.GetString(2);
            mail.To = dataReader.GetString(3);
            mail.CC = dataReader.IsDBNull(4) ? null : dataReader.GetString(4);
            mail.BCC = dataReader.IsDBNull(5) ? null : dataReader.GetString(5);
            mail.ReplyTo = dataReader.IsDBNull(6) ? null : dataReader.GetString(6);
            mail.Sender = dataReader.IsDBNull(7) ? null : dataReader.GetString(7);
            mail.Priority = (MailPriority)dataReader.GetInt32(8);
            mail.Subject = dataReader.GetString(9);
            mail.Body = dataReader.IsDBNull(10) ? null : dataReader.GetString(10);
            mail.CreateTime = dataReader.GetDateTime(11);
            mail.Status = dataReader.GetInt32(12);

            return mail;
        }

        private static Attach PopulateAttach(IDataReader dataReader)
        {
            Attach attach = new Attach(dataReader.GetInt32(0), dataReader.GetGuid(1),
                dataReader.IsDBNull(2) ? null : dataReader.GetString(2),
                dataReader.GetString(3), dataReader.GetString(4));

            return attach;
        }



        public static void InsertMaillAttach(Attach attach)
        {
            InsertMaillAttach(attach, DBHelper.GetDatabase(), null);
        }
        public static void InsertMaillAttach(Attach attach, TranscationHelper trans)
        {
            InsertMaillAttach(attach, trans.DataBase, trans.Transaction);
        }
        private static void InsertMaillAttach(Attach attach, Database db, DbTransaction trans)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("Usp_InsertMailAttach",
                attach.MailID, attach.ContentID, attach.Title, attach.Path);
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


        public static void InsertMaillAttach(Guid fileID, string directory, Guid mailID)
        {
            InsertMaillAttach(fileID, directory, mailID, DBHelper.GetDatabase(), null);
        }
        public static void InsertMaillAttach(Guid fileID, string directory, Guid mailID, TranscationHelper trans)
        {
            InsertMaillAttach(fileID, directory, mailID, trans.DataBase, trans.Transaction);
        }
        private static void InsertMaillAttach(Guid fileID, string directory, Guid mailID, Database db, DbTransaction trans)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("Usp_InsertMailAttachByFileID",
                fileID, directory, mailID);
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



        /// <summary>
        /// 插入已发送邮件。
        /// </summary>
        /// <param name="message">邮件对象。</param>
        public static void InsertMaillSend(Message message)
        {
            InsertMaillSend(message, DBHelper.GetDatabase(), null);
        }
        public static void InsertMaillSend(Message message, TranscationHelper trans)
        {
            InsertMaillSend(message, trans.DataBase, trans.Transaction);
        }
        private static void InsertMaillSend(Message message, Database db, DbTransaction trans)
        {
            DbCommand dbCommand = db.GetStoredProcCommand("Usp_InsertMailSend",
                message.UID,
                message.System,
                message.From,
                message.To,
                message.CC,
                message.BCC,
                message.ReplyTo,
                message.Sender,
                (int)message.Priority,
                message.Subject,
                message.Body,
                message.CreateTime);

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
