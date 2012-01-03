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
        /// ���캯����
        /// </summary>
        internal DicMgrProviderBase()
        {
        }

        /// <summary>
        /// ���������ֵ��
        /// </summary>
        /// <remarks>
        /// ���뱣֤����ǰ����������
        /// Ҫ�������·�ʽʵ�֣��Ȼ�ȡ����->����->���¸�ֵ</remarks>
        abstract protected void Load();

        /// <summary>
        /// �õ����е������ֵ������ݡ�
        /// </summary>
        /// <returns>���û������ؿ��б�</returns>
        abstract protected List<T> LoadData();

        /// <summary>
        /// ���¼������ݡ�
        /// </summary>
        /// <remarks>���뱣֤����ǰ����������</remarks>
        public void ReLoad()
        {
            this.Load();        // Load()��֤����������
        }


        #region ���ݴ洢

        /// <summary>
        /// ������������
        /// </summary>
        protected object o_lock = new object();                             // ������������

        /// <summary>
        /// �洢���е������ֵ���
        /// </summary>
        protected Dictionary<string, T> allData;                            // �洢���е������ֵ��
        /// <summary>
        /// �����еĿɼ��������ֵ������
        /// </summary>
        protected List<T> sortDataVisible;                                  // �洢���еĿɼ��������ֵ������
        /// <summary>
        /// �洢���е������ֵ������
        /// </summary>
        protected List<T> sortDataAll;                                      // �洢���е������ֵ������

        // ʹ��allData�洢���е������ֵ������Visible����Ϊfalse���Code��Ϊ����
        // ʹ��sortDataVisible�洢���еĿɼ��������ֵ����֤������
        // ʹ��sortDataAll�洢���еĵ������ֵ����֤������
        // allData��visibleData��������ͬ�������ֵ������

        #endregion


        #region ���ʷ���

        /// <summary>
        /// �����������������ֵ����Code��ȡ��Ӧ��Title��
        /// </summary>
        /// <param name="code">�ֵ����Code��</param>
        /// <returns>��Code��Ӧ���ֵ������ʱ������null��</returns>
        /// <remarks></remarks>
        public virtual string this[string code]
        {
            get
            {
                return this.GetTitle(code);
            }
        }

        /// <summary>
        /// ���������ֵ����Code��ȡ��Ӧ��Title��
        /// </summary>
        /// <param name="code"></param>
        /// <returns>��Code��Ӧ���ֵ������ʱ������null��</returns>
        public virtual string GetTitle(string code)
        {
            if (this.allData.ContainsKey(code))
                return this.allData[code].Title;
            else
                return null;
        }

        /// <summary>
        /// ���������ֵ����Code��ȡ��Ӧ���ֵ������
        /// </summary>
        /// <param name="code">��Code��Ӧ���ֵ������ʱ������null��</param>
        /// <returns></returns>
        public virtual T GetEntry(string code)
        {
            if (this.allData.ContainsKey(code))
                return this.allData[code];
            else
                return null;
        }

        /// <summary>
        /// ��ȡ�����ֵ����б�
        /// </summary>
        /// <param name="all">�Ƿ�õ�ȫ������������ؿɼ��������ֵ��</param>
        /// <returns>����ǰ���α���������ֵ䣬�򷵻ص�һ��(��)�����ֵ��
        /// ���򣬷������е������ֵ��</returns>
        abstract public IList<T> GetList(bool all);
        
        /// <summary>
        /// ��ȡ�����ֵ����б�
        /// </summary>
        /// <param name="pCode">�������ֵ����Code��</param>
        /// <param name="all">�Ƿ�õ�ȫ������������ؿɼ��������ֵ��</param>
        /// <returns>����ǰ���α���������ֵ䣬�򷵻�ָ�����������ֱ���������ֵ���
        /// �����������ڣ����ؿ��б�;����
        /// ���򣬷������е������ֵ��</returns>
        abstract public IList<T> GetList(string pCode, bool all);

        /// <summary>
        /// ȷ�������Ƿ��Ѵ��ڡ� 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public virtual bool Exists(string code)
        {
            return this.allData.ContainsKey(code);
        }

        #endregion


        #region ά������

        /// <summary>
        /// ���һ�������ֵ��
        /// </summary>
        /// <param name="entry"></param>
        abstract public void Add(T entry);

        /// <summary>
        /// ����һ�������ֵ��
        /// </summary>
        /// <param name="entry"></param>
        /// <remarks>���������ֵ����������жϣ�����Code��</remarks>
        abstract public void Update(T entry);

        /// <summary>
        /// ɾ��һ�������ֵ��
        /// </summary>
        /// <param name="entry"></param>
        /// <remarks>���������ֵ����������жϣ�����Code��</remarks>
        abstract public void Delete(T entry);



        /// <summary>
        /// ������ӵĳ־û�����
        /// </summary>
        /// <param name="entry"></param>
        abstract protected void AddPrivate(T entry);

        /// <summary>
        /// ���и��µĳ־û�����
        /// </summary>
        /// <param name="entry"></param>
        abstract protected void UpdatePrivate(T entry);

        /// <summary>
        /// ����ɾ���ĳ־û�����
        /// </summary>
        /// <param name="entry"></param>
        abstract protected void DeletePrivate(T entry);


        #endregion


        #region CreateEntry

        abstract public T CreateEntry();

        #endregion
    }
}
