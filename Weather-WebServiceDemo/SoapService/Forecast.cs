using System;
using Parser;
using SoapService.ndfd;

namespace SoapService
{
	public class Forecast
	{
        ndfdXMLPortTypeClient soapService = new ndfdXMLPortTypeClient("ndfdXMLPort");

        public string get7DayLowAndHigh(string zip, DateTime beginDateTime) {
			// Get latitude and longitude from zip code
			string latLonXml = soapService.LatLonListZipCode(zip);
			string latLon = XmlParser.ParseZipXml (latLonXml);

			// Get the forecast
			string forecast =  soapService.NDFDgenLatLonList (latLon,
				"glance", beginDateTime, beginDateTime.AddDays(7),
				"e", new weatherParametersType() 
			{ mint = true, maxt = true} );

			// Parse and return a string with the forecast
			return XmlParser.ParseLowsXml(forecast);
		}
 	}
}
