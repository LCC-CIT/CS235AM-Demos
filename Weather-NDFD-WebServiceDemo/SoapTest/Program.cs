using SoapTest.ndfdService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoapTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var soapService = new ndfdXMLPortTypeClient();
            string result = soapService.LatLonListZipCode("97477");
            //string result = soapService.LatLonListCityNames("1");
            Console.WriteLine(result);
        }
    }
}
