using Android.App;
using Android.Widget;
using Android.OS;
using Android.Gms.Location;
using Android.Gms.Common.Apis;
using Android.Util;

namespace FusedLocationProviderDemo
{
	[Activity (Label = "Fused Location Provider Demo", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity, GoogleApiClient.IConnectionCallbacks,
		GoogleApiClient.IOnConnectionFailedListener, 
		ILocationListener 
	{
		Button button;
		TextView locationTextView;
		GoogleApiClient apiClient;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Set up Google Play location service
			apiClient = new GoogleApiClient.Builder (this, this, this)
				.AddApi (LocationServices.API).Build ();

			button = FindViewById<Button> (Resource.Id.myButton);
			locationTextView = FindViewById<TextView> (Resource.Id.locationTextView);
			
			// Clicking the first button will make a one-time call to get the user's last location
			button.Click += delegate {
				apiClient.Connect();
				locationTextView.Text = "";				// Clear text view
				button.Text = "Getting Last Location";
			};		
		}


		// Interface implementations

		// Implementation for IConnectionCallbacks
		public void OnConnected (Bundle connectionHint)
		{
			Android.Locations.Location location = LocationServices.FusedLocationApi.GetLastLocation (apiClient);
			if (location != null)
			{
				locationTextView.Text = "Latitude: " + location.Latitude.ToString() + "\n";
				locationTextView.Text += "Longitude: " + location.Longitude.ToString() + "\n";
				locationTextView.Text += "Provider: " + location.Provider.ToString();
			}
			else
			{
				locationTextView.Text = "No location info available";
			}
			button.Text = "Show Location";
			apiClient.Disconnect ();
		}


		public void OnConnectionSuspended (int cause)
		{
			throw new System.NotImplementedException ();
		}


		// IOnConnectionFailedListener
		public void OnConnectionFailed (Android.Gms.Common.ConnectionResult result)
		{
			Toast.MakeText (this, "Connection failed", ToastLength.Long);
		}


		// ILocationListener
		public void OnLocationChanged (Android.Locations.Location location)
		{
			// This method returns changes in the user's location if they've been requested
			locationTextView.Text = "Latitude: " + location.Latitude.ToString() + "\n";
			locationTextView.Text += "Longitude: " + location.Longitude.ToString() + "\n";
			locationTextView.Text += "Provider: " + location.Provider.ToString();
		}
	}
}


