using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.SessionState;
using System.Web.Security;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using Log = Dotnet.Commons.Logging.ILog;
using LogFactory = Dotnet.Commons.Logging.LogFactory;

namespace Lenovo.CFI.Identity
{
    /// <summary>
    /// 根据Cookie恢复身份验证Session的HttpModule。
    /// </summary>
    public class IdentityCookieHttpModule : IHttpModule
    {
        private Log log = LogFactory.GetLogger(typeof(IdentityCookieHttpModule));

        #region IHttpModule Members

        /// <summary>
        /// 初始化IdentityCookie模块，并使其为处理请求做好准备。
        /// </summary>
        /// <param name="context">一个 HttpApplication，
        /// 它提供对 ASP.NET 应用程序内所有应用程序对象的公用的方法、属性和事件的访问。</param>
        /// <remarks>初始化IdentityCookie模块后，
        /// 如果发送的请求未包含会话标识符、会话标识符无效或与会话标识符关联的会话已过期，
        /// 会首先检查是否存在身份Cookie，并根据存在的身份Cookie恢复会话。</remarks>
        public void Init(HttpApplication context)
        {
            IHttpModule module = context.Modules["Session"];
            if (module.GetType() == typeof(SessionStateModule))
            {
                SessionStateModule stateModule = (SessionStateModule)module;
                stateModule.Start += new EventHandler(Session_Start);

                // SessionStateModule.Start 事件：创建会话时发生的事件。 
                // 启动新会话后，在请求的初始阶段引发了 Start 事件。
                // 如果发送的请求未包含会话标识符、会话标识符无效或与会话标识符关联的会话已过期，
                // 则会启动新的会话。（而不论是否存在通过编程方式设置的Session对象） 
            }
        }

        /// <summary>
        /// 处置由实现 IHttpModule 的模块使用的资源（内存除外）。
        /// </summary>
        public void Dispose()
        {
        }

        #endregion

        //
        private void Session_Start(object sender, EventArgs e)
        {
            try
            {
                IdentityInfo identityInfo = GetAuthCookieIdentity(HttpContext.Current);

                if (identityInfo != null)
                {
                    EstablishSession(identityInfo, HttpContext.Current);

                    // BETTER:可以在AuthCookie存储当前会话的内容，并在恢复会话的时候同时恢复内容。
                }
            }
            catch (Exception ex)
            {
                log.Error(String.Format("Session_Start Error(Auto Cookie):{0}", ex.ToString()));
            }
        }


        private static IdentityInfo GetAuthCookieIdentity(HttpContext context)
        {
            HttpCookie authCookie = context.Request.Cookies[Settings.GetAuthCookieName()];
            if (authCookie != null)
            {
                try
                {
                    FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);   //解密 

                    // 反序列化
                    using (MemoryStream buffer = new MemoryStream(System.Convert.FromBase64String(authTicket.UserData)))
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        return (IdentityInfo)(formatter.Deserialize(buffer));
                    }

                }
                catch
                {
                    throw;
                }
            }

            return null;
        }

        /// <summary>
        /// 建立会话
        /// </summary>
        /// <param name="identityInfo"></param>
        /// <param name="sessionContex"></param>
        private static void EstablishSession(IdentityInfo identityInfo, HttpContext sessionContex)
        {
            sessionContex.Session["UserId"] = identityInfo.UserKey;     // 兼容CQS

            sessionContex.Session["UID"] = identityInfo.UserKey;
            sessionContex.Session["UserName"] = identityInfo.UserName;
            sessionContex.Session["Cookie"] = true;

            PublishAuthCookie(sessionContex, identityInfo);
        }

        /// <summary>
        /// 建立会话
        /// </summary>
        /// <param name="identityInfo"></param>
        /// <param name="sessionContex"></param>
        public static void EstablishSession(Guid userKey, string username, HttpContext sessionContex)
        {
            EstablishSession(new IdentityInfo(userKey, username), sessionContex);
        } 


        private static void PublishAuthCookie(HttpContext context, IdentityInfo identityInfo)
        {
            #region 如果支持持久性身份验证Cookie

            string userData = null;
            using (MemoryStream buffer = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(buffer, identityInfo);
                buffer.Position = 0;
                userData = System.Convert.ToBase64String(buffer.ToArray());
            }


            // 使用本地日期和时间
            FormsAuthenticationTicket tk = new FormsAuthenticationTicket(1, identityInfo.UserName,
                DateTime.Now, DateTime.Now.AddMinutes((double)Settings.GetAuthCookieTimeOut()),
                true, userData, Settings.GetAuthCookiePath());
            string encryptedTicket = FormsAuthentication.Encrypt(tk);   //加密身份验票 
            System.Web.HttpCookie authCookie = new HttpCookie(Settings.GetAuthCookieName(), encryptedTicket);
            authCookie.Path = Settings.GetAuthCookiePath();
            authCookie.Domain = Settings.GetAuthCookieDomain();
            authCookie.Expires = tk.Expiration;
            authCookie.Secure = Settings.GetAuthCookieRequireSSL();
            context.Response.Cookies.Add(authCookie);

            #endregion
        }

        public static void RemoveAuthCookie(HttpContext context)
        {
            System.Web.HttpCookie authCookie = new HttpCookie(Settings.GetAuthCookieName());
            authCookie.Path = Settings.GetAuthCookiePath();
            authCookie.Domain = Settings.GetAuthCookieDomain();
            authCookie.Expires = DateTime.Now.AddDays(-100);    // 本地日期和时间
            authCookie.Secure = Settings.GetAuthCookieRequireSSL();
            context.Response.Cookies.Add(authCookie);
        }
    }
}
