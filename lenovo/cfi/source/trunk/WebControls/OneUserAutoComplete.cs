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
    [ToolboxData("<{0}:OneUserAutoComplete runat=server></{0}:OneUserAutoComplete>")]
    public class OneUserAutoComplete : TextBox, System.Web.UI.INamingContainer
    {
        public OneUserAutoComplete()
        {}

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
function oacParse(d) {
    return $.map(eval(d), function (row) { return { data: row, value: row, result: row} });
}
");
                    if (this.RegisterScriptFormat) 
                    {
                        sb.Append(@"
function oacFormatItem(data, i, total) { return data; }
function oacFormatMatch(data, i, total) { return data; }
function oacFormatResult(data, value) { return data; }
");

                    }

                    //
                    sb.AppendFormat(@"
function oacProcessResultSucceededCallback(result, userContext) {{
    if (result != null && result.length > 0) {{
        var acInput = userContext[1];
        
        if (result.length >= 1) {{ acInput[0].value = result[0].value;}}
    }}
    else {{ alert(""Invalid Input!""); }}
}}
");

                    //
                    sb.Append(@"
function oacProcessResult(original, acInput) {
");

                    if (!String.IsNullOrEmpty(this.CheckServiceUrl))
                    {
                        sb.AppendFormat("    {0}(original, oacProcessResultSucceededCallback, null, new Array(true, acInput));", this.CheckServiceUrl);
                    }
                    else
                    {
                        sb.AppendFormat(@"    var list = $.map(original.split(""{0}""), function (v) {{ return {{value : v, display : v}} }});
    oacProcessResultSucceededCallback(list, new Array(false, acInput));", this.ValueSeparator);
                    }

                    sb.Append(@"
}");

                    //
                    sb.AppendFormat(@"
function oacDirectInput(acInput) {{
    var result = acInput[0].value;
    if (result != null && result != '') {{
        oacProcessResult(result, acInput);
    }}

    return true;
}}
");

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), this.GetType().ToString(), sb.ToString(), true);
                }

                #endregion
            }


            if (this.RegisterScript && !this.ReadOnly && this.Enabled)
            {
                ScriptManager.RegisterStartupScript(this,
                        this.GetType(), this.ClientID, String.Format(@"
$(document).ready(function () {{
    var acInput = $(""#{0}"");
    acInput.autocomplete(""{2}"", {{
        minChars: {3}, max: {4},
        width: {5}, autoFill: {6},
        scroll: {7}, scrollHeight: {8},
        extraParams: {{{9}}},
        parse: {10}, formatItem: {11},
        formatMatch: {12}, formatResult: {13}
    }}).result(function (event, original, formatted) {{ oacProcessResult(original, acInput); }});

    //acInput.keydown(function () {{ if (event.keyCode == 13) {{ if ({14}(acInput)) event.returnValue = false;}} }});
    acInput.change(function () {{ if ({14}(acInput)) acInput[0].value = ''; }});
}});", 
     this.ClientID, null, this.AcServiceUrl,
     0, 15, 200, false.ToString().ToLower(), false.ToString().ToLower(), 500, "", "oacParse", "oacFormatItem", "oacFormatMatch", "oacFormatResult", "oacDirectInput" // 未来扩展
     ), true);
            }

            
        }
    }
}
