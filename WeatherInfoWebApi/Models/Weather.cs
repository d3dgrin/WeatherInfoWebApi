using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherInfoWebApi.Models
{
    public class Weather
    {
        public Main Main { get; set; }
        public Wind Wind { get; set; }
        public Clouds Clouds { get; set; }
        public string Dt_txt { get; set; }
    }
}