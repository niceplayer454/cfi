using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Text.RegularExpressions;

namespace Lenovo.CFI.Common.Dic
{
    public class DataDictionaryEntry : DicMgr.Default.CodeDictionaryEntry
    {
        #region .ctor

        /// <summary>
        /// </summary>
        public DataDictionaryEntry()
            : base()
        { }

        protected DataDictionaryEntry(string code, string pCode, string title, int sort, bool visible, string updator, DateTime updateTime)
            : base(ValidCode(code), pCode, title, 0, sort, visible, null, updator, updateTime)
        {
        }

        public DataDictionaryEntry(string code, string title, int sort, bool visible, string updator, DateTime updateTime)
            : base(ValidCode(code), null, title, 0, sort, visible, null, updator, updateTime)
        {
        }

        #endregion


        private static Regex codeRegex = new Regex("[^A-Z0-9_]");
        public static string ValidCode(string code)
        {
            if (code == null) return null;
            code = code.ToUpper();
            return codeRegex.Replace(code, "");
        }



        /// <summary>
        /// 获取或设置字典项的编码。
        /// </summary>
        public override string Code
        {
            get { return base.Code; }
            set { base.Code = ValidCode(value); }
        }

        public override string Title
        {
            get { return base.Title; }
            set { base.Title = value; }
        }

        public override int Sort
        {
            get { return base.Sort; }
            set { base.Sort = value; }
        }

        public override bool Visible
        {
            get { return base.Visible; }
            set { base.Visible = value; }
        }
    }
}
