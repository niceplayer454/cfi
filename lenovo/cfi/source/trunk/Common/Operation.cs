using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lenovo.CFI.Common
{
    public class OperationInfo
    {
        protected OperationInfo(string user)
        {
            this.user = user;
        }

        public OperationInfo(string user, DateTime time)
        {
            this.user = user;
            this.time = time;
        }

        protected string user;
        protected DateTime? time;

        public string User
        {
            get { return user; }
            set { user = value; }
        }

        public DateTime Time
        {
            get { return time.Value; }
            set { time = value; }
        }

        public override string ToString()
        {
            return this.user + this.time.Value.ToString("yyyy-MM-dd HH:mm");
        }

        public string ToString(string format)
        {
            return this.user + this.time.Value.ToString(format);
        }
    }
}
