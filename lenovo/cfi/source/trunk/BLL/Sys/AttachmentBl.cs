using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Lenovo.CFI.DAL.Sys;
using Lenovo.CFI.Common;

namespace Lenovo.CFI.BLL.Sys
{
    public class AttachmentBl
    {
        public Attachment GetAttachmentByID(Guid id)
        {
            return AttachmentDa.GetAttachmentByID(id);
        }

        public List<Attachment> GetAttachmentByID(List<Guid> ids)
        {
            return AttachmentDa.GetAttachmentByID(ids);
        }

        public void AddAttach(Attachment attach) 
        {
            AttachmentDa.InsertAttach(attach);
        }
    }
}
