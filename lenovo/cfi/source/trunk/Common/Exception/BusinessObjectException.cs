using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Lenovo.CFI.Common
{
    /// <summary>
    /// 业务对象无效异常。
    /// </summary>
    [Serializable]
    public class BusinessObjectException : ApplicationException
    {
        public BusinessObjectException()
            : base("业务对象数据无效！") { }
        public BusinessObjectException(string message)
            : base(message) { }
        public BusinessObjectException(string message, Exception innerException)
            : base(message, innerException) { }
        protected BusinessObjectException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }

    /// <summary>
    /// 业务对象数据逻辑异常。
    /// </summary>
    [Serializable]
    public class BusinessObjectLogicException : BusinessObjectException
    {
        public BusinessObjectLogicException()
            : base("业务对象数据逻辑错误！") { }
        public BusinessObjectLogicException(string message)
            : base(message) { }
        public BusinessObjectLogicException(string message, Exception innerException)
            : base(message, innerException) { }
        protected BusinessObjectLogicException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }

    /// <summary>
    /// 业务对象数据不存在异常
    /// </summary>
    [Serializable]
    public class BusinessObjectExistException : BusinessObjectException
    {
        public BusinessObjectExistException()
            : base("业务对象数据不存在！") { }
        public BusinessObjectExistException(string message)
            : base(message) { }
        public BusinessObjectExistException(string message, Exception innerException)
            : base(message, innerException) { }
        protected BusinessObjectExistException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}
