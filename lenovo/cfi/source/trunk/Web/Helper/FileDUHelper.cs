using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.IO;

using Lenovo.CFI.Common;
using Lenovo.CFI.BLL.Sys;
using AjaxControlToolkit;

namespace Lenovo.CFI.Web.Helper
{
    public class FileDUHelper
    {
        public static void Download(string name, string file)
        {
            HttpContext.Current.Response.AddHeader("Content-Type", MimeTypesHelper.GetMimeType(Path.GetExtension(file)));
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" +
                HttpUtility.UrlEncode(name, System.Text.Encoding.UTF8).Replace("+", "%20"));
            HttpContext.Current.Response.BinaryWrite(System.IO.File.ReadAllBytes(file));
            HttpContext.Current.Response.End(); // TODO:加还是不加？是不是加了以后报错？
        }

        public static void Download(string content, string name, string extension)
        {
            HttpContext.Current.Response.AddHeader("Content-Type", MimeTypesHelper.GetMimeType(extension));
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" +
                HttpUtility.UrlEncode(name, System.Text.Encoding.UTF8).Replace("+", "%20"));
            HttpContext.Current.Response.Write(content);
            HttpContext.Current.Response.End(); // TODO:加还是不加？是不是加了以后报错？
        }


        public static Guid UploadAttach(FileUpload fu)
        {
            if (!fu.HasFile || fu.FileName.Length == 0)
            {
                throw new BusinessObjectLogicException("Please select upload file!");
            }

            string path = null;
            try
            {
                string subDirectory = DateTime.Now.ToString("yyyyMM") + Path.DirectorySeparatorChar + DateTime.Now.ToString("dd");
                string directory = System.Configuration.ConfigurationManager.AppSettings["File"] + subDirectory;

                if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);

                string title = Path.GetFileNameWithoutExtension(fu.FileName);
                string ext = Path.GetExtension(fu.FileName);

                path = Path.DirectorySeparatorChar + Path.GetRandomFileName() + ext;

                fu.SaveAs(directory + path);


                Attachment attach = new Attachment(UserHelper.UserName);
                attach.Title = title;
                attach.Path = subDirectory + path;

                new AttachmentBl().AddAttach(attach);

                return attach.UID;
            }
            catch
            {
                throw new BusinessObjectLogicException("File upload fail!");
            }
        }

        public static Guid UploadAttach(AsyncFileUpload fu)
        {
            if (!fu.HasFile || fu.FileName.Length == 0)
            {
                throw new BusinessObjectLogicException("Please select upload file!");
            }

            string path = null;
            try
            {
                string subDirectory = DateTime.Now.ToString("yyyyMM") + Path.DirectorySeparatorChar + DateTime.Now.ToString("dd");
                string directory = System.Configuration.ConfigurationManager.AppSettings["File"] + subDirectory;

                if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);

                string title = Path.GetFileName(fu.FileName);
                string ext = Path.GetExtension(fu.FileName);

                path = Path.DirectorySeparatorChar + Path.GetRandomFileName() + ext;

                fu.SaveAs(directory + path);


                Attachment attach = new Attachment(UserHelper.UserName);
                attach.Title = title;
                attach.Path = subDirectory + path;

                new AttachmentBl().AddAttach(attach);

                return attach.UID;
            }
            catch
            {
                throw new BusinessObjectLogicException("File upload fail!");
            }
        }

    }
}
