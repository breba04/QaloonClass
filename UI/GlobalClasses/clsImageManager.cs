using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using static UI.GlobalClasses.clsImageManager;

namespace UI.GlobalClasses
{
    public class clsImageManager
    {
        public enum enImageFolder { Student =1 ,Users =2}
        static public string StudentsImageFolder = ConfigurationManager.AppSettings.Get("Student_Image");
        static public string UsersImageFolder = ConfigurationManager.AppSettings.Get("Users_Image");
        static public string GetImagePath(string ImageName,enImageFolder type)
        {
            string ImageFolder = (type == enImageFolder.Student ? StudentsImageFolder : UsersImageFolder);
            return (string.IsNullOrEmpty(ImageFolder)||string.IsNullOrEmpty(ImageName) ? null : Path.Combine(ImageFolder, ImageName));
        }

        static public bool ReplaceImage(string SourceFile, string OldImageName,out string NewImageName,out string ErroeMessage ,enImageFolder type = enImageFolder.Student)
        {
            NewImageName = ErroeMessage = null;
            string ImageFolder = (type == enImageFolder.Student ? StudentsImageFolder : UsersImageFolder);
            if (!string.IsNullOrEmpty(OldImageName))
            {
                string OldImagePath = Path.Combine(ImageFolder, OldImageName);
                if (!DeleteFile(OldImagePath, ref ErroeMessage)) return false;
            }
            if (string.IsNullOrEmpty(SourceFile))
                return true;
            return SaveImage(SourceFile,  ImageFolder, out NewImageName, ref ErroeMessage);
        }
        static public bool SaveImage(string SourceFile, string ImageFolder, out string NewImageName,ref string ErroeMessage)
        {
            NewImageName = null;
            if (!string.IsNullOrEmpty(SourceFile))
            {
                string GUIDName = Guid.NewGuid().ToString() + Path.GetExtension(SourceFile);
                string destFileName = Path.Combine(ImageFolder, GUIDName);
                if (!CopyFileFromTo(SourceFile, destFileName, ref ErroeMessage)) return false;
                NewImageName = GUIDName;
            }
            return true;
        }
        static private bool CopyFileFromTo(string SourceFile, string destFileName, ref string ErrorMessage)
        {
            if (!File.Exists(SourceFile))
            {
                ErrorMessage = "الملف المصدر غير موجود";
                return false;
            }
            string destPath = Path.GetDirectoryName(destFileName);
            if (!Directory.Exists(destPath))
                Directory.CreateDirectory(destPath);
            try
            {
                File.Copy(SourceFile, destFileName);
            }
            catch (IOException ex)
            {
                ErrorMessage = ex.Message;
                return false;
            }
            return true;
        }
        static private bool DeleteFile(string Path, ref string ErrorMessage)
        {
            if (string.IsNullOrEmpty(Path) || !File.Exists(Path)) return true;
            try
            {
                File.Delete(Path);
            }
            catch (IOException ex)
            {
                ErrorMessage = ex.Message;
                return false;
            }
            return true;
        }
    }
}
