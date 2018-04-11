// client for Weather Service 

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Weather.Models;

namespace WeatherClient
{
    
    class Program
    {
        static async Task Run()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:1676/");                             // base URL for API Controller i.e. RESTFul service

                    // add an Accept header for JSON
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // 1
                    // get weather info for all cities
                    // GET ../api/weather
                    HttpResponseMessage response = await client.GetAsync("api/weather");               // accessing the Result property blocks
                    if (response.IsSuccessStatusCode)                                                  // 200.299
                    {
                        // read result 
                        var weather = await response.Content.ReadAsAsync<IEnumerable<WeatherInformation>>();
                        foreach (var w in weather)
                        {
                            Console.WriteLine(w.City + " " + w.Temperature + "C " + w.WindSpeed + "km/h " + w.Conditions + " warning: " + w.WeatherWarning);
                        }
                    }
                    else
                    {
                        Console.WriteLine(response.StatusCode + " " + response.ReasonPhrase);
                    }

                    // 2
                    // get weather info for Dublin
                    // GET ../api/weather/Dublin
                    WeatherInformation weatherInfo = new WeatherInformation();
                    response = await client.GetAsync("api/weather/Dublin");
                    if (response.IsSuccessStatusCode)
                    {
                        // read result 
                        weatherInfo = await response.Content.ReadAsAsync<WeatherInformation>();
                        Console.WriteLine(weatherInfo.City + " " + weatherInfo.Temperature + "C " + weatherInfo.WindSpeed + "km/h " + weatherInfo.Conditions + " Warning: " + weatherInfo.WeatherWarning);
                    }
                    else
                    {
                        Console.WriteLine(response.StatusCode + " " + response.ReasonPhrase);
                    }

                    // 3
                    // update by Put to api/weather/Dublin - now its sunny
                    weatherInfo.Conditions = "Sunny";                                              
                    response = await client.PutAsJsonAsync("api/weather/Dublin", weatherInfo);
                    if (!response.IsSuccessStatusCode)
                    {
                        Console.WriteLine(response.StatusCode + " " + response.ReasonPhrase);
                    }

                    // 4
                    // get cities with weather warnings in place
                    // GET ../api/weather?warning=true
                    response = await client.GetAsync("api/weather?warning=true");
                    if (response.IsSuccessStatusCode)
                    {
                        // read result 
                        var cities = await response.Content.ReadAsAsync<IEnumerable<String>>();
                        foreach (String city in cities)
                        {
                            Console.WriteLine(city);
                        }
                    }
                    else
                    {
                        Console.WriteLine(response.StatusCode + " " + response.ReasonPhrase);
                    }

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }

        public static void Main()
        {
            Run().Wait();
        }

    }
}
