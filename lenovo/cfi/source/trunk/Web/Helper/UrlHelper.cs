using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace Lenovo.CFI.Web.Helper
{
    public class UrlHelper
    {
        public static string GenerateUrl(string vpKey, params string[] para)
        {
            StringBuilder url = new StringBuilder();
            url.Append(UserHelper.GetVPUrl(vpKey));
            if (url.ToString() != "#" && para != null)
            {
                for (int i = 0; i < para.Length / 2; i++)
                {
                    url.AppendFormat("&{0}={1}", para[2 * i], para[2 * i + 1]);
                }
            }
            return Root + HttpUtility.UrlPathEncode(url.ToString());
        }

        public static string GenerateUrlDefault(params string[] para)
        {
            return GenerateUrl(HttpContext.Current.Request.QueryString["vp"], para);
        }

        public static string Root
        {
            get
            {
                string root = HttpContext.Current.Request.ApplicationPath;
                if (root.EndsWith("/"))
                    return root;
                else
                    return root + "/";
            }
        }

        public static string GetQueryString(string key)
        {
            return HttpContext.Current.Request.QueryString[key];
        }


        public static int? GetQueryStringToInt(string key)
        {
            string id = GetQueryString(key);
            if (!String.IsNullOrEmpty(id))
                return int.Parse(id);
            else
                return (int?)null;
        }

        public static DateTime? GetQueryStringToDateTime(string key)
        {
            string day = GetQueryString(key);
            if (!String.IsNullOrEmpty(day))
                return DateTime.Parse(day);
            else
                return (DateTime?)null;
        }

        public static int? GetQueryStringID()
        {
            string id = GetQueryString("id");
            if (!String.IsNullOrEmpty(id))
                return int.Parse(id);
            else
                return (int?)null;
        }

        public static Guid? GetQueryStringGUID()
        {
            string id = GetQueryString("uid");

            if (!String.IsNullOrEmpty(id))
            {
                try
                {
                    return new Guid(id);
                }
                catch { }
            }

            return (Guid?)null;
        }

        public static Guid? GetQueryStringGUID(string key)
        {
            string id = GetQueryString(key);

            if (!String.IsNullOrEmpty(id))
            {
                try
                {
                    return new Guid(id);
                }
                catch { }
            }

            return (Guid?)null;
        }

        public static string EncodePara(string para)
        {
            return Common.UrlEncoder.Encode(para);
            // return HttpContext.Current.Server.UrlPathEncode(para).Replace("\"", "%22").Replace("#", "%23").Replace("&", "%26").Replace("'", "%27").Replace("(", "%28").Replace(")", "%29").Replace("+", "%2B");
        }

        public static string HashPara(params string[] para)
        {
            return Common.UrlEncoder.HashPara(para);
        }

        public static bool ValidatePara(string hash, params string[] para)
        {
            return Common.UrlEncoder.ValidatePara(hash, para);
        }


        //public void UrlEncodeTest(){    string url = "C++ C#";    
        //    Console.WriteLine(HttpUtility.UrlEncode(url));//C%2b%2b+C%23    
        //    Console.WriteLine(HttpUtility.UrlPathEncode(url));//C++%20C#    
        //    Console.WriteLine(Uri.EscapeUriString(url));//C++%20C#    
        //    Console.WriteLine(Uri.EscapeDataString(url));//C%2B%2B%20C%23
        //}
    }
}
