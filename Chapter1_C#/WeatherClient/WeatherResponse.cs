using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace WeatherClient
{
    class WeatherResponse
    {
        public Coord Coord { get; set; }
        public List<Weather> Weather { get; set; }
        public string Base { get; set; }
        public Main Main { get; set; }
        public int Visibility { get; set; }
        public Wind Wind { get; set; }
        public Rain Rain { get; set; }
        public Clouds Clouds { get; set; }
        public int Dt { get; set; }
        public Sys Sys { get; set; }
        public int Timezone { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cod {  get; set; }

        public WeatherResponse() { }
    }
    struct Coord 
    {
        public float lon { get; set; }
        public float lat { get; set; }
    }
    struct Weather 
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }
    struct Main 
    {
        public float temp { get; set; }
        public float feels_like { get; set; }
        public float temp_min { get; set; }
        public float temp_max { get; set; }
        public int pressure { get; set; }
        public int humidity { get; set; }
        public int sea_level { get; set; }
        public int grnd_level { get; set; }
    }
    struct Wind 
    {
        public float speed { get; set; }
        public int deg { get; set; }
        public float gust { get; set; }
    }
    struct Rain 
    {
        [JsonPropertyName("1h")]
        public float hour { get; set; }
    }
    struct Clouds
    {
        public int all { get; set; }
    }
    struct Sys 
    {
        public int type { get; set; }
        public int id { get; set; }
        public string country { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
    }
}
