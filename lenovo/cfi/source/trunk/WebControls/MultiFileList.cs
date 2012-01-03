using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lenovo.CFI.WebControls
{
    [ToolboxData("<{0}:MultiFileList runat=server></{0}:MultiFileList>")]
    public class MultiFileList : WebControl
    {
        public MultiFileList()
            : base(HtmlTextWriterTag.Ul)
        {}

        public void SetFile(List<string[]> files)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string[] file in files)
            {
                sb.AppendFormat(@"<a 
    href=""{0}"" target=""_blank"">{1}</a>", file[2], file[1]);
            }
            this.ltr.Text = sb.ToString();
        }

        private Literal ltr = new Literal();
        protected override void CreateChildControls()
        {
            base.CreateChildControls();

            this.ltr.ID = "list";
            this.Controls.Add(this.ltr);
        }


        protected override void RenderContents(HtmlTextWriter output)
        {
            base.RenderContents(output);
        }
    }
}
