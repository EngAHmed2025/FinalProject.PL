using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace FinalProject.PL.Helpers
{
    public class DocumentSettings
    {
        public static string UploadFile(IFormFile file, string folderName)
        {
            //string folderPath = Directory.GetCurrentDirectory() + "WWWroot\\Files" + folderName;
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot\\Files"+ folderName);
            string fileName = $"{Guid.NewGuid()}{file.FileName}";
            string filePath = Path.Combine(folderPath, fileName);
          using var fileStream = new FileStream(filePath,FileMode.Create);
            file.CopyTo(fileStream);
            return fileName;
        }

        public static void DeleteFile(String fileName, string folderName)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot\\Files", folderName,fileName);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

        }
    }
}
