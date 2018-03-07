using System.Collections.Generic;

namespace ead2_ex1.Models
{
    public class WeatherService
    {
        public WeatherService()
        {
//            CitiWeathers.Add(new City().Name);
        }

        public Weather c1 = new Weather()
        {
            Name = "Dublin",
            CurrentTemperature = 34,
            CurrentWindSpeed = 78,
            WeatherWarning = true
        };
//        Weather _weather = new Weather();
        public List<City> CitiWeathers = new List<City>();
    }
}