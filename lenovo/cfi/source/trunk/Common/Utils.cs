using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lenovo.CFI.Common
{
    public class Utils
    {
        public static string GetSysStatement()
        {
            return string.Format(@"<p>This is an auto generated mail from the <a href=""{0}"" target=""_blank"">TQMP System</a></p>",
                System.Configuration.ConfigurationManager.AppSettings["SysUrl"]);
        }

        /// <summary>
        /// 是否是集成模式（兼容旧系统）
        /// </summary>
        /// <returns></returns>
        public static bool IsIntegratedMode()
        {
            return System.Configuration.ConfigurationManager.AppSettings["Integrated"] == "1";
        }

        public static string SysDomain()
        {
            return System.Configuration.ConfigurationManager.AppSettings["Domain"];
        }

        public static string SysUrl()
        {
            return System.Configuration.ConfigurationManager.AppSettings["SysUrl"];
        }

        public static string SysFileDir()
        {
            return System.Configuration.ConfigurationManager.AppSettings["File"];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool EnableHiddenFunction()
        {
            return System.Configuration.ConfigurationManager.AppSettings["EnableDebug"] == "1";
        }



        public static string AdDomain()
        {
            return System.Configuration.ConfigurationManager.AppSettings["ADPath"];
        }
        public static string AdUsername()
        {
            return System.Configuration.ConfigurationManager.AppSettings["ADUsername"];
        }
        public static string AdPassword()
        {
            return System.Configuration.ConfigurationManager.AppSettings["ADPassword"];
        }

    }
}
