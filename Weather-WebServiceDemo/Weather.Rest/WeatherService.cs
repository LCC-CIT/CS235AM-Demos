using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Xml;

namespace Weather.Rest
{
	public class WeatherService
	{
        public string Get3DayForecast(string city, string state, ForecastFormat format)
        {
            string apiKey = "0e3e69302fba4e56";  // put your own API key here
            string baseUri = "http://api.wunderground.com/api/";
            string query = "/forecast/q/" + state + "/" + city + "." + format.ToString();
            string uri = baseUri + apiKey + query;
            string response;

            try
            {
                using (var webClient = new WebClient())
                {
                    response = webClient.DownloadString(uri);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return response;
        }


        public List<Forecast> Parse3DayForecastXML(string xml)
        {
            var forecasts = new List<Forecast>();
            const string TITLE = "title";
            const string TEXT = "fcttext";

            using (XmlReader reader = XmlReader.Create(new StringReader(xml)))
            {
                Forecast forecast = null;
                // Parse the file and save data for each of the nodes.
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            if (reader.Name.Equals(TITLE))
                            {
                                reader.Read();
                                forecast = new Forecast();
                                forecast.Title = reader.Value;
                            }
                            else if (reader.Name.Equals(TEXT))
                            {
                                reader.Read();
                                forecast.ForecastText = reader.Value;
                                forecasts.Add(forecast);
                            }
                            break;
                    }
                }
            }
            return forecasts;
        }
    }
}