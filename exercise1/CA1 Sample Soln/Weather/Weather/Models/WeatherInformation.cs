using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Weather.Models
{
    // weather info i.e. city, current temperature, current windspeed, current weather conditions, and whether a weather warning is in place
    public class WeatherInformation
    {  
        // the city to which this weather information applies
        [Required(ErrorMessage = "Invalid City")]
        public String City
        {
            get;
            set;
        }

        // current temperature in Celsius
        [Range(-50, 50, ErrorMessage="Invalid Temperature")]
        public double Temperature       
        {
            get;
            set;
        }

        // current wind speed km/h
        [Range(0, 200, ErrorMessage = "Invalid Wind Speed")]
        public int WindSpeed
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Invalid Conditions")]
        public String Conditions
        {
            get;
            set;
        }

        // is there a weather warning in place for this city at the moment?
        public bool WeatherWarning { get; set; }
    }
}