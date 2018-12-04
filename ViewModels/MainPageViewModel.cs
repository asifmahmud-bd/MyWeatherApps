using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using MyWeatherApps.Models;
using MyWeatherApps.Services;
using Xamarin.Essentials;

namespace MyWeatherApps.ViewModels
{
    public class MainPageViewModel : MvxViewModel
    {

        private bool _isBusy;
        public bool IsBusy
        {       
            get => _isBusy;
            set
            {
                _isBusy = value;
                RaisePropertyChanged(() => _isBusy);
            }
        }

        private string _temp;
        public string Temp
        {
            get => _temp;
            set
            {
                _temp = value;
                RaisePropertyChanged(() => _temp);
            }
        }

        private WeatherForecastRoot _currentForecastData;
        public WeatherForecastRoot CurrentForecastData
        {
            get { return _currentForecastData; }
            set
            { _currentForecastData = value; RaisePropertyChanged(); }
        }

        public IMvxCommand GetWeatherCommand => new MvxCommand(async () => await ExecuteGetWeatherCommand());


        private async Task ExecuteGetWeatherCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                WeatherForecastRoot weatherForecastRoot = null;
                var position = await Geolocation.GetLastKnownLocationAsync();

                if (position == null)
                {
                    position = await Geolocation.GetLocationAsync(new GeolocationRequest
                    {
                        DesiredAccuracy = GeolocationAccuracy.Medium,
                        Timeout = TimeSpan.FromSeconds(30)
                    });
                }

                weatherForecastRoot = await WeatherForecastService.Instance.GetWeatherAsync(position.Latitude, position.Longitude);
                Temp = null;

            }
            catch (Exception e)
            {
                // Unable to get location
            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}
