using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;

namespace Lenovo.CFI.Web.WS
{
    public class SuggestUser
    {
        public string value = "";
        public string display = "";
    }

    /// <summary>
    /// Summary description for AjaxUser
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    [GenerateScriptType(typeof(SuggestUser))]
    public class AjaxUser : System.Web.Services.WebService
    {
        [WebMethod(true)]
        public SuggestUser[] CheckItCodesOrEmail(string codes)
        {
            List<SuggestUser> sus = new List<SuggestUser>();

            string[] codesArr = codes.ToLower().Split(new string[] { ";", "\r", "\n", "；", "," }, StringSplitOptions.RemoveEmptyEntries);

            int i = 0;
            while (i < codesArr.Length)
            {
                if (codesArr[i].Contains("@"))
                {
                    SuggestUser su = new WS.SuggestUser();
                    su.value = codesArr[i];
                    su.display = codesArr[i];
                    sus.Add(su);
                }
                else
                {
                    SuggestUser su = new WS.SuggestUser();
                    su.value = codesArr[i] + "@lenovo.com";
                    su.display = codesArr[i] + "@lenovo.com";
                    sus.Add(su);
                }

                i++;
            }

            return sus.ToArray();
        }
    }
}