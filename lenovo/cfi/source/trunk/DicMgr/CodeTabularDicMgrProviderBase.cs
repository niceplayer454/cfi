using System;
using System.Collections.Generic;
using System.Text;

namespace Lenovo.CFI.DicMgr
{
    /// <summary>
    /// </summary>
    /// <typeparam name="T">被管理的数据字典项的类型。</typeparam>
    abstract public class CodeTabularDicMgrProviderBase<T> : DicMgrProviderBase<T> 
        where T : AbstractCodeDictionaryEntry
    {
        /// <summary>
        /// 构造函数。
        /// </summary>
        protected CodeTabularDicMgrProviderBase()
        { }

        /// <summary>
        /// 加载数据字典项。
        /// </summary>
        /// <remarks>必须保证调用前对象被锁定。</remarks>
        protected override void Load()
        {
            List<T> data = this.LoadData();         // 获取数据

            Dictionary<string, T> allDataN = new Dictionary<string, T>();
            List<T> sortDataVisibleN = new List<T>();
            List<T> sortDataAllN = new List<T>();

            foreach (T item in data)
            {
                allDataN.Add(item.Code, item);      // 字典

                sortDataAllN.Add(item);

                if (item.Visible)
                {
                    sortDataVisibleN.Add(item);
                }
            }

            // 排序
            sortDataAllN.Sort();
            sortDataVisibleN.Sort();

            lock (this.o_lock)
            {
                this.allData = allDataN;
                this.sortDataVisible = sortDataVisibleN;
                this.sortDataAll = sortDataAllN;
            }
        }

        #region 访问方法

        /// <summary>
        /// 获取数据字典项列表。
        /// </summary>
        /// <param name="all">是否得到全部。否则仅返回可见的数据字典项。</param>
        /// <returns>如果是按层次编码的数据字典，则返回第一级(层)数据字典项；
        /// 否则，返回所有的数据字典项。</returns>
        public override IList<T> GetList(bool all)
        {
            if (all)
            {
                return this.sortDataAll;
            }
            else
            {
                return this.sortDataVisible;
            }
        }

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
            return new List<T>();
        }

        #endregion

        #region 维护方法

        /// <summary>
        /// 添加一个数据字典项。
        /// </summary>
        /// <param name="entry"></param>
        public override void Add(T entry)
        {
            try
            {
                this.AddPrivate(entry);                     // 持久化 -- 发生错误，引发异常

                entry.Accept();
            }
            catch
            {
                throw;
            }

            lock (this.o_lock)                          // 更新缓存数据
            {
                this.allData.Add(entry.Code, entry);
                if (entry.Visible)
                {
                    this.sortDataVisible.Add(entry);
                    this.sortDataVisible.Sort();
                }
                this.sortDataAll.Add(entry);
                this.sortDataAll.Sort();
            }
        }

        /// <summary>
        /// 更新一个数据字典项。
        /// </summary>
        /// <param name="entry"></param>
        /// <remarks>根据数据字典项对象进行判断，而非Code。</remarks>
        public override void Update(T entry)
        {
            if (!entry.HasChange)
                return;

            try
            {
                this.UpdatePrivate(entry);                     // 持久化 -- 发生错误，引发异常
            }
            catch
            {
                entry.Reject();
                throw;
            }

                                                        // 修改前数据
            string oCode = entry.Code;                  // 原Code
            bool oVisible = entry.Visible;              // 原Visible
            DictionaryEntryChange change = entry.Accept();
            if (change == DictionaryEntryChange.None)   // 如果没有更新
                return;

            bool[] needSort = new bool[] { false, false};

            lock (this.o_lock)                          // 更新缓存数据
            {
                if ((change & DictionaryEntryChange.Code) == DictionaryEntryChange.Code)
                {
                    this.allData.Remove(oCode);
                    this.allData.Add(entry.Code, entry);        
                    // 这里假定如果Code变化会引起Sort变化，那么change应当包括DictionaryEntryChange.Sort。
                    // 故这里不设置需要排序。
                }
                if ((change & DictionaryEntryChange.Visible) == DictionaryEntryChange.Visible)
                {
                    if (entry.Visible != oVisible)
                    {
                        if (entry.Visible)
                        {
                            this.sortDataVisible.Add(entry);
                        }
                        else
                        {
                            this.sortDataVisible.Remove(entry);
                        }
                        needSort[0] = true;
                    }
                }

                if ((change & DictionaryEntryChange.Sort) == DictionaryEntryChange.Sort)
                {
                    needSort[0] = true;
                    needSort[1] = true;
                }

                if (needSort[0])
                    this.sortDataVisible.Sort();
                if (needSort[1])
                    this.sortDataAll.Sort();
            }
        }

        /// <summary>
        /// 删除一个数据字典项。
        /// </summary>
        /// <param name="entry"></param>
        /// <remarks>根据数据字典项对象进行判断，而非Code。</remarks>
        public override void Delete(T entry)
        {
            try
            {
                this.DeletePrivate(entry);                     // 持久化 -- 发生错误，引发异常
            }
            catch
            {
                throw;
            }

            lock (this.o_lock)                          // 更新缓存数据
            {
                this.allData.Remove(entry.Code);
                if (entry.Visible)
                {
                    this.sortDataVisible.Remove(entry);
                    this.sortDataVisible.Sort();
                }
                this.sortDataAll.Remove(entry);
                this.sortDataAll.Sort();
            }
        }



        #endregion
    }
}
