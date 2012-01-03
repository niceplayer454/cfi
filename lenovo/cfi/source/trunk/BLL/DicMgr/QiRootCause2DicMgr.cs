using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Lenovo.CFI.Common.Dic;
using Lenovo.CFI.BLL.DicBll;

namespace Lenovo.CFI.BLL.DicMgr
{
    public class QiRootCause2DicMgr : Lenovo.CFI.DicMgr.CodeCascadingDicMgrProviderBase<QiRootCause2>
    {
        // 私有构造函数
        internal QiRootCause2DicMgr()
        {
        }


        #region Create

        public QiRootCause2 CreateEntry(string code, string rootCause1, string title, int sort, bool visible, string updator, DateTime updateTime)
        {
            return new QiRootCause2(code, rootCause1, title, sort, visible, updator, updateTime);
        }

        public override QiRootCause2 CreateEntry()
        {
            return new QiRootCause2();
        }

        #endregion

        #region load data

        /// <summary>
        /// 加载数据
        /// </summary>
        /// <remarks>必须锁定对象</remarks>
        protected override List<QiRootCause2> LoadData()
        {
            return business.GetAll();
        }

        #endregion

        #region maintain

        protected override void AddPrivate(QiRootCause2 entry)
        {
            business.Add(entry);
        }

        protected override void UpdatePrivate(QiRootCause2 entry)
        {
            business.Edit(entry);
        }

        protected override void DeletePrivate(QiRootCause2 entry)
        {
            business.Remove(entry);
        }

        #endregion

        protected QiRootCause2Bl business = new QiRootCause2Bl();

        #region singleton

        // 单例对象
        internal volatile static QiRootCause2DicMgr dicMgr = null;
        // 锁定辅助对象
        private static object s_lock = new object();

        /// <summary>
        /// 构造函数，初始化单例对象，并加载数据。
        /// </summary>
        static QiRootCause2DicMgr()
        {
            dicMgr = new QiRootCause2DicMgr();
            dicMgr.Load();          // 加载数据            
        }


        /// <summary>
        /// 获取实例。
        /// </summary>
        /// <returns></returns>
        public static QiRootCause2DicMgr GetInstance()
        {
            return dicMgr;
        }

        public static QiRootCause2 GetByCode(string code)
        {
            return dicMgr.GetEntry(code);
        }

        public static IList<QiRootCause2> Get()
        {
            return dicMgr.GetList(false);
        }

        public static IList<QiRootCause2> Get(bool withHidden)
        {
            return dicMgr.GetList(withHidden);
        }

        public static IList<QiRootCause2> Get(string cause1)
        {
            return dicMgr.GetList(cause1, false);
        }

        public static IList<QiRootCause2> Get(string cause1, bool withHidden)
        {
            return dicMgr.GetList(cause1, withHidden);
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
