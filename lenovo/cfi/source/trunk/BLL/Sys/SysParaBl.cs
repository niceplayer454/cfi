using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Lenovo.CFI.Common.Sys;
using Lenovo.CFI.DAL.Sys;

namespace Lenovo.CFI.BLL.Sys
{
    public class SysParaBl
    {
        private const string RC_MAILLIST = "RCMAILLIST";        // RC 固定的收件人
        private const string RC_ATTENDEELIST = "RCATTENDEELIST";// RC 固定参会人
        private const string RC_MAILTEMP = "RCMAILTEMP";        // RC 模板
        private const string QR_EXPLIST = "QREXPLIST";          // QR 导出列列表
        private const string QR_MAILLIST = "QRMAILLIST";        // QR 固定的收件人
        private const string CL_MAILLIST = "CLMAILLIST";        // QR CloseLoop固定的收件人
        private const string SYS_ADMIN = "SYSADMIN";            // 系统管理员
        private const string LE_PROCESSOWNER = "LPROCESSOWNER"; // LL Process Owner
        private const string LE_MAILLIST = "LEMAILLIST";        // LL 固定的收件人
        private const string LE_EXPLIST = "LEEXPLIST";          // QR 导出列列表


        public string GetRcMailList(string bu) 
        {
            return SysParaDa.GetSysPara(RC_MAILLIST, bu);
        }

        public string GetRcAttendeeList(string bu)
        {
            return SysParaDa.GetSysPara(RC_ATTENDEELIST, bu);
        }

        public string GetRcMailTemp(string bu)
        {
            return SysParaDa.GetSysPara(RC_MAILTEMP, bu);
        }

        public string GetQrExpList(string itcode)
        {
            return SysParaDa.GetSysPara(itcode + QR_EXPLIST, null);
        }

        public string GetQrMailList(string bu)
        {
            return SysParaDa.GetSysPara(QR_MAILLIST, bu);
        }

        public string GetQrCloseLoopMailList(string bu)
        {
            return SysParaDa.GetSysPara(CL_MAILLIST, bu);
        }

        public string GetSysAdminList()
        {
            return SysParaDa.GetSysPara(SYS_ADMIN, null);
        }

        public string GetLeMailList(string bu)
        {
            return SysParaDa.GetSysPara(LE_MAILLIST, bu);
        }

        public string GetLeProcessOwner(string bu)
        {
            return SysParaDa.GetSysPara(LE_PROCESSOWNER, bu);
        }

        public string GetLeExpList(string itcode)
        {
            return SysParaDa.GetSysPara(itcode + LE_EXPLIST, null);
        }

        public Dictionary<string, string> GetAllLeProcessOwner()
        {
            return SysParaDa.GetSysParas(LE_PROCESSOWNER);
        }


        public void SaveRcMailList(string bu, string value)
        {
            if (value != null) value = value.ToLower();     // 小写
            SysParaDa.SaveSysPara(RC_MAILLIST, bu, value);
        }

        public void SaveRcAttendeeList(string bu, string value)
        {
            if (value != null) value = value.ToLower();     // 小写
            SysParaDa.SaveSysPara(RC_ATTENDEELIST, bu, value);
        }

        public void SaveRcMailTemp(string bu, string value)
        {
            SysParaDa.SaveSysPara(RC_MAILTEMP, bu, value);
        }

        public void SaveQrExpList(string itcode, string value)
        {
            SysParaDa.SaveSysPara(itcode + QR_EXPLIST, null, value);
        }

        public void SaveQrMailList(string bu, string value)
        {
            if (value != null) value = value.ToLower();     // 小写
            SysParaDa.SaveSysPara(QR_MAILLIST, bu, value);
        }

        public void SaveQrCloseLoopMailList(string bu, string value)
        {
            if (value != null) value = value.ToLower();     // 小写
            SysParaDa.SaveSysPara(CL_MAILLIST, bu, value);
        }

        public void SaveSysAdminList(string value)
        {
            if (value != null) value = value.ToLower();     // 小写
            SysParaDa.SaveSysPara(SYS_ADMIN, null, value);
        }

        public void SaveLeMailList(string bu, string value)
        {
            if (value != null) value = value.ToLower();     // 小写
            SysParaDa.SaveSysPara(LE_MAILLIST, bu, value);
        }

        public void SaveLeProcessOwner(string bu, string value)
        {
            if (value != null) value = value.ToLower();     // 小写
            SysParaDa.SaveSysPara(LE_PROCESSOWNER, bu, value);
        }

        public void SaveLeExpList(string itcode, string value)
        {
            SysParaDa.SaveSysPara(itcode + LE_EXPLIST, null, value);
        }

    }
}
