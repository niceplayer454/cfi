using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Lenovo.CFI.Web.Helper;
using Lenovo.CFI.BLL;
using Lenovo.CFI.Common;
using Lenovo.CFI.BLL.Sys;

namespace Lenovo.CFI.Web
{
    public partial class File : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) 
            {
                Guid? id = UrlHelper.GetQueryStringGUID("id");

                Attachment attach = null;
                if (id.HasValue)
                    attach = new AttachmentBl().GetAttachmentByID(id.Value);

                if (attach == null) return;

                FileDUHelper.Download(attach.Title, System.Configuration.ConfigurationManager.AppSettings["File"] + attach.Path);
            }
        }


        
    }
}