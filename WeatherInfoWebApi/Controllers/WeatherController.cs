using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WeatherInfoWebApi.Models;

namespace WeatherInfoWebApi.Controllers
{
    public class WeatherController : ApiController
    {
        string apiKey = "811f374e434dc1caf50c9db3c60e7c2e";
        string baseUrl = "http://api.openweathermap.org/data/2.5/";

        /// <summary>
        ///  Get weather in specific city
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        // GET: api/Weather/GetCurrentWeather/city
        [Route("api/weather/GetCurrentWeather/{city}")]
        public IHttpActionResult GetCurrentWeather(string city)
        {
            string url = baseUrl + "weather?units=metric&appid=" + apiKey + "&q=" + city;

            string responseText = GetResponseText(url);

            WeatherCurrentResponse response = JsonConvert.DeserializeObject<WeatherCurrentResponse>(responseText);

            // If the response is an error, then we give only the code and the error message
            if (response.Cod != "200")
            {
                WeatherErrorResponse errorResponse = new WeatherErrorResponse { Cod = response.Cod, Message = response.Message };
                return Json(errorResponse);
            }

            return Json(response);
        }

        /// <summary>
        /// Get forecast for specific city
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        // GET: api/Weather/GetForecast/city
        [Route("api/weather/GetForecast/{city}")]
        public IHttpActionResult GetForecast(string city)
        {
            string url = baseUrl + "forecast?units=metric&appid=" + apiKey + "&q=" + city;

            string responseText = GetResponseText(url);

            WeatherForecastResponse response = JsonConvert.DeserializeObject<WeatherForecastResponse>(responseText);

            // If the response is an error, then we give only the code and the error message
            if (response.Cod != "200")
            {
                WeatherErrorResponse errorResponse = new WeatherErrorResponse { Cod = response.Cod, Message = response.Message };
                return Json(errorResponse);
            }

            return Json(response);
        }

        /// <summary>
        ///  Get weather by ZIP code
        /// </summary>
        /// <param name="zip"></param>
        /// <returns></returns>
        // GET: api/Weather/GetCurrentWeatherByZip/zip
        [Route("api/weather/GetCurrentWeatherByZip/{zip}")]
        public IHttpActionResult GetCurrentWeatherByZip(string zip)
        {
            string url = baseUrl + "weather?units=metric&appid=" + apiKey + "&zip=" + zip;

            string responseText = GetResponseText(url);

            WeatherZipResponse response = JsonConvert.DeserializeObject<WeatherZipResponse>(responseText);

            // If the response is an error, then we give only the code and the error message
            if (response.Cod != "200")
            {
                WeatherErrorResponse errorResponse = new WeatherErrorResponse { Cod = response.Cod, Message = response.Message };
                return Json(errorResponse);
            }

            return Json(response);
        }

        private string GetResponseText(string url)
        {
            HttpWebRequest httpWebRequest = WebRequest.Create(url) as HttpWebRequest;
            HttpWebResponse httpWebResponse;
            string responseText;

            try
            {
                httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse;
            }
            catch (WebException webEx)
            {
                httpWebResponse = webEx.Response as HttpWebResponse;
            }

            using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                responseText = streamReader.ReadToEnd();
            }

            return responseText;
        }
    }
}
