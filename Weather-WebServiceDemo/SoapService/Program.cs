//using System;
//using SoapPractice.graphical.weather.gov;
//using SoapPractice.opendap.co_ops.nos.noaa.gov;
//
//namespace SoapPractice
//{
//	class MainClass
//	{
//		public static void Main (string[] args)
//		{
//			ndfdXML soapService = new ndfdXML ();
//
//			// string latLon = soapService.LatLonListZipCode ("97405");
//
//			// Console.WriteLine (latLon);
//
//			string weather = soapService.NDFDgenLatLonList ("43.9292,-123.087",
//				                 productType.glance, DateTime.Now, DateTime.Now.AddDays (1),
//				unitType.e, new weatherParametersType () 
//				{mint = true, maxt = true, pop12 = true}
//			);
//			Console.WriteLine (weather);
//
//			var tideService = new highlowtidepredService ();
//			//tideService.
//
//		}
//	}
//}
