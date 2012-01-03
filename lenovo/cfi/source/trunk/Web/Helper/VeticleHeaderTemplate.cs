using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace Lenovo.CFI.Web.Helper
{
    public class VeticleHeaderTemplate : ITemplate
    {
        public VeticleHeaderTemplate(string id)
        {
            this.id = id;
        }

        private string id; 

        private Literal l;
        public void InstantiateIn(Control container)
        {
            l = new Literal();
            l.ID = id;
            l.Text = "<span class=\"veti\">" + id + "-CTO</span>";
            container.Controls.Add(l);
        }
    }
}
