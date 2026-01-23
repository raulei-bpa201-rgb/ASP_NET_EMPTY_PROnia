
using Microsoft.AspNetCore.Http;
using System.Drawing;
using WebApplicationTASK14.Models;
using WebApplicationTASK14.Utilites.Enums;

namespace WebApplicationTASK14.Utilites.Extensions
{
    public static class Validator
    {
        public static bool ValidationType(this IFormFile formFile,string type)
        {
            if (!formFile.ContentType.Contains(type))
            {
                return true;
            }

            return false;
        }

        public static bool ValidationSize(this IFormFile formFile,FileSize fileSize,int size)
        {
            switch (fileSize)
            {
                case FileSize.KB:
                    return formFile.Length > size * 1024;
                case FileSize.MB:
                    return formFile.Length > size * 1024 * 1024;
                case FileSize.GB:
                    return formFile.Length > size * 1024 * 1024 * 1024;
            }

            return false;
        }

        public async static Task<string> CreateFile(this IFormFile formFile,params string[] roots)
        {
            string fileimage = String.Concat(Guid.NewGuid(), formFile.FileName);

            string path = string.Empty;

            for (int i=0;i <roots.Length;i++)
            {
                path = Path.Combine(path, roots[i]);
            }

            path = Path.Combine(path, fileimage);

            using (FileStream fileStream = new FileStream(path,FileMode.Create))
            {
                await formFile.CopyToAsync(fileStream);
                fileStream.Close();
            }

                
            return fileimage;
        }


        public async static void DeleteFile(this string FileName, params string[] roots)
        {

            string path = string.Empty;

            for (int i = 0; i < roots.Length; i++)
            {
                path = Path.Combine(path, roots[i]);
            }

            path = Path.Combine(path, FileName);

            System.IO.File.Delete(path);
        }
    }
}
