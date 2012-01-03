using System;
using System.Collections.Generic;
using System.Text;

namespace Lenovo.CFI.DicMgr.Default
{
    /// <summary>
    /// 
    /// </summary>
    abstract public class CodeTabularDicMgrProvider : CodeTabularDicMgrProviderBase<CodeDictionaryEntry>
    {
        /// <summary>
        /// ¹¹Ôìº¯Êý¡£
        /// </summary>
        protected CodeTabularDicMgrProvider()
            : base() {}

        public CodeDictionaryEntry CreateEntry(string code, string title, int value, int sort, bool visible, string note, string updator, DateTime updateTime)
        {
            return new CodeDictionaryEntry(code, null, title, value, sort, visible, note, updator, updateTime);
        }

        public CodeDictionaryEntry CreateEntry(string code, string title, int sort, bool visible, string updator, DateTime updateTime)
        {
            return new CodeDictionaryEntry(code, null, title, sort, visible, updator, updateTime);
        }

        public override CodeDictionaryEntry CreateEntry()
        {
            return new CodeDictionaryEntry();
        }
    }
}
