using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using Lenovo.CFI.Common.Dic;
using Lenovo.CFI.Web.Helper;
using Lenovo.CFI.BLL.DicMgr;
using Lenovo.CFI.Common;

namespace Lenovo.CFI.Web.VP
{
    public partial class CfgData : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.ViewState["DicName"] = 21;

                // for bu admin
                if (UserHelper.GetVPKey() == "cfgfamily")
                {
                    ViewState["budata"] = true;
                    this.DdlType.Items.Clear();
                    this.DdlType.Items.Add(new ListItem("QR Product Line", "21"));
                    this.DdlType.Items.Add(new ListItem("RC MailGroup", "31", false));
                }

                this.BindData();

                MessageHelper.Prepare(this.Page);
            }
        }

        private void BindData()
        {
            DictionaryName dic = (DictionaryName)this.ViewState["DicName"];
            SetEditArea(dic);
            switch (dic)
            {
                case DictionaryName.QiProductFamily:
                    if (ViewState["budata"] != null && (bool)ViewState["budata"])
                    {
                        //this.GvList.DataSource = ProductFamilyDicMgr.Get(UserHelper.CurrentBu, true);
                    }
                    else
                    {
                        this.GvList.DataSource = ProductFamilyDicMgr.Get(true);
                    }
                    break;
                case DictionaryName.QiAttachCategory:
                    this.GvList.DataSource = QiAttachCategoryDicMgr.Get(true);
                    break;
                case DictionaryName.QiProblemType:
                    this.GvList.DataSource = QiProblemTypeDicMgr.Get(true);
                    break;
                case DictionaryName.QiRootCause1:
                    this.GvList.DataSource = QiRootCause1DicMgr.Get(true);
                    break;
                case DictionaryName.QiRootCause2:
                    this.GvList.DataSource = QiRootCause2DicMgr.Get(true);
                    break;
                case DictionaryName.QiRootCause3:
                    this.GvList.DataSource = QiRootCause3DicMgr.Get(true);
                    break;
                case DictionaryName.QiCloseLoopCategory:
                    this.GvList.DataSource = CloseLoopCategoryDicMgr.Get(true);
                    break;
                case DictionaryName.QiCloseLoopDepartment:
                    this.GvList.DataSource = CloseLoopDepartmentDicMgr.Get(true);
                    break;
                case DictionaryName.RcMailGroup:
                    if (ViewState["budata"] != null && (bool)ViewState["budata"])
                    {
                        //this.GvList.DataSource = RcMailGroupDicMgr.Get(UserHelper.CurrentBu, true);
                    }
                    else
                    {
                        this.GvList.DataSource = RcMailGroupDicMgr.Get(true);
                    }
                    break;
                case DictionaryName.EwgInitIssueStatus:
                    this.GvList.DataSource = EwgInitIssueStatusDicMgr.Get(true);
                    break;
                case DictionaryName.EwgMeetingTeam:
                    this.GvList.DataSource = EwgMeetingTeamDicMgr.Get(true);
                    break;
                case DictionaryName.EwgFolder:
                    this.GvList.DataSource = EwgFolderDicMgr.Get(true);
                    break;
                case DictionaryName.EwgInitIssuePhase:
                    this.GvList.DataSource = EwgInitIssuePhaseDicMgr.Get(true);
                    break;

                case DictionaryName.LeDept:
                    this.GvList.DataSource = LeDeptDicMgr.Get(true);
                    break;
                case DictionaryName.LeProblemSource:
                    this.GvList.DataSource = LeProblemSourceDicMgr.Get(true);
                    break;
                case DictionaryName.LeProblemFactory:
                    this.GvList.DataSource = LeProblemFactoryDicMgr.Get(true);
                    break;
                case DictionaryName.LePart:
                    this.GvList.DataSource = LePartDicMgr.Get(true);
                    break;
            }

            this.GvList.DataBind();
        }

        private void SetEditArea(DictionaryName dic)
        {
            switch (dic)
            {
                case DictionaryName.QiProductFamily:
                    this.DivBuAdd.Visible = true;
                    this.DivBuEdit.Visible = true;
                    this.DivParentAdd.Visible = false;
                    this.DivParentEdit.Visible = false;
                    this.DivMailListEdit.Visible = true;
                    //BindHelper.BindBu(this.DdlBuAdd, null, null, null, false);
                    // for bu admin
                    if (ViewState["budata"] != null && (bool)ViewState["budata"])
                    {
                        this.DdlBuAdd.ClearSelection();
                        //this.DdlBuAdd.Items.FindByValue(UserHelper.CurrentBu).Selected = true;
                        this.DdlBuAdd.Enabled = false;
                    }
                    break;
                case DictionaryName.QiRootCause2:
                    this.DivBuAdd.Visible = false;
                    this.DivBuEdit.Visible = false;
                    this.DivParentAdd.Visible = true;
                    this.DivParentEdit.Visible = true;
                    this.DivMailListEdit.Visible = false;
                    //BindHelper.BindQiRootCause1(this.DdlParentAdd, null, null, null, false);
                    break;
                case DictionaryName.QiRootCause3:
                    this.DivBuAdd.Visible = false;
                    this.DivBuEdit.Visible = false;
                    this.DivParentAdd.Visible = true;
                    this.DivParentEdit.Visible = true;
                    this.DivMailListEdit.Visible = false;
                    //BindHelper.BindQiRootCause2(this.DdlParentAdd, null, null, null, null, false);
                    break;
                case DictionaryName.RcMailGroup:
                    this.DivBuAdd.Visible = true;
                    this.DivBuEdit.Visible = true;
                    this.DivMailListEdit.Visible = true;
                    //BindHelper.BindBu(this.DdlBuAdd, null, null, null, false);
                    // for bu admin
                    if (ViewState["budata"] != null && (bool)ViewState["budata"])
                    {
                        this.DdlBuAdd.ClearSelection();
                        //this.DdlBuAdd.Items.FindByValue(UserHelper.CurrentBu).Selected = true;
                        this.DdlBuAdd.Enabled = false;
                    }
                    break;
                default:
                    this.DivBuAdd.Visible = false;
                    this.DivBuEdit.Visible = false;
                    this.DivMailListEdit.Visible = false;
                    break;
            }
        }

        protected void DdlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ViewState["DicName"] = Convert.ToInt32(this.DdlType.SelectedValue);

            this.BindData();
        }

        protected void GvList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)    // 数据行
            {
                // 设置行号
                ((Literal)(e.Row.FindControl("LtrNo"))).Text = String.Format("{0}", e.Row.DataItemIndex + 1);

                DataDictionaryEntry dde = (DataDictionaryEntry)e.Row.DataItem;

                if (dde is QiAttachCategory)
                {
                    if (!((QiAttachCategory)dde).ReportAttach)
                    {
                        ((ImageButton)e.Row.FindControl("BtnEdit")).Visible = false;
                    }
                }
            }
        }

        protected void GvList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "OpenEdit")
            {
                DataDictionaryEntry dde = null;

                switch ((DictionaryName)this.ViewState["DicName"])
                {
                    case DictionaryName.QiProductFamily:
                        ProductFamily pf = ProductFamilyDicMgr.GetByCode(e.CommandArgument.ToString());
                        this.TxtCodeEdit.Text = pf.Code;
                        this.TxtTitleEdit.Text = pf.Title;
                        this.TxtSortEdit.Text = pf.Sort.ToString();
                        this.CbVisibleEdit.Checked = pf.Visible;
                        this.ViewState["Code"] = pf.Code;
                        this.TxtBuEdit.Text = pf.BU;
                        this.UacOwnerEdit.Value = pf.MailList;
                        ScriptManager.RegisterStartupScript(this.GvList, this.GvList.GetType(), this.UacOwnerEdit.ClientID,
                            this.UacOwnerEdit.GetJsInitFunction(false) + ";", true);
                        break;
                    case DictionaryName.QiAttachCategory:
                        dde = QiAttachCategoryDicMgr.GetByCode(e.CommandArgument.ToString());
                        this.TxtCodeEdit.Text = dde.Code;
                        this.TxtTitleEdit.Text = dde.Title;
                        this.TxtSortEdit.Text = dde.Sort.ToString();
                        this.CbVisibleEdit.Checked = dde.Visible;
                        this.ViewState["Code"] = dde.Code;
                        break;
                    case DictionaryName.QiProblemType:
                        dde = QiProblemTypeDicMgr.GetByCode(e.CommandArgument.ToString());
                        this.TxtCodeEdit.Text = dde.Code;
                        this.TxtTitleEdit.Text = dde.Title;
                        this.TxtSortEdit.Text = dde.Sort.ToString();
                        this.CbVisibleEdit.Checked = dde.Visible;
                        this.ViewState["Code"] = dde.Code;
                        break;
                    case DictionaryName.QiRootCause1:
                        dde = QiRootCause1DicMgr.GetByCode(e.CommandArgument.ToString());
                        this.TxtCodeEdit.Text = dde.Code;
                        this.TxtTitleEdit.Text = dde.Title;
                        this.TxtSortEdit.Text = dde.Sort.ToString();
                        this.CbVisibleEdit.Checked = dde.Visible;
                        this.ViewState["Code"] = dde.Code;
                        break;
                    case DictionaryName.QiRootCause2:
                        QiRootCause2 qrc2 = QiRootCause2DicMgr.GetByCode(e.CommandArgument.ToString());
                        this.TxtCodeEdit.Text = qrc2.Code;
                        this.TxtTitleEdit.Text = qrc2.Title;
                        this.TxtSortEdit.Text = qrc2.Sort.ToString();
                        this.CbVisibleEdit.Checked = qrc2.Visible;
                        this.ViewState["Code"] = qrc2.Code;
                        //this.TxtParentEdit.Text = qrc2.RootCauseTitle();
                        break;
                    case DictionaryName.QiRootCause3:
                        QiRootCause3 qrc3 = QiRootCause3DicMgr.GetByCode(e.CommandArgument.ToString());
                        this.TxtCodeEdit.Text = qrc3.Code;
                        this.TxtTitleEdit.Text = qrc3.Title;
                        this.TxtSortEdit.Text = qrc3.Sort.ToString();
                        this.CbVisibleEdit.Checked = qrc3.Visible;
                        this.ViewState["Code"] = qrc3.Code;
                        //this.TxtParentEdit.Text = qrc3.RootCauseTitle();
                        break;
                    case DictionaryName.QiCloseLoopCategory:
                        dde = CloseLoopCategoryDicMgr.GetByCode(e.CommandArgument.ToString());
                        this.TxtCodeEdit.Text = dde.Code;
                        this.TxtTitleEdit.Text = dde.Title;
                        this.TxtSortEdit.Text = dde.Sort.ToString();
                        this.CbVisibleEdit.Checked = dde.Visible;
                        this.ViewState["Code"] = dde.Code;
                        break;
                    case DictionaryName.QiCloseLoopDepartment:
                        dde = CloseLoopDepartmentDicMgr.GetByCode(e.CommandArgument.ToString());
                        this.TxtCodeEdit.Text = dde.Code;
                        this.TxtTitleEdit.Text = dde.Title;
                        this.TxtSortEdit.Text = dde.Sort.ToString();
                        this.CbVisibleEdit.Checked = dde.Visible;
                        this.ViewState["Code"] = dde.Code;
                        break;
                    case DictionaryName.RcMailGroup:
                        RcMailGroup rm = RcMailGroupDicMgr.GetByCode(e.CommandArgument.ToString());
                        this.TxtCodeEdit.Text = rm.Code;
                        this.TxtTitleEdit.Text = rm.Title;
                        this.TxtSortEdit.Text = rm.Sort.ToString();
                        this.CbVisibleEdit.Checked = rm.Visible;
                        this.ViewState["Code"] = rm.Code;
                        this.TxtBuEdit.Text = rm.BU;
                        this.UacOwnerEdit.Value = rm.MailList;
                        ScriptManager.RegisterStartupScript(this.GvList, this.GvList.GetType(), this.UacOwnerEdit.ClientID,
                            this.UacOwnerEdit.GetJsInitFunction(false) + ";", true);
                        break;

                    case DictionaryName.EwgInitIssueStatus:
                        dde = EwgInitIssueStatusDicMgr.GetByCode(e.CommandArgument.ToString());
                        this.TxtCodeEdit.Text = dde.Code;
                        this.TxtTitleEdit.Text = dde.Title;
                        this.TxtSortEdit.Text = dde.Sort.ToString();
                        this.CbVisibleEdit.Checked = dde.Visible;
                        this.ViewState["Code"] = dde.Code;
                        break;
                    case DictionaryName.EwgMeetingTeam:
                        dde = EwgMeetingTeamDicMgr.GetByCode(e.CommandArgument.ToString());
                        this.TxtCodeEdit.Text = dde.Code;
                        this.TxtTitleEdit.Text = dde.Title;
                        this.TxtSortEdit.Text = dde.Sort.ToString();
                        this.CbVisibleEdit.Checked = dde.Visible;
                        this.ViewState["Code"] = dde.Code;
                        break;
                    case DictionaryName.EwgFolder:
                        dde = EwgFolderDicMgr.GetByCode(e.CommandArgument.ToString());
                        this.TxtCodeEdit.Text = dde.Code;
                        this.TxtTitleEdit.Text = dde.Title;
                        this.TxtSortEdit.Text = dde.Sort.ToString();
                        this.CbVisibleEdit.Checked = dde.Visible;
                        this.ViewState["Code"] = dde.Code;
                        break;

                    case DictionaryName.LeDept:
                        dde = LeDeptDicMgr.GetByCode(e.CommandArgument.ToString());
                        this.TxtCodeEdit.Text = dde.Code;
                        this.TxtTitleEdit.Text = dde.Title;
                        this.TxtSortEdit.Text = dde.Sort.ToString();
                        this.CbVisibleEdit.Checked = dde.Visible;
                        this.ViewState["Code"] = dde.Code;
                        break;
                    case DictionaryName.LeProblemSource:
                        dde = LeProblemSourceDicMgr.GetByCode(e.CommandArgument.ToString());
                        this.TxtCodeEdit.Text = dde.Code;
                        this.TxtTitleEdit.Text = dde.Title;
                        this.TxtSortEdit.Text = dde.Sort.ToString();
                        this.CbVisibleEdit.Checked = dde.Visible;
                        this.ViewState["Code"] = dde.Code;
                        break;
                    case DictionaryName.LeProblemFactory:
                        dde = LeProblemFactoryDicMgr.GetByCode(e.CommandArgument.ToString());
                        this.TxtCodeEdit.Text = dde.Code;
                        this.TxtTitleEdit.Text = dde.Title;
                        this.TxtSortEdit.Text = dde.Sort.ToString();
                        this.CbVisibleEdit.Checked = dde.Visible;
                        this.ViewState["Code"] = dde.Code;
                        break;
                    case DictionaryName.LePart:
                        dde = LePartDicMgr.GetByCode(e.CommandArgument.ToString());
                        this.TxtCodeEdit.Text = dde.Code;
                        this.TxtTitleEdit.Text = dde.Title;
                        this.TxtSortEdit.Text = dde.Sort.ToString();
                        this.CbVisibleEdit.Checked = dde.Visible;
                        this.ViewState["Code"] = dde.Code;
                        break;
                }

                this.MpeEdit.Show();
            }
        }


        protected void BtnSaveAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DataDictionaryEntry dde = null;

                switch ((DictionaryName)this.ViewState["DicName"])
                {
                    case DictionaryName.QiProductFamily:
                        ProductFamily pf = ProductFamilyDicMgr.GetInstance().CreateEntry(
                            this.TxtCodeAdd.Text, this.TxtTitleAdd.Text,
                            Convert.ToInt32(this.TxtSortAdd.Text),
                            true, UserHelper.UserName, DateTime.Now, 
                            this.DdlBuAdd.SelectedValue, "");

                        ProductFamilyDicMgr.GetInstance().Add(pf);
                        break;
                    case DictionaryName.QiAttachCategory:
                        QiAttachCategory qac = QiAttachCategoryDicMgr.GetInstance().CreateEntry(
                            this.TxtCodeAdd.Text, this.TxtTitleAdd.Text,
                            Convert.ToInt32(this.TxtSortAdd.Text),
                            true, UserHelper.UserName, DateTime.Now, 
                            true);

                        QiAttachCategoryDicMgr.GetInstance().Add(qac);
                        break;
                    case DictionaryName.QiProblemType:
                        dde = QiProblemTypeDicMgr.GetInstance().CreateEntry(
                            this.TxtCodeAdd.Text, this.TxtTitleAdd.Text,
                            Convert.ToInt32(this.TxtSortAdd.Text),
                            true, UserHelper.UserName, DateTime.Now);

                        QiProblemTypeDicMgr.GetInstance().Add(dde);
                        break;
                    case DictionaryName.QiRootCause1:
                        dde = QiRootCause1DicMgr.GetInstance().CreateEntry(
                            this.TxtCodeAdd.Text, this.TxtTitleAdd.Text,
                            Convert.ToInt32(this.TxtSortAdd.Text),
                            true, UserHelper.UserName, DateTime.Now);

                        QiRootCause1DicMgr.GetInstance().Add(dde);
                        break;
                    case DictionaryName.QiRootCause2:
                        QiRootCause2 qrc2 = QiRootCause2DicMgr.GetInstance().CreateEntry(
                            this.TxtCodeAdd.Text, this.DdlParentAdd.SelectedValue, this.TxtTitleAdd.Text,
                            Convert.ToInt32(this.TxtSortAdd.Text),
                            true, UserHelper.UserName, DateTime.Now);

                        QiRootCause2DicMgr.GetInstance().Add(qrc2);
                        break;
                    case DictionaryName.QiRootCause3:
                        QiRootCause3 qrc3 = QiRootCause3DicMgr.GetInstance().CreateEntry(
                            this.TxtCodeAdd.Text, this.DdlParentAdd.SelectedValue, this.TxtTitleAdd.Text,
                            Convert.ToInt32(this.TxtSortAdd.Text),
                            true, UserHelper.UserName, DateTime.Now);

                        QiRootCause3DicMgr.GetInstance().Add(qrc3);
                        break;
                    case DictionaryName.QiCloseLoopCategory:
                        dde = CloseLoopCategoryDicMgr.GetInstance().CreateEntry(
                            this.TxtCodeAdd.Text, this.TxtTitleAdd.Text,
                            Convert.ToInt32(this.TxtSortAdd.Text),
                            true, UserHelper.UserName, DateTime.Now);

                        CloseLoopCategoryDicMgr.GetInstance().Add(dde);
                        break;
                    case DictionaryName.QiCloseLoopDepartment:
                        dde = CloseLoopDepartmentDicMgr.GetInstance().CreateEntry(
                            this.TxtCodeAdd.Text, this.TxtTitleAdd.Text,
                            Convert.ToInt32(this.TxtSortAdd.Text),
                            true, UserHelper.UserName, DateTime.Now);

                        CloseLoopDepartmentDicMgr.GetInstance().Add(dde);
                        break;
                    case DictionaryName.RcMailGroup:
                        RcMailGroup rm = RcMailGroupDicMgr.GetInstance().CreateEntry(
                            this.TxtCodeAdd.Text, this.TxtTitleAdd.Text,
                            Convert.ToInt32(this.TxtSortAdd.Text),
                            true, UserHelper.UserName, DateTime.Now,
                            this.DdlBuAdd.SelectedValue, "");

                        RcMailGroupDicMgr.GetInstance().Add(rm);
                        break;
                    case DictionaryName.EwgInitIssueStatus:
                        dde = EwgInitIssueStatusDicMgr.GetInstance().CreateEntry(
                            this.TxtCodeAdd.Text, this.TxtTitleAdd.Text,
                            Convert.ToInt32(this.TxtSortAdd.Text),
                            true, UserHelper.UserName, DateTime.Now);

                        EwgInitIssueStatusDicMgr.GetInstance().Add(dde);
                        break;
                    case DictionaryName.EwgMeetingTeam:
                        dde = EwgMeetingTeamDicMgr.GetInstance().CreateEntry(
                            this.TxtCodeAdd.Text, this.TxtTitleAdd.Text,
                            Convert.ToInt32(this.TxtSortAdd.Text),
                            true, UserHelper.UserName, DateTime.Now);

                        EwgMeetingTeamDicMgr.GetInstance().Add(dde);
                        break;
                    case DictionaryName.EwgFolder:
                        dde = EwgFolderDicMgr.GetInstance().CreateEntry(
                            this.TxtCodeAdd.Text, this.TxtTitleAdd.Text,
                            Convert.ToInt32(this.TxtSortAdd.Text),
                            true, UserHelper.UserName, DateTime.Now);

                        EwgFolderDicMgr.GetInstance().Add(dde);
                        break;
                    case DictionaryName.EwgInitIssuePhase:
                        dde = EwgInitIssuePhaseDicMgr.GetInstance().CreateEntry(
                            this.TxtCodeAdd.Text, this.TxtTitleAdd.Text,
                            Convert.ToInt32(this.TxtSortAdd.Text),
                            true, UserHelper.UserName, DateTime.Now);

                        EwgInitIssuePhaseDicMgr.GetInstance().Add(dde);
                        break;

                    case DictionaryName.LeDept:
                        dde = LeDeptDicMgr.GetInstance().CreateEntry(
                            this.TxtCodeAdd.Text, this.TxtTitleAdd.Text,
                            Convert.ToInt32(this.TxtSortAdd.Text),
                            true, UserHelper.UserName, DateTime.Now);

                        LeDeptDicMgr.GetInstance().Add(dde);
                        break;
                    case DictionaryName.LeProblemSource:
                        dde = LeProblemSourceDicMgr.GetInstance().CreateEntry(
                            this.TxtCodeAdd.Text, this.TxtTitleAdd.Text,
                            Convert.ToInt32(this.TxtSortAdd.Text),
                            true, UserHelper.UserName, DateTime.Now);

                        LeProblemSourceDicMgr.GetInstance().Add(dde);
                        break;
                    case DictionaryName.LeProblemFactory:
                        dde = LeProblemFactoryDicMgr.GetInstance().CreateEntry(
                            this.TxtCodeAdd.Text, this.TxtTitleAdd.Text,
                            Convert.ToInt32(this.TxtSortAdd.Text),
                            true, UserHelper.UserName, DateTime.Now);

                        LeProblemFactoryDicMgr.GetInstance().Add(dde);
                        break;
                    case DictionaryName.LePart:
                        dde = LePartDicMgr.GetInstance().CreateEntry(
                            this.TxtCodeAdd.Text, this.TxtTitleAdd.Text,
                            Convert.ToInt32(this.TxtSortAdd.Text),
                            true, UserHelper.UserName, DateTime.Now);

                        LePartDicMgr.GetInstance().Add(dde);
                        break;
                }

                this.TxtCodeAdd.Text = "";
                this.TxtTitleAdd.Text = "";
                this.TxtSortAdd.Text = "";

                MessageHelper.RegShowJSAjax(this.BtnSaveAdd, "Success!", this.Page);
            }
            catch (ApplicationException aex)
            {
                MessageHelper.RegShowJSAjax(this.BtnSaveAdd, aex.Message, this.Page);
            }
            catch (Exception ex)            // Ajax无法使用默认异常处理程序处理异常
            {
                ErrorHelper.ExceptionHanderForAjax(ex, this.BtnSaveAdd, this.Page);
            }

            this.BindData();
            this.MpeAdd.Hide();
        }

        protected void BtnSaveEdit_Click(object sender, EventArgs e)
        {
            try
            {
                DataDictionaryEntry dde = null;

                switch ((DictionaryName)this.ViewState["DicName"])
                {
                    case DictionaryName.QiProductFamily:
                        ProductFamily pf = ProductFamilyDicMgr.GetByCode(this.ViewState["Code"].ToString());
                        pf.Title = this.TxtTitleEdit.Text;
                        pf.Sort = Convert.ToInt32(this.TxtSortEdit.Text);
                        pf.Visible = this.CbVisibleEdit.Checked;
                        pf.MailList = this.UacOwnerEdit.Value;

                        ProductFamilyDicMgr.GetInstance().Update(pf);
                        break;
                    case DictionaryName.QiAttachCategory:
                        QiAttachCategory qac = QiAttachCategoryDicMgr.GetByCode(this.ViewState["Code"].ToString());
                        qac.Title = this.TxtTitleEdit.Text;
                        qac.Sort = Convert.ToInt32(this.TxtSortEdit.Text);
                        qac.Visible = this.CbVisibleEdit.Checked;

                        QiAttachCategoryDicMgr.GetInstance().Update(qac);
                        break;
                    case DictionaryName.QiProblemType:
                        dde = QiProblemTypeDicMgr.GetByCode(this.ViewState["Code"].ToString());
                        dde.Title = this.TxtTitleEdit.Text;
                        dde.Sort = Convert.ToInt32(this.TxtSortEdit.Text);
                        dde.Visible = this.CbVisibleEdit.Checked;

                        QiProblemTypeDicMgr.GetInstance().Update(dde);
                        break;
                    case DictionaryName.QiRootCause1:
                        dde = QiRootCause1DicMgr.GetByCode(this.ViewState["Code"].ToString());
                        dde.Title = this.TxtTitleEdit.Text;
                        dde.Sort = Convert.ToInt32(this.TxtSortEdit.Text);
                        dde.Visible = this.CbVisibleEdit.Checked;

                        QiRootCause1DicMgr.GetInstance().Update(dde);
                        break;
                    case DictionaryName.QiRootCause2:
                        QiRootCause2 qrc2 = QiRootCause2DicMgr.GetByCode(this.ViewState["Code"].ToString());
                        qrc2.Title = this.TxtTitleEdit.Text = dde.Title;
                        qrc2.Sort = Convert.ToInt32(this.TxtSortEdit.Text);
                        qrc2.Visible = this.CbVisibleEdit.Checked;

                        QiRootCause2DicMgr.GetInstance().Update(qrc2);
                        break;
                    case DictionaryName.QiRootCause3:
                        QiRootCause3 qrc3 = QiRootCause3DicMgr.GetByCode(this.ViewState["Code"].ToString());
                        qrc3.Title = this.TxtTitleEdit.Text = dde.Title;
                        qrc3.Sort = Convert.ToInt32(this.TxtSortEdit.Text);
                        qrc3.Visible = this.CbVisibleEdit.Checked;

                        QiRootCause3DicMgr.GetInstance().Update(qrc3);
                        break;
                    case DictionaryName.QiCloseLoopCategory:
                        dde = CloseLoopCategoryDicMgr.GetByCode(this.ViewState["Code"].ToString());
                        dde.Title = this.TxtTitleEdit.Text;
                        dde.Sort = Convert.ToInt32(this.TxtSortEdit.Text);
                        dde.Visible = this.CbVisibleEdit.Checked;

                        CloseLoopCategoryDicMgr.GetInstance().Update(dde);
                        break;
                    case DictionaryName.QiCloseLoopDepartment:
                        dde = CloseLoopDepartmentDicMgr.GetByCode(this.ViewState["Code"].ToString());
                        dde.Title = this.TxtTitleEdit.Text;
                        dde.Sort = Convert.ToInt32(this.TxtSortEdit.Text);
                        dde.Visible = this.CbVisibleEdit.Checked;

                        CloseLoopDepartmentDicMgr.GetInstance().Update(dde);
                        break;
                    case DictionaryName.RcMailGroup:
                        RcMailGroup rm = RcMailGroupDicMgr.GetByCode(this.ViewState["Code"].ToString());
                        rm.Title = this.TxtTitleEdit.Text;
                        rm.Sort = Convert.ToInt32(this.TxtSortEdit.Text);
                        rm.Visible = this.CbVisibleEdit.Checked;
                        rm.MailList = this.UacOwnerEdit.Value;

                        RcMailGroupDicMgr.GetInstance().Update(rm);
                        break;
                    case DictionaryName.EwgInitIssueStatus:
                        dde = EwgInitIssueStatusDicMgr.GetByCode(this.ViewState["Code"].ToString());
                        dde.Title = this.TxtTitleEdit.Text;
                        dde.Sort = Convert.ToInt32(this.TxtSortEdit.Text);
                        dde.Visible = this.CbVisibleEdit.Checked;

                        EwgInitIssueStatusDicMgr.GetInstance().Update(dde);
                        break;
                    case DictionaryName.EwgMeetingTeam:
                        dde = EwgMeetingTeamDicMgr.GetByCode(this.ViewState["Code"].ToString());
                        dde.Title = this.TxtTitleEdit.Text;
                        dde.Sort = Convert.ToInt32(this.TxtSortEdit.Text);
                        dde.Visible = this.CbVisibleEdit.Checked;

                        EwgMeetingTeamDicMgr.GetInstance().Update(dde);
                        break;
                    case DictionaryName.EwgFolder:
                        dde = EwgFolderDicMgr.GetByCode(this.ViewState["Code"].ToString());
                        dde.Title = this.TxtTitleEdit.Text;
                        dde.Sort = Convert.ToInt32(this.TxtSortEdit.Text);
                        dde.Visible = this.CbVisibleEdit.Checked;

                        EwgFolderDicMgr.GetInstance().Update(dde);
                        break;
                    case DictionaryName.EwgInitIssuePhase:
                        dde = EwgInitIssuePhaseDicMgr.GetByCode(this.ViewState["Code"].ToString());
                        dde.Title = this.TxtTitleEdit.Text;
                        dde.Sort = Convert.ToInt32(this.TxtSortEdit.Text);
                        dde.Visible = this.CbVisibleEdit.Checked;

                        EwgInitIssuePhaseDicMgr.GetInstance().Update(dde);
                        break;

                    case DictionaryName.LeDept:
                        dde = LeDeptDicMgr.GetByCode(this.ViewState["Code"].ToString());
                        dde.Title = this.TxtTitleEdit.Text;
                        dde.Sort = Convert.ToInt32(this.TxtSortEdit.Text);
                        dde.Visible = this.CbVisibleEdit.Checked;

                        LeDeptDicMgr.GetInstance().Update(dde);
                        break;
                    case DictionaryName.LeProblemSource:
                        dde = LeProblemSourceDicMgr.GetByCode(this.ViewState["Code"].ToString());
                        dde.Title = this.TxtTitleEdit.Text;
                        dde.Sort = Convert.ToInt32(this.TxtSortEdit.Text);
                        dde.Visible = this.CbVisibleEdit.Checked;

                        LeProblemSourceDicMgr.GetInstance().Update(dde);
                        break;
                    case DictionaryName.LeProblemFactory:
                        dde = LeProblemFactoryDicMgr.GetByCode(this.ViewState["Code"].ToString());
                        dde.Title = this.TxtTitleEdit.Text;
                        dde.Sort = Convert.ToInt32(this.TxtSortEdit.Text);
                        dde.Visible = this.CbVisibleEdit.Checked;

                        LeProblemFactoryDicMgr.GetInstance().Update(dde);
                        break;
                    case DictionaryName.LePart:
                        dde = LePartDicMgr.GetByCode(this.ViewState["Code"].ToString());
                        dde.Title = this.TxtTitleEdit.Text;
                        dde.Sort = Convert.ToInt32(this.TxtSortEdit.Text);
                        dde.Visible = this.CbVisibleEdit.Checked;

                        LePartDicMgr.GetInstance().Update(dde);
                        break;
                }

                MessageHelper.RegShowJSAjax(this.BtnSaveEdit, "Success!", this.Page);
            }
            catch (ApplicationException aex)
            {
                MessageHelper.RegShowJSAjax(this.BtnSaveEdit, aex.Message, this.Page);
            }
            catch (Exception ex)            // Ajax无法使用默认异常处理程序处理异常
            {
                ErrorHelper.ExceptionHanderForAjax(ex, this.BtnSaveEdit, this.Page);
            }

            this.BindData();
            this.MpeEdit.Hide();
        }
    }
}