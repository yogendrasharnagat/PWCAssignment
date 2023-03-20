
using System.Text.Json.Serialization;

namespace CustomWeatherClientTool
{
    public class CurrentWeather
    {
        [JsonPropertyName("temperature")]
        public double Temperature { get; set; }
        [JsonPropertyName("windspeed")]
        public double Windspeed { get; set; }
        [JsonPropertyName("winddirection")]
        public double WindDirection { get; set; }
        [JsonPropertyName("weathercode")]
        public int WeatherCode { get; set; }
        [JsonPropertyName("time")]
        public string Time { get; set; }
    }

    public class CityCurrentWeather
    {
        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }
        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }
        [JsonPropertyName("generationtime_ms")]
        public double GenerationtTimeMs { get; set; }
        [JsonPropertyName("utc_offset_seconds")]
        public int UtcOffsetSeconds { get; set; }
        [JsonPropertyName("timezone")]
        public string Timezone { get; set; }
        [JsonPropertyName("timezone_abbreviation")]
        public string TimezoneAbbreviation { get; set; }
        [JsonPropertyName("elevation")]
        public double elevation { get; set; }
        [JsonPropertyName("current_weather")]
        public CurrentWeather CurrentWeather { get; set; }
    }
}
