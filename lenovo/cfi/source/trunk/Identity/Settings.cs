using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;
using System.Configuration;

namespace Lenovo.CFI.Identity
{
    /// <summary>
    /// AuthCookie配置类，对应Web.config中tbias/authcookie配置节。
    /// </summary>
    internal class Settings
    {
        #region const

        /// <summary>
        /// 配置节名称
        /// </summary>
        public const string SectionName = "identity/authcookie";

        #region AuthCookie

        /// <summary>
        /// AuthCookie名称
        /// </summary>
        public const string KeyAuthCookieName = "Name";
        /// <summary>
        /// AuthCookie路径
        /// </summary>
        public const string KeyAuthCookiePath = "Path";
        /// <summary>
        /// AuthCookie域
        /// </summary>
        public const string KeyAuthCookieDomain = "Domain";
        /// <summary>
        /// AuthCookie过期时间
        /// </summary>
        public const string KeyAuthCookieTimeOut = "TimeOut";
        /// <summary>
        /// AuthCookie是否使用SSL
        /// </summary>
        public const string KeyAuthCookieRequireSSL = "RequireSSL";

        #endregion

        #endregion


        /// <summary>
        /// 静态构造函数，获取配置内容。
        /// </summary>
        static Settings()
        {
            object section = ConfigurationManager.GetSection(SectionName);      // 返回ReadOnlyNameValueCollection
            if ((section == null) || !(section is NameValueCollection))
            {
                throw new ConfigurationErrorsException("Section identity/authcookie has not been configurated.");
            }

            NameValueCollection settings = (NameValueCollection)section;
            string value = settings[KeyAuthCookieName];
            if (value != null)
                authCookieName = value;
            value = settings[KeyAuthCookiePath];
            if (value != null)
                authCookiePath = value;
            value = settings[KeyAuthCookieDomain];
            if (value != null)
                authCookieDomain = value;
            value = settings[KeyAuthCookieTimeOut];
            if (value != null)
                authCookieTimeOut = int.Parse(value);
            value = settings[KeyAuthCookieRequireSSL];
            if (value != null)
                authCookieRequireSSL = bool.Parse(value);
        }

        #region 属性

        private static string authCookieName = ".IdentityProvider";
        private static string authCookiePath = "/";
        private static string authCookieDomain = null;
        private static int authCookieTimeOut = 20;
        private static bool authCookieRequireSSL = false;

        #endregion

        #region 方法

        public static string GetAuthCookieName()
        {
            return authCookieName;
        }

        public static string GetAuthCookiePath()
        {
            return authCookiePath;
        }

        public static string GetAuthCookieDomain()
        {
            return authCookieDomain;
        }

        public static int GetAuthCookieTimeOut()
        {
            return authCookieTimeOut;
        }

        public static bool GetAuthCookieRequireSSL()
        {
            return authCookieRequireSSL;
        }

        #endregion
    }
}
