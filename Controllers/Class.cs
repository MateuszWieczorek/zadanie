using static Zadanie_rekrutacyjne_07.Controllers.Root;

namespace Zadanie_rekrutacyjne_07.Controllers
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Astro
    {
    }

    public class Condition
    {
        public string? text { get; set; }
        public string? icon { get; set; }
        public int code { get; set; }
    }

    public class Current
    {
        public int last_updated_epoch { get; set; }
        public string? last_updated { get; set; }
        public double temp_c { get; set; }
        public int is_day { get; set; }
        public Condition? condition { get; set; }
        public double wind_kph { get; set; }
        public double pressure_mb { get; set; }
        public double vis_miles { get; set; }
        public double uv { get; set; }
    }

    public class Day
    {
        public double maxtemp_c { get; set; }
        public double mintemp_c { get; set; }
        public double avgtemp_c { get; set; }
        public double maxwind_mph { get; set; }
        public double maxwind_kph { get; set; }
        public Condition? condition { get; set; }
    }

    public class Forecast
    {
        public List<Forecastday>? forecastday { get; set; }
    }

    public class Forecastday
    {
        public string? date { get; set; }
        public int date_epoch { get; set; }
        public Day? day { get; set; }
        public Astro? astro { get; set; }
        public List<Hour>? hour { get; set; }
    }

    public class Hour
    {
        public double temp_c { get; set; }
        public Condition? condition { get; set; }
        public double wind_kph { get; set; }
        public double pressure_mb { get; set; }
    }

    public class Location
    {
        public string? name { get; set; }
        public string? region { get; set; }
        public string? country { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
        public string? tz_id { get; set; }
        public int localtime_epoch { get; set; }
        public string? localtime { get; set; }
    }

    //public class Srednia
    //{


    //    public double wynik_avg_temp_c { get; set; }
    //    public double wynik_avg_predkosc_wiatru { get; set; }
    //    public double wynik_avg_cisnienia { get; set; }
    //}

    [Serializable]
    public class Root
    {


        public Location? Location { get; set; }
        public Current? Current { get; set; }
        public Forecast? Forecast { get; set; }

        public Srednia? srednia { get; set; }

    }

        public class Srednia
        {
            public double wynik_avg_temp_c { get; set; }
            public double wynik_avg_predkosc_wiatru { get; set; }
            public double wynik_avg_cisnienia { get; set; }
        }
}

    



      


    


