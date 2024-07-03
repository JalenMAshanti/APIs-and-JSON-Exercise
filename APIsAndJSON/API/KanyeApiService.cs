using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace APIsAndJSON.API
{
    public class KanyeApiService : APIService
    {
        private readonly HttpClient _httpClient;
        public KanyeApiService(string? url, HttpClient httpClient) : base(url, httpClient)
        {
            _httpClient = httpClient;

        }


        public async Task<JToken> GetApiResponseObject(string optionalParams = "")
        {
            try
            {
                if (!string.IsNullOrEmpty(optionalParams))
                {
                    _url += optionalParams;
                }
                var response = await _httpClient.GetStringAsync(_url);
                var results = JObject.Parse(response);
                var spec = results["quote"];
                return spec;
            }
            catch (Exception ex)
            {

                throw new Exception($"{ex}");
            }

        }

        public void GenerateKanyeQuote()
        {
            var quote = GetApiResponseObject().Result;
            Console.WriteLine(quote);
        }
    }
}
