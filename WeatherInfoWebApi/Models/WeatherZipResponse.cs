using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherInfoWebApi.Models
{
    public class WeatherZipResponse
    {
        public string Cod { get; set; }
        public string Message { get; set; }
        public Main Main { get; set; }
        public Wind Wind { get; set; }
        public Clouds Clouds { get; set; }
        public Coord Coord { get; set; }
    }
}