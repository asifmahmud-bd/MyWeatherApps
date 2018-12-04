using System;
using System.Net.Http;
using System.Threading.Tasks;
using MyWeatherApps.Models;
using Newtonsoft.Json;

namespace MyWeatherApps.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {

        private static WeatherForecastService _instance;

        public static WeatherForecastService Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new WeatherForecastService();

                return _instance;
            }
        }

        private string GetWeatherUri(double latitude, double longitude)
        {
            return $"https://api.openweathermap.org/data/2.5/weather?lat={latitude}&lon={longitude}&units=metric&appid=653b1f0bf8a08686ac505ef6f05b94c2";
        }

        public async Task<WeatherForecastRoot> GetWeatherAsync(double latitude, double longitude)
        {
            using (var httpClient = new HttpClient())
            {
                var cityUriString = GetWeatherUri(latitude, longitude);
                var responseJson = await httpClient.GetStringAsync(cityUriString);

                if (string.IsNullOrWhiteSpace(responseJson))
                    return null;

                return JsonConvert.DeserializeObject<WeatherForecastRoot>(responseJson);
            }
        }


    }
}
