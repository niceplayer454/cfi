using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;

using Lenovo.CFI.Web.Helper;
using System.Web.UI.HtmlControls;
using TB.Web.UI.WebControls;

namespace Lenovo.CFI.Web.UserControls
{
    public partial class MultiAsyncFileUpload : System.Web.UI.UserControl
    {
        public string SessionKey
        {
            get
            {
                object obj = this.ViewState["FileKey"];
                if (obj != null)
                    return (string)obj;

                return InitSessionKey();
            }
            set
            {
                this.ViewState["FileKey"] = value;
            }
        }

        private string InitSessionKey()
        {
            if (this.ViewState["FileKey"] == null)
            {
                string key = Guid.NewGuid().ToString();
                this.ViewState["FileKey"] = key;
                return key;
            }
            else
                return this.ViewState["FileKey"].ToString();
        }

        public string CssClass
        {
            get { return this.PnlMafu.CssClass; }
            set { this.PnlMafu.CssClass = value; }
        }

        public string AfuCssClass
        {
            get { return this.AfuFile.CssClass; }
            set { this.AfuFile.CssClass = value; }
        }

        public Unit Width
        {
            get { return this.AfuFile.Width; }
            set { this.AfuFile.Width = value; }
        }

        public UpdatePanelRenderMode RenderMode
        {
            get { return this.UpFileAfu.RenderMode; }
            set { this.UpFileAfu.RenderMode = value; }
        }

        //public Guid? UploadFileID
        //{
        //    get
        //    {
        //        //if (!String.IsNullOrEmpty(this.HiFile.Value))
        //        //    return new Guid(this.HiFile.Value);
        //        return null;
        //    }
        //}

        /// <summary>
        /// 是否显示文件下载链接
        /// </summary>
        public bool ShowFileLink
        {
            get
            {
                object obj = this.ViewState["ShowFileLink"];
                if (obj != null)
                    return (bool)obj;

                return false;
            }
            set
            {
                this.ViewState["ShowFileLink"] = value;
            }
        }

        /// <summary>
        /// SetFile时的默认值
        /// </summary>
        public bool ReadOnly
        {
            get
            {
                object obj = this.ViewState["ReadOnly"];
                if (obj != null)
                    return (bool)obj;

                return false;
            }
            set
            {
                this.ViewState["ReadOnly"] = value;
            }
        }


        public string OnClientUploadComplete
        {
            get { return this.AfuFile.OnClientUploadComplete; }
            set { this.AfuFile.OnClientUploadComplete = value; }
        }


        //public Guid? ExistFileID
        //{
        //    get
        //    {
        //        object obj = this.ViewState["ExistFileID"];
        //        if (obj != null)
        //            return (Guid)obj;

        //        return null;
        //    }
        //    set { this.ViewState["ExistFileID"] = value; }
        //}

        //public Guid? FinalFileID
        //{
        //    get
        //    {
        //        Guid? id = this.UploadFileID;
        //        if (id.HasValue) return id;
        //        else return this.ExistFileID;
        //    }
        //}

        public string UpdateUniqueID
        {
            get { return this.BtnFileUpdate.UniqueID; }
        }


        [Category("Server Events")]
        [Bindable(true)]
        public event EventHandler<AjaxControlToolkit.AsyncFileUploadEventArgs> UploadedCompleted;
        [Category("Server Events")]
        [Bindable(true)]
        public event EventHandler ExistFileRemoved;


        protected virtual void OnUploadedCompleted(AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {
            if (UploadedCompleted != null) UploadedCompleted(this, e);
        }

        protected virtual void OnExistFileRemoved(EventArgs e)
        {
            if (ExistFileRemoved != null) ExistFileRemoved(this, e);
        }


        public void SetFile(List<string[]> files)
        {
            SetFile(files, this.ReadOnly);
        }

        public void SetFile(List<string[]> files, bool readOnly)
        {
            this.ReadOnly = readOnly;

            this.RepFiles.DataSource = files;
            this.RepFiles.DataBind();
        }

        public List<Guid> GetFiles()
        {
            List<Guid> files = new List<Guid>();

            foreach (RepeaterItem item in this.RepFiles.Items)
            {
                HtmlInputHidden hiNewFileID = (HtmlInputHidden)item.FindControl("HiNewFileID");

                // 如果有新文件
                if (!String.IsNullOrEmpty(hiNewFileID.Value))
                {
                    files.Add(new Guid(hiNewFileID.Value));
                }
                else
                {
                    HtmlInputHidden hiExistFileID = (HtmlInputHidden)item.FindControl("HiExistFileID");

                    files.Add(new Guid(hiExistFileID.Value));
                }
            }

            return files;
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.InitSessionKey();
            }
        }



