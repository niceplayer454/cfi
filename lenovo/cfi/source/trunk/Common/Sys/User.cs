using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lenovo.CFI.Common.Sys
{
    public class User : UserBase
    {
        #region ctor

        /// <summary>
        /// 构造函数
        /// </summary>
        public User()
            : base()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="itCode">itCode</param>
        /// <param name="uid">标识</param>
        public User(string itCode, Guid uid)
            : base(itCode, uid)
        {
        }

        #endregion

        #region field

        private string password;
        private DateTime createTime;
        private string resetpwdcode;
        private string defaultBu;
        private string department;
        private string delegateUser;


        private List<UserRole> roles;
        
        #endregion

        #region properity

        /// <summary>
        /// 获取或设置密码
        /// </summary>
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        /// <summary>
        /// 获取或设置创建时间
        /// </summary>
        public DateTime CreateTime
        {
            get { return createTime; }
            set { createTime = value; }
        }

        /// <summary>
        /// 密码重置验证码 或其它验证码
        /// </summary>
        public string ResetPwdCode
        {
            get { return resetpwdcode; }
            set { resetpwdcode = value; }
        }

        /// <summary>
        /// 默认的BU -- 作为用户最后选择的BU
        /// </summary>
        public string DefaultBu
        {
            get { return defaultBu; }
            set { defaultBu = value; }
        }

        /// <summary>
        /// Department；可能为空
        /// </summary>
        public string Department
        {
            get { return department; }
            set { department = value; }
        }

        /// <summary>
        /// 委托用户；默认为自己
        /// </summary>
        public string DelegateUser
        {
            get { return delegateUser; }
            set { delegateUser = value; }
        }


        public List<UserRole> Roles
        {
            get 
            {
                if (this.roles == null)
                    this.roles = new List<UserRole>();

                return this.roles;
            }
        }

        #endregion

    }
}
