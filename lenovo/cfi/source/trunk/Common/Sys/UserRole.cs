using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lenovo.CFI.Common.Sys
{
    public class UserRole
    {
        public const int ROLE_ADMIN = 0;
        public const int ROLE_BUADMIN = 1;
        public const int ROLE_READER = 2;
        //public const int ROLE_WRITER = 4;
        public const int ROLE_MANAGER = 8;

        public const int ROLE_WRITER_QR = 16;
        public const int ROLE_WRITER_RC = 32;
        public const int ROLE_WRITER_EWG = 64;
        public const int ROLE_WRITER_LL = 128;
    }
}
