
using System;

using SecurityDAL;
using InfinigentBackend.SECURITY.SecurityEntity;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Web;

namespace Sundorbon.Backend.SECURITY.SecurityBLL
{
      public class AssetConfigTransactionBLL //: IDisposible
    {
            public AssetConfigTransactionBLL()
            {
            _AssetConfigTransactionDAO = new AssetConfigTransactionDAO();
            }

        public AssetConfigTransactionDAO _AssetConfigTransactionDAO { get; set; }





        public async Task<int> Post(AssetConfigTransaction _Transaction)
        {
            try
            {
               
                if (!string.IsNullOrEmpty(_Transaction.LU_Asset_Config_Photos.ShopImage))
                {
                    _Transaction.LU_Asset_Config_Photos.ShopImage = isAssetAuditImageSaved(_Transaction.LU_Asset_Config_Photos.ShopImage, _Transaction.LU_Asset_Config_Photos.AssetNumber, "ShopImage", "AssetAuditPhotos");

                }
                if (!string.IsNullOrEmpty(_Transaction.LU_Asset_Config_Photos.AssetImage))
                {
                    _Transaction.LU_Asset_Config_Photos.AssetImage = isAssetAuditImageSaved(_Transaction.LU_Asset_Config_Photos.AssetImage, _Transaction.LU_Asset_Config_Photos.AssetNumber, "AssetImage", "AssetAuditPhotos");

                }
                if (!string.IsNullOrEmpty(_Transaction.LU_Asset_Config_Photos.SignImage))
                {
                    _Transaction.LU_Asset_Config_Photos.SignImage = isAssetAuditImageSaved(_Transaction.LU_Asset_Config_Photos.SignImage, _Transaction.LU_Asset_Config_Photos.AssetNumber, "SignImage", "AssetAuditPhotos");

                }
                if (!string.IsNullOrEmpty(_Transaction.LU_Asset_Config_Photos.CoolerImage))
                {
                    _Transaction.LU_Asset_Config_Photos.CoolerImage = isAssetAuditImageSaved(_Transaction.LU_Asset_Config_Photos.CoolerImage, _Transaction.LU_Asset_Config_Photos.AssetNumber, "CoolerImage", "AssetAuditPhotos");

                }

                return await _AssetConfigTransactionDAO.Post(_Transaction);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



       


        public string isAssetAuditImageSaved(String imgBytes, String number, String imageName, String folderName)
        {
            var bytes = Convert.FromBase64String(imgBytes);
            string _imageActualPath = string.Empty;
            string _imagePath = string.Empty;
            using (var ms = new MemoryStream(bytes, 0, bytes.Length))
            {
                Image image = Image.FromStream(ms, true);
                _imagePath = "/" + folderName + "/" + number + "_" + imageName + ".png";
                _imageActualPath = HttpContext.Current.Server.MapPath("~/" + folderName + "/" + number + "_" + imageName + ".png");
                image.Save(_imageActualPath, System.Drawing.Imaging.ImageFormat.Png);

            }
            return _imagePath;
        }




    }






      
        

    

}
