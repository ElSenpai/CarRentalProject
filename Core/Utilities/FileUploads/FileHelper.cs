using Core.Entities;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Core.Utilities.FileUploads
{
    public class FileHelper

    {
        private static string currentDirectory = Environment.CurrentDirectory + @"\wwwroot";
        private static string path = @"\images\";
        

        public static IResult Add(FileTools file)
        {
            if (file.Files.Length > 0)
            {

               var guidName = Guid.NewGuid().ToString();
              var  type = Path.GetExtension(file.Files.FileName);
                
                using (FileStream filestream = File.Create(currentDirectory + path + guidName + type))
                {

                    file.Files.CopyTo(filestream);
                    filestream.Flush();

                }
                return new SuccessResult((guidName + type));
            }
            return new ErrorResult();

        }
        public static IResult Delete(string file)
        {

            File.Delete((currentDirectory + path + file));

            return new SuccessResult();


        }
        public static IResult Update(FileTools file, string imagePath)
        {

            if (file.Files.Length > 0)
            {
               var guidName = Guid.NewGuid().ToString();
               var type = Path.GetExtension(file.Files.FileName);
                FileHelper.Delete(imagePath);
                FileHelper.Add(file);
                
                return new SuccessResult((guidName + type));
            }
            return new ErrorResult();
        }

    }
}
