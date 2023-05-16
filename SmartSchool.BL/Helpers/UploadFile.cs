using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.BL.Helpers
{
    public class UploadFile
    {
        public static string Photo(string photoString, string folderName)
        {
            //Should we add separate folders or not 
            Random rnd = new Random();
            Byte[] bytes = Convert.FromBase64String(photoString);
            string filePath1 = (folderName+"/" + Path.GetFileName(photoString) + rnd.Next() + ".jpg");
            System.IO.File.WriteAllBytes("wwwroot/" + filePath1, bytes);
            photoString = filePath1;
            return photoString;
        }
    }
}