        protected void AfuFile_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {
            try
            {
                Guid id = FileDUHelper.UploadAttach(this.AfuFile);

                Session[this.SessionKey] = new object[] {id, this.AfuFile.FileName};

                this.OnUploadedCompleted(e);
            }
            catch (ApplicationException aex)
            {
                throw aex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void BtnFileUpdate_Click(object sender, EventArgs e)
        {
            // 更新
            object[] upload = (object[])Session[this.SessionKey]; Session[this.SessionKey] = null;

            List<string[]> files = new List<string[]>();

            foreach (RepeaterItem item in this.RepFiles.Items)
            {
                HtmlInputHidden hiExistFileID = (HtmlInputHidden)item.FindControl("HiExistFileID");
                HtmlInputHidden hiExistFileTitle = (HtmlInputHidden)item.FindControl("HiExistFileTitle");
                HtmlInputHidden hiExistFileLink = (HtmlInputHidden)item.FindControl("HiExistFileLink");

                HtmlInputHidden hiNewFileID = (HtmlInputHidden)item.FindControl("HiNewFileID");

                // 如果有新文件
                if (!String.IsNullOrEmpty(hiNewFileID.Value))
                {
                    HtmlInputHidden hiNewFileTitle = (HtmlInputHidden)item.FindControl("HiNewFileTitle");
                    HtmlInputHidden hiNewFileLink = (HtmlInputHidden)item.FindControl("HiNewFileLink");

                    files.Add(new string[] { hiExistFileID.Value, hiExistFileTitle.Value, hiExistFileLink.Value, hiNewFileID.Value, hiNewFileTitle.Value, hiNewFileLink.Value });
                }
                else
                {
                    files.Add(new string[] { hiExistFileID.Value, hiExistFileTitle.Value, hiExistFileLink.Value, null, null, null });
                }
            }

            files.Add(new string[] { null, null, null, upload[0].ToString(), upload[1].ToString(), null});

            this.RepFiles.DataSource = files;
            this.RepFiles.DataBind();

            ScriptManager.RegisterStartupScript(this.BtnFileUpdate, this.BtnFileUpdate.GetType(), "PostBack",
    "theForm.__EVENTTARGET.value=null;", true); 

            this.UpFile.Update();
        }

        protected void RepFiles_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                string[] file = (string[])e.Item.DataItem;

                HtmlInputHidden hiExistFileID = (HtmlInputHidden)e.Item.FindControl("HiExistFileID");
                HtmlInputHidden hiExistFileTitle = (HtmlInputHidden)e.Item.FindControl("HiExistFileTitle");
                HtmlInputHidden hiExistFileLink = (HtmlInputHidden)e.Item.FindControl("HiExistFileLink");

                HtmlInputHidden hiNewFileID = (HtmlInputHidden)e.Item.FindControl("HiNewFileID");
                HtmlInputHidden hiNewFileTitle = (HtmlInputHidden)e.Item.FindControl("HiNewFileTitle");
                HtmlInputHidden hiNewFileLink = (HtmlInputHidden)e.Item.FindControl("HiNewFileLink");

                hiExistFileID.Value = file[0];
                hiExistFileTitle.Value = file[1];
                hiExistFileLink.Value = file[2];

                if (file.Length > 3)
                {
                    hiNewFileID.Value = file[3];
                    hiNewFileTitle.Value = file[4];
                    hiNewFileLink.Value = file[5];
                }

                HyperLink hlFile = (HyperLink)e.Item.FindControl("HlFile");
                ConfirmImageButton btnRemove = (ConfirmImageButton)e.Item.FindControl("BtnRemove");

                if (this.ReadOnly)
                {
                    btnRemove.Visible = false;
                    hlFile.Text = file[1];
                    if (ShowFileLink) hlFile.NavigateUrl = file[2];
                }
                else
                {
                    btnRemove.Visible = true;
                    btnRemove.CommandArgument = e.Item.ItemIndex.ToString();

                    // 如果有新文件
                    if (file.Length > 3 && !String.IsNullOrEmpty(file[3]))
                    {
                        hlFile.Text = file[4];
                        hlFile.NavigateUrl = null;
                        btnRemove.ConfirmText = "Reset?";
                    }
                    else
                    {
                        hlFile.Text = file[1];

                        if (ShowFileLink) hlFile.NavigateUrl = file[2];

                        btnRemove.ConfirmText = "Remove?";
                    }
                }
            }
        }

        protected void RepFiles_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Reomve")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                List<string[]> files = new List<string[]>();

                foreach (RepeaterItem item in this.RepFiles.Items)
                {
                    if (item.ItemIndex == index) continue;

                    HtmlInputHidden hiExistFileID = (HtmlInputHidden)item.FindControl("HiExistFileID");
                    HtmlInputHidden hiExistFileTitle = (HtmlInputHidden)item.FindControl("HiExistFileTitle");
                    HtmlInputHidden hiExistFileLink = (HtmlInputHidden)item.FindControl("HiExistFileLink");

                    HtmlInputHidden hiNewFileID = (HtmlInputHidden)item.FindControl("HiNewFileID");

                    // 如果有新文件
                    if (!String.IsNullOrEmpty(hiNewFileID.Value))
                    {
                        HtmlInputHidden hiNewFileTitle = (HtmlInputHidden)item.FindControl("HiNewFileTitle");
                        HtmlInputHidden hiNewFileLink = (HtmlInputHidden)item.FindControl("HiNewFileLink");

                        files.Add(new string[] { hiExistFileID.Value, hiExistFileTitle.Value, hiExistFileLink.Value, hiNewFileID.Value, hiNewFileTitle.Value, hiNewFileLink.Value });
                    }
                    else
                    {
                        files.Add(new string[] { hiExistFileID.Value, hiExistFileTitle.Value, hiExistFileLink.Value, null, null, null });
                    }
                }

                this.RepFiles.DataSource = files;
                this.RepFiles.DataBind();

                this.UpFileAfu.Update();
            }
        }

        

        

        //protected void BtnFileClear_Click(object sender, EventArgs e)
        //{
        //    if (this.HiFile.Value != String.Empty)
        //    {
        //        this.HiFile.Value = null;
        //        if (this.ExistFileID != null)       // 如果原来有文件
        //            this.BtnFileClear.Text = "Remove";
        //        else
        //            this.BtnFileClear.Visible = false;
        //    }
        //    else
        //    {
        //        this.OnExistFileRemoved(e);

        //        this.ExistFileID = null;            // Clear掉原有文件

        //        this.HlFile.Visible = false;
        //        this.BtnFileClear.Visible = false;
        //        this.HiFile.Value = null;

        //    }

        //    // update
        //    this.UpFileAfu.Update();
        //}

    }

}