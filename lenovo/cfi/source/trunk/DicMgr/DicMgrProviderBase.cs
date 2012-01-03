using System;
using System.Collections.Generic;
using System.Text;

namespace Lenovo.CFI.DicMgr
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    abstract public class DicMgrProviderBase<T> where T : AbstractDictionaryEntry
    {
        /// <summary>
        /// 构造函数。
        /// </summary>
        internal DicMgrProviderBase()
        {
        }

        /// <summary>
        /// 加载数据字典项。
        /// </summary>
        /// <remarks>
        /// 必须保证调用前对象被锁定。
        /// 要求按照以下方式实现：先获取数据->处理->重新赋值</remarks>
        abstract protected void Load();

        /// <summary>
        /// 得到所有的数据字典项数据。
        /// </summary>
        /// <returns>如果没有项，返回空列表。</returns>
        abstract protected List<T> LoadData();

        /// <summary>
        /// 重新加载数据。
        /// </summary>
        /// <remarks>必须保证调用前对象被锁定。</remarks>
        public void ReLoad()
        {
            this.Load();        // Load()保证对象被锁定。
        }


        #region 数据存储

        /// <summary>
        /// 锁定辅助对象
        /// </summary>
        protected object o_lock = new object();                             // 锁定辅助对象

        /// <summary>
        /// 存储所有的数据字典项
        /// </summary>
        protected Dictionary<string, T> allData;                            // 存储所有的数据字典项。
        /// <summary>
        /// 储所有的可见的数据字典项，排序。
        /// </summary>
        protected List<T> sortDataVisible;                                  // 存储所有的可见的数据字典项，排序。
        /// <summary>
        /// 存储所有的数据字典项，排序。
        /// </summary>
        protected List<T> sortDataAll;                                      // 存储所有的数据字典项，排序。

        // 使用allData存储所有的数据字典项，包括Visible属性为false的项。Code作为键。
        // 使用sortDataVisible存储所有的可见的数据字典项，保证已排序。
        // 使用sortDataAll存储所有的的数据字典项，保证已排序。
        // allData和visibleData均引用相同的数据字典项对象。

        #endregion


        #region 访问方法

        /// <summary>
        /// 索引器。根据数据字典项的Code获取对应的Title。
        /// </summary>
        /// <param name="code">字典项的Code。</param>
        /// <returns>当Code对应的字典项不存在时，返回null。</returns>
        /// <remarks></remarks>
        public virtual string this[string code]
        {
            get
            {
                return this.GetTitle(code);
            }
        }

        /// <summary>
        /// 根据数据字典项的Code获取对应的Title。
        /// </summary>
        /// <param name="code"></param>
        /// <returns>当Code对应的字典项不存在时，返回null。</returns>
        public virtual string GetTitle(string code)
        {
            if (this.allData.ContainsKey(code))
                return this.allData[code].Title;
            else
                return null;
        }

        /// <summary>
        /// 根据数据字典项的Code获取对应的字典项对象。
        /// </summary>
        /// <param name="code">当Code对应的字典项不存在时，返回null。</param>
        /// <returns></returns>
        public virtual T GetEntry(string code)
        {
            if (this.allData.ContainsKey(code))
                return this.allData[code];
            else
                return null;
        }

        /// <summary>
        /// 获取数据字典项列表。
        /// </summary>
        /// <param name="all">是否得到全部。否则仅返回可见的数据字典项。</param>
        /// <returns>如果是按层次编码的数据字典，则返回第一级(层)数据字典项；
        /// 否则，返回所有的数据字典项。</returns>
        abstract public IList<T> GetList(bool all);
        
        /// <summary>
        /// 获取数据字典项列表。
        /// </summary>
        /// <param name="pCode">父数据字典项的Code。</param>
        /// <param name="all">是否得到全部。否则仅返回可见的数据字典项。</param>
        /// <returns>如果是按层次编码的数据字典，则返回指定父项的所有直接子数据字典项
        /// （如果父项不存在，返回空列表;）；
        /// 否则，返回所有的数据字典项。</returns>
        abstract public IList<T> GetList(string pCode, bool all);

        /// <summary>
        /// 确定编码是否已存在。 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public virtual bool Exists(string code)
        {
            return this.allData.ContainsKey(code);
        }

        #endregion


        #region 维护方法

        /// <summary>
        /// 添加一个数据字典项。
        /// </summary>
        /// <param name="entry"></param>
        abstract public void Add(T entry);

        /// <summary>
        /// 更新一个数据字典项。
        /// </summary>
        /// <param name="entry"></param>
        /// <remarks>根据数据字典项对象进行判断，而非Code。</remarks>
        abstract public void Update(T entry);

        /// <summary>
        /// 删除一个数据字典项。
        /// </summary>
        /// <param name="entry"></param>
        /// <remarks>根据数据字典项对象进行判断，而非Code。</remarks>
        abstract public void Delete(T entry);



        /// <summary>
        /// 进行添加的持久化操作
        /// </summary>
        /// <param name="entry"></param>
        abstract protected void AddPrivate(T entry);

        /// <summary>
        /// 进行更新的持久化操作
        /// </summary>
        /// <param name="entry"></param>
        abstract protected void UpdatePrivate(T entry);

        /// <summary>
        /// 进行删除的持久化操作
        /// </summary>
        /// <param name="entry"></param>
        abstract protected void DeletePrivate(T entry);


        #endregion


        #region CreateEntry

        abstract public T CreateEntry();

        #endregion
    }
}
