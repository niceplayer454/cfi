using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lenovo.CFI.DicMgr;

namespace Lenovo.CFI.Common.Dic
{
    public class QiAttachCategory : DataDictionaryEntry
    {
        #region .ctor

        /// <summary>
        /// </summary>
        public QiAttachCategory()
            : base()
        { }

        public QiAttachCategory(string code, string title, int sort, bool visible, string updator, DateTime updateTime,
            bool reportAttach)
            : base(code, title, sort, visible, updator, updateTime)
        {
            this.reportAttach = reportAttach;

            this.reportAttachT = reportAttach;
        }

        #endregion

        #region fields

        private bool reportAttach;

        private bool reportAttachT;

        #endregion

        #region properity

        public bool ReportAttach
        {
            get { return this.reportAttach; }
            set
            {
                if (this.reportAttach != value)
                {
                    this.editding = true;
                    this.reportAttachT = value;
                }
            }
        }

        public bool ReportAttachT
        {
            get { return reportAttachT; }
        }

        #endregion

        #region IComparable Members

        /// <summary>
        /// 比较当前对象和同一类型的另一对象。用于排序。
        /// </summary>
        /// <param name="obj">与此对象进行比较的对象。</param>
        /// <returns>一个 32 位有符号整数，指示要比较的对象的相对顺序。</returns>
        /// <remarks>也可以添加一个范型实现。</remarks>
        public override int CompareTo(object obj)
        {
            if (obj is QiAttachCategory)
            {
                QiAttachCategory temp = (QiAttachCategory)obj;

                int s = this.Sort.CompareTo(temp.Sort);

                if (s == 0) return this.Code.CompareTo(temp.Code);
                else return s;
            }

            throw new ArgumentException("object is not a WarranyEntry");
        }

        /// <summary>
        /// 比较当前对象和同一类型的另一对象。用于排序。
        /// </summary>
        /// <param name="other">与此对象进行比较的对象。</param>
        /// <returns>一个 32 位有符号整数，指示要比较的对象的相对顺序。</returns>
        public int CompareTo(QiAttachCategory other)
        {
            int s = this.Sort.CompareTo(other.Sort);

            if (s == 0) return this.Code.CompareTo(other.Code);
            else return s;
        }

        #endregion

        #region 支持非立即、可撤销更新

        /// <summary>
        /// 是否有更新
        /// </summary>
        public override bool HasChange
        {
            get
            {
                return (this.editding);
            }
        }

        /// <summary>
        /// 更新类型
        /// </summary>
        public override DictionaryEntryChange Change
        {
            get
            {
                return base.Change;
            }
        }

        /// <summary>
        /// 接受更新
        /// </summary>
        /// <returns>数据字典项发生了何种变化。</returns>
        /// <remarks>接受对数据字典项所作的修改，并使更新可见。
        /// 如果数据字典项没有实际变化，则不会进行实质性操作并返回DictionaryEntryChange.None。</remarks>
        protected override DictionaryEntryChange AcceptPrivate()
        {
            if (this.editding)
            {
                // 更新值
                this.reportAttach = this.reportAttachT;

                return base.AcceptPrivate();
            }
            else
                return DictionaryEntryChange.None;
        }

        /// <summary>
        /// 拒绝更新--需要子类实现
        /// </summary>
        /// <remarks>撤销对数据字典项所作的修改</remarks>
        protected override void RejectPrivate()
        {
            base.RejectPrivate();

            this.reportAttachT = this.reportAttach;
        }

        #endregion

    }
}
