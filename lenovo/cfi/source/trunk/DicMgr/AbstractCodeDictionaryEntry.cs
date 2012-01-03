using System;
using System.Collections.Generic;
using System.Text;

namespace Lenovo.CFI.DicMgr
{
    /// <summary>
    /// ���뷽ʽΪ�ַ�����������ֵ���ֵ��
    /// </summary>
    /// <remarks>ʵ�ʲ����Ʊ��뷽ʽ����Ϊָ������������У�Ӧ�ó�������ݿ⣩������</remarks>
    abstract public class AbstractCodeDictionaryEntry : AbstractDictionaryEntry
    {
        /// <summary>
        /// 
        /// </summary>
        protected AbstractCodeDictionaryEntry() : base() { }

        #region properity


        /// <summary>
        /// ��ȡ�ֵ���ĸ�����
        /// </summary>
        abstract public string PCode { get; set; }


        #endregion


        #region ��������

        /// <summary>
        /// ��ȡָ������ĸ�����
        /// </summary>
        /// <returns></returns>
        public override string GetParentCode()
        {
            return this.PCode;
        }


        #endregion
    }
}
