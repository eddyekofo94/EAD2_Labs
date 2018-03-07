using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ead2_ex1.Models;

namespace ead2_ex1.Models
{
    public enum WeatherConditions
    {
        Cloudy,
        Sunny,
        Rain,
        Fog,
        Snow
    }

    public class Weather : City
    {
        //	the current temperature in the city (degrees Celsius in range -50 to 50)
        private int _temp { get; set; }

//        private List<string> _weatherConditions = new List<string>(new[]
//        {
//        });

        [Range(-50, 50)] public int CurrentTemperature { get; set; }

        [Range(0, 200)]
        public int CurrentWindSpeed
        {
            get => _temp;
            set
            {
                if ((value > 50) && (value < -50))
                {
                    _temp = value;
                }
            }
        }

        public bool WeatherWarning { get; set; }

//        public string CurrentWeathercondition
//        {
//            get;
//            set
//            {
//                foreach (var condition in _weatherConditions)
//                {
//                    if ()
//                    {
//                        
//                    }
//                }
//            }
//        }
    }
}