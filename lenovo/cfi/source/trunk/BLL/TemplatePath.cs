using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lenovo.CFI.BLL
{
    public class TemplatePath
    {
        public static string ExcelTemplate()
        {
            return System.Configuration.ConfigurationManager.AppSettings["ExcelTemplate"];
        }

        public const string DefaultEwgMeeting = "EWG Meeting Minutes.xls";

        public const string DefaultRcMeeting = "Rollcall Meeting Minutes.xls";

        public const string DefaultQrList = "Quality Report List.xls";

        public const string DefaultQrTracking = "Quality Report Tracking.xls";

        public const string DefaultQrReport = "Quality Report.xls";

    }
}
