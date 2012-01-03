using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Lenovo.CFI.Web.Helper;
using Lenovo.CFI.Common.Sys;
using Lenovo.CFI.BLL.Sys;

namespace Lenovo.CFI.Web.VP
{
    public partial class CfgUserDelegate : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //User user = new UserBl().GetUserByItCode(UserHelper.UserName);


                MessageHelper.Prepare(this.Page);
            }
        }

        protected void BtnDelegate_Click(object sender, EventArgs e)
        {
            try
            {
                //new UserBl().SetDelgate(UserHelper.UserName, this.DdlDelegate.SelectedValue);

                MessageHelper.Show("Success!", this.Page);
            }
            catch (ApplicationException aex)
            {
                MessageHelper.Show(aex.Message, this.Page);
            }
            catch (Exception ex)
            {
                ErrorHelper.Handle(ex);
            }
        }

    }
}