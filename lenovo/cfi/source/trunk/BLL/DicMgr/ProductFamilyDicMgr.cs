using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Lenovo.CFI.Common.Dic;
using Lenovo.CFI.BLL.DicBll;

namespace Lenovo.CFI.BLL.DicMgr
{
    public class ProductFamilyDicMgr : Lenovo.CFI.DicMgr.CodeTabularDicMgrProviderBase<ProductFamily>
    {
        // 私有构造函数
        internal ProductFamilyDicMgr()
        { }

        #region Create

        public ProductFamily CreateEntry(string code, string title, int sort, bool visible, string updator, DateTime updateTime,
            string bu, string maillist)
        {
            return new ProductFamily(code, title, sort, visible, updator, updateTime,
                bu, maillist);
        }

        public override ProductFamily CreateEntry()
        {
            return new ProductFamily();
        }

        #endregion

        #region load data

        /// <summary>
        /// 加载数据
        /// </summary>
        /// <remarks>必须锁定对象</remarks>
        protected override List<ProductFamily> LoadData()
        {
            return business.GetAll();
        }

        #endregion

        #region maintain

        protected override void AddPrivate(ProductFamily entry)
        {
            business.Add(entry);
        }

        protected override void UpdatePrivate(ProductFamily entry)
        {
            business.Edit(entry);
        }

        protected override void DeletePrivate(ProductFamily entry)
        {
            business.Remove(entry);
        }

        #endregion

        protected ProductFamilyBl business = new ProductFamilyBl();


        #region singleton

        // 单例对象
        internal volatile static ProductFamilyDicMgr dicMgr = null;
        // 锁定辅助对象
        private static object s_lock = new object();

        /// <summary>
        /// 构造函数，初始化单例对象，并加载数据。
        /// </summary>
        static ProductFamilyDicMgr()
        {
            dicMgr = new ProductFamilyDicMgr();
            dicMgr.Load();          // 加载数据            
        }


        /// <summary>
        /// 获取实例。
        /// </summary>
        /// <returns></returns>
        public static ProductFamilyDicMgr GetInstance()
        {
            return dicMgr;
        }

        public static ProductFamily GetByCode(string code)
        {
            return dicMgr.GetEntry(code);
        }

        public static IList<ProductFamily> Get()
        {
            return dicMgr.GetList(false);
        }

        public static IList<ProductFamily> Get(bool withHidden)
        {
            return dicMgr.GetList(withHidden);
        }

        public static IList<ProductFamily> Get(string bu, bool withHidden)
        {
            List<ProductFamily> pfs = new List<ProductFamily>();
            foreach(ProductFamily pf in dicMgr.GetList(withHidden))
            {
                if (pf.BU == bu)
                    pfs.Add(pf);
            }

            return pfs;
        }

        #endregion


        /// <summary>
        /// 重新加载数据。
        /// </summary>
        public static void ReLoadDic()
        {
            lock (s_lock)
            {
                GetInstance().ReLoad();
            }
        }
    }
}
