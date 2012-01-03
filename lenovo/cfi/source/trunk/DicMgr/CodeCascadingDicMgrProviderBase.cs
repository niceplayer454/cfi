using System;
using System.Collections.Generic;
using System.Text;

namespace Lenovo.CFI.DicMgr
{
    /// <summary>
    /// </summary>
    /// <typeparam name="T">被管理的数据字典项的类型。</typeparam>
    abstract public class CodeCascadingDicMgrProviderBase<T> : CodeTabularDicMgrProviderBase<T> 
        where T : AbstractCodeDictionaryEntry
    {
        /// <summary>
        /// 构造函数。
        /// </summary>
        protected CodeCascadingDicMgrProviderBase()
            : base() {}

        #region 访问方法

        /// <summary>
        /// 获取数据字典项列表。
        /// </summary>
        /// <param name="pCode">父数据字典项的Code。</param>
        /// <param name="all">是否得到全部。否则仅返回可见的数据字典项。</param>
        /// <returns>如果是按层次编码的数据字典，则返回指定父项的所有直接子数据字典项
        /// （如果父项不存在，返回空列表;）；
        /// 否则，返回所有的数据字典项。</returns>
        public override IList<T> GetList(string pCode, bool all)
        {
            if (all)
            {
                return this.sortDataAll.FindAll(x => x.PCode == pCode);
            }
            else
            {
                return this.sortDataVisible.FindAll(x => x.PCode == pCode);
            }
        }


        #endregion
    }
}
