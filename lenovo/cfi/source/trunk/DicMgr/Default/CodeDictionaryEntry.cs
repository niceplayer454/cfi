using System;
using System.Collections.Generic;
using System.Text;

namespace Lenovo.CFI.DicMgr.Default
{
    /// <summary>
    /// 数据项。默认实现。
    /// </summary>
    public class CodeDictionaryEntry : AbstractCodeDictionaryEntry, IComparable<CodeDictionaryEntry>
    {
        #region .ctor

        /// <summary>
        /// </summary>
        internal protected CodeDictionaryEntry() : base()
        { }

        public CodeDictionaryEntry(string code, string pCode, string title, int value, int sort, bool visible, string note, string updator, DateTime updateTime)
            : base()
        {
            this.code = code;
            this.pCode = pCode;
            this.title = title;
            this._value = value;
            this.sort = sort;
            this.visible = visible;
            this.note = note;
            this.updator = updator;
            this.updateTime = updateTime;

            this.editding = false;
            this.codeT = this.code;
            this.pCodeT = this.pCode;
            this.titleT = this.title;
            this.valueT = this._value;
            this.sortT = this.sort;
            this.visibleT = this.visible;
            this.noteT = note;
            this.updatorT = updator;
            this.updateTimeT = updateTime;

        }

        public CodeDictionaryEntry(string code, string pCode, string title, int sort, bool visible, string updator, DateTime updateTime)
            : this(code, pCode, title, 0, sort,  visible, null, updator, updateTime)
        {
        }

        public CodeDictionaryEntry(string code, string title, int sort, bool visible, string updator, DateTime updateTime)
            : this(code, null, title, 0, sort, visible, null, updator, updateTime)
        {
        }

        #endregion

        #region fields

        private string code;
        private string pCode;
        private string title;
        private int _value;
        private int sort;
        private string note;
        private string updator;
        private DateTime updateTime;

        protected bool editding;
        private string codeT;
        private string pCodeT;
        private string titleT;
        private int valueT;
        private int sortT;
        private bool visibleT;
        private string noteT;
        private string updatorT;
        private DateTime updateTimeT;

        #endregion

        #region properity

        /// <summary>
        /// 获取或设置字典项的编码。
        /// </summary>
        public override string Code
        {
            get { return this.code; }
            set
            {
                if (this.code != value)
                {
                    this.editding = true;
                    this.codeT = value;
                }
            }
        }

        /// <summary>
        /// 获取或设置字典项的父编码。
        /// </summary>
        public override string PCode
        {
            get { return this.pCode; }
            set
            {
                if (this.pCode != value)
                {
                    this.editding = true;
                    this.pCodeT = value;
                }
            }
        }

        /// <summary>
        /// 获取或设置字典项的名称。
        /// </summary>
        public override string Title
        {
            get { return this.title; }
            set
            {
                if (this.title != value)
                {
                    this.editding = true;
                    this.titleT = value;
                }
            }
        }

        /// <summary>
        /// 获取或设置字典项的值。
        /// </summary>
        public int Value
        {
            get { return this._value; }
            set
            {
                if (this._value != value)
                {
                    this.editding = true;
                    this.valueT = value;
                }
            }
        }

        /// <summary>
        /// 获取或设置字典项的排序值。
        /// </summary>
        public virtual int Sort
        {
            get { return this.sort; }
            set
            {
                if (this.sort != value)
                {
                    this.editding = true;
                    this.sortT = value;
                }
            }
        }

        /// <summary>
        /// 获取或设置字典项是否可见。
        /// </summary>
        public override bool Visible
        {
            set
            {
                if (this.visible != value)
                {
                    this.editding = true;
                    this.visibleT = value;
                }
            }
        }

        public string Note
        {
            get { return this.note; }
            set
            {
                if (this.note != value)
                {
                    this.editding = true;
                    this.noteT = value;
                }
            }
        }

        public string Updator
        {
            get { return this.updator; }
            set
            {
                if (this.updator != value)
                {
                    this.editding = true;
                    this.updatorT = value;
                }
            }
        }

        public DateTime UpdateTime
        {
            get { return this.updateTime; }
            set
            {
                if (this.updateTime != value)
                {
                    this.editding = true;
                    this.updateTimeT = value;
                }
            }
        }




        public string CodeT
        {
            get { return codeT; }
        }

        public string PCodeT
        {
            get { return pCodeT; }
        }

        public string TitleT
        {
            get { return titleT; }
        }

        public int ValueT
        {
            get { return valueT; }
        }

        public int SortT
        {
            get { return sortT; }
        }

        public bool VisibleT
        {
            get { return visibleT; }
        }

        public string NoteT
        {
            get { return noteT; }
        }

        public string UpdatorT
        {
            get { return updatorT; }
        }

        public DateTime UpdateTimeT
        {
            get { return updateTimeT; }
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
            if (obj is CodeDictionaryEntry)
            {
                CodeDictionaryEntry temp = (CodeDictionaryEntry)obj;

                int s = this.sort.CompareTo(temp.Sort);

                if (s == 0) return this.code.CompareTo(temp.code);
                else return s;
            }

            throw new ArgumentException("object is not a CodeDictionaryEntry");
        }

        /// <summary>
        /// 比较当前对象和同一类型的另一对象。用于排序。
        /// </summary>
        /// <param name="other">与此对象进行比较的对象。</param>
        /// <returns>一个 32 位有符号整数，指示要比较的对象的相对顺序。</returns>
        public int CompareTo(CodeDictionaryEntry other)
        {
            int s = this.sort.CompareTo(other.Sort);

            if (s == 0) return this.code.CompareTo(other.code);
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
                DictionaryEntryChange change = DictionaryEntryChange.None;

                if (this.editding)
                {
                    if (this.code != this.codeT ||
                        this.pCode != this.pCodeT ||
                        this.sort != this.sortT ||
                        this.visible != this.visibleT)
                    {
                        if (this.code != this.codeT || this.pCode != this.pCodeT)
                            change |= DictionaryEntryChange.Code;
                        if (this.sort != this.sortT)
                            change |= DictionaryEntryChange.Sort;
                        if (this.visible != this.visibleT)
                            change |= DictionaryEntryChange.Visible;
                    }
                    else
                    {
                        change |= DictionaryEntryChange.Other;
                    }
                }

                return change;
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
                // 判断更新内容
                DictionaryEntryChange change = this.Change;

                // 更新值
                this.code = this.codeT;
                this.pCode = this.pCodeT;
                this.title = this.titleT;
                this._value = this.valueT;
                this.sort = this.sortT;
                this.visible = this.visibleT;
                this.note = this.noteT;

                // *T的值现在与正式的值相同了。

                this.editding = false;

                return change;
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
            this.codeT = this.code;
            this.pCodeT = this.pCode;
            this.titleT = this.title;
            this.valueT = this._value;
            this.sortT = this.sort;
            this.visibleT = this.visible;
            this.noteT = this.note;
            this.editding = false;
        }

        #endregion

    }
}
