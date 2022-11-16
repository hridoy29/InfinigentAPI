
using System;

using SecurityDAL;
using InfinigentBackend.SECURITY.SecurityEntity;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Web;

namespace Sundorbon.Backend.SECURITY.SecurityBLL
{
      public class QuestionnaireTransactionBLL //: IDisposible
    {
            public QuestionnaireTransactionBLL()
            {
            _QuestionnaireTransactionDAO = new QuestionnaireTransactionDAO();
            }

        public QuestionnaireTransactionDAO _QuestionnaireTransactionDAO { get; set; }





        public async Task<int> Post(QuestionnaireTransaction _Transaction)
        {
            try
            {
               
                if (!string.IsNullOrEmpty(_Transaction.TRN_QuestionnaireDetails.DayCloseImage))
                {
                    _Transaction.TRN_QuestionnaireDetails.DayCloseImage = isQuestionnaireImageSaved(_Transaction.TRN_QuestionnaireDetails.DayCloseImage, _Transaction.TRN_QuestionnaireDetails.Number, "DayCloseImage", "QDImage");

                }
                if (!string.IsNullOrEmpty(_Transaction.TRN_QuestionnaireDetails.LogoImage))
                {
                    _Transaction.TRN_QuestionnaireDetails.LogoImage = isQuestionnaireImageSaved(_Transaction.TRN_QuestionnaireDetails.LogoImage, _Transaction.TRN_QuestionnaireDetails.Number, "LogoImage", "QDImage");

                }
                if (!string.IsNullOrEmpty(_Transaction.TRN_QuestionnaireDetails.GitImage))
                {
                    _Transaction.TRN_QuestionnaireDetails.GitImage = isQuestionnaireImageSaved(_Transaction.TRN_QuestionnaireDetails.GitImage, _Transaction.TRN_QuestionnaireDetails.Number, "GitImage", "QDImage");

                }
                if (!string.IsNullOrEmpty(_Transaction.TRN_QuestionnaireDetails.MemoImage) )
                {
                    _Transaction.TRN_QuestionnaireDetails.MemoImage = isQuestionnaireImageSaved(_Transaction.TRN_QuestionnaireDetails.MemoImage, _Transaction.TRN_QuestionnaireDetails.Number, "MemoImage", "QDImage");

                }



                foreach (InfinigentBackend.SECURITY.SecurityEntity.TRN_QuestionnaireHyginePhotos photo in _Transaction.TRN_QuestionnaireHyginePhotoss)
                {


                    if (photo != null)
                    {



                        photo.HyginePhoto = isQuestionnaireImageSaved(photo.HyginePhoto, photo.Number, "" + photo.Id, "HyginePhotos");


                    }


                }




                if (!string.IsNullOrEmpty(_Transaction.TRN_QuestionnaireHygineSignature.SignaturePhoto) )
                {
                    _Transaction.TRN_QuestionnaireHygineSignature.SignaturePhoto = isQuestionnaireImageSaved(_Transaction.TRN_QuestionnaireHygineSignature.SignaturePhoto, _Transaction.TRN_QuestionnaireHygineSignature.Number, "Sign", "HygineSign");

                }
                if (!string.IsNullOrEmpty(_Transaction.TRN_QuestionnaireHygineSignature.DistributorPhoto))
                {
                    _Transaction.TRN_QuestionnaireHygineSignature.DistributorPhoto = isQuestionnaireImageSaved(_Transaction.TRN_QuestionnaireHygineSignature.DistributorPhoto, _Transaction.TRN_QuestionnaireHygineSignature.Number, "Photo", "HygineSign");

                }


                return await _QuestionnaireTransactionDAO.Post(_Transaction);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public string isQuestionnaireImageSaved(String imgBytes, String number, String imageName, String folderName)
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
