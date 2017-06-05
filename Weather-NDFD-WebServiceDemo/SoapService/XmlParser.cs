using System;
using System.Linq;
using System.Xml.Linq;

namespace Parser
{
	public static class XmlParser
	{
		/*XML returned for LatLonList
         * <dwml version='1.0' xmlns:xsd='http://www.w3.org/2001/XMLSchema' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xsi:noNamespaceSchemaLocation='http://graphical.weather.gov/xml/DWMLgen/schema/DWML.xsd'>
         *   <latLonList>43.9292,-123.087</latLonList>
         * </dwml>
         */

		public static string ParseZipXml(string latLonXml) {
			var latLonDoc = XDocument.Parse (latLonXml);
			XElement latLonElement = latLonDoc.Element ("dwml").Element("latLonList");
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

		public static string ParseLowsXml(string forecastXml) {
			var forecastDoc = XDocument.Parse (forecastXml);
			// This works too, but I commented it out to use Linq instead
			// var temperatureElements = forecastDoc.Element("dwml").Element("data").Element("parameters").Element("temperature").Elements();
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

