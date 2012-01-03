using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lenovo.CFI.Common.Dic
{
    public class QiRootCause3 : DataDictionaryEntry
    {
        public static readonly string DD_SOFTWAREISSUES = "SOFTWAREISSUES";


        #region .ctor

        /// <summary>
        /// </summary>
        public QiRootCause3()
            : base()
        { }

        public QiRootCause3(string code, string rootCause2, string title, int sort, bool visible, string updator, DateTime updateTime)
            : base(code, rootCause2, title, sort, visible, updator, updateTime)
        {}

        #endregion

        #region fields

        #endregion

        #region properity

        public string RootCause2
        {
            get { return this.PCode; }
            set { this.PCode = value; }
        }


        #endregion
    }
}
