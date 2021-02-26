using Core.Results.Utilities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Business.Concrete
{
    public static class FileOperations
    {
        public static string ImageFolder = "/CarImages/";
        public static string ImagePath = Directory.GetParent(Environment.CurrentDirectory) + @"\CarImages\";
        public static IResult UploadImage(IFormFile resim)
        {

            
            try
            {
                if (resim.Length > 0)
                {
                    if (!Directory.Exists(ImagePath))
                    {
                        Directory.CreateDirectory(ImagePath);
                    }
                    FileInfo f = new FileInfo(ImagePath + resim.FileName);
                    string uzanti = f.Extension;
                    string randomName = Guid.NewGuid().ToString("n");
                    string filePath = ImagePath + randomName + uzanti;
                    using (FileStream fileStream = System.IO.File.Create(filePath))
                    {
                        resim.CopyTo(fileStream);
                        fileStream.Flush();
                    }
                    return new SuccessResult(ImageFolder + randomName + uzanti);

                }
            }
            catch
            {
                return new ErrorResult();
            }
            return null;
        }
        public static IResult DeleteImage(string Path)
        {
            try
            {
                string[] str = Path.Split('/');
                System.IO.File.Delete(ImagePath + str[2]);
                return new SuccessResult();
            }
            catch
            {
                return new ErrorResult();
            }
        }
    }
}
