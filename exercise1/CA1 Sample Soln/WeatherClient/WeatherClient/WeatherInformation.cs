namespace Weather.Models
{
    public class WeatherInformation
    {
        // the city to which this weather information applies
        public string City
        {
            get;
            set;
        }

        // current temperature in Celsius
        public double Temperature
        {
            get;
            set;
        }

        // current wind speed km/h
        public int WindSpeed
        {
            get;
            set;
        }

        public string Conditions
        {
            get;
            set;
        }

        // is there a weather warning in place for this city at the moment?
        public bool WeatherWarning { get; set; }
    }
}
