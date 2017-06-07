using Weather.Rest;
using System;

namespace Weather.Dos
{
	class MainClass
	{
		public static void Main (string[] args)
		{
            var weatherService = new WeatherService();
            // string response = weatherService.Get3DayForecast("Eugene", "OR", ForecastFormat.xml);
            // var forecasts = weatherService.ParseForecastXML(response);
            string response = weatherService.Get3DayForecast("Eugene", "OR", ForecastFormat.json);
            var forecasts = weatherService.ParseForecastJson(response);
            foreach (ShortForecast f in forecasts)
            {
                Console.WriteLine(f.Title);
                Console.WriteLine(f.ForecastText);
                Console.WriteLine("--------------------------------------");
            }

        }
	}
}
