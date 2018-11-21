using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace LKMMVC_1.Models
{
    //nustatymui ar geras failas ikeltas
    public enum SuportedTypes
    {
        Documents,
        Images
    }
    public class FileUpload
    {

        string[] supportedFileTypes;

        public string Message { get; set; }
        public decimal filesize { get; set; }
        public string UploadUserFile(HttpFileCollectionBase file, SuportedTypes suportedTypes)
        {
            try
            {
                if (suportedTypes.Equals(SuportedTypes.Documents))
                {
                    supportedFileTypes = new[] { "txt", "doc", "docx", "pdf", "xls", "xlsx" };
                }
                else
                {
                    supportedFileTypes = new[] { "jpg", "jpeg", "png" };
                }
                for (int i = 0; i < file.Count; i++)
                {

                    var fileExt = Path.GetExtension(file[i].FileName).Substring(1);
                    if (!supportedFileTypes.Contains(fileExt))
                    {
                        Message = "File Extension Is InValid - Only Upload WORD/PDF/EXCEL/TXT File";
                        //Message[0] = "1";
                        return Message;
                    }
                    else if (file[i].ContentLength > (filesize * 1024))
                    {
                        Message = "File size Should Be UpTo " + filesize + "KB";
                        //Message[0] = "1";
                        return Message;
                    }
                    else
                    {
                        Message = "File Is Successfully Uploaded";
                        //Message[0] = "0";
                        return Message;
                    }
                }
            }
            catch (Exception ex)
            {
                Message = "Upload Container Should Not Be Empty or Contact Admin";
                //Message[0] = "1";
                return Message;
            }
            return Message;
        }

    }
}