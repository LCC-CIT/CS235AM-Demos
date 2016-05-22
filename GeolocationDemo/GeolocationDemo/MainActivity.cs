// Demonstration of the Xamarin gelolocaction plug-in (aka component)
// Written by Brian Bird, 6/5/13

using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Geolocation;
using System.Threading.Tasks;

namespace GeolocationDemo
{
	[Activity (Label = "GeolocationDemo", MainLauncher = true)]
	public class MainActivity : Activity
	{

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Note: In project options, Build, Android Application,
			// check ACCESS_FINE_LOCATION and ACCESS_COARSE_LOCATION
			// These must be enabled for Geolocation to work
			var locator = new Geolocator(this) { DesiredAccuracy = 50 };

			// Get our button and TextView from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButton);
			TextView textView = FindViewById<TextView> (Resource.Id.positionTextView);

			button.Click += delegate {
				// GetPositionAsynch will either get position information or timeout
				locator.GetPositionAsync (timeout: 10000)
				// After getting position info or timing out, execution will continue here
				// t represents a Task object (GetPositionAsync returns a Task object)
				.ContinueWith (t =>  
				{
					try
					{
						// t.Result is a Position object
						textView.Text = String.Format ("Position Status: {0}\r\n", t.Result.Timestamp);
						textView.Text += String.Format ("Position Latitude: {0}\r\n", t.Result.Latitude);
						textView.Text += String.Format ("Position Longitude: {0}\r\n", t.Result.Longitude);
					}
					catch(Exception ex)
					{
						textView.Text += ex.ToString();
					}
					// Specify the thread to continue on- it's the UI thread
				}, TaskScheduler.FromCurrentSynchronizationContext() );
			};

		}
	}
}


