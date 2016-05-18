using System;
using SoapService;

namespace Weather.Dos
{
	class MainClass
	{
		public static void Main (string[] args)
		{
            //var forecast = new Forecast ();
            var forecast = new RestService.Forecast();

            Console.WriteLine (forecast.get7DayLowAndHigh("97405"));


		}
	}
}
