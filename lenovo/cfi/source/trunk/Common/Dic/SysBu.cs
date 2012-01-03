using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lenovo.CFI.DicMgr;

namespace Lenovo.CFI.Common.Dic
{
    public class SysBu : DataDictionaryEntry
    {
        #region .ctor

        /// <summary>
        /// </summary>
        public SysBu()
            : base()
        { }

        public SysBu(string code, string title, int sort, bool visible, string updator, DateTime updateTime,
            string qrPrefix, string lePrefix)
            : base(code, title, sort, visible, updator, updateTime)
        {
            this.qrPrefix = qrPrefix;
            this.qrPrefixT = qrPrefix;

            this.lePrefix = lePrefix;
            this.lePrefixT = lePrefix;

        }

        #endregion

        #region fields

        private string qrPrefix;
        private string lePrefix;

        private string qrPrefixT;
        private string lePrefixT;

        #endregion

        #region properity

        public string QrPrefix
        {
            get { return this.qrPrefix; }
            set
            {
                if (this.qrPrefix != value)
                {
                    this.editding = true;
                    this.qrPrefixT = value;
                }
            }
        }

        public string LePrefix
        {
            get { return this.lePrefix; }
            set
            {
                if (this.lePrefix != value)
                {
                    this.editding = true;
                    this.lePrefixT = value;
                }
            }
        }


        public string QrPrefixT
        {
            get { return qrPrefixT; }
        }
        
        public string LePrefixT
        {
            get { return lePrefixT; }
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
            if (obj is SysBu)
            {
                SysBu temp = (SysBu)obj;

                int s = this.Sort.CompareTo(temp.Sort);

                if (s == 0) return this.Code.CompareTo(temp.Code);
                else return s;
            }

            throw new ArgumentException("object is not a SysBu");
        }

        /// <summary>
        /// 比较当前对象和同一类型的另一对象。用于排序。
        /// </summary>
        /// <param name="other">与此对象进行比较的对象。</param>
        /// <returns>一个 32 位有符号整数，指示要比较的对象的相对顺序。</returns>
        public int CompareTo(SysBu other)
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
                this.qrPrefix = this.qrPrefixT;
                this.lePrefix = this.lePrefixT;

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

            this.qrPrefixT = this.qrPrefix;
            this.lePrefixT = this.lePrefix;
        }

        #endregion
    }
}
