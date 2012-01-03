using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net.Mail;

namespace Lenovo.CFI.Common.Mail
{
    /// <summary>
    /// 定义邮件
    /// </summary>
    public class Message
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public Message()
            : this(Guid.NewGuid())
        {
        }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="uid">邮件标识。</param>
        public Message(Guid uid)
        {
            this.uid = uid;
            this.status = 0;
            this.priority = MailPriority.Normal;
            this.createTime = DateTime.Now;
        }


        #region field
        private Guid uid;
        private Guid? system;
        private string from;
        private string to;
        private string cc;
        private string bcc;
        private string replyTo;
        private string sender;
        private MailPriority priority;
        private string subject;
        private string body;
        private DateTime createTime;
        private DateTime? sendTime;
        private int status;


        private List<Attach> attaches;

        #endregion

        #region properity

        /// <summary>
        /// 获取或设置标识
        /// </summary>
        public Guid UID
        {
            get { return uid; }
            set { uid = value; }
        }

        /// <summary>
        /// 获取或设置应用系统
        /// </summary>
        public Guid? System
        {
            get { return system; }
            set { system = value; }
        }

        /// <summary>
        /// 获取或设置发件人
        /// </summary>
        public string From
        {
            get { return from; }
            set { from = value; }
        }

        /// <summary>
        /// 获取或设置收件人
        /// </summary>
        public string To
        {
            get { return to; }
            set { to = value; }
        }

        /// <summary>
        /// 获取或设置抄送人
        /// </summary>
        public string CC
        {
            get { return cc; }
            set { cc = value; }
        }

        /// <summary>
        /// 获取或设置密件抄送人
        /// </summary>
        public string BCC
        {
            get { return bcc; }
            set { bcc = value; }
        }

        /// <summary>
        /// 获取或设置邮件回复地址
        /// </summary>
        public string ReplyTo
        {
            get { return replyTo; }
            set { replyTo = value; }
        }

        /// <summary>
        /// 获取或设置发信人
        /// </summary>
        /// <remarks>From与Sender的区别：
        /// Sender是发件人地址，发送邮件时使用，必须正确；From则可以任意填写，显示使用。
        /// 当未设置Sender时，将会使用From的值。
        /// 另外，对于MailMessage类，初始化的时候会将From设置为mailSettings中的配置。</remarks>
        public string Sender
        {
            get { return sender; }
            set { sender = value; }
        }

        /// <summary>
        /// 获取或设置优先级
        /// </summary>
        public MailPriority Priority
        {
            get { return priority; }
            set { priority = value; }
        }

        /// <summary>
        /// 获取或设置主题
        /// </summary>
        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }

        /// <summary>
        /// 获取或设置正文
        /// </summary>
        public string Body
        {
            get { return body; }
            set { body = value; }
        }

        /// <summary>
        /// 获取或设置创建时间
        /// </summary>
        public DateTime CreateTime
        {
            get { return createTime; }
            set { createTime = value; }
        }

        /// <summary>
        /// 获取或设置发送时间
        /// </summary>
        public DateTime? SendTime
        {
            get { return sendTime; }
            set { sendTime = value; }
        }

        /// <summary>
        /// 获取或设置邮件状态
        /// </summary>
        public int Status
        {
            get { return status; }
            set { status = value; }
        }

        #endregion

        /// <summary>
        /// 优先级名称。
        /// </summary>
        public string PriorityText
        {
            get
            {
                string t = "";
                switch (this.priority)
                {
                    case MailPriority.Low:
                        t = "低";
                        break;
                    case MailPriority.Normal:
                        t = "中";
                        break;
                    case MailPriority.High:
                        t = "高";
                        break;
                }
                return t;
            }
        }


        public List<Attach> Attaches
        {
            get 
            {
                if (this.attaches == null)
                    this.attaches = new List<Attach>();
                return attaches; 
            }
        }




        /// <summary>
        /// 解析邮件地址。
        /// </summary>
        /// <param name="addressStr"></param>
        /// <returns></returns>
        /// <remarks>\r\n分割多个地址，每个地址使用\t分割多个部分(最多2个，邮件地址和显示名称)。
        /// 保证邮件地址和显示名称不含\t,\n,\r字符。</remarks>
        public static string[][] ParseMailAddress(string addressStr)
        {
            List<string[]> results = new List<string[]>();
            string[] adds = addressStr.Split(new char[] { ';'}, StringSplitOptions.RemoveEmptyEntries);
            foreach (string add in adds)
            {
                results.Add(add.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries));
            }

            return results.ToArray();
        }

        /// <summary>
        /// 转换邮件地址
        /// </summary>
        /// <param name="addressArray"></param>
        /// <returns></returns>
        /// <remarks>\r\n分割多个地址，每个地址使用\t分割多个部分(最多2个，邮件地址和显示名称)。</remarks>
        public static string ConvertMailAddress(params string[][] addressArray)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string[] add in addressArray)
            {
                if (add.Length == 1)
                {
                    sb.AppendFormat("{0};", add[0].Replace("\t", ""));       // 去除t
                }
                else if (add.Length >= 2)
                {
                    sb.AppendFormat("{0}\t{1};",
                        add[0].Replace("\t", ""),
                        add[1].Replace("\t", ""));
                }
            }

            return sb.ToString();
        }

        public static string ConvertMailAddress(params string[] itcodesOrEmail)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string add in itcodesOrEmail)
            {
                if (add.Contains("@"))
                    sb.AppendFormat("{0};", add.Replace("\t", ""));       // 去除t
                else
                    sb.AppendFormat("{0}@lenovo.com;", add.Replace("\t", ""));       // 去除t
            }

            return sb.ToString();
        }
    }

    /// <summary>
    /// 附件
    /// </summary>
    public class Attach
    {
        public Attach(Guid mailID, string contentID, string title, string path)
        {
            this.mailID = mailID;
            this.contentID = contentID;
            this.title = title;
            this.path = path;
        }

        public Attach(int id, Guid mailID, string contentID, string title, string path)
        {
            this.id = id;
            this.mailID = mailID;
            this.contentID = contentID;
            this.title = title;
            this.path = path;
        }

        private int id;
        private Guid mailID;
        private string contentID;
        private string title;
        private string path;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public Guid MailID
        {
            get { return mailID; }
            set { mailID = value; }
        }

        public string ContentID
        {
            get { return contentID; }
            set { contentID = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Path
        {
            get { return path; }
            set { path = value; }
        }
    }
}
