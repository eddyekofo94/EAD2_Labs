using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ead2_ex1.Models;

namespace ead2_ex1.Models
{
    public class Weather : City
    {
        //	the current temperature in the city (degrees Celsius in range -50 to 50)
        [Range(-50, 50)] public int CurrentTemperature { get; set; }

        [Range(0, 200)] public int CurrentWindSpeed { get; set; }

        public bool WeatherWarning { get; set; }

        public string CurrentWeathercondition { get; set; }
    }
}