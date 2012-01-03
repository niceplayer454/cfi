using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using Lenovo.CFI.Common.Sys;
using Lenovo.CFI.Common.Dic;
using Lenovo.CFI.BLL.DicMgr;
using Lenovo.CFI.Common;

namespace Lenovo.CFI.BLL
{
    public static class CommonExtensions
    {


        public static string Format4Html(this string input)
        {
            if (String.IsNullOrEmpty(input)) return " ";

            return input.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;");
        }

        public static string Format4HtmlWithBlank(this string input)
        {
            if (String.IsNullOrEmpty(input)) return " ";

            Regex regEx = new Regex(@"[\n|\r]+");
            return regEx.Replace(input.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("  ", "&nbsp; "), "<br />").Replace("\t", "&emsp;");
        }



        public static bool IsNumeric(this string obj)
        {
            if (String.IsNullOrEmpty(obj))
                return false;

            for (int i = 0; i < obj.Length; i++)
            {
                if (obj[i] < '0' || obj[i] > '9')
                    return false;
            }
            return true;
        }
    }
}
