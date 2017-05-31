using System;
using Parser;
using SoapService.graphical.weather.gov;

namespace SoapService
{
	public class Forecast
	{
		ndfdXML soapService = new ndfdXML();

		public string get7DayLowAndHigh(string zip, DateTime beginDateTime) {
			// Get latitude and longitude from zip code
			string latLonXml = soapService.LatLonListZipCode(zip);
			string latLon = XmlParser.ParseZipXml (latLonXml);

			// Get the forecast
			string forecast =  soapService.NDFDgenLatLonList (latLon,
				productType.glance, beginDateTime, beginDateTime.AddDays(7),
				unitType.e, new weatherParametersType() 
			{ mint = true, maxt = true} );

			// Parse and return a string with the forecast
			return XmlParser.ParseLowsXml(forecast);
		}
 	}
}
