using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Lenovo.CFI.Common.Dic;
using Lenovo.CFI.DAL.Dic;

namespace Lenovo.CFI.BLL.DicBll
{
    public class QiRootCause2Bl
    {
        internal QiRootCause2Bl()
        {
        }

        public List<QiRootCause2> GetAll()
        {
            return QiRootCause2Da.GetAll();
        }


        public void Add(QiRootCause2 entry)
        {
            QiRootCause2Da.Insert(entry);
        }
        public void Edit(QiRootCause2 entry)
        {
            QiRootCause2Da.Update(entry);
        }
        public void Remove(QiRootCause2 entry)
        {
            QiRootCause2Da.Delete(entry);
        }
    }
}
