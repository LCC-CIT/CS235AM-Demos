using System;
using System.Xml.Linq;
using SoapPractice.graphical.weather.gov;
using System.Linq;

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
			XElement latLonElement = latLonDoc.Element ("dwml");
			return latLonElement.Value;
		}


		/*
		 * The temperature element of the forecast XML looks like this:
		 * 
		<parameters applicable-location="point1">
      	  <temperature type="maximum" units="Fahrenheit" time-layout="k-p24h-n7-1">
            <name>Daily Minimum Temperature</name>
            <value>72</value>
            <value>57</value>
            <value>60</value>
            <value>65</value>
            <value>64</value>
            <value>64</value>
            <value>65</value>
        </temperature>
      */

		private string ParseLowsXml(string forecastXml) {
			var forecastDoc = XDocument.Parse (forecastXml);
			// This works too, but I commented it out to use Linq instead
			// var minTempElements = forecastDoc.Element("dwml").Element("data").Element("parameters").Element("temperature").Elements();
			var temperatureElements = forecastDoc.Root.Descendants("temperature");
			var minTemperatures = (from t in temperatureElements
				where t.Element("name").Value == "Daily Minimum Temperature"
				select t.Elements ("value")).FirstOrDefault();

			string minTemps = "";
			foreach(XElement e in minTemperatures) 
				minTemps += e.Value + ", ";

			return minTemps;
		}
	}
}
