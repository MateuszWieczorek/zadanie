using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;

namespace Zadanie_rekrutacyjne_07.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        //public System.Runtime.CompilerServices.ValueTaskAwaiter<Root> GetAwaiter();




        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        //private readonly Root? myDeserializedClass;


        public WeatherForecastController(ILogger<WeatherForecastController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;

        }

        //[HttpGet]
        //public async Task<Srednia> GetName(string cityName)
        //{
        //    //var obj = JsonConvert.DeserializeObject<Root>(cityName);

        //    var httpClient = _httpClientFactory.CreateClient();
        //    var URL = $"http://api.weatherapi.com/v1/forecast.json?key=a30b0f8a0d9e49ada43190402222705&q={cityName}&days=3&aqi=no&alerts=no";
        //    var response = await httpClient.GetAsync(URL);
        //    string jasonString = await response.Content.ReadAsStringAsync();

        //    Root? myDeserializedClass = JsonConvert.DeserializeObject<Root?>(jasonString);

            

           
        //    if (!string.IsNullOrEmpty(jasonString))
        //    {


        //        double suma = 0; //suma œredniej temp


        //        foreach (var item in myDeserializedClass.Forecast.forecastday)
        //        {
        //            suma += item.day.avgtemp_c;
        //        }
               
                

        //        double wynik_avg_temp_c = suma / myDeserializedClass.Forecast.forecastday.Count;
        //        myDeserializedClass.srednia.wynik_avg_temp_c = wynik_avg_temp_c;
                

        //    }



        //    if (response.IsSuccessStatusCode)
        //    {

              

        //    }
        //    else
        //    {
        //        var result = $"{(int)response.StatusCode} ({response.ReasonPhrase})";
               
        //    }
        //    // Request.RouteValues.Add(a,myDeserializedClass);
        //    return myDeserializedClass.srednia;





        //}
        [HttpHead("avg")]
        public async Task<Srednia> Get(string cityName)
        {
            var httpClient = _httpClientFactory.CreateClient();
           var URL = $"http://api.weatherapi.com/v1/forecast.json?key=a30b0f8a0d9e49ada43190402222705&q={cityName}&days=3&aqi=no&alerts=no";
            var response = await httpClient.GetAsync(URL);
            string b  = await response.Content.ReadAsStringAsync();
            

            Root? myDeserializedClass = JsonConvert.DeserializeObject<Root>(b);



        
            if (!string.IsNullOrEmpty(b))
            {
                double suma_wind = 0;//suma œredniej prêdkoœci wiatru,
                double suma_prussure = 0;// suma ciœnienia,
                double suma_temp = 0; //suma temepratury

              ;
                int count = 0;
               


                foreach (var forecastday in myDeserializedClass.Forecast.forecastday)
                {
                   
                    foreach (var day in forecastday.hour)
                    {
                        suma_prussure += day.pressure_mb;
                        suma_wind += day.wind_kph;
                        suma_temp += day.temp_c;
                        count++;
                        
                    }
                }

        




                double wynik_avg_predkosc_wiatru = suma_prussure / count;
                double wynik_avg_cisnienia = suma_wind / count;
                double wynik_avg_temp_c = suma_temp / count;
                myDeserializedClass.srednia.wynik_avg_predkosc_wiatru = wynik_avg_predkosc_wiatru; // W TYM MIEJSCU WYSKAKUJE WYJ¥TEK ¯E SREDNIA JEST JAKO NULL A WYNIK POJEDYÑCZYCH WYLICZONYCH WARTOŒCI PODAJE 
                myDeserializedClass.srednia.wynik_avg_cisnienia = wynik_avg_cisnienia;
                myDeserializedClass.srednia.wynik_avg_temp_c = wynik_avg_temp_c;
                
            }


        

            return myDeserializedClass.srednia;
        }
    }
}


        



