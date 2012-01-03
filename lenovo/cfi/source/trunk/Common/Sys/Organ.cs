using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Lenovo.CFI.Common.Sys
{
    /// <summary>
    /// 组织对象。
    /// </summary>
    [Serializable]
    public class Organ
    {
        #region ctor

        /// <summary>
        /// 构造函数
        /// </summary>
        public Organ()
        {
            this.id = Guid.NewGuid();
            this.valid = true;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="id">标识</param>
        public Organ(Guid id)
        {
            this.id = id;
            this.valid = true;
        }

        #endregion

        private Guid id;
        private string title;
        private Organ parent;
        private int level;
        private string bu;
        
        [NonSerialized]
        private bool valid;
        [NonSerialized]
        private List<Organ> children;

        #region properity

        /// <summary>
        /// 获取或设置标识
        /// </summary>
        public Guid ID
        {
            get { return id; }
            set { id = value; }
        }
        /// <summary>
        /// 获取或设置标题
        /// </summary>
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        /// <summary>
        /// 获取或设置父
        /// </summary>
        public Organ Parent
        {
            get { return parent; }
            set { parent = value; }
        }
        /// <summary>
        /// 获取或设置级别，从1开始
        /// </summary>
        public int Level
        {
            get { return level; }
            set { level = value; }
        }
        /// <summary>
        /// 默认的BU
        /// </summary>
        public string BU
        {
            get { return bu; }
            set { bu = value; }
        }
        /// <summary>
        /// 获取或设置是否有效
        /// </summary>
        public bool Valid
        {
            get { return valid; }
            set { valid = value; }
        }
        /// <summary>
        /// 获取或设置子组织
        /// </summary>
        public List<Organ> Children
        {
            get
            {
                if (this.children == null)
                    this.children = new List<Organ>();
                return children;
            }
        }
        /// <summary>
        /// 获取显示名称和标识。
        /// </summary>
        public string DisplayID
        {
            get { return String.Format("{0}({1})", this.title, this.id); }
        }

        #endregion

        /// <summary>
        /// 获取所有子孙节点列表。
        /// </summary>
        /// <returns></returns>
        public List<Organ> GetAllChildren()
        {
            List<Organ> allChildren = new List<Organ>();

            Stack<Organ> nodeQueue = new Stack<Organ>();

            nodeQueue.Push(this);

            Organ node;
            while (nodeQueue.Count != 0)
            {
                node = nodeQueue.Pop();

                allChildren.Add(node);

                if (node.children != null)
                {
                    for (int i = node.children.Count - 1; i >= 0; i--)
                        nodeQueue.Push(node.children[i]);
                }
            }

            return allChildren;
        }

        public void ChildrenSortAndSetLevel()
        {
            if (this.children != null)
            {
                this.children.Sort((x, y) => x.title.CompareTo(y.title));

                int l = this.level + 1;
                foreach (Organ child in this.Children)
                {
                    child.level = l;

                    child.ChildrenSortAndSetLevel();
                }
            }
        }

        public string GetFullTitle()
        {
            return GetFullTitle(false);
        }

        public string GetFullTitle(bool withSeparator)
        {
            string fullTitle = this.title;
            Organ po = this.parent;
            while (po != null && po.level > 1)
            {
                if (withSeparator)
                    fullTitle = po.title + " - " + fullTitle;
                else
                    fullTitle = po.title + fullTitle;
                po = po.parent;
            }
            return fullTitle;
        }
    }

}
