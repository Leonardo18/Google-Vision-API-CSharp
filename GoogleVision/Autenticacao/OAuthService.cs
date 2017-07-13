using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Vision.v1;
using Google.Apis.Vision.v1.Data;
using System.IO;

namespace GoogleVision.Autenticacao
{
    public class OAuthService
    {
        public string ApplicationName { get { return "PROJECT NAME IN GOOGLE CONSOLE DEVELOPERS"; } }

        public string JsonResult { get; set; }
        public AnnotateImageResponse DadosImagem { get; set; }
        public string Error { get; set; }

        public GoogleCredential CreateCredential(string filePath)
        {
            // this is the place to enter your own google API key (= json file). The app crashes without valid key. 
            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                string[] scopes = { VisionService.Scope.CloudPlatform };
                var credential = GoogleCredential.FromStream(stream);
                credential = credential.CreateScoped(scopes);
                return credential;
            }
        }


        public VisionService CreateService(GoogleCredential credential)
        {
            var service = new VisionService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
                GZipEnabled = true,
            });

            return service;
        }
    }
}