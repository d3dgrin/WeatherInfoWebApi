using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherInfoWebApi.Models
{
    public class WeatherForecastResponse
    {
        public string Cod { get; set; }
        public string Message { get; set; }
        public List<Weather> List { get; set; }
        public City City { get; set; }
    }
}