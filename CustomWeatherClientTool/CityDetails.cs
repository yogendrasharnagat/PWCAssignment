
using System.Text.Json.Serialization;

namespace CustomWeatherClientTool
{
    public class CityDetails
    {
        [JsonPropertyName("city")]
        public string? City { get; set; }
        [JsonPropertyName("lat")]
        public string? Lat { get; set; }
        [JsonPropertyName("lng")]
        public string? Lng { get; set; }
        [JsonPropertyName("country")]
        public string? Country { get; set; }
        [JsonPropertyName("iso2")]
        public string? Iso2 { get; set; }
        [JsonPropertyName("admin_name")]
        public string? AdminName { get; set; }
        [JsonPropertyName("capital")]
        public string? Capital { get; set; }
        [JsonPropertyName("population")]
        public string? Population { get; set; }
        [JsonPropertyName("population_proper")]
        public string? PopulationPrope { get; set; }
    }
}
