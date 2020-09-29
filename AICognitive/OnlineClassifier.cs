using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AICognitive.Models;
using Newtonsoft.Json;

namespace AICognitive
{
    public class OnlineClassifier : IClassifier
    {
        public event EventHandler<ClassificationEventArgs> ClassificationCompleted;

        public async Task Classify(byte[] bytes)
        {
            var client = new HttpClient();
            client.Timeout = new TimeSpan(0, 0, 3);

            client.DefaultRequestHeaders.Add("Prediction-Key", "<insert-key-here>");

            //string url = "https://southcentralus.api.cognitive.microsoft.com/customvision/v3.0/Prediction/80c96cf0-45ee-4887-9925-46422af8711d/classify/iterations/Iteration3/image";
            string url = "https://aicognitive.cognitiveservices.azure.com/subscriptions/f61de1da-32f8-43f4-b731-caa2d81b2057/resourceGroups/devtestresource/providers/Microsoft.CognitiveServices/accounts/AICognitive";
            HttpResponseMessage response;

            using (var content = new ByteArrayContent(bytes))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                response = await client.PostAsync(url, content);
                var json = await response.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<PredictionResult>(json);

                ClassificationCompleted.Invoke(this, new ClassificationEventArgs(result.Predictions));
            }
        }
    }
}
