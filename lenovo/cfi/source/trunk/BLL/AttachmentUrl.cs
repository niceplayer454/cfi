using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lenovo.CFI.BLL
{
    public class AttachmentUrl
    {
        public static string GetQrFileUrl(int reportID, Guid id, bool withRoot)
        {
            return String.Format("{2}QrFile.aspx?t=aaa&rid={0}&id={1}", reportID, id, withRoot ? "~/" : "");
        }


        public static string GetRcFileUrl(int meetingID, Guid id, bool withRoot)
        {
            return String.Format("{2}RcFile.aspx?mid={0}&id={1}", meetingID, id, withRoot ? "~/" : "");
        }



        public static string GetEwgFileUrl_Init(int projID, Guid id, bool withRoot)
        {
            return String.Format("{2}EwgFile.aspx?t=caa&projid={0}&id={1}", projID, id, withRoot ? "~/" : "");
        }

        public static string GetEwgFileUrl_InitIssue(int projID, Guid id, bool withRoot)
        {
            return String.Format("{2}EwgFile.aspx?t=cab&projid={0}&id={1}", projID, id, withRoot ? "~/" : "");
        }

        public static string GetEwgFileUrl_Meeting(int meetingID, Guid id, bool withRoot)
        {
            return String.Format("{2}EwgFile.aspx?t=cae&meeting={0}&id={1}", meetingID, id, withRoot ? "~/" : "");
        }

        public static string GetEwgFileUrl_MeetingWi(int meetingID, Guid id, bool withRoot)
        {
            return String.Format("{2}EwgFile.aspx?t=caf&meeting={0}&id={1}", meetingID, id, withRoot ? "~/" : "");
        }

        public static string GetEwgFileUrl_MeetingTrackSit(int meetingID, Guid id, bool withRoot)
        {
            return String.Format("{2}EwgFile.aspx?t=cag&meeting={0}&id={1}", meetingID, id, withRoot ? "~/" : "");
        }

        public static string GetEwgFileUrl_Folder(int projID, Guid id, bool withRoot)
        {
            return String.Format("{2}EwgFile.aspx?t=cah&projid={0}&id={1}", projID, id, withRoot ? "~/" : "");
        }


        public static string GetLeFileUrl(int caseID, Guid id, bool withRoot)
        {
            return String.Format("{2}LeFile.aspx?t=aaa&cid={0}&id={1}", caseID, id, withRoot ? "~/" : "");
        }

        public static string GetLeActionFileUrl(int caseID, Guid id, bool withRoot)
        {
            return String.Format("{2}LeFile.aspx?t=bbb&cid={0}&id={1}", caseID, id, withRoot ? "~/" : "");
        }
    }
}
