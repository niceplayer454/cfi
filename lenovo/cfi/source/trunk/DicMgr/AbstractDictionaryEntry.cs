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

        // ������Ĺ��캯����Ҫ��
        // ��Ϊ��� ֧�ַ��������ɳ�������
        // ����Ҫ�������һ�����ڳ�ʼ���Ĺ��캯����

        // ��Ʋ���ֱ�ӹ������ֻ��ͨ��DicMgrProviderBase<T>.CreateEntry()��
        // �ʹ��캯��ֻ����internal�ġ�
        // ��Ƴ��������޷��������ݡ���public��������ҪCoding��������Ҳ�޷����ⴴ����

        #endregion

        #region fields

        /// <summary>
        /// �Ƿ�ɼ�
        /// </summary>
        protected bool visible;

        #endregion

        #region properity

        /// <summary>
        /// ��ȡ�ֵ���ļ���
        /// </summary>
        abstract public string Code { get; set;}

        /// <summary>
        /// ��ȡ�ֵ�������ơ�
        /// </summary>
        abstract public string Title { get;  set;}

        /// <summary>
        /// ��ȡ�������ֵ����Ƿ�ɼ���
        /// </summary>
        public virtual bool Visible
        {
            get { return this.visible; }
            set {}
        }


        #endregion
    
        #region IComparable Members

        /// <summary>
        /// �Ƚϵ�ǰ�����ͬһ���͵���һ������������
        /// </summary>
        /// <param name="obj">��˶�����бȽϵĶ���</param>
        /// <returns>һ�� 32 λ�з���������ָʾҪ�ȽϵĶ�������˳��</returns>
        /// <remarks>Ҳ�������һ������ʵ�֡�</remarks>
        abstract public int CompareTo(object obj);

        #endregion

        #region ֧�ַ��������ɳ�������

        /// <summary>
        /// �Ƿ��и���
        /// </summary>
        abstract public bool HasChange { get;}

        /// <summary>
        /// ��������
        /// </summary>
        abstract public DictionaryEntryChange Change { get;}

        /// <summary>
        /// ���ܸ���
        /// </summary>
        /// <returns>�����ֵ�����˺��ֱ仯��</returns>
        /// <remarks>���ܶ������ֵ����������޸ģ���ʹ���¿ɼ���
        /// ΪDicMgrProviderBase.Update(T entry)���񣬹����Ϊinternal��
        /// ��������ֵ���û��ʵ�ʱ仯���򲻻����ʵ���Բ�����</remarks>
        internal DictionaryEntryChange Accept()
        {
            if (this.HasChange)
                return this.AcceptPrivate();
            else
                return DictionaryEntryChange.None;
        }

        /// <summary>
        /// ���ܸ���--��Ҫ����ʵ��
        /// </summary>
        /// <returns>�����ֵ�����˺��ֱ仯��</returns>
        /// <remarks>���ܶ������ֵ����������޸ģ���ʹ���¿ɼ���
        /// ��������ֵ���û��ʵ�ʱ仯���򲻻����ʵ���Բ���������DictionaryEntryChange.None��</remarks>
        abstract protected DictionaryEntryChange AcceptPrivate();

        /// <summary>
        /// �ܾ�����
        /// </summary>
        /// <remarks>�����������ֵ����������޸ġ�ΪDicMgrProviderBase.Update(T entry)���񣬹����Ϊinternal��</remarks>
        internal void Reject()
        {
            this.RejectPrivate();
        }

        /// <summary>
        /// �ܾ�����--��Ҫ����ʵ��
        /// </summary>
        /// <remarks>�����������ֵ����������޸ġ�</remarks>
        abstract protected void RejectPrivate();

        #endregion

        #region ��������


        /// <summary>
        /// ��ȡָ������ĸ�����
        /// </summary>
        /// <returns></returns>
        public abstract string GetParentCode();

        #endregion
    }

    /// <summary>
    /// ���������ֵ������ʱ��������Щ�仯
    /// </summary>
    [Flags()]
    public enum DictionaryEntryChange
    {
        /// <summary>
        /// �ޱ仯
        /// </summary>
        None = 0,
        /// <summary>
        /// ���뱻�޸�
        /// </summary>
        Code = 1,
        /// <summary>
        /// �ɼ��Է�������
        /// </summary>
        Visible = 2,
        /// <summary>
        /// �������Է����仯
        /// </summary>
        Sort = 4,
        /// <summary>
        /// �������Ա仯
        /// </summary>
        Other = 8
    }
}
