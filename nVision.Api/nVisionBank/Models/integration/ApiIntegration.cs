using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace nVisionBank.integration
{
   public class ApiIntegration
    {
        public string GetFromAPI(string ednpoiint, string apiURL)
        {
            var message = "";
            var client = new HttpClient {BaseAddress = new Uri(apiURL)};

            var response = client.GetAsync(ednpoiint).GetAwaiter().GetResult();

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            if (response.IsSuccessStatusCode)
            {
                message = response.Content.ReadAsStringAsync().Result;
            }

            return message;
        }

        public string ResponseFromAPIPost(string ednpoiint, string apiURL)
        {
            var message = "";
            var client = new HttpClient {BaseAddress = new Uri(apiURL)};

            var response = client.PostAsync(ednpoiint,null).GetAwaiter().GetResult();

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            if (response.IsSuccessStatusCode)
            {
                message = response.Content.ReadAsStringAsync().Result;
            }

            return message;
        }

        public string ResponseFromAPIPost<T>(string ednpoiint, T passedObject, string apiURL) where T : class
        {
            var message = "";
            var client = new HttpClient {BaseAddress = new Uri(apiURL)};
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


            var stringContent = JsonConvert.SerializeObject(passedObject);

            var response = client.PostAsJsonAsync(ednpoiint, stringContent).GetAwaiter().GetResult();

            if (response.IsSuccessStatusCode)
            {
                message = response.Content.ReadAsStringAsync().Result;
            }

            return message;
        }

    }
}
