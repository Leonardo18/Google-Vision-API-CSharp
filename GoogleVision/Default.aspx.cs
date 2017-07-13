using Google.Apis.Vision.v1.Data;
using GoogleVision.VisionAPI;
using System;
using System.Collections.Generic;

namespace GoogleVision
{
    public partial class Default : System.Web.UI.Page
    {
        public List<string> Text = new List<string>();

        public string image = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            var Archive = Request["Archive"];

            if (!IsPostBack)
            {
                ddlType.Items.Add("TEXT_DETECTION");
                ddlType.Items.Add("DOCUMENT_TEXT_DETECTION");
                ddlType.Items.Add("FACE_DETECTION");
                ddlType.Items.Add("LOGO_DETECTION");
                ddlType.Items.Add("LABEL_DETECTION");
                ddlType.Items.Add("LANDMARK_DETECTION");
                ddlType.Items.Add("SAFE_SEARCH_DETECTION");
                ddlType.Items.Add("IMAGE_PROPERTIES");
            }
            else
            {
                AnalyseVision service = new AnalyseVision();

                AnnotateImageResponse DadosImagem = service.AnalyseImage(Server.MapPath("~/images/" + Archive), "en", ddlType.SelectedValue, Server.MapPath("AccountService.json"));

                switch (ddlType.SelectedValue)
                {
                    case "TEXT_DETECTION":
                        if (DadosImagem.TextAnnotations != null)
                        {
                            foreach (var item in DadosImagem.TextAnnotations)
                            {
                                Text.Add(item.Description);
                            }
                        }
                        else
                        {
                            Text.Add("Data not found");
                        }
                        break;

                    case "DOCUMENT_TEXT_DETECTION":
                        Text.Add(DadosImagem.FullTextAnnotation.Text);
                        break;

                    case "FACE_DETECTION":
                        if (DadosImagem.FaceAnnotations != null)
                        {
                            foreach (var item in DadosImagem.FaceAnnotations)
                            {
                                Text.Add(item.BlurredLikelihood);
                            }
                        }
                        else
                        {
                            Text.Add("Data not found");
                        }
                        break;

                    case "LOGO_DETECTION":
                        if (DadosImagem.LogoAnnotations != null)
                        {
                            foreach (var item in DadosImagem.LogoAnnotations)
                            {
                                Text.Add(item.Description);
                            }
                        }
                        else
                        {
                            Text.Add("Data not found");
                        }
                        break;

                    case "LABEL_DETECTION":
                        if (DadosImagem.LabelAnnotations != null)
                        {
                            foreach (var item in DadosImagem.LabelAnnotations)
                            {
                                Text.Add(item.Description + " " + item.Score * 100 + "%");
                            }
                        }
                        else
                        {
                            Text.Add("Data not found");
                        }
                        break;

                    case "LANDMARK_DETECTION":
                        if (DadosImagem.LandmarkAnnotations != null)
                        {
                            foreach (var item in DadosImagem.LandmarkAnnotations)
                            {
                                Text.Add(item.Description + " " + item.Score * 100 + "%");
                            }
                        }
                        else
                        {
                            Text.Add("Data not found");
                        }
                        break;

                    case "SAFE_SEARCH_DETECTION":
                        if (DadosImagem.SafeSearchAnnotation != null)
                        {
                            Text.Add(DadosImagem.SafeSearchAnnotation.Violence);
                        }
                        else
                        {
                            Text.Add("Data not found");
                        }
                        break;

                    case "IMAGE_PROPERTIES":
                        if (DadosImagem.ImagePropertiesAnnotation != null)
                        {
                            Text.Add(DadosImagem.ImagePropertiesAnnotation.ETag);
                        }
                        else
                        {
                            Text.Add("Data not found");
                        }
                        break;

                    default:
                        break;
                }

                image = Archive;
            }
        }
    }
}