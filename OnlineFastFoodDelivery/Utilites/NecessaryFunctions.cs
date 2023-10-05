using Models;
using System.Drawing;
using Microsoft.AspNetCore.Http;

namespace OnlineFastFoodDelivery.Utilites
{
    public class NecessaryFunctions
    {
        //public static readonly List<string> ImageExtensions = new() { ".JPG", ".BMP", ".PNG" };
        //public IFormFile imageFile { get; set; }
        public byte[] ImageSave(byte[] img, IFormFile imageFile)
        {
            
                using var ms = new MemoryStream();
                imageFile.CopyTo(ms);
                byte[] imagebytes = ms.ToArray();
                 img= imagebytes;
                //string base64string = Convert.ToBase64String(imagebytes);
                //user.Image = base64string;
            
            return img;
        }
       
    }
}
