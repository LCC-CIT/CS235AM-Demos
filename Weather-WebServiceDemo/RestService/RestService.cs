using System;
using System.IO;
using System.Linq;
using System.Net;

namespace RestService
{
	public class Forecast
	{
		public string get7DayLowAndHigh(string zip)
		{
			string serviceUrl = "http://graphical.weather.gov/xml/SOAP_server/ndfdXMLclient.php";
			string requestParameters = "?whichClient=NDFDgen&product=time-series&Unit=e&maxt=maxt&mint=mint";
			var beginDateTime = new DateTime (2016, 5, 18);
			string begin = beginDateTime.ToString ("yyyy-mm-ddTH:mm:ss");
			//string begin = "2016-05-18T00:00:00";
			string endDateTime = "2016-05-25T00:00:00";


			string content = "";
			var request = HttpWebRequest.Create("http://graphical.weather.gov/xml/SOAP_server/ndfdXMLclient.php?whichClient=NDFDgen&lat=38.99&lon=-77.01&listLatLon=&lat1=&lon1=&lat2=&lon2=&resolutionSub=&listLat1=&listLon1=&listLat2=&listLon2=&resolutionList=&endPoint1Lat=&endPoint1Lon=&endPoint2Lat=&endPoint2Lon=&listEndPoint1Lat=&listEndPoint1Lon=&listEndPoint2Lat=&listEndPoint2Lon=&zipCodeList=&listZipCodeList=&centerPointLat=&centerPointLon=&distanceLat=&distanceLon=&resolutionSquare=&listCenterPointLat=&listCenterPointLon=&listDistanceLat=&listDistanceLon=&listResolutionSquare=&citiesLevel=&listCitiesLevel=&sector=&gmlListLatLon=&featureType=&requestedTime=&startTime=&endTime=&compType=&propertyName=&product=time-series&begin=2016-05-18T00%3A00%3A00&end=2016-05-25T00%3A00%3A00&Unit=e&maxt=maxt&mint=mint&Submit=Submit");
			var response = (HttpWebResponse)request.GetResponse();
			var reader = new StreamReader(response.GetResponseStream());
			content = reader.ReadToEnd();

			return content;
		}
	}
}