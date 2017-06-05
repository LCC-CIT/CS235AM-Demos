using Weather.Rest;
using System;

namespace Weather.Dos
{
	class MainClass
	{
		public static void Main (string[] args)
		{
            var weatherService = new WeatherService();
            string response = weatherService.Get3DayForecast("Eugene", "OR", ForecastFormat.xml);
            var forecasts = weatherService.Parse3DayForecastXML(response);
            foreach(Forecast f in forecasts)
            {
                Console.WriteLine(f.Title);
                Console.WriteLine(f.ForecastText);
                Console.WriteLine("--------------------------------------");
            }

        }
	}
}
