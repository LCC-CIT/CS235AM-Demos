using System;
using System.Xml.Linq;
using SoapPractice.graphical.weather.gov;

namespace SoapService
{
	class Forecast
	{
		ndfdXML soapService = new ndfdXML ();

		public string get7DayLowAndHigh(string zip) {
			string latLonXml = soapService.LatLonListZipCode (zip);
			string latLon = ParseZipXml (latLonXml);
			string forecast =  soapService.NDFDgenLatLonList (latLon,
				productType.glance, DateTime.Now, DateTime.Now.AddDays (7),
				unitType.e, new weatherParametersType () 
			{ mint = true, maxt = true} );
			return ParseLowHighXml (forecast);
		}

		private string ParseZipXml(string latLonXml) {
			var latLonDoc = XDocument.Parse (latLonXml);
			XElement latLon = latLonDoc.Element ("dwml");
			return latLon.Value;
		}

		private string ParseLowHighXml(string forecastXml) {
			var forecastDoc = XDocument.Parse (forecastXml);
			var minTempElements = forecastDoc.Element("dwml").Element("data").Element("parameters").Element("temperature").Elements();
			string minTemps = "";
			foreach(XElement e in minTempElements) 
				minTemps += e.Value + ", ";

			return minTemps;
		}
	}
}
