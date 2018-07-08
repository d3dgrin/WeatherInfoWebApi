using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherInfoWebApi.Models
{
    public class WeatherErrorResponse
    {
        public string Cod { get; set; }
        public string Message { get; set; }
    }
}