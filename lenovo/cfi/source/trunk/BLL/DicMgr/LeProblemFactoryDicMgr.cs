﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Lenovo.CFI.Common.Dic;

namespace Lenovo.CFI.BLL.DicMgr
{
    public class LeProblemFactoryDicMgr : TabularDicMgr
    {
        // 私有构造函数
        internal LeProblemFactoryDicMgr() : base(DictionaryName.LeProblemFactory) { }

        #region singleton

        // 单例对象
        internal volatile static LeProblemFactoryDicMgr dicMgr = null;
        // 锁定辅助对象
        private static object s_lock = new object();

        /// <summary>
        /// 构造函数，初始化单例对象，并加载数据。
        /// </summary>
        static LeProblemFactoryDicMgr()
        {
            dicMgr = new LeProblemFactoryDicMgr();
            dicMgr.Load();          // 加载数据            
        }


        /// <summary>
        /// 获取实例。
        /// </summary>
        /// <returns></returns>
        public static LeProblemFactoryDicMgr GetInstance()
        {
            return dicMgr;
        }

        public static DataDictionaryEntry GetByCode(string code)
        {
            return dicMgr.GetEntry(code);
        }

        public static IList<DataDictionaryEntry> Get()
        {
            return dicMgr.GetList(false);
        }

        public static IList<DataDictionaryEntry> Get(bool withHidden)
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
