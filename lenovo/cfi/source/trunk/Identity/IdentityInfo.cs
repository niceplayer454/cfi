using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lenovo.CFI.Identity
{
    [Serializable]
    public class IdentityInfo : ICloneable
    {
        public IdentityInfo(Guid userKey, string userName)
        {
            this.userKey = userKey;
            this.userName = userName;
        }

        public virtual Guid UserKey { get { return this.userKey; } }
        public virtual string UserName { get { return this.userName; } }

        private Guid userKey;
        private string userName;

        public object Clone()
        {
            return new IdentityInfo(this.userKey, this.userName);
        }
    }
}
