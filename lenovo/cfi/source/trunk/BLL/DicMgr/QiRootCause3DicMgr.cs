using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Lenovo.CFI.Common.Dic;
using Lenovo.CFI.BLL.DicBll;

namespace Lenovo.CFI.BLL.DicMgr
{
    public class QiRootCause3DicMgr : Lenovo.CFI.DicMgr.CodeCascadingDicMgrProviderBase<QiRootCause3>
    {
        // 私有构造函数
        internal QiRootCause3DicMgr()
        {
        }


        #region Create

        public QiRootCause3 CreateEntry(string code, string rootCause2, string title, int sort, bool visible, string updator, DateTime updateTime)
        {
            return new QiRootCause3(code, rootCause2, title, sort, visible, updator, updateTime);
        }

        public override QiRootCause3 CreateEntry()
        {
            return new QiRootCause3();
        }

        #endregion

        #region load data

        /// <summary>
        /// 加载数据
        /// </summary>
        /// <remarks>必须锁定对象</remarks>
        protected override List<QiRootCause3> LoadData()
        {
            return business.GetAll();
        }

        #endregion

        #region maintain

        protected override void AddPrivate(QiRootCause3 entry)
        {
            business.Add(entry);
        }

        protected override void UpdatePrivate(QiRootCause3 entry)
        {
            business.Edit(entry);
        }

        protected override void DeletePrivate(QiRootCause3 entry)
        {
            business.Remove(entry);
        }

        #endregion

        protected QiRootCause3Bl business = new QiRootCause3Bl();

        #region singleton

        // 单例对象
        internal volatile static QiRootCause3DicMgr dicMgr = null;
        // 锁定辅助对象
        private static object s_lock = new object();

        /// <summary>
        /// 构造函数，初始化单例对象，并加载数据。
        /// </summary>
        static QiRootCause3DicMgr()
        {
            dicMgr = new QiRootCause3DicMgr();
            dicMgr.Load();          // 加载数据            
        }


        /// <summary>
        /// 获取实例。
        /// </summary>
        /// <returns></returns>
        public static QiRootCause3DicMgr GetInstance()
        {
            return dicMgr;
        }

        public static QiRootCause3 GetByCode(string code)
        {
            return dicMgr.GetEntry(code);
        }

        public static IList<QiRootCause3> Get()
        {
            return dicMgr.GetList(false);
        }

        public static IList<QiRootCause3> Get(bool withHidden)
        {
            return dicMgr.GetList(withHidden);
        }

        public static IList<QiRootCause3> Get(string cause2)
        {
            return dicMgr.GetList(cause2, false);
        }

        public static IList<QiRootCause3> Get(string cause2, bool withHidden)
        {
            return dicMgr.GetList(cause2, withHidden);
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
