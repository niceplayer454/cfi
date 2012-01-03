using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Lenovo.CFI.Common.Dic;
using Lenovo.CFI.DAL.Dic;

namespace Lenovo.CFI.BLL.DicBll
{
    public class QiRootCause3Bl
    {
        internal QiRootCause3Bl()
        {
        }

        public List<QiRootCause3> GetAll()
        {
            return QiRootCause3Da.GetAll();
        }


        public void Add(QiRootCause3 entry)
        {
            QiRootCause3Da.Insert(entry);
        }
        public void Edit(QiRootCause3 entry)
        {
            QiRootCause3Da.Update(entry);
        }
        public void Remove(QiRootCause3 entry)
        {
            QiRootCause3Da.Delete(entry);
        }
    }
}
