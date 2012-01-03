using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Lenovo.CFI.Common.Dic;
using Lenovo.CFI.BLL.DicBll;

namespace Lenovo.CFI.BLL.DicMgr
{
    public class QiAttachCategoryDicMgr : Lenovo.CFI.DicMgr.CodeTabularDicMgrProviderBase<QiAttachCategory>
    {
        // 私有构造函数
        internal QiAttachCategoryDicMgr()
        { }

        #region Create

        public QiAttachCategory CreateEntry(string code, string title, int sort, bool visible, string updator, DateTime updateTime,
            bool reportAttach)
        {
            return new QiAttachCategory(code, title, sort, visible, updator, updateTime,
                reportAttach);
        }

        public override QiAttachCategory CreateEntry()
        {
            return new QiAttachCategory();
        }

        #endregion

        #region load data

        /// <summary>
        /// 加载数据
        /// </summary>
        /// <remarks>必须锁定对象</remarks>
        protected override List<QiAttachCategory> LoadData()
        {
            return business.GetAll();
        }

        #endregion

        #region maintain

        protected override void AddPrivate(QiAttachCategory entry)
        {
            business.Add(entry);
        }

        protected override void UpdatePrivate(QiAttachCategory entry)
        {
            business.Edit(entry);
        }

        protected override void DeletePrivate(QiAttachCategory entry)
        {
            business.Remove(entry);
        }

        #endregion

        protected QiAttachCategoryBl business = new QiAttachCategoryBl();


        #region singleton

        // 单例对象
        internal volatile static QiAttachCategoryDicMgr dicMgr = null;
        // 锁定辅助对象
        private static object s_lock = new object();

        /// <summary>
        /// 构造函数，初始化单例对象，并加载数据。
        /// </summary>
        static QiAttachCategoryDicMgr()
        {
            dicMgr = new QiAttachCategoryDicMgr();
            dicMgr.Load();          // 加载数据            
        }


        /// <summary>
        /// 获取实例。
        /// </summary>
        /// <returns></returns>
        public static QiAttachCategoryDicMgr GetInstance()
        {
            return dicMgr;
        }

        public static QiAttachCategory GetByCode(string code)
        {
            return dicMgr.GetEntry(code);
        }

        public static IList<QiAttachCategory> Get()
        {
            return dicMgr.GetList(false);
        }

        public static IList<QiAttachCategory> Get(bool withHidden)
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
