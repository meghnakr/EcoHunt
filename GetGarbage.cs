using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction;
using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Training;
using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Training.Models;

namespace EcoHunt
{
    class GetGarbage
    {
        public static bool CheckGarbage(String link) //Give a link to image file
        {
            string predictionKey = EcoHunt.API_Keys.AzurePredictionKey;
            string endpoint = EcoHunt.API_Keys.AzureEndpoint;
            string name = EcoHunt.API_Keys.AzurepublishedName;
            string projectId = EcoHunt.API_Keys.AzureProjectID;

            CustomVisionPredictionClient predictionAPI = new CustomVisionPredictionClient()
            {
                ApiKey = predictionKey,
                Endpoint = endpoint
            };

            var uri = new Uri(link);
            var imageUrl = new Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction.Models.ImageUrl(link);
            var result = predictionAPI.ClassifyImageUrl(new Guid(projectId), name, imageUrl);
            var s = result.Predictions;
            var x = s[0].TagName;
            // Loop over each prediction and write out the results
            if (result.Predictions[0].TagName.Equals("Garbage"))
            {
                return true;
            }
            return false;
        }
    }
}