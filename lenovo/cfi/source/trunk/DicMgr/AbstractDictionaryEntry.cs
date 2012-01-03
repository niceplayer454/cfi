using System;
using System.Collections.Generic;
using System.Text;

namespace Lenovo.CFI.DicMgr
{
    /// <summary>
    /// 
    /// </summary>
    abstract public class AbstractDictionaryEntry : IComparable
    {
        #region .ctor 

        /// <summary>
        /// </summary>
        internal AbstractDictionaryEntry() 
        {
        }

        // 对子类的构造函数的要求：
        // 因为设计 支持非立即、可撤销更新
        // 故需要子类具有一个用于初始化的构造函数。

        // 设计不能直接构造对象，只能通过DicMgrProviderBase<T>.CreateEntry()。
        // 故构造函数只能是internal的。
        // 设计成这样，无法加载数据。故public，但因需要Coding参数，故也无法随意创建。

        #endregion

        #region fields

        /// <summary>
        /// 是否可见
        /// </summary>
        protected bool visible;

        #endregion

        #region properity

        /// <summary>
        /// 获取字典项的键。
        /// </summary>
        abstract public string Code { get; set;}

        /// <summary>
        /// 获取字典项的名称。
        /// </summary>
        abstract public string Title { get;  set;}

        /// <summary>
        /// 获取或设置字典项是否可见。
        /// </summary>
        public virtual bool Visible
        {
            get { return this.visible; }
            set {}
        }


        #endregion
    
        #region IComparable Members

        /// <summary>
        /// 比较当前对象和同一类型的另一对象。用于排序。
        /// </summary>
        /// <param name="obj">与此对象进行比较的对象。</param>
        /// <returns>一个 32 位有符号整数，指示要比较的对象的相对顺序。</returns>
        /// <remarks>也可以添加一个范型实现。</remarks>
        abstract public int CompareTo(object obj);

        #endregion

        #region 支持非立即、可撤销更新

        /// <summary>
        /// 是否有更新
        /// </summary>
        abstract public bool HasChange { get;}

        /// <summary>
        /// 更新类型
        /// </summary>
        abstract public DictionaryEntryChange Change { get;}

        /// <summary>
        /// 接受更新
        /// </summary>
        /// <returns>数据字典项发生了何种变化。</returns>
        /// <remarks>接受对数据字典项所作的修改，并使更新可见。
        /// 为DicMgrProviderBase.Update(T entry)服务，故设计为internal。
        /// 如果数据字典项没有实际变化，则不会进行实质性操作。</remarks>
        internal DictionaryEntryChange Accept()
        {
            if (this.HasChange)
                return this.AcceptPrivate();
            else
                return DictionaryEntryChange.None;
        }

        /// <summary>
        /// 接受更新--需要子类实现
        /// </summary>
        /// <returns>数据字典项发生了何种变化。</returns>
        /// <remarks>接受对数据字典项所作的修改，并使更新可见。
        /// 如果数据字典项没有实际变化，则不会进行实质性操作并返回DictionaryEntryChange.None。</remarks>
        abstract protected DictionaryEntryChange AcceptPrivate();

        /// <summary>
        /// 拒绝更新
        /// </summary>
        /// <remarks>撤销对数据字典项所作的修改。为DicMgrProviderBase.Update(T entry)服务，故设计为internal。</remarks>
        internal void Reject()
        {
            this.RejectPrivate();
        }

        /// <summary>
        /// 拒绝更新--需要子类实现
        /// </summary>
        /// <remarks>撤销对数据字典项所作的修改。</remarks>
        abstract protected void RejectPrivate();

        #endregion

        #region 帮助方法


        /// <summary>
        /// 获取指定编码的父编码
        /// </summary>
        /// <returns></returns>
        public abstract string GetParentCode();

        #endregion
    }

    /// <summary>
    /// 定义数据字典项更新时发生了哪些变化
    /// </summary>
    [Flags()]
    public enum DictionaryEntryChange
    {
        /// <summary>
        /// 无变化
        /// </summary>
        None = 0,
        /// <summary>
        /// 编码被修改
        /// </summary>
        Code = 1,
        /// <summary>
        /// 可见性发生编码
        /// </summary>
        Visible = 2,
        /// <summary>
        /// 排序属性发生变化
        /// </summary>
        Sort = 4,
        /// <summary>
        /// 其它属性变化
        /// </summary>
        Other = 8
    }
}
