using System.Collections.Generic;

namespace ead2_ex1.Models
{
    public class WeatherService
    {

//        private static List<WeatherInformation> weather = new List<WeatherInformation>() 
        public IEnumerable<Weather> CityWeathers = new List<Weather>()
        {
            new Weather
            {
                Name = "Dublin",
                CurrentTemperature = 10,
                CurrentWindSpeed = 30,
                CurrentWeathercondition = "Cloudy",
                WeatherWarning = false
            },
            new Weather
            {
                Name = "Cork",
                CurrentTemperature = 10,
                CurrentWindSpeed = 50,
                CurrentWeathercondition = "Rain",
                WeatherWarning = true
            },
            new Weather
            {
                Name = "Galway",
                CurrentTemperature = 12,
                CurrentWindSpeed = 10,
                CurrentWeathercondition = "Sunny",
                WeatherWarning = false
            },
            new Weather
            {
                Name = "Limerick",
                CurrentTemperature = 8,
                CurrentWindSpeed = 50,
                CurrentWeathercondition = "Rain",
                WeatherWarning = true
            }
        };
    }
}