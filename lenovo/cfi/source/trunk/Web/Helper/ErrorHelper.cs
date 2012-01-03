using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using Lenovo.CFI.Common;

namespace Lenovo.CFI.Web.Helper
{
    public class ErrorHelper
    {
        /// <summary>
        /// 处理错误信息。
        /// </summary>
        /// <param name="msg">错误信息。</param>
        public static void Handle(Exception ex)
        {
            HttpContext.Current.Items.Add("Exception", ex);

            if (!(ex is ApplicationException))
            {
                // TODO:ExceptionLog.Log(ex);           // 记录非ApplicationException异常
            }

            // 转到提示信息页面
            HttpContext.Current.Server.Transfer(ConfigurationManager.AppSettings["MessagePage"]);
        }

        /// <summary>
        /// 检验异常是否发生，并处理异常。
        /// </summary>
        /// <param name="ex"></param>
        public static void CheckException(Exception ex)
        {
            if (ex != null)
                Handle(ex);
        }

        /// <summary>
        /// 处理请求数据不存在的异常。
        /// </summary>
        public static void RaiseNoValueError()
        {
            Handle(new BusinessObjectExistException("请求的数据不存在、已被删除或已被处理!"));
        }

        /// <summary>
        /// 处理缺少相应权限的异常。
        /// </summary>
        public static void RaiseNoPermError()
        {
            Handle(new ApplicationException("非法请求!"));
        }


        public static void RaiseError(string hint)
        {
            Handle(new ApplicationException(hint));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        /// <remarks>Ajax无法使用默认异常处理程序处理异常</remarks>
        public static void ExceptionHanderForAjax(Exception ex, System.Web.UI.Control ctl, System.Web.UI.Page page)
        {
            // TODO:ExceptionLog.Log(ex);
            // throw new Exception("很抱歉，系统检测到一个未处理异常。请与系统管理员联系!");

            MessageHelper.RegShowJSAjax(ctl,
                @"There is a unhandled exception!
Technical detail:" + ex.Message + ".", page);
        }
    }
}
