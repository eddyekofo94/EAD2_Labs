using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ead2_ex1.Models;
using Microsoft.AspNetCore.Mvc;

namespace ead2_ex1.Controllers
{
    [Route("api/[controller]")]
    public class WeatherController : Controller
    {
        IEnumerable<WeatherService> _weatherService = new[] {new WeatherService()};

        // GET api/values
        [HttpGet]
        public IEnumerable<WeatherService> Get()
        {
            return _weatherService;
        }

        // GET api/weather/dublin
        [HttpGet("{city}")]
        public OkObjectResult Get(String city)
        {
            var cities = from u in _weatherService
                select u;
            
            Weather weather = new Weather();
            var weatherServices = cities as WeatherService[] ?? cities.ToArray();
            foreach (var w in weatherServices)
            {
                weather = w.CityWeathers.FirstOrDefault(c => c.Name.ToUpper() == city.ToUpper());
            }
            return Ok(weather);
        }

//        public OkObjectResult Get()
//        {
//            
//        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}