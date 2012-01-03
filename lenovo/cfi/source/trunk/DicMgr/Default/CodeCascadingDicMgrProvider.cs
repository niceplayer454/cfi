using System;
using System.Collections.Generic;
using System.Text;

namespace Lenovo.CFI.DicMgr.Default
{
    /// <summary>
    /// 
    /// </summary>
    abstract public class CodeCascadingDicMgrProvider : CodeCascadingDicMgrProviderBase<CodeDictionaryEntry>
    {
        /// <summary>
        /// ¹¹Ôìº¯Êý¡£
        /// </summary>
        protected CodeCascadingDicMgrProvider()
            : base() {}

        public CodeDictionaryEntry CreateEntry(string code, string pCode, string title, int value, int sort, bool visible, string note, string updator, DateTime updateTime)
        {
            return new CodeDictionaryEntry(code, pCode, title, value, sort, visible, note, updator, updateTime);
        }

        public CodeDictionaryEntry CreateEntry(string code, string pCode, string title, int sort, bool visible, string updator, DateTime updateTime)
        {
            return new CodeDictionaryEntry(code, pCode, title, sort, visible, updator, updateTime);
        }

        public CodeDictionaryEntry CreateEntry(string code, string title, int sort, bool visible, string updator, DateTime updateTime)
        {
            return new CodeDictionaryEntry(code, title, sort, visible, updator, updateTime);
        }
    }
}
