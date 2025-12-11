using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace WeatherClient
{
    public class WeatherResponse
    {
        public Coord coord { get; set; }
        public List<Weather> weather { get; set; }
        [JsonProperty("base")]
        public string Base { get; set; }
        public Main main { get; set; }
        public int visibility { get; set; }
        public Wind wind { get; set; }
        public Rain rain { get; set; }
        public Clouds clouds { get; set; }
        public int dt { get; set; }
        public Sys sys { get; set; }
        public int timezone { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int cod {  get; set; }

        public WeatherResponse() { }
    }
    public struct Coord 
    {
        public float lon { get; set; }
        public float lat { get; set; }
    }
    public struct Weather 
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }
    public struct Main 
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
    public struct Wind 
    {
        public float speed { get; set; }
        public int deg { get; set; }
        public float gust { get; set; }
    }
    public struct Rain 
    {
        [JsonProperty("1h")]
        public float hour { get; set; }
    }
    public struct Clouds
    {
        public int all { get; set; }
    }
    public struct Sys 
    {
        public int type { get; set; }
        public int id { get; set; }
        public string country { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
    }
}
