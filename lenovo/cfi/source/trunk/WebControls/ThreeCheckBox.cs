using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace Lenovo.CFI.WebControls
{
    [ToolboxData("<{0}:ThreeCheckBox runat=server></{0}:ThreeCheckBox>")]
    public class ThreeCheckBox : WebControl, System.Web.UI.INamingContainer
    {
        public ThreeCheckBox()
            : base(HtmlTextWriterTag.Unknown)
        {}

        public string CheckBoxID
        {
            get
            {
                return this.ID + "cb";
            }
        }

        public bool Label
        {
            get 
            {
                object obj = this.ViewState["Label"];
                if (obj == null)
                    return false;
                else
                    return (bool)obj;
            }
            set { this.ViewState["Label"] = value; }
        }

        public string LabelText
        {
            get
            {
                object obj = this.ViewState["LabelText"];
                if (obj == null)
                    return null;
                else
                    return (string)obj;
            }
            set { this.ViewState["LabelText"] = value; }
        }

        private CheckBox cbUsing;
        private HiddenField hiUsing;
        private Label lblUsing;

        protected override void CreateChildControls()
        {
            //Controls.Clear();

            base.CreateChildControls();

            this.cbUsing = new CheckBox();
            this.cbUsing.ID = "cb";
            this.Controls.Add(this.cbUsing);

            this.hiUsing = new HiddenField();
            this.hiUsing.ID = "hi";
            this.Controls.Add(this.hiUsing);

            this.cbUsing.Attributes["onclick"] = String.Format("setusing(this, '{0}');", 
                this.hiUsing.ClientID);

            if (this.Label)
            {
                this.lblUsing = new Label();
                this.lblUsing.ID = "lbl";
                this.lblUsing.Text = LabelText;
                this.lblUsing.AssociatedControlID = this.cbUsing.ID;
                this.Controls.Add(this.lblUsing);
            }

            //ClearChildViewState();
        }

        private bool hiUsingValueChanged = false;
        /// <summary>
        /// 0 using, 1 wfdm, 2 unusing
        /// </summary>
        /// <param name="state"></param>
        public void SetUsingState(int state)
        {
            this.EnsureChildControls();

            if (state == 0)
            {
                this.cbUsing.Checked = true;
                this.hiUsingValueChanged = (this.hiUsing.Value == "1");
                this.hiUsing.Value = "";
            }
            else if (state == 1)
            {
                this.hiUsingValueChanged = (this.hiUsing.Value != "1");
                this.hiUsing.Value = "1";
            }
            else
            {
                this.cbUsing.Checked = false;
                this.hiUsingValueChanged = (this.hiUsing.Value == "1");
                this.hiUsing.Value = "";
            }
        }

        public int GetUsingState()
        {
            if (this.cbUsing.Checked) return 0;
            else if (this.hiUsing.Value == "1") return 1;
            else return 2;
        }

        public override void RenderBeginTag(HtmlTextWriter writer)
        {
        }

        public override void RenderEndTag(HtmlTextWriter writer)
        {
        }

        protected override void RenderContents(HtmlTextWriter writer)
        {
            this.cbUsing.RenderControl(writer);
            this.hiUsing.RenderControl(writer);
            if (this.lblUsing != null) this.lblUsing.RenderControl(writer);
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);


            if (!this.Page.ClientScript.IsClientScriptBlockRegistered("ThreeCheckBox"))
            {
                ScriptManager.RegisterClientScriptBlock(this,
                    this.GetType(), "ThreeCheckBox", @"function setusing(cb, hi) {
    if (!cb.checked) {
        var hiUsing = $(""#"" + hi).get(0);
        if (hiUsing.value == ""1"") {
            cb.checked = false;
            hiUsing.value = """";
        }
        else {
            cb.indeterminate = true;
            hiUsing.value = ""1"";
        }
    }
}", 
                    true);
            }

            if (this.hiUsingValueChanged || this.hiUsing.Value == "1")
            {
                string script = @"$(""#" + this.cbUsing.ClientID + @""").get(0).indeterminate = " + ((hiUsing.Value == "1") ? "true" : "false") + @";";
                ScriptManager.RegisterStartupScript(this, this.GetType(), this.UniqueID, script, true);
            }

            //if (hiUsing.Value == "1")
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), this.UniqueID,
            //        @"$(""#" + this.cbUsing.ClientID + @""").get(0).indeterminate = ""true"";", true);
            //        //@"$(""#" + this.ID + @""").attr(""checked"")", true);
            //}
        }
    }
}
