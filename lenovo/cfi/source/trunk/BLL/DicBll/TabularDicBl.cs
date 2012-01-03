using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Lenovo.CFI.Common.Dic;
using Lenovo.CFI.DAL.Dic;

namespace Lenovo.CFI.BLL.DicBll
{
    public class TabularDicBl
    {
        internal TabularDicBl(DictionaryName dicName)
        {
            this.dicName = dicName;
        }

        private DictionaryName dicName;

        public List<DataDictionaryEntry> GetAll()
        {
            return DataDictionaryEntryDa.GetAll(this.dicName);
        }


        public void Add(DataDictionaryEntry entry)
        {
            DataDictionaryEntryDa.Insert(entry, this.dicName);
        }
        public void Edit(DataDictionaryEntry entry)
        {
            DataDictionaryEntryDa.Update(entry, this.dicName);
        }
        public void Remove(DataDictionaryEntry entry)
        {
            DataDictionaryEntryDa.Delete(entry, this.dicName);
        }
    }
}
