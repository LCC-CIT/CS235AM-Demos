using System;
using System.IO;
using System.Linq;
using System.Net;
using Parser;

namespace RestService
{
	public class Forecast
	{
		public string get7DayLowAndHigh(string zip, DateTime beginDateTime)
		{
			// Set up the URL for querying the service
			string serviceUrl = "http://graphical.weather.gov/xml/SOAP_server/ndfdXMLclient.php";
			string requestParameters = "whichClient=NDFDgen&product=time-series&Unit=e&maxt=maxt&mint=mint";
			// Required date-time format example: "2016-05-18T00:00:00";
			const string DATE_TIME_TEMPLATE = "yyyy-MM-ddTH:mm:ss";
			string begin = beginDateTime.ToString (DATE_TIME_TEMPLATE);
			string end = beginDateTime.AddDays(7).ToString(DATE_TIME_TEMPLATE);

			string requestString = string.Format ("{0}?{1}&begin={2}&end={3}&zipCodeList={4}", 
				                       serviceUrl, requestParameters, begin, end, zip);

			// Send a request to the service and get a response
			var request = HttpWebRequest.Create(requestString);
			var response = (HttpWebResponse)request.GetResponse();

			// Read and parse the response
			var reader = new StreamReader(response.GetResponseStream());
			string content = reader.ReadToEnd();
			return XmlParser.ParseLowsXml (content);
		}
	}
}