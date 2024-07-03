using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace APIsAndJSON.API
{
    public abstract class APIService : IAPIService
    {
        public string? _url { get; set; }
        private readonly HttpClient _httpClient;

        public APIService(string? url, HttpClient httpClient) 
        { 
            _url = url;
            _httpClient = httpClient;        
        }

    }
}
