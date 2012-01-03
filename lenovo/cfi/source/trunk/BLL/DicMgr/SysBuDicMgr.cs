using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Lenovo.CFI.Common.Dic;
using Lenovo.CFI.BLL.DicBll;

namespace Lenovo.CFI.BLL.DicMgr
{
    public class SysBuDicMgr : Lenovo.CFI.DicMgr.CodeTabularDicMgrProviderBase<SysBu>
    {
        // 私有构造函数
        internal SysBuDicMgr() { }

        #region Create

        public SysBu CreateEntry(string code, string title, int sort, bool visible, string updator, DateTime updateTime,
            string qrPrefix, string lePrefix)
        {
            return new SysBu(code, title, sort, visible, updator, updateTime,
                qrPrefix, lePrefix);
        }

        public override SysBu CreateEntry()
        {
            return new SysBu();
        }

        #endregion

        #region load data

        /// <summary>
        /// 加载数据
        /// </summary>
        /// <remarks>必须锁定对象</remarks>
        protected override List<SysBu> LoadData()
        {
            return business.GetAll();
        }

        #endregion

        #region maintain

        protected override void AddPrivate(SysBu entry)
        {
            business.Add(entry);
        }

        protected override void UpdatePrivate(SysBu entry)
        {
            business.Edit(entry);
        }

        protected override void DeletePrivate(SysBu entry)
        {
            business.Remove(entry);
        }

        #endregion

        protected SysBuBl business = new SysBuBl();

        #region singleton

        // 单例对象
        internal volatile static SysBuDicMgr dicMgr = null;
        // 锁定辅助对象
        private static object s_lock = new object();

        /// <summary>
        /// 构造函数，初始化单例对象，并加载数据。
        /// </summary>
        static SysBuDicMgr()
        {
            dicMgr = new SysBuDicMgr();
            dicMgr.Load();          // 加载数据            
        }


        /// <summary>
        /// 获取实例。
        /// </summary>
        /// <returns></returns>
        public static SysBuDicMgr GetInstance()
        {
            return dicMgr;
        }

        public static SysBu GetByCode(string code)
        {
            return dicMgr.GetEntry(code);
        }

        public static IList<SysBu> Get()
        {
            return dicMgr.GetList(false);
        }

        public static IList<SysBu> Get(bool withHidden)
        {
            return dicMgr.GetList(withHidden);
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
