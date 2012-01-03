using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Lenovo.CFI.Common.Dic;
using Lenovo.CFI.DAL.Dic;

namespace Lenovo.CFI.BLL.DicBll
{
    public class QiAttachCategoryBl
    {
        internal QiAttachCategoryBl()
        {
        }

        public List<QiAttachCategory> GetAll()
        {
            return QiAttachCategoryDa.GetAll();
        }


        public void Add(QiAttachCategory entry)
        {
            QiAttachCategoryDa.Insert(entry);
        }
        public void Edit(QiAttachCategory entry)
        {
            QiAttachCategoryDa.Update(entry);
        }
        public void Remove(QiAttachCategory entry)
        {
            QiAttachCategoryDa.Delete(entry);
        }
    }
}
