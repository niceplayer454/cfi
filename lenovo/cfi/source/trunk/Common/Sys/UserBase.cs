using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Lenovo.CFI.Common.Sys
{
    /// <summary>
    /// 用户对象。
    /// 以便序列化。
    /// </summary>
    [Serializable]
    public class UserBase
    {
        #region ctor

        /// <summary>
        /// 构造函数
        /// </summary>
        public UserBase()
        {
            this.uid = Guid.NewGuid();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="itCode">itCode</param>
        public UserBase(string itCode)
        {
            this.itCode = itCode;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="itCode">itCode</param>
        /// <param name="uid">标识</param>
        public UserBase(string itCode, Guid uid)
        {
            this.itCode = itCode;
            this.uid = uid;
        }

        #endregion

        #region field

        /// <summary>
        /// 
        /// </summary>
        protected Guid uid;
        /// <summary>
        /// 
        /// </summary>
        protected string itCode;
        /// <summary>
        /// 
        /// </summary>
        protected string firstName;
        /// <summary>
        /// 
        /// </summary>
        protected string lastName;
        /// <summary>
        /// 
        /// </summary>
        protected string abbrName;
        /// <summary>
        /// 
        /// </summary>
        protected UserBase superior;
        /// <summary>
        /// 
        /// </summary>
        protected Organ organ;
        /// <summary>
        /// 
        /// </summary>
        protected string phone;
        /// <summary>
        /// 
        /// </summary>
        protected bool disabled;

        protected Guid? adUID;
        protected string adPath;

        #endregion

        #region properity

        /// <summary>
        /// 获取或设置标识
        /// </summary>
        public Guid UID
        {
            get
            {
                return this.uid;
            }
            set
            { }
        }

        /// <summary>
        /// 获取或设置用户名
        /// </summary>
        public string ItCode
        {
            get
            {
                return this.itCode;
            }
            set
            {
                this.itCode = value.ToLower();
            }
        }

        /// <summary>
        /// 获取或设置名
        /// </summary>
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        /// <summary>
        /// 获取或设置姓
        /// </summary>
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        /// <summary>
        /// 获取用户全名
        /// </summary>
        public string FullName
        {
            get { return this.lastName + this.firstName; }
        }

        /// <summary>
        /// 获取或设置缩略名
        /// </summary>
        public string AbbrName
        {
            get { return abbrName; }
            set { abbrName = value; }
        }

        /// <summary>
        /// 获取或设置上级
        /// </summary>
        public UserBase Superior
        {
            get { return superior; }
            set { superior = value; }
        }

        public string SuperiorFullName
        {
            get { return ((superior == null) ? null : superior.FullName); }
        }

        public string SuperiorItCode
        {
            get { return ((superior == null) ? null : superior.itCode); }
        }

        /// <summary>
        /// 获取或设置固定电话
        /// </summary>
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        /// <summary>
        /// 获取或设置是否禁用
        /// </summary>
        public bool Disabled
        {
            get { return disabled; }
            set { disabled = value; }
        }

        /// <summary>
        /// 获取或设置用户所在组织
        /// </summary>
        public Organ Organ
        {
            get { return organ; }
            set { organ = value; }
        }

        /// <summary>
        /// 获取用户Email
        /// </summary>
        public string Email
        {
            get { return String.Format("{0}@{1}", this.itCode, Utils.SysDomain()); }
        }

        /// <summary>
        /// 获取用户的显示名称和标识。
        /// </summary>
        public string DisplayID
        {
            get { return String.Format("{0}({1})", this.itCode, this.FullName); }
        }


        public Guid? AdUID
        {
            get
            {
                return this.adUID;
            }
            set
            {
                this.adUID = value;
            }
        }

        public string AdPath
        {
            get
            {
                return this.adPath;
            }
            set
            {
                this.adPath = value;
            }
        }

        #endregion
    }
}
