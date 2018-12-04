using System;
using System.Threading.Tasks;
using MyWeatherApps.Models;

namespace MyWeatherApps.Services
{
    public interface IWeatherForecastService
    {
        Task<WeatherForecastRoot> GetWeatherAsync(double latitude, double longitude);
    }
}
