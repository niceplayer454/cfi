using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using TB.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Text;

namespace Lenovo.CFI.Web.Helper
{
    /// <summary>
    /// Message 的摘要说明
    /// </summary>
    /// <summary>
    /// 系统向用户发出提示或警告信息的帮助类。
    /// </summary>
    public class MessageHelper
    {
        /// <summary>
        /// 准备控件。Ajax。
        /// </summary>
        /// <param name="page">WEB窗体引用。</param>
        public static void Prepare(Page page)
        {
            Prepare(page, null);
        }

        /// <summary>
        /// 准备控件。Ajax。
        /// </summary>
        /// <param name="page">WEB窗体引用。</param>
        /// <param name="showLink">是否显示链接。null表示使用默认值。</param>
        public static void Prepare(Page page, bool? showLink)
        {
            object ctl = null;
            if (page.Master != null)
                ctl = page.Master.FindControl("PWMessage");
            if (ctl == null)
                ctl = page.FindControl("PWMessage");
            if (ctl != null)
            {
                ((PopupWin)ctl).Visible = true;
                if (showLink.HasValue)
                {
                    ((PopupWin)ctl).ShowLink = showLink.Value;
                }
            }
        }

        /// <summary>
        /// 显示指定的提示信息。
        /// 显示位置居中，2秒后消失。
        /// </summary>
        /// <param name="msg">消息内容。</param>
        /// <param name="page">WEB窗体引用。</param>
        public static void Show(string msg, Page page)
        {
            Show(msg, page, MessageType.Popup);
        }

        /// <summary>
        /// 显示指定的警告信息。
        /// </summary>
        /// <param name="msg">消息内容。</param>
        /// <param name="page">WEB窗体引用。</param>
        public static void Alert(string msg, Page page)
        {
            Show(msg, page, MessageType.Alert);
        }

        private static void Show(string msg, Page page, MessageType type)
        {
            switch (type)
            {
                case MessageType.Popup:
                    PopupWin ctl = GetPopupWin(page);
                    if (ctl != null)
                    {
                        ctl.Visible = true;
                        ctl.Title = "System Message";
                        if (msg.Length <= LENGTH)
                        {
                            ctl.Message = msg;
                        }
                        else
                        {
                            ctl.Message = msg.Substring(0, LENGTH);
                            ctl.Text = msg.Replace("\\", "\\\\").Replace("\"", "\\\"").Replace("\r", "").Replace("\n", "<br />");
                            ctl.ShowLink = true;
                        }
                        //((PopupWin)ctl).DockMode = TB.Web.UI.PopupDocking.BottomRight;
                        //((PopupWin)ctl).DisplayDuration = 1500;

                        if (!page.ClientScript.IsStartupScriptRegistered(page.GetType(), "showMessage"))
                            page.ClientScript.RegisterStartupScript(page.GetType(), "showMessage", ctl.GetShowPopupScript(null));

                    }
                    else
                    { }
                    // TODO:发出一个居中的提示信息
                    break;
                case MessageType.Alert:
                    page.ClientScript.RegisterStartupScript(page.GetType(), "Msg", "<script>alert('System Message:" + Filter(msg) + "');</script>");
                    break;
            }
        }

        // TODO:转义不完全
        private static string Filter(string msg)
        {
            msg = Regex.Replace(msg, "\\s", "");
            msg = Regex.Replace(msg, "'", "\"");
            return msg;
        }


        /// <summary>
        /// 获取显示提示信息的Javascript脚本。
        /// </summary>
        /// <param name="msg">消息内容。</param>
        /// <param name="page">WEB窗体引用。</param>
        public static void RegShowJS(string msg, Page page)
        {
            if (!page.ClientScript.IsStartupScriptRegistered(page.GetType(), "ShowJS"))
            {
                page.ClientScript.RegisterStartupScript(page.GetType(), "ShowJS", ShowJS(msg, page), true);
            }
        }

        /// <summary>
        /// 获取显示提示信息的Javascript脚本。Ajax
        /// </summary>
        /// <param name="control">触发者。</param>
        /// <param name="msg">消息内容。</param>
        /// <param name="page">WEB窗体引用。</param>
        public static void RegShowJSAjax(Control control, string msg, Page page)
        {
            if (msg.Length > LENGTH)
            {
                PopupWin ctl = GetPopupWin(page);
                if (ctl != null)
                    ctl.ShowLink = true;
            }
            if (!page.ClientScript.IsStartupScriptRegistered(page.GetType(), "ShowJS"))
            {
                System.Web.UI.ScriptManager.RegisterStartupScript(control, page.GetType(), "ShowJS", ShowJS(msg, page), true);
            }
        }

        private const int LENGTH = 100;
        private static PopupWin GetPopupWin(Page page)
        {
            object ctl = null;
            if (page.Master != null)
                ctl = page.Master.FindControl("PWMessage");
            if (ctl == null)
                ctl = page.FindControl("PWMessage");

            if (ctl != null)
                return (PopupWin)ctl;
            else
                return null;
        }
        /// <summary>
        /// 显示指定的提示信息。
        /// 显示位置居中，2秒后消失。
        /// 直接由客户端调用
        /// </summary>
        /// <param name="msg">消息内容。</param>
        /// <param name="page">WEB窗体引用。</param>
        public static string ShowJS(string msg, Page page)
        {
            StringBuilder sb = new StringBuilder();

            PopupWin ctl = GetPopupWin(page);
            if (ctl != null)
            {
                ctl.Visible = true;
                if (msg.Length > LENGTH)
                {
                    sb.AppendFormat(@"
    {0}nText=""{1}"";", ctl.ClientID, ctl.GetWinText(msg.Substring(0, LENGTH), msg));
                    // 消息
                    sb.AppendFormat(@"
    {0}nMsg=""{1}"";", ctl.ClientID,
                     msg.Substring(0, LENGTH).Replace("\\", "\\\\").Replace("\"", "\\\"").Replace("\r", "").Replace("\n", "<br />"));
                }
                else
                {
                    // 消息
                    sb.AppendFormat(@"
    {0}nMsg=""{1}"";", ctl.ClientID,
                     msg.Replace("\\", "\\\\").Replace("\"", "\\\"").Replace("\r", "").Replace("\n", "<br />"));
                }

                // 标题
                sb.AppendFormat(@"
    {0}nTitle=""{1}"";", ctl.ClientID, "System Message");
                // 标志
                sb.AppendFormat(@"
    {0}bChangeTexts=true;", ctl.ClientID);

                sb.AppendFormat(@"
    {0}espopup_ShowPopup(null);            // 显示
", ctl.ClientID);
            }

            return sb.ToString();
        }


        public static string ListToString(List<string> msgs)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string msg in msgs)
            {
                sb.AppendLine(msg);
            }
            return sb.ToString();
        }
    }

    public enum MessageType
    {
        Popup,
        Alert,
        Confirm
    }
}
