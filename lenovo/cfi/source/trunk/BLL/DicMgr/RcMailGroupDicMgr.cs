using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Lenovo.CFI.Common.Dic;
using Lenovo.CFI.BLL.DicBll;

namespace Lenovo.CFI.BLL.DicMgr
{
    public class RcMailGroupDicMgr : Lenovo.CFI.DicMgr.CodeTabularDicMgrProviderBase<RcMailGroup>
    {
        // 私有构造函数
        internal RcMailGroupDicMgr()
        { }

        #region Create

        public RcMailGroup CreateEntry(string code, string title, int sort, bool visible, string updator, DateTime updateTime,
            string bu, string maillist)
        {
            return new RcMailGroup(code, title, sort, visible, updator, updateTime,
                bu, maillist);
        }

        public override RcMailGroup CreateEntry()
        {
            return new RcMailGroup();
        }

        #endregion

        #region load data

        /// <summary>
        /// 加载数据
        /// </summary>
        /// <remarks>必须锁定对象</remarks>
        protected override List<RcMailGroup> LoadData()
        {
            return business.GetAll();
        }

        #endregion

        #region maintain

        protected override void AddPrivate(RcMailGroup entry)
        {
            business.Add(entry);
        }

        protected override void UpdatePrivate(RcMailGroup entry)
        {
            business.Edit(entry);
        }

        protected override void DeletePrivate(RcMailGroup entry)
        {
            business.Remove(entry);
        }

        #endregion

        protected RcMailGroupBl business = new RcMailGroupBl();


        #region singleton

        // 单例对象
        internal volatile static RcMailGroupDicMgr dicMgr = null;
        // 锁定辅助对象
        private static object s_lock = new object();

        /// <summary>
        /// 构造函数，初始化单例对象，并加载数据。
        /// </summary>
        static RcMailGroupDicMgr()
        {
            dicMgr = new RcMailGroupDicMgr();
            dicMgr.Load();          // 加载数据            
        }


        /// <summary>
        /// 获取实例。
        /// </summary>
        /// <returns></returns>
        public static RcMailGroupDicMgr GetInstance()
        {
            return dicMgr;
        }

        public static RcMailGroup GetByCode(string code)
        {
            return dicMgr.GetEntry(code);
        }

        public static IList<RcMailGroup> Get()
        {
            return dicMgr.GetList(false);
        }

        public static IList<RcMailGroup> Get(bool withHidden)
        {
            return dicMgr.GetList(withHidden);
        }

        public static IList<RcMailGroup> Get(string bu, bool withHidden)
        {
            List<RcMailGroup> pfs = new List<RcMailGroup>();
            foreach (RcMailGroup pf in dicMgr.GetList(withHidden))
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
