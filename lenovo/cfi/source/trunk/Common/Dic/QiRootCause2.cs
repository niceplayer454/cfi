using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lenovo.CFI.Common.Dic
{
    public class QiRootCause2 : DataDictionaryEntry
    {
        public static readonly string DD_DEV = "DEV";


        #region .ctor

        /// <summary>
        /// </summary>
        public QiRootCause2()
            : base()
        { }

        public QiRootCause2(string code, string rootCause1, string title, int sort, bool visible, string updator, DateTime updateTime)
            : base(code, rootCause1, title, sort, visible, updator, updateTime)
        {}

        #endregion

        #region fields

        #endregion

        #region properity

        public string RootCause1
        {
            get { return this.PCode; }
            set { this.PCode = value; }
        }


        #endregion
    }
}
