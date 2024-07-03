using APIsAndJSON.API.Responses;
using APIsAndJSON.DTO;

namespace APIsAndJSON.Mappers
{
    public class WeatherMapper
    {

        public static Weather_DTO WeatherMapping(WeatherApiResponse weatherApiResponse)
        {
            try
            {
                Weather_DTO weatherDto = new Weather_DTO();

                if (weatherApiResponse.main is null) 
                { 
                    return weatherDto;
                }
                weatherDto.Temp = weatherApiResponse.main.temp;
                weatherDto.Humidity = weatherApiResponse.main.humidity;
                weatherDto.Pressure = weatherApiResponse.main.pressure;
                weatherDto.TempMin = weatherApiResponse.main.temp_min;
                weatherDto.TempMax = weatherApiResponse.main.temp_max;
                return weatherDto;
            }
            catch (Exception ex) 
            {

                throw; 
                
            }
        }
    }
}
