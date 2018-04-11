// a RESFul service which reports weather information for all cities or a specified city, or reports cities for a weather warning status
// and supports weather updates for specified cities

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Weather.Models;                   // weather information model class

namespace Weather.Controllers
{
    public class WeatherController : ApiController
    {
        /*
        * GET /api/weather                  get weather information for all cities       GetAllWeatherInformation()
        * GET /api/weather/city             get weather information for city             GetWeatherInformationForCity(city)
        * GET /api/weather?warning=true     get cities which have a weather warning      GetCitiesForWarningStatus(true)
          PUT /api/weather                  update weather information for city          PutWeatherInformationForCity(city)
         */

        private static List<WeatherInformation> weather = new List<WeatherInformation>() 
                { 
                    new WeatherInformation { City = "Dublin", Temperature = 10, WindSpeed = 30, Conditions = "Cloudy", WeatherWarning = false }, 
                    new WeatherInformation { City = "Cork", Temperature = 10, WindSpeed = 50, Conditions = "Rain", WeatherWarning = true  }, 
                    new WeatherInformation { City = "Galway", Temperature = 12, WindSpeed = 10, Conditions = "Sunny", WeatherWarning = false },
                    new WeatherInformation { City = "Limerick", Temperature = 8, WindSpeed = 50, Conditions = "Rain", WeatherWarning = true  } 
                };

        // GET api/weather
        public IEnumerable<WeatherInformation> GetAllWeatherInformation()
        {
            return weather;                                                     // 200 OK, weather serialized in response body
        }

        // GET api/weather/Dublin or api/weather?city=Dublin
        public WeatherInformation GetWeatherInformationForCity(String city)
        {
            // LINQ query, find matching city (case-insensitive) or default value (null) if none matching
            WeatherInformation cityWeather = weather.FirstOrDefault(w => w.City.ToUpper() == city.ToUpper());
            if (cityWeather == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);       // translated into a http response status code 404
            }
            return cityWeather;                                                 // 200 OK, weather info serialized in response body
        }

        // GET api/weather?warning=true or false
        public IEnumerable<String> GetCitiesForWarningStatus(bool warning)
        {
            // LINQ query, find cities whoose weather warning status matches warning paramater
            var cities = weather.Where(w => w.WeatherWarning == warning).Select(w => w.City);
            return cities;                                                      // 200 OK, weather info serialized in response body
        }

        // update weather for specified city
        public void PutUpdateWeatherForCity(String city, WeatherInformation weatherInfo)                  
        {
            if (ModelState.IsValid)
            {
                if (city == weatherInfo.City)
                {
                    int index = weather.FindIndex(w => w.City.ToUpper() == weatherInfo.City.ToUpper());
                    if (index == -1)
                    {
                        throw new HttpResponseException(HttpStatusCode.NotFound);               // 404
                    }
                    else
                    {
                        weather.RemoveAt(index);
                        weather.Add(weatherInfo);
                        // default is to return 204 Empty
                    }
                }
                else
                {
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                }
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }

       
    }
}
