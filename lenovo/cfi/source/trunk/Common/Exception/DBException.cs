using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Lenovo.CFI.Common
{
        /// <summary>
        /// 数据库异常。
        /// </summary>
        [Serializable]
        public class DBException : ApplicationException
        {
            public DBException()
                : base("数据库异常！")
            { }
            public DBException(string message)
                : base(message)
            { }
            public DBException(string message, Exception innerException)
                : base(message, innerException)
            { }
            protected DBException(SerializationInfo info, StreamingContext context)
                : base(info, context) { }
        }

        /// <summary>
        /// 可可解释或预见的数据库异常。
        /// 应当由应用程序捕获，并处理。
        /// </summary>
        [Serializable]
        public class DBExplainableException : DBException
        {
            public DBExplainableException()
                : base("可解释或预见的数据库异常！")
            { }
            public DBExplainableException(string message)
                : base(message)
            { }
            public DBExplainableException(string message, Exception innerException)
                : base(message, innerException)
            { }
            protected DBExplainableException(SerializationInfo info, StreamingContext context)
                : base(info, context) { }
        }



        /// <summary>
        /// 违反约束的数据库异常。
        /// 插入或更新时，引用的数据不存在；
        /// 删除时，要删除的数据被引用。
        /// </summary>
        [Serializable]
        public class ViolateReferenceException : DBExplainableException
        {
            public ViolateReferenceException()
                : base("违反约束数据库异常！") { }
            public ViolateReferenceException(string message)
                : base(message) { }
            public ViolateReferenceException(string message, Exception innerException)
                : base(message, innerException) { }
            protected ViolateReferenceException(SerializationInfo info, StreamingContext context)
                : base(info, context) { }
        }

        /// <summary>
        /// 违反约束的数据库异常。-- 删除时，要删除的数据被引用。
        /// </summary>
        [Serializable]
        public class DeletingDataUsedException : ViolateReferenceException
        {
            public DeletingDataUsedException()
                : base("删除的数据被引用！") { }
            public DeletingDataUsedException(string message)
                : base(message) { }
            public DeletingDataUsedException(string message, Exception innerException)
                : base(message, innerException) { }
            protected DeletingDataUsedException(SerializationInfo info, StreamingContext context)
                : base(info, context) { }
        }

        /// <summary>
        /// 违反约束的数据库异常。-- 插入或更新时，引用的数据不存在。
        /// </summary>
        [Serializable]
        public class ReferDataNotExistException : ViolateReferenceException
        {
            public ReferDataNotExistException()
                : base("引用的数据不存在！") { }
            public ReferDataNotExistException(string message)
                : base(message) { }
            public ReferDataNotExistException(string message, Exception innerException)
                : base(message, innerException) { }
            protected ReferDataNotExistException(SerializationInfo info, StreamingContext context)
                : base(info, context) { }
        }


        /// <summary>
        /// NULL值插入非空列数据库异常。
        /// </summary>
        [Serializable]
        public class DBNotNullException : DBExplainableException
        {
            public DBNotNullException()
                : base("无法将NULL值插入非空列！") { }
            public DBNotNullException(string message)
                : base(message) { }
            public DBNotNullException(string message, Exception innerException)
                : base(message, innerException) { }
            protected DBNotNullException(SerializationInfo info, StreamingContext context)
                : base(info, context) { }
        }

        /// <summary>
        /// 数据过期异常。-- 比较时间戳。
        /// </summary>
        [Serializable]
        public class StampOverdueException : DBExplainableException
        {
            public StampOverdueException()
                : base("数据过期！") { }
            public StampOverdueException(string message)
                : base(message) { }
            public StampOverdueException(string message, Exception innerException)
                : base(message, innerException) { }
            protected StampOverdueException(SerializationInfo info, StreamingContext context)
                : base(info, context) { }
        }
}
