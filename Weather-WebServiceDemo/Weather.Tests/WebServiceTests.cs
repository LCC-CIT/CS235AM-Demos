using System;
using NUnit.Framework;
using Weather.Droid.graphical.weather.gov;

namespace Weather.Tests
{
	[TestFixture]
	public class WebServiceTests
	{
		ndfdXML weatherService;

		[SetUp]
		public void Setup ()
		{
			weatherService = new ndfdXML ();
		}

		
		[TearDown]
		public void Tear ()
		{
		}

		[Test]
		public void Pass ()
		{
			Console.WriteLine ("testing");
			Assert.True (true);
		}

		[Test]
		public void Inconclusive ()
		{
			Console.WriteLine(weatherService.LatLonListZipCode("97405"));
			Assert.Inconclusive ("Inconclusive");
		}
	}
}

