using System;
using System.Collections.Generic;
using System.Text;

namespace Lenovo.CFI.DicMgr
{
    /// <summary>
    /// </summary>
    /// <typeparam name="T">������������ֵ�������͡�</typeparam>
    abstract public class CodeTabularDicMgrProviderBase<T> : DicMgrProviderBase<T> 
        where T : AbstractCodeDictionaryEntry
    {
        /// <summary>
        /// ���캯����
        /// </summary>
        protected CodeTabularDicMgrProviderBase()
        { }

        /// <summary>
        /// ���������ֵ��
        /// </summary>
        /// <remarks>���뱣֤����ǰ����������</remarks>
        protected override void Load()
        {
            List<T> data = this.LoadData();         // ��ȡ����

            Dictionary<string, T> allDataN = new Dictionary<string, T>();
            List<T> sortDataVisibleN = new List<T>();
            List<T> sortDataAllN = new List<T>();

            foreach (T item in data)
            {
                allDataN.Add(item.Code, item);      // �ֵ�

                sortDataAllN.Add(item);

                if (item.Visible)
                {
                    sortDataVisibleN.Add(item);
                }
            }

            // ����
            sortDataAllN.Sort();
            sortDataVisibleN.Sort();

            lock (this.o_lock)
            {
                this.allData = allDataN;
                this.sortDataVisible = sortDataVisibleN;
                this.sortDataAll = sortDataAllN;
            }
        }

        #region ���ʷ���

        /// <summary>
        /// ��ȡ�����ֵ����б�
        /// </summary>
        /// <param name="all">�Ƿ�õ�ȫ������������ؿɼ��������ֵ��</param>
        /// <returns>����ǰ���α���������ֵ䣬�򷵻ص�һ��(��)�����ֵ��
        /// ���򣬷������е������ֵ��</returns>
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
        /// ��ȡ�����ֵ����б�
        /// </summary>
        /// <param name="pCode">�������ֵ����Code��</param>
        /// <param name="all">�Ƿ�õ�ȫ������������ؿɼ��������ֵ��</param>
        /// <returns>����ǰ���α���������ֵ䣬�򷵻�ָ�����������ֱ���������ֵ���
        /// �����������ڣ����ؿ��б�;����
        /// ���򣬷������е������ֵ��</returns>
        public override IList<T> GetList(string pCode, bool all)
        {
            return new List<T>();
        }

        #endregion

        #region ά������

        /// <summary>
        /// ���һ�������ֵ��
        /// </summary>
        /// <param name="entry"></param>
        public override void Add(T entry)
        {
            try
            {
                this.AddPrivate(entry);                     // �־û� -- �������������쳣

                entry.Accept();
            }
            catch
            {
                throw;
            }

            lock (this.o_lock)                          // ���»�������
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
        /// ����һ�������ֵ��
        /// </summary>
        /// <param name="entry"></param>
        /// <remarks>���������ֵ����������жϣ�����Code��</remarks>
        public override void Update(T entry)
        {
            if (!entry.HasChange)
                return;

            try
            {
                this.UpdatePrivate(entry);                     // �־û� -- �������������쳣
            }
            catch
            {
                entry.Reject();
                throw;
            }

                                                        // �޸�ǰ����
            string oCode = entry.Code;                  // ԭCode
            bool oVisible = entry.Visible;              // ԭVisible
            DictionaryEntryChange change = entry.Accept();
            if (change == DictionaryEntryChange.None)   // ���û�и���
                return;

            bool[] needSort = new bool[] { false, false};

            lock (this.o_lock)                          // ���»�������
            {
                if ((change & DictionaryEntryChange.Code) == DictionaryEntryChange.Code)
                {
                    this.allData.Remove(oCode);
                    this.allData.Add(entry.Code, entry);        
                    // ����ٶ����Code�仯������Sort�仯����ôchangeӦ������DictionaryEntryChange.Sort��
                    // �����ﲻ������Ҫ����
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
        /// ɾ��һ�������ֵ��
        /// </summary>
        /// <param name="entry"></param>
        /// <remarks>���������ֵ����������жϣ�����Code��</remarks>
        public override void Delete(T entry)
        {
            try
            {
                this.DeletePrivate(entry);                     // �־û� -- �������������쳣
            }
            catch
            {
                throw;
            }

            lock (this.o_lock)                          // ���»�������
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
