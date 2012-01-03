using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Lenovo.CFI.Common.Dic;
using Lenovo.CFI.DAL.Dic;

namespace Lenovo.CFI.BLL.DicBll
{
    public class ProductFamilyBl
    {
        internal ProductFamilyBl()
        {
        }

        public List<ProductFamily> GetAll()
        {
            return ProductFamilyDa.GetAll();
        }


        public void Add(ProductFamily entry)
        {
            ProductFamilyDa.Insert(entry);
        }
        public void Edit(ProductFamily entry)
        {
            ProductFamilyDa.Update(entry);
        }
        public void Remove(ProductFamily entry)
        {
            ProductFamilyDa.Delete(entry);
        }
    }
}
