using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Lenovo.CFI.Common.Mail;
using Lenovo.CFI.DAL.Mail;
using System.Net.Mail;
using System.Configuration;
using System.Net.Configuration;

using Log = Dotnet.Commons.Logging.ILog;
using LogFactory = Dotnet.Commons.Logging.LogFactory;

namespace Lenovo.CFI.BLL.Mail
{
    /// <summary>
    /// 维护、查询和发送邮件。
    /// </summary>
    public class Sender
    {        
        /// <summary>
        /// 静态构造函数，初始化默认发件人。
        /// </summary>
        static Sender()
        {
            MailSettingsSectionGroup ms = NetSectionGroup.GetSectionGroup(
                System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/web.config")).MailSettings;

            defaultFrom = ms.Smtp.From;
            defaultHost = ms.Smtp.Network.Host;
            defaultPort = ms.Smtp.Network.Port;
            defaultUserName = ms.Smtp.Network.UserName;
            defaultPassword = ms.Smtp.Network.Password;
        }

        private Log log = LogFactory.GetLogger(typeof(Sender));

        // 默认发件人
        private static string defaultFrom;          // 系统默认的发信人
        private static string defaultHost;          // 系统默认的
        private static int defaultPort;             // 系统默认的
        private static string defaultUserName;      // 系统默认的
        private static string defaultPassword;      // 系统默认的


        public static string GetDefaultFrom()
        {
            return defaultFrom;
        }

        /// <summary>
        /// 根据邮件标识(UID)获取邮件队列中的邮件。。
        /// </summary>
        /// <param name="mid">邮件标识(UID)。</param>
        /// <returns>邮件对象。不存在返回null。</returns>
        public Message GetMailQueueByID(Guid mid)
        {
            return MessageDa.GetMailQueueByID(mid);
        }

        /// <summary>
        /// 取消邮件队列中的指定邮件。
        /// </summary>
        /// <param name="mailUID">邮件标识(UID)。</param>
        public void CancleMailQueue(Guid mid)
        {
            MessageDa.DeleteMaillQueue(mid);
        }



        private static object s_lock = new object();        // 
        private static bool sending = false;                // 发送标志
        private DateTime time;

        /// <summary>
        /// 发送邮件队列中的邮件 -- 保证同时只有一个在执行
        /// </summary>
        /// <param name="includeFailed">是否包括发送失败的邮件。</param>
        /// <returns>是否执行了发送。</returns>
        public bool SendMailQueue()
        {
            lock (s_lock)
            {
                if (sending)            // 如果正在发送，直接返回
                {
                    log.Info(String.Format("Starting to send mail queue at {0:yyyy-MM-dd HH:mm:ss}, but last job({1:yyyy-MM-dd HH:mm:ss}) is still running", DateTime.Now, time));

                    return false;
                }
                else
                {
                    sending = true;

                    time = DateTime.Now;
                    log.Info(String.Format("Starting to send mail queue at {0:yyyy-MM-dd HH:mm:ss}", time));
                }
            }

            try
            {
                List<Message> queue = MessageDa.GetMailQueue(null, true);

                foreach (Message m in queue)
                {
                    try
                    {
                        // 3次以内重发
                        if (m.Status <= 3) SendMail(m);
                    }
                    catch (Exception ex)
                    {
                        m.Status++;

                        log.Warn(String.Format("Sending the specified mail[{0}] Exception:{1}", m.UID, ex.ToString()));

                        MessageDa.UpdateMaillQueue(m);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(String.Format("Unable to get the mail queue with Exception:{0}", ex.ToString()));
            }
            finally 
            {
                lock (s_lock)
                {
                    sending = false;
                }
            }

            return true;
        }

        

        // 发送邮件
        private void SendMail(Message mail)
        {
            #region 发送邮件

            Send(mail, defaultHost, defaultPort, defaultUserName, defaultPassword);

            #endregion

            #region 删除队列 保存已发送邮件

            MessageDa.DeleteMaillQueue(mail.UID);

            MessageDa.InsertMaillSend(mail);

            #endregion
        }



        // 发送邮件
        private static void Send(Message message, 
            string host, int port, string userName, string password)
        {

            if (String.IsNullOrEmpty(message.From)) return;
            if (String.IsNullOrEmpty(message.To)) return;

#if DEBUG
            // 测试时，是否发送邮件
            if (ConfigurationManager.AppSettings["DebugMailSend"] != "0")
                return;
            // 测试时，重新定向收信人发信人等
            message.From = ConfigurationManager.AppSettings["DebugMailFrom"];
            message.To = ConfigurationManager.AppSettings["DebugMailTo"];
            message.CC = null;
            //message.Sender = ConfigurationManager.AppSettings["DebugMailFrom"];

            host = ConfigurationManager.AppSettings["DebugMailHost"];
            port = int.Parse(ConfigurationManager.AppSettings["DebugMailPort"]);
            userName = ConfigurationManager.AppSettings["DebugMailUserName"];
            password = ConfigurationManager.AppSettings["DebugMailPassword"];
#endif

            MailMessage mailMsg = new MailMessage();
            
            #region content

            mailMsg.BodyEncoding = System.Text.Encoding.UTF8;
            mailMsg.Subject = message.Subject;
            mailMsg.IsBodyHtml = true;
            mailMsg.Priority = message.Priority;

            mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(message.Body, null, "text/html"));
            //mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(message.Body, null, "text/plain"));

            
            foreach (Attach attach in message.Attaches)
            {
                Attachment attachment = new Attachment(attach.Path);    // 文件路径
                attachment.Name = attach.Title;

                if (String.IsNullOrEmpty(attach.ContentID))
                {
                    attachment.ContentId = attach.ContentID;
                    attachment.ContentDisposition.Inline = true;
                    attachment.ContentDisposition.DispositionType = System.Net.Mime.DispositionTypeNames.Inline;
                }

                mailMsg.Attachments.Add(attachment);
            }

            // from
            string[][] fromAddress = Message.ParseMailAddress(message.From);
            if (fromAddress[0].Length == 1)
            {
                mailMsg.From = new MailAddress(fromAddress[0][0]);
            }
            else if (fromAddress[0].Length >= 2)
            {
                mailMsg.From = new MailAddress(fromAddress[0][0], fromAddress[0][1]);
            }

            // to
            string[][] toAddress = Message.ParseMailAddress(message.To);
            foreach (string[] t in toAddress)
            {
                MailAddress add = null;
                if (t.Length == 1)
                {
                    add = new MailAddress(t[0]); 
                }
                else if (t.Length >= 2)
                {
                    add = new MailAddress(t[0], t[1]); 
                }

                if (add != null && !mailMsg.To.Contains(add))
                    mailMsg.To.Add(add);
            }
            // cc
            if (!String.IsNullOrEmpty(message.CC))
            {
                string[][] ccAddress = Message.ParseMailAddress(message.CC);
                foreach (string[] c in ccAddress)
                {
                    MailAddress add = null;
                    if (c.Length == 1)
                    {
                        add = new MailAddress(c[0]); 
                    }
                    else if (c.Length >= 2)
                    {
                        add = new MailAddress(c[0], c[1]); 
                    }

                    if (add != null && !mailMsg.CC.Contains(add))
                        mailMsg.CC.Add(add);
                }
            }
            // bcc
            if (!String.IsNullOrEmpty(message.BCC))
            {
                string[][] bccAddress = Message.ParseMailAddress(message.BCC);
                foreach (string[] b in bccAddress)
                {
                    if (b.Length == 1)
                    {
                        mailMsg.Bcc.Add(new MailAddress(b[0]));
                    }
                    else if (b.Length >= 2)
                    {
                        mailMsg.Bcc.Add(new MailAddress(b[0], b[1]));
                    }
                }
            }
            if (!String.IsNullOrEmpty(message.ReplyTo))
            {
                string[][] replyToAddress = Message.ParseMailAddress(message.ReplyTo);
                if (replyToAddress[0].Length == 1)
                {
                    mailMsg.ReplyTo = new MailAddress(replyToAddress[0][0]);
                }
                else if (replyToAddress[0].Length >= 2)
                {
                    mailMsg.ReplyTo = new MailAddress(replyToAddress[0][0], replyToAddress[0][1]);
                }
            }
            // sender -- 似乎无意义
            if (!String.IsNullOrEmpty(message.Sender))
            {
                string[][] senderAddress = Message.ParseMailAddress(message.Sender);
                if (senderAddress[0].Length == 1)
                {
                    mailMsg.Sender = new MailAddress(senderAddress[0][0]);
                }
                else if (senderAddress[0].Length >= 2)
                {
                    mailMsg.Sender = new MailAddress(senderAddress[0][0], senderAddress[0][1]);
                }
            }

            #endregion

            SmtpClient client = new SmtpClient();
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = false;
            client.UseDefaultCredentials = false;
            client.Host = host;
            client.Port = port;
            client.Credentials = new System.Net.NetworkCredential(userName, password);
            #if DEBUG
                client.EnableSsl = (ConfigurationManager.AppSettings["DebugMailSsl"] == "0");    // true for google
            #endif

            client.Send(mailMsg);       // 直接抛出异常
        }









        /// <summary>
        /// 转换邮件地址
        /// </summary>
        /// <param name="addressArray"></param>
        /// <returns></returns>
        /// <remarks>\r\n分割多个地址，每个地址使用\t分割多个部分(最多2个，邮件地址和显示名称)。</remarks>
        public static string ConvertMailAddress(params string[][] addressArray)
        {
            return Message.ConvertMailAddress(addressArray);
        }

        /// <summary>
        /// 转换邮件地址
        /// </summary>
        /// <param name="addressArray"></param>
        /// <returns></returns>
        /// <remarks>\r\n分割多个地址，每个地址使用\t分割多个部分(最多2个，邮件地址和显示名称)。</remarks>
        public static string ConvertMailAddress(params string[] addressArray)
        {
            return Message.ConvertMailAddress(addressArray);
        }
    }
}
