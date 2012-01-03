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
    public partial class CfgUserInfo : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                User user = new UserBl().GetUserByItCode(UserHelper.UserName);
                this.TxtItCode.Text = user.ItCode;
                this.TxtFirstName.Text = user.FirstName;
                this.TxtLastName.Text = user.LastName;
                this.TxtPhone.Text = user.Phone;

                //BindHelper.BindUser(this.DdlDelegate, "Select...", "", user.DelegateUser, true);

                MessageHelper.Prepare(this.Page);
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //new UserBl().EditUserInfo(UserHelper.UserName, this.TxtPassword.Text,
                //    this.TxtFirstName.Text, this.TxtLastName.Text, this.TxtPhone.Text);

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