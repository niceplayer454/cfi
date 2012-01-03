using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lenovo.CFI.Common
{
    [Serializable]
    public class TolerableException : ApplicationException
    {
        public TolerableException()
            : base("可容忍的异常！")
        { }
        public TolerableException(string message)
            : base(message)
        { }

        public TolerableException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
