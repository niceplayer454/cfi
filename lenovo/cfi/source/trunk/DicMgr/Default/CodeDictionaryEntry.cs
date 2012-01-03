using System;
using System.Collections.Generic;
using System.Text;

namespace Lenovo.CFI.DicMgr.Default
{
    /// <summary>
    /// �����Ĭ��ʵ�֡�
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
        /// ��ȡ�������ֵ���ı��롣
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
        /// ��ȡ�������ֵ���ĸ����롣
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
        /// ��ȡ�������ֵ�������ơ�
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
        /// ��ȡ�������ֵ����ֵ��
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
        /// ��ȡ�������ֵ��������ֵ��
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
        /// ��ȡ�������ֵ����Ƿ�ɼ���
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
        /// �Ƚϵ�ǰ�����ͬһ���͵���һ������������
        /// </summary>
        /// <param name="obj">��˶�����бȽϵĶ���</param>
        /// <returns>һ�� 32 λ�з���������ָʾҪ�ȽϵĶ�������˳��</returns>
        /// <remarks>Ҳ�������һ������ʵ�֡�</remarks>
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
        /// �Ƚϵ�ǰ�����ͬһ���͵���һ������������
        /// </summary>
        /// <param name="other">��˶�����бȽϵĶ���</param>
        /// <returns>һ�� 32 λ�з���������ָʾҪ�ȽϵĶ�������˳��</returns>
        public int CompareTo(CodeDictionaryEntry other)
        {
            int s = this.sort.CompareTo(other.Sort);

            if (s == 0) return this.code.CompareTo(other.code);
            else return s;
        }

        #endregion

        #region ֧�ַ��������ɳ�������

        /// <summary>
        /// �Ƿ��и���
        /// </summary>
        public override bool HasChange
        {
            get
            {
                return (this.editding);
            }
        }

        /// <summary>
        /// ��������
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
        /// ���ܸ���
        /// </summary>
        /// <returns>�����ֵ�����˺��ֱ仯��</returns>
        /// <remarks>���ܶ������ֵ����������޸ģ���ʹ���¿ɼ���
        /// ��������ֵ���û��ʵ�ʱ仯���򲻻����ʵ���Բ���������DictionaryEntryChange.None��</remarks>
        protected override DictionaryEntryChange AcceptPrivate()
        {
            if (this.editding)
            {
                // �жϸ�������
                DictionaryEntryChange change = this.Change;

                // ����ֵ
                this.code = this.codeT;
                this.pCode = this.pCodeT;
                this.title = this.titleT;
                this._value = this.valueT;
                this.sort = this.sortT;
                this.visible = this.visibleT;
                this.note = this.noteT;

                // *T��ֵ��������ʽ��ֵ��ͬ�ˡ�

                this.editding = false;

                return change;
            }
            else
                return DictionaryEntryChange.None;
        }

        /// <summary>
        /// �ܾ�����--��Ҫ����ʵ��
        /// </summary>
        /// <remarks>�����������ֵ����������޸�</remarks>
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
