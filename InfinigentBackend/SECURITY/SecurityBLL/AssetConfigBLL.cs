
using System;

using SecurityDAL;
using InfinigentBackend.SECURITY.SecurityEntity;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Web;

namespace Sundorbon.Backend.SECURITY.SecurityBLL
{
      public class AssetConfigBLL //: IDisposible
    {
            public AssetConfigBLL()
            {
            //ad_BankDAO = ad_Bank.GetInstanceThreadSafe;
            _AssetConfigDAO = new AssetConfigDAO();
            }

        public AssetConfigDAO _AssetConfigDAO { get; set; }





      

        public async Task<List<LU_Asset_Config>> GetAssetConfigs()
        {
            try
            {
                return await _AssetConfigDAO.GetAssetConfigs();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<int> PostAssetConfigs(AssetConfigTransaction assetConfigTransaction)
        {
            try
            {
                if (!string.IsNullOrEmpty(assetConfigTransaction.LU_Asset_Config_Photos.AssetImage))
                {
                    Random r = new Random();
                    var imageName = r.Next(int.MaxValue);
                    assetConfigTransaction.LU_Asset_Config_Photos.AssetImage= isAssetConfigImageSaved(assetConfigTransaction.LU_Asset_Config_Photos.AssetImage, imageName.ToString(), "AssetImage", "AssetAuditPhotos");
                }
                if (!string.IsNullOrEmpty(assetConfigTransaction.LU_Asset_Config_Photos.CoolerImage))
                {
                    Random r = new Random();
                    var imageName = r.Next(int.MaxValue);
                    assetConfigTransaction.LU_Asset_Config_Photos.CoolerImage = isAssetConfigImageSaved(assetConfigTransaction.LU_Asset_Config_Photos.CoolerImage, imageName.ToString(), "CoolerImage", "AssetAuditPhotos");  
                }
                if (!string.IsNullOrEmpty(assetConfigTransaction.LU_Asset_Config_Photos.ShopImage))
                {
                    Random r = new Random();
                    var imageName = r.Next(int.MaxValue);
                    assetConfigTransaction.LU_Asset_Config_Photos.ShopImage = isAssetConfigImageSaved(assetConfigTransaction.LU_Asset_Config_Photos.ShopImage, imageName.ToString(), "ShopImage", "AssetAuditPhotos"); 
                }
                if (!string.IsNullOrEmpty(assetConfigTransaction.LU_Asset_Config_Photos.SignImage))
                {
                    Random r = new Random();
                    var imageName = r.Next(int.MaxValue);
                    assetConfigTransaction.LU_Asset_Config_Photos.SignImage = isAssetConfigImageSaved(assetConfigTransaction.LU_Asset_Config_Photos.SignImage, imageName.ToString(), "SignImage", "AssetAuditPhotos");
                }

                return await _AssetConfigDAO.PostAssetConfigs(assetConfigTransaction);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string isAssetConfigImageSaved(String imgBytes, String number, String imageName, String folderName)
        {
            var bytesimg = Convert.FromBase64String(imgBytes);
            MemoryStream ms = new MemoryStream(bytesimg);
            try
            {
                using (FileStream file = new FileStream(HttpContext.Current.Server.MapPath("~/AssetAuditPhotos/" + number + "_" + imageName + ".png"), FileMode.Create, System.IO.FileAccess.Write))
                {
                    byte[] bytes = new byte[ms.Length];
                    ms.Read(bytes, 0, (int)ms.Length);
                    file.Write(bytes, 0, bytes.Length);
                    ms.Close();
                    var imagePath = "/Content/" + number + "_" + imageName + ".png";
                    return imagePath;
                }
            }
            catch (Exception ex)
            {
                return "Not saved";
            }
        }
    }


      
        

    

}
