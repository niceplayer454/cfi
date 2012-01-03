using System;
using System.Collections.Generic;
using System.Text;

namespace Lenovo.CFI.DicMgr
{
    /// <summary>
    /// 编码方式为字符编码的数据字典的字典项。
    /// </summary>
    /// <remarks>实际不限制编码方式，人为指定编码或由序列（应用程序或数据库）产生。</remarks>
    abstract public class AbstractCodeDictionaryEntry : AbstractDictionaryEntry
    {
        /// <summary>
        /// 
        /// </summary>
        protected AbstractCodeDictionaryEntry() : base() { }

        #region properity


        /// <summary>
        /// 获取字典项的父键。
        /// </summary>
        abstract public string PCode { get; set; }


        #endregion


        #region 帮助方法

        /// <summary>
        /// 获取指定编码的父编码
        /// </summary>
        /// <returns></returns>
        public override string GetParentCode()
        {
            return this.PCode;
        }


        #endregion
    }
}
