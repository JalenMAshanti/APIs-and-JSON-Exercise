
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace APIsAndJSON.API
{
    public class RonApiService : APIService
    {
        private readonly HttpClient _httpClient;
        public RonApiService(string? url, HttpClient httpClient) : base(url, httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<JToken> GetApiResponseArray(string optionalParams = "")
        {
            try
            {
                if (!string.IsNullOrEmpty(optionalParams))
                {
                    _url += optionalParams;
                }
                var response = await _httpClient.GetStringAsync(_url);
                var results = JArray.Parse(response);
                var spec = results[0];
                return spec;
            }
            catch (Exception ex)
            {

                throw new Exception($"{ex}");
            }

        }

        public  void GenerateRonQuote() 
        {
           var quote = GetApiResponseArray().Result;
           Console.WriteLine(quote);
        }
    }
}
