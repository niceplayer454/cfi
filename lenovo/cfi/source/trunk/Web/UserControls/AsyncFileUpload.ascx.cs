using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;

using Lenovo.CFI.Web.Helper;

namespace Lenovo.CFI.Web.UserControls
{
    public partial class AsyncFileUpload : System.Web.UI.UserControl
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

        public Guid? UploadFileID
        {
            get
            {
                if (!String.IsNullOrEmpty(this.HiFile.Value))
                    return new Guid(this.HiFile.Value);
                return null;
            }
        }

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

        public bool HintVisible
        {
            get
            {
                object obj = this.ViewState["HintVisible"];
                if (obj != null)
                    return (bool)obj;

                return true;
            }
            set
            {
                this.ViewState["HintVisible"] = value;
            }
        }


        public string OnClientUploadComplete
        {
            get { return this.AfuFile.OnClientUploadComplete; }
            set { this.AfuFile.OnClientUploadComplete = value; }
        }


        public Guid? ExistFileID
        {
            get
            {
                object obj = this.ViewState["ExistFileID"];
                if (obj != null)
                    return (Guid)obj;

                return null;
            }
            set { this.ViewState["ExistFileID"] = value; }
        }

        public Guid? FinalFileID
        {
            get
            {
                Guid? id = this.UploadFileID;
                if (id.HasValue) return id;
                else return this.ExistFileID;
            }
        }

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


        public void SetFile(Guid? id, string title, string url)
        {
            SetFile(id, title, url, this.ReadOnly);
        }

        public void SetFile(Guid? id, string title, string url, bool readOnly)
        {
            this.ReadOnly = readOnly;

            this.ExistFileID = id;      // 已有的文件的ID

            if (id.HasValue)
            {
                this.HlFile.Visible = true;
                this.HlFile.Text = title;
                if (ShowFileLink) this.HlFile.NavigateUrl = url;
                else this.HlFile.NavigateUrl = "";

                if (readOnly)
                {
                    this.BtnFileClear.Visible = false;
                    this.AfuFile.Visible = false;
                    this.LtrHint.Visible = false;
                }
                else
                {
                    this.BtnFileClear.Text = "Remove";
                    this.AfuFile.Visible = true;
                    this.LtrHint.Visible = this.HintVisible;
                }
            }
            else
            {
                this.HlFile.Visible = false;
                this.BtnFileClear.Visible = false;

                if (readOnly)
                {
                    this.LtrHint.Visible = false;
                    this.AfuFile.Visible = false;
                }
                else
                {
                    this.LtrHint.Visible = this.HintVisible;
                    this.AfuFile.Visible = true;
                }
            }

            this.HiFile.Value = null;
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

                Session[this.SessionKey] = id;

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
            Guid id = (Guid)Session[this.SessionKey]; Session[this.SessionKey] = null;

            this.HiFile.Value = id.ToString();

            this.BtnFileClear.Visible = true;
            this.BtnFileClear.Text = "Reset";
        }

        protected void BtnFileClear_Click(object sender, EventArgs e)
        {
            if (this.HiFile.Value != String.Empty)
            {
                this.HiFile.Value = null;
                if (this.ExistFileID != null)       // 如果原来有文件
                    this.BtnFileClear.Text = "Remove";
                else
                    this.BtnFileClear.Visible = false;
            }
            else
            {
                this.OnExistFileRemoved(e);

                this.ExistFileID = null;            // Clear掉原有文件

                this.HlFile.Visible = false;
                this.BtnFileClear.Visible = false;
                this.HiFile.Value = null;

            }

            // update
            this.UpFileAfu.Update();
        }

    }
}