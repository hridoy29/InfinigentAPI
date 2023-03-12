
using System;

using SecurityDAL;
using InfinigentBackend.SECURITY.SecurityEntity;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Web;

namespace Sundorbon.Backend.SECURITY.SecurityBLL
{
      public class AssetAuditTransactionBLL //: IDisposible
    {
            public AssetAuditTransactionBLL()
            {
            _AssetAuditTransactionDAO = new AssetAuditTransactionDAO();
            }

        public AssetAuditTransactionDAO _AssetAuditTransactionDAO { get; set; }





        public async Task<int> Post(AssetAuditTransaction _Transaction)
        {
            try
            {
               
                if (!string.IsNullOrEmpty(_Transaction.TRN_AssetAuditPhotos.ShopImage))
                {
                    _Transaction.TRN_AssetAuditPhotos.ShopImage = isAssetAuditImageSaved(_Transaction.TRN_AssetAuditPhotos.ShopImage, _Transaction.TRN_AssetAuditPhotos.Number, "ShopImage", "AssetAuditPhotos");

                }
                if (!string.IsNullOrEmpty(_Transaction.TRN_AssetAuditPhotos.AssetImage))
                {
                    _Transaction.TRN_AssetAuditPhotos.AssetImage = isAssetAuditImageSaved(_Transaction.TRN_AssetAuditPhotos.AssetImage, _Transaction.TRN_AssetAuditPhotos.Number, "AssetImage", "AssetAuditPhotos");

                }
                if (!string.IsNullOrEmpty(_Transaction.TRN_AssetAuditPhotos.SignImage))
                {
                    _Transaction.TRN_AssetAuditPhotos.SignImage = isAssetAuditImageSaved(_Transaction.TRN_AssetAuditPhotos.SignImage, _Transaction.TRN_AssetAuditPhotos.Number, "SignImage", "AssetAuditPhotos");

                }

                return await _AssetAuditTransactionDAO.Post(_Transaction);
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
