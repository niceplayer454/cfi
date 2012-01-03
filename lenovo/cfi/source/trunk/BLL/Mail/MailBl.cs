using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net.Mail;
using Lenovo.CFI.Common.Mail;
using Lenovo.CFI.DAL.Mail;
using Lenovo.CFI.DAL;
using Lenovo.CFI.Common;

namespace Lenovo.CFI.BLL.Mail
{
    public class MailBl
    {
        /// <summary>
        /// 发送邮件
        /// </summary>
        public void SendMail(string to, string cc, string subject, string body, MailPriority priority, params Guid[] files)
        {
            using (TranscationHelper trans = TranscationHelper.GetInstance())
            {
                trans.BeginTrans();
                try
                {
                    SendMail(trans, to, cc, subject, body, priority, files);

                    trans.CommitTrans();
                }
                catch
                {
                    trans.RollTrans();
                    throw;
                }
            }
        }


        internal static void SendMail(TranscationHelper trans, string to, string cc, string subject, string body, MailPriority priority, params Guid[] files)
        {
            Message message = new Message();
            message.From = Sender.GetDefaultFrom();
            message.To = to;
            message.CC = cc;
            message.Subject = subject;
            message.Body = body;
            message.Priority = priority;


            MessageDa.InsertMaillQueue(message, trans);

            if (files != null)
            {
                foreach (Guid file in files)
                {
                    MessageDa.InsertMaillAttach(file, Utils.SysFileDir(), message.UID, trans);
                }
            }
        }
    }
}
