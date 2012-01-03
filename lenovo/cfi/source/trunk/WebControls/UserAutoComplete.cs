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
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:UserAutoComplete runat=server></{0}:UserAutoComplete>")]
    public class UserAutoComplete : WebControl, System.Web.UI.INamingContainer
    {
        public UserAutoComplete()
            : base(HtmlTextWriterTag.Input)
        {}

        public bool ReadOnly
        {
            get
            {
                object obj = this.ViewState["ReadOnly"];
                if (obj == null)
                    return false;
                else
                    return (bool)obj;
            }

            set
            {
                ViewState["ReadOnly"] = value;
            }
        }

        public bool AppendAsEmail
        {
            get
            {
                object obj = this.ViewState["AppendAsEmail"];
                if (obj == null)
                    return false;
                else
                    return (bool)obj;
            }

            set
            {
                ViewState["AppendAsEmail"] = value;
            }
        }


        public bool RegisterScript
        {
            get
            {
                object obj = this.ViewState["RegisterScript"];
                if (obj == null)
                    return true;
                else
                    return (bool)obj;
            }

            set
            {
                ViewState["RegisterScript"] = value;
            }
        }

        public bool RegisterScriptCommon
        {
            get
            {
                object obj = this.ViewState["RegisterScriptCommon"];
                if (obj == null)
                    return true;
                else
                    return (bool)obj;
            }

            set
            {
                ViewState["RegisterScriptCommon"] = value;
            }
        }

        public bool RegisterScriptFormat
        {
            get
            {
                object obj = this.ViewState["RegisterScriptFormat"];
                if (obj == null)
                    return true;
                else
                    return (bool)obj;
            }

            set
            {
                ViewState["RegisterScriptFormat"] = value;
            }
        }

        public int MaxCount
        {
            get
            {
                object obj = this.ViewState["MaxCount"];
                if (obj == null)
                    return 1;
                else
                    return (int)obj;
            }

            set
            {
                ViewState["MaxCount"] = value;
            }
        }

        public string AcServiceUrl
        {
            get
            {
                String s = (String)ViewState["AcServiceUrl"];
                return ((s == null) ? "/" : s);
            }

            set
            {
                ViewState["AcServiceUrl"] = value;
            }
        }

        // 如果要检测输入
        public string CheckServiceUrl
        {
            get
            {
                String s = (String)ViewState["CheckServiceUrl"];
                return ((s == null) ? String.Empty : s);
            }

            set
            {
                ViewState["CheckServiceUrl"] = value;
            }
        }

        // 默认;
        public string ValueSeparator
        {
            get
            {
                String s = (String)ViewState["ValueSeparator"];
                return ((s == null) ? ";" : s);
            }

            set
            {
                ViewState["ValueSeparator"] = value;
            }
        }

        public string OuterClientID
        {
            get { return this.ClientID + this.ClientIDSeparator + "Outer"; }
        }

        public string InnerClientID
        {
            get { return this.ClientID + this.ClientIDSeparator + "Inner"; }
        }

        public string ValueClientID
        {
            get { return this.hidden.ClientID; }
        }


        public string Value
        {
            get { return this.hidden.Value; }
            set { this.hidden.Value = value; }
        }


        public string GetJsInitFunction(bool check)
        {
            return String.Format("acInitDisplay{0}({1})", this.ClientID, check ? "true" : "false");
        }

        public string GetJsInitFunction(string values, bool check)
        {
            return String.Format("acInitDisplayByValues{0}('{1}', {2})", this.ClientID, values, check ? "true" : "false");
        }

        private HiddenField hidden = new HiddenField();

        protected override void CreateChildControls()
        {
            //Controls.Clear();

            base.CreateChildControls();

            //this.hidden = new HiddenField();
            this.hidden.ID = "value";
            this.Controls.Add(this.hidden);
        }


        public override void RenderBeginTag(HtmlTextWriter writer)
        {
            writer.AddAttribute(HtmlTextWriterAttribute.Id, this.OuterClientID);
            if (!this.Enabled)
                writer.AddAttribute(HtmlTextWriterAttribute.Class, this.CssClass + " " + this.CssClass + "_Disabled");
            else if (this.ReadOnly)
                writer.AddAttribute(HtmlTextWriterAttribute.Class, this.CssClass + " " + this.CssClass + "_ReadOnly");
            else
                writer.AddAttribute(HtmlTextWriterAttribute.Class, this.CssClass);

            if (!this.Width.IsEmpty)
                writer.AddStyleAttribute(HtmlTextWriterStyle.Width, this.Width.ToString());
            foreach (string key in this.Attributes.Keys) writer.AddAttribute(key, this.Attributes[key]);
            writer.RenderBeginTag(HtmlTextWriterTag.Div);
        }

        public override void RenderEndTag(HtmlTextWriter writer)
        {
            writer.RenderEndTag();
        }

        protected override void RenderContents(HtmlTextWriter writer)
        {
            writer.AddAttribute(HtmlTextWriterAttribute.Id, this.InnerClientID);
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "inner");
            writer.RenderBeginTag(HtmlTextWriterTag.Div);


            writer.AddAttribute(HtmlTextWriterAttribute.Id, this.ClientID);
            writer.AddAttribute(HtmlTextWriterAttribute.Name, this.UniqueID);
            writer.AddAttribute(HtmlTextWriterAttribute.Title, this.ToolTip);
            writer.AddAttribute(HtmlTextWriterAttribute.Class, "input");
            if (!this.Enabled)
                writer.AddAttribute(HtmlTextWriterAttribute.Disabled, "disabled");
            else if (this.ReadOnly)
                writer.AddAttribute(HtmlTextWriterAttribute.ReadOnly, "readonly");
            writer.RenderBeginTag(HtmlTextWriterTag.Input);
            writer.RenderEndTag();

            writer.RenderEndTag();

            this.hidden.RenderControl(writer);
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            if (this.RegisterScriptCommon)
            {
                #region Common

                if (!this.Page.ClientScript.IsClientScriptBlockRegistered(this.GetType().ToString()))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(@"
function acParse(d) {
    return $.map(eval(d), function (row) { return { data: row, value: row, result: row} });
}
");
                    if (this.RegisterScriptFormat) 
                    {
                        sb.Append(@"
function acFormatItem(data, i, total) { return data; }
function acFormatMatch(data, i, total) { return data; }
function acFormatResult(data, value) { return data; }
");

                    }
                    //
                    sb.AppendFormat(@"function acRemoveValue(element, original, acValue) {{
    $(element).remove();
    var exist = acValue[0].value.split('{0}'); 
    var index = $.inArray(original.toString(), exist);
    if (index != -1) {{
        exist.splice(index, 1);
        acValue[0].value = exist.join('{0}');
    }}
}}
", this.ValueSeparator);
                    //
                    sb.AppendFormat(@"
function acCreateValue(value, display, acValue, email) {{
    if (value == null || value == '') return null;

    var valuespan = $(['<span class=""{1}"" title=""{0}"" value=""', value, '"">', display, (email == true) ? '@lenovo.com' : '' ,'{3} </span>'].join(''));
    valuespan.hover(function () {{ $(this).addClass('{2}'); }}, function () {{ $(this).removeClass('{2}'); }});
    valuespan.keydown(function () {{ if (event.keyCode == 8 || event.keyCode == 46) {{ acRemoveValue(this,value,acValue); }} event.returnValue = false; }});   // 8 backspace; 46 delete 

    return valuespan;
}}
", "remove by Backspace or Delete key", "value", "valuehover", this.ValueSeparator);
                    // TODO:ReadOnly -- 不删除

                    //
                    sb.AppendFormat(@"
function acProcessResultSucceededCallback(result, userContext) {{
    if (result != null && result.length > 0) {{
        var acInput = userContext[1];
        var acValue = userContext[2];
        var email = userContext[3];

        $.each(result, function () {{
            var exist = acValue[0].value.split(""{0}"");
            if (this.value != '') {{ 
                if ($.inArray(this.value, exist) != -1) {{ alert(this.value + "" Exist!""); }}
                else {{
                    if ({1} == 0 || exist[exist.length-1] != '' && exist.length < {1} || exist.length - 1 < {1}) {{
                        var valuespan = acCreateValue(this.value, this.display, acValue, email);
                        if (valuespan != null) {{
                            valuespan.insertBefore(acInput);

                            acValue[0].value = acValue[0].value + (this.value + ""{0}"");
                        }}
                    }}
                    else {{ alert(""Maximum Count Limitation!""); }}
                }}
            }}
        }});
    }}
    else {{ alert(""Invalid Input!""); }}
}}
", this.ValueSeparator, this.MaxCount);     // TODO:多个控件值不同时，是一个潜在的问题

                    //
                    sb.Append(@"
function acProcessResult(original, acInput, acValue, email, checkServiceUrl) {
    acInput[0].value = """"; // clear
");

                    if (!String.IsNullOrEmpty(this.CheckServiceUrl))
                    {
                        sb.AppendFormat("    checkServiceUrl(original, acProcessResultSucceededCallback, null, new Array(true, acInput, acValue, email));");
                        //sb.AppendFormat("    {0}(original, acProcessResultSucceededCallback, null, new Array(true, acInput, acValue, email));", this.CheckServiceUrl);
                    }
                    else
                    {
                        sb.AppendFormat(@"    var list = $.map(original.split(""{0}""), function (v) {{ return {{value : v, display : v}} }});
    acProcessResultSucceededCallback(list, new Array(false, acInput, acValue, email));", this.ValueSeparator);
                    }

                    sb.Append(@"
}");

                    //
                    sb.AppendFormat(@"
function acDirectInput(acInput, acValue, email, checkServiceUrl) {{
    var result = acInput[0].value;
    if (result != null && result != '') {{
        acProcessResult(result, acInput, acValue, email, checkServiceUrl);
    }}

    return true;
}}
", this.CheckServiceUrl);

                    //
                    sb.AppendFormat(@"
function acInitDisplayByValues(values, check, acInputID, acValueID, acInnerID) {{
    var acInput = $(""#"" + acInputID);
    var acValue = $(""#"" + acValueID);

    acValue[0].value = """";

    $.each($('#' + acInnerID + ' span'), function () {{ $(this).remove(); }});

    if (values != null && values != '') {{
        if (check) {{
            acProcessResult(values, acInput, acValue, {1}, {2});
        }}
        else {{
            var list = $.map(values.split(""{0}""), function (v) {{ return {{value : v, display : v}} }});
            acProcessResultSucceededCallback(list, new Array(false, acInput, acValue));
        }}
    }}
}}
", this.ValueSeparator, this.AppendAsEmail.ToString().ToLower(), this.CheckServiceUrl);

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), this.GetType().ToString(), sb.ToString(), true);
                }

                #endregion
            }

            if (!this.Page.ClientScript.IsClientScriptBlockRegistered(this.ClientID))
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendFormat(@"
function acInitDisplay{0}(check) {{
    acInitDisplayByValues($(""#{1}"")[0].value, check, ""{0}"", ""{1}"", ""{2}"");
}}
function acInitDisplayByValues{0}(values, check) {{
    acInitDisplayByValues(values, check, ""{0}"", ""{1}"", ""{2}"");
}}
", this.ClientID, this.hidden.ClientID, this.InnerClientID);

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), this.ClientID, sb.ToString(), true);
            }

            if (this.RegisterScript && !this.ReadOnly && this.Enabled)
            {
                ScriptManager.RegisterStartupScript(this,
                        this.GetType(), this.ClientID, String.Format(@"
$(document).ready(function () {{
    var acInput = $(""#{0}"");
    var acValue = $(""#{1}"");
    acInput.autocomplete(""{2}"", {{
        minChars: {3}, max: {4},
        width: {5}, autoFill: {6},
        scroll: {7}, scrollHeight: {8},
        extraParams: {{{9}}},
        parse: {10}, formatItem: {11},
        formatMatch: {12}, formatResult: {13}
    }}).result(function (event, original, formatted) {{ acProcessResult(original, acInput, acValue, {15}, {16}); }});

    acInput.keydown(function () {{ if (event.keyCode == 13) {{ if ({14}(acInput, acValue, {15}, {16})) event.returnValue = false;}} }});
}});", 
     this.ClientID, this.hidden.ClientID, this.AcServiceUrl,
     0, 15, 200, false.ToString().ToLower(), false.ToString().ToLower(), 500, "", "acParse", "acFormatItem", "acFormatMatch", "acFormatResult", "acDirectInput", // 未来扩展
     this.AppendAsEmail.ToString().ToLower(), this.CheckServiceUrl
     ), true);
            }

            
        }
    }
}
