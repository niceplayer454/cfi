using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lenovo.CFI.Common
{
    public class Attachment
    {
        public Attachment(Guid uid)
        {
            this.uid = uid;
        }

        public Attachment(string create)
        {
            this.uid = Guid.NewGuid();
            this.create = new OperationInfo(create, DateTime.Now);
        }

        public Attachment(Guid uid, string title, string path,
            string create, DateTime time, string note)
        {
            this.uid = uid;
            this.title = title;
            this.path = path;
            this.create = new OperationInfo(create, time);
            this.note = note;
        }

        protected Guid uid;
        protected string title;
        protected string path;
        protected OperationInfo create;
        protected string note;

        public Guid UID
        {
            get { return uid; }
            set { uid = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Path
        {
            get { return path; }
            set { path = value; }
        }

        public OperationInfo Create
        {
            get { return create; }
            set { create = value; }
        }

        public string Note
        {
            get { return note; }
            set { note = value; }
        }
    }
}
