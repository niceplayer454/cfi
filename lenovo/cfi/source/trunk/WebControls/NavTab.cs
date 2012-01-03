using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace Lenovo.CFI.WebControls
{
    [DefaultProperty("CssClass")]
    [ToolboxData("<{0}:NavTab runat=server></{0}:NavTab>")]
    public class NavTab : WebControl
    {
        public NavTab()
            : base(HtmlTextWriterTag.Ul)
        {
            this.CssClass = "tabsList";
        }

        private TB.Web.Nav.NavTab[] tabs = null;
        private int selectedIndex = 0;

        public void SetTabs(TB.Web.Nav.NavTab[] tabs, int selectedIndex)
        {
            if (tabs != null)
            {
                this.tabs = tabs;
                if (selectedIndex >= 0 && selectedIndex < tabs.Length)
                    this.selectedIndex = selectedIndex;
            }
        }

        public void SetTabs(TB.Web.Nav.NavTab[] tabs, int selectedIndex, string css)
        {
            this.SetTabs(tabs, selectedIndex);

            this.CssClass = css;
        }


        protected override void RenderContents(HtmlTextWriter output)
        {
            base.RenderContents(output);

            TB.Web.Nav.NavTab tab = null;
            if (this.tabs != null)
            {
                for (int i = 0; i < this.tabs.Length; i++)
                {
                    tab = this.tabs[i];
                    output.Write(@"<li{0}><a href=""{1}"" title=""{2}""><span>{3}</span></a></li>",
                        ((i == this.selectedIndex) ? @" class=""current""" : ""),
                        (tab.ShowUrl ? tab.Url : "#"),
                        tab.Title,
                        tab.Title);
                }
            }
        }
    }
}
