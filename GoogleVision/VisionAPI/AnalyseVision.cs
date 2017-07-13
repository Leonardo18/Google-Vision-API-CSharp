using Google.Apis.Vision.v1.Data;
using GoogleVision.Auth;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GoogleVision.VisionAPI
{
    public class AnalyseVision
    {
        public string Error { get; set; }

        /// <summary>
        /// read image as byte and send to google api
        /// </summary>
        /// <param name="imgPath"></param>
        /// <param name="language"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public AnnotateImageResponse AnalyseImage(string imgPath, string language, string type, string jsonPath)
        {
            OAuthService oAuth = new OAuthService();

            var credential = oAuth.CreateCredential(jsonPath);
            var service = oAuth.CreateService(credential);
            service.HttpClient.Timeout = new TimeSpan(1, 1, 1);
            byte[] file = File.ReadAllBytes(imgPath);

            BatchAnnotateImagesRequest batchRequest = new BatchAnnotateImagesRequest();
            batchRequest.Requests = new List<AnnotateImageRequest>();
            batchRequest.Requests.Add(new AnnotateImageRequest()
            {
                Features = new List<Feature>() { new Feature() { Type = type }, },
                ImageContext = new ImageContext() { LanguageHints = new List<string>() { language } },
                Image = new Image() { Content = Convert.ToBase64String(file) }
            });

            var annotate = service.Images.Annotate(batchRequest);
            BatchAnnotateImagesResponse batchAnnotateImagesResponse = annotate.Execute();
            if (batchAnnotateImagesResponse.Responses.Any())
            {
                AnnotateImageResponse annotateImageResponse = batchAnnotateImagesResponse.Responses[0];
                if (annotateImageResponse.Error != null)
                {
                    if (annotateImageResponse.Error.Message != null)
                        Error = annotateImageResponse.Error.Message;
                }
                else
                {
                    return annotateImageResponse;
                }

            }

            return new AnnotateImageResponse();
        }
    }
}