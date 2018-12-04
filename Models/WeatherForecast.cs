using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MyWeatherApps.Models
{

    public class Coordinates
    {
        [JsonProperty("lat")]
        public double Latitude { get; set; }

        [JsonProperty("lon")]
        public double Longitude { get; set; }
    }

    public class Sys
    {
        [JsonProperty("pod")]
        public string pod { get; set; }
    }

    public class Main
    {
        [JsonProperty("temp")]
        public double Temperature { get; set; }

        [JsonProperty("humidity")]
        public int Humidity { get; set; }
    }

    public class Clouds
    {
        [JsonProperty("all")]
        public int All { get; set; }
    }

    public class Wind
    {
        [JsonProperty("speed")]
        public double WindSpeed { get; set; }

        [JsonProperty("deg")]
        public double WindDirectionDegrees { get; set; }
    }

    public class WeatherCondition
    {
        [JsonProperty("main")]
        public string Main { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }
    }

    public class WeatherForecastItem
    {
        [JsonProperty("main")]
        public Main MainWeather { get; set; }

        [JsonProperty("weather")]
        public List<WeatherCondition> Weather { get; set; }

        [JsonProperty("clouds")]
        public Clouds Clouds { get; set; }

        [JsonProperty("wind")]
        public Wind Wind { get; set; }

        [JsonProperty("sys")]
        public Sys Sys { get; set; }

        [JsonProperty("dt_txt")]
        public string Date { get; set; }

        [JsonIgnore]
        public string DisplayIcon => $"http://openweathermap.org/img/w/{Weather?[0]?.Icon}.png";
    }

    public class City
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("coord")]
        public Coordinates Coordinates { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }
    }

    public class WeatherForecastRoot
    {
        [JsonProperty("cod")]
        public string Code { get; set; }

        [JsonProperty("list")]
        public List<WeatherForecastItem> WeatherForecastItems { get; set; }

        [JsonProperty("city")]
        public City City { get; set; }
    }
}
