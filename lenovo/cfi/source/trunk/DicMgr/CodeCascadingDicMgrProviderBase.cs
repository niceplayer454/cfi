using System;
using System.Collections.Generic;
using System.Text;

namespace Lenovo.CFI.DicMgr
{
    /// <summary>
    /// </summary>
    /// <typeparam name="T">������������ֵ�������͡�</typeparam>
    abstract public class CodeCascadingDicMgrProviderBase<T> : CodeTabularDicMgrProviderBase<T> 
        where T : AbstractCodeDictionaryEntry
    {
        /// <summary>
        /// ���캯����
        /// </summary>
        protected CodeCascadingDicMgrProviderBase()
            : base() {}

        #region ���ʷ���

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
            if (all)
            {
                return this.sortDataAll.FindAll(x => x.PCode == pCode);
            }
            else
            {
                return this.sortDataVisible.FindAll(x => x.PCode == pCode);
            }
        }


        #endregion
    }
}
