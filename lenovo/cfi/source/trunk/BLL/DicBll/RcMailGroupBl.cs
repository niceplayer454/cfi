using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Lenovo.CFI.Common.Dic;
using Lenovo.CFI.DAL.Dic;

namespace Lenovo.CFI.BLL.DicBll
{
    public class RcMailGroupBl
    {
        internal RcMailGroupBl()
        {
        }

        public List<RcMailGroup> GetAll()
        {
            return RcMailGroupDa.GetAll();
        }


        public void Add(RcMailGroup entry)
        {
            RcMailGroupDa.Insert(entry);
        }
        public void Edit(RcMailGroup entry)
        {
            RcMailGroupDa.Update(entry);
        }
        public void Remove(RcMailGroup entry)
        {
            RcMailGroupDa.Delete(entry);
        }
    }
}
