using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web;

namespace Lenovo.CFI.WebControls
{
    [DefaultProperty("CssClass")]
    [ToolboxData("<{0}:NavMenu runat=server></{0}:NavMenu>")]
    public class NavMenu : WebControl
    {
        public NavMenu()
            : base(HtmlTextWriterTag.Ul)
        {
            this.CssClass = "menuslist";
        }

        private TB.Web.Nav.NavMenu[] menus = null;
        private int selectedIndex = 0;

        public void SetMenus(TB.Web.Nav.NavMenu[] menus, string selectedId)
        {
            if (menus != null)
            {
                this.menus = menus;

                foreach (TB.Web.Nav.NavMenu m in menus)
                {
                    if (m.Id == selectedId)
                        break;
                    this.selectedIndex++;
                }
            }
        }

        public void SetMenus(TB.Web.Nav.NavMenu[] menus, string selectedId, string css)
        {
            this.SetMenus(menus, selectedId);

            this.CssClass = css;
        }

        public override void RenderBeginTag(HtmlTextWriter writer)
        {
            if (!this.DesignMode)
            {
                HttpBrowserCapabilities bc = HttpContext.Current.Request.Browser;

                if (bc != null && bc.Browser == "IE" && bc.MajorVersion == 6)
                {
                    int width = 0;
                    foreach (TB.Web.Nav.NavMenu menu in this.menus)
                    {
                        switch (menu.Id)
                        {
                            case "1000100":
                                width += 78;
                                break;
                            case "0010000":
                            case "1010000":
                                width += 132;
                                break;
                            case "0020000":
                            case "1020000":
                                width += 89;
                                break;
                            case "1030000":
                                if (menu.Title.Length <= 3)
                                    width += 65;
                                else
                                    width += 182;
                                break;
                            case "0040000":
                                width += 121;
                                break;
                            case "0050000":
                            case "1050100":
                                width += 127;
                                break;
                            case "0080000":
                                width += 75;
                                break;
                            case "1060000":
                                width += 127;
                                break;
                            case "1080000":
                                width += 78;
                                break;
                        }
                    }

                    writer.AddStyleAttribute(HtmlTextWriterStyle.Width, width + "px");
                }
            }

            base.RenderBeginTag(writer);
        }

        protected override void RenderContents(HtmlTextWriter output)
        {
            base.RenderContents(output);

            TB.Web.Nav.NavMenu menu = null;
            if (this.menus != null)
            {
                for (int i = 0; i < this.menus.Length; i++)
                {
                    menu = this.menus[i];
                    output.Write(@"<li{0}><a href=""{1}"" title=""{2}""{4}><span>{3}</span></a></li>",
                        ((i == this.selectedIndex) ? @" class=""current""" : ""),
                        (menu.Url),
                        menu.Title,
                        menu.Title, "");
                    //((menu.Id == "1090000" || menu.Id == "1100000") ? @"target=""_blank""" : ""));
                }
            }
        }
    }
}
