using APIsAndJSON.API;

namespace APIsAndJSON
{
    public class Program
    {
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();
            RonApiService ron = new RonApiService("https://ron-swanson-quotes.herokuapp.com/v2/quotes", client);
            KanyeApiService kanye = new KanyeApiService("https://api.kanye.rest/", client);

            for (int i = 0; i < 5; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                ron.GenerateRonQuote();
                
                Console.ForegroundColor = ConsoleColor.Red; 
                kanye.GenerateKanyeQuote();
                Console.WriteLine();
            }           

            WeatherAPIService weather = new WeatherAPIService("https://api.openweathermap.org/data/2.5/weather?q=London&appid=ed4bb091455ddcd02efd9541b2217ca2", client);
            weather.GetWeatherJObject();
        }
    }
}
