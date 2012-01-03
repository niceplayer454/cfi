using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Lenovo.CFI.Common.Dic;
using Lenovo.CFI.BLL.DicBll;

namespace Lenovo.CFI.BLL.DicMgr
{
    public class TabularDicMgr : Lenovo.CFI.DicMgr.CodeTabularDicMgrProviderBase<DataDictionaryEntry>
    {
        // 私有构造函数
        internal protected TabularDicMgr(DictionaryName dicName)
        {
            this.dicName = dicName;

            business = new TabularDicBl(this.dicName);
        }

        private DictionaryName dicName;


        #region Create

        public DataDictionaryEntry CreateEntry(string code, string title, int sort, bool visible, string updator, DateTime updateTime)
        {
            return new DataDictionaryEntry(code, title, sort, visible, updator, updateTime);
        }

        public override DataDictionaryEntry CreateEntry()
        {
            return new DataDictionaryEntry();
        }

        #endregion

        #region load data

        /// <summary>
        /// 加载数据
        /// </summary>
        /// <remarks>必须锁定对象</remarks>
        protected override List<DataDictionaryEntry> LoadData()
        {
            return business.GetAll();
            //return business.GetAll().ConvertAll<Group>(entry => new Group(entry));
        }

        #endregion

        #region maintain

        protected override void AddPrivate(DataDictionaryEntry entry)
        {
            business.Add(entry);
        }

        protected override void UpdatePrivate(DataDictionaryEntry entry)
        {
            business.Edit(entry);
        }

        protected override void DeletePrivate(DataDictionaryEntry entry)
        {
            business.Remove(entry);
        }

        #endregion

        protected TabularDicBl business = null;
    }
}
