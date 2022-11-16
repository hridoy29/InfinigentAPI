using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
 

namespace InfinigentAPI.Models
{
    public class SaveImages
    {
        public string isImageSaved(TRN_SchemeAuditChild tRN_SchemeAuditChild)
        {
            var bytes = Convert.FromBase64String(tRN_SchemeAuditChild.ImageLocation);
            string _imageActualPath = string.Empty;
            string _imagePath = string.Empty;
            using (var ms = new MemoryStream(bytes, 0, bytes.Length))
            {
                Image image =  Image.FromStream(ms, true);
                _imagePath= "/image/" + tRN_SchemeAuditChild.Number + "_" + tRN_SchemeAuditChild.Id + ".png";
                _imageActualPath = HttpContext.Current.Server.MapPath("~/image/"+ tRN_SchemeAuditChild.Number + "_" + tRN_SchemeAuditChild.Id + ".png");
                image.Save(_imageActualPath, System.Drawing.Imaging.ImageFormat.Png);

            }
            return _imagePath;
        }



        public string isQuestionnaireImageSaved(String imgBytes, String number,String imageName, String folderName)
        {
            var bytes = Convert.FromBase64String(imgBytes);
            string _imageActualPath = string.Empty;
            string _imagePath = string.Empty;
            using (var ms = new MemoryStream(bytes, 0, bytes.Length))
            {
                Image image = Image.FromStream(ms, true);
                _imagePath = "/"+folderName+"/" + number + "_" + imageName + ".png";
                _imageActualPath = HttpContext.Current.Server.MapPath("~/" + folderName + "/" + number + "_" + imageName + ".png");
                image.Save(_imageActualPath, System.Drawing.Imaging.ImageFormat.Png);

            }
            return _imagePath;
        }
    }
}