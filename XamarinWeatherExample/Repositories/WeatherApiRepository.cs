using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using XamarinWeatherExample.Contracts.Repositories;

namespace XamarinWeatherExample.Repositories
{
    public class WeatherApiRepository : IGenericRepository
    {
        public WeatherApiRepository()
        {
        }

        public async Task<T> GetAsync<T>(string uri)
        {
            try
            {
                HttpClient httpClient = CreateHttpClient();
                string jsonResult = string.Empty;
                var responseMessage = await httpClient.GetAsync(uri);
                
                if (responseMessage.IsSuccessStatusCode)
                {
                    jsonResult = await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
                    return JsonConvert.DeserializeObject<T>(jsonResult);
                }

                if (responseMessage.StatusCode == HttpStatusCode.Forbidden ||
                    responseMessage.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new Exception(jsonResult);
                }

                throw new Exception($"{responseMessage.StatusCode}");

            }
            catch (Exception)
            {
                throw;
            }
        }

        private HttpClient CreateHttpClient()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return httpClient;
        }
    }
}