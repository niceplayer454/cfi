using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Lenovo.CFI.Common.Dic;
using Lenovo.CFI.DAL.Dic;

namespace Lenovo.CFI.BLL.DicBll
{
    public class SysBuBl
    {
        internal SysBuBl()
        {
        }

        public List<SysBu> GetAll()
        {
            return SysBuDa.GetAll();
        }


        public void Add(SysBu entry)
        {
            SysBuDa.Insert(entry);
        }
        public void Edit(SysBu entry)
        {
            SysBuDa.Update(entry);
        }
        public void Remove(SysBu entry)
        {
            SysBuDa.Delete(entry);
        }
    }
}
