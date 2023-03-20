using RestSharp;
using System.Text.Json;

namespace CustomWeatherClientTool
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter city name: ");
            string? city = Console.ReadLine();

            string cityDetailsText = File.ReadAllText(@"./CityDetails.json");
            var cityDetails = JsonSerializer.Deserialize<List<CityDetails>>(cityDetailsText);
            
            var filterCityDetail = cityDetails?.Where(x=>x?.City?.ToUpper() == city?.ToUpper()).FirstOrDefault();
            if(filterCityDetail != null)
            {
                string apiEndPoint = "https://api.open-meteo.com/v1/forecast?latitude=latitudeValue&longitude=longitudeValue&current_weather=true";
                apiEndPoint = apiEndPoint.Replace("latitudeValue", filterCityDetail?.Lat).Replace("longitudeValue", filterCityDetail?.Lng);
                
                var client = new RestClient(apiEndPoint);
                Method requestType = Method.Get;
                var body = @"";
                var restRequest = new RestRequest();
                restRequest.Method = requestType;
                restRequest.AddHeader("Content-Type", "application/json");
                restRequest.AddParameter("application/json", body, ParameterType.RequestBody);
                RestResponse response = client.Execute(restRequest);

                if (response != null)
                {
                    CityCurrentWeather? cityCurrentWeather  = new CityCurrentWeather();
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string? contentType = response?.Content?.ToString();

                        if (!string.IsNullOrEmpty(contentType))
                        {
                            cityCurrentWeather = JsonSerializer.Deserialize<CityCurrentWeather>(contentType);
                            Console.WriteLine("Weather Related Information:");
                            Console.WriteLine($"temperature: {cityCurrentWeather?.CurrentWeather?.Temperature}");
                            Console.WriteLine($"windspeed: {cityCurrentWeather?.CurrentWeather?.Windspeed}");
                            Console.WriteLine($"winddirection: {cityCurrentWeather?.CurrentWeather?.WindDirection}");
                            Console.WriteLine($"weathercode: {cityCurrentWeather?.CurrentWeather?.WeatherCode}");
                            Console.WriteLine($"time: {cityCurrentWeather?.CurrentWeather?.Time}");
                        }
                        else
                        {
                            Console.WriteLine("Record not found in open api server");
                        }
                    }
                    else
                    {
                        Console.WriteLine(response?.ErrorMessage);
                    }
                }
            }
            else
            {
                Console.WriteLine("Record not found in database");
            }
        }
    }
}