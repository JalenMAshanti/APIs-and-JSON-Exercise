using APIsAndJSON.API.Responses;
using APIsAndJSON.Mappers;
using Newtonsoft.Json;

namespace APIsAndJSON.API
{
    public class WeatherAPIService : APIService
    {
        private readonly HttpClient _httpClient;

        public WeatherAPIService(string? url, HttpClient httpClient) : base(url, httpClient)
        {
            _httpClient = httpClient;

        }

        public async Task GetWeatherJObject(string optionalParams = "")
        {
            try
            {
                if (!string.IsNullOrEmpty(optionalParams))
                {
                    _url += optionalParams;
                }
                var response = _httpClient.GetStringAsync(_url).Result;

                var result = JsonConvert.DeserializeObject<WeatherApiResponse>(response);

                var weatherDTO = WeatherMapper.WeatherMapping(result);

               Console.WriteLine($"Temp: {weatherDTO.Temp} \nPressure: {weatherDTO.Pressure} \nHumidity: {weatherDTO.Humidity} \nTemp Min: {weatherDTO.TempMin} \nTemp Max: {weatherDTO.TempMax}");
            }

            catch (Exception ex)
            {

                throw new Exception($"{ex}");
            }

        }

    }
}
