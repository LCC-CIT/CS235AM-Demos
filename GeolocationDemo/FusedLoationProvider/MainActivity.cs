using Android.App;
using Android.Widget;
using Android.OS;
using Android.Gms.Location;
using Android.Gms.Common.Apis;

namespace FusedLocationProviderDemo
{
	[Activity (Label = "Fused Location Provider Demo", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity, GoogleApiClient.IConnectionCallbacks,
		GoogleApiClient.IOnConnectionFailedListener, 
		ILocationListener 
	{
		Button lastLocationButton, locationUpdateButton;
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
			apiClient.Connect ();

			lastLocationButton = FindViewById<Button> (Resource.Id.lastLocationButton);
			locationTextView = FindViewById<TextView> (Resource.Id.locationTextView);
			
			// Clicking the button will make a one-time call to get the device's last known location
			lastLocationButton.Click += delegate {
				Android.Locations.Location location = LocationServices.FusedLocationApi.GetLastLocation (apiClient);
				locationTextView.Text = "Last location:\n";
				DisplayLocation(location);
			};		

			locationUpdateButton = FindViewById<Button> (Resource.Id.locationUpdateButton);

			// Clicking the button will send a request for continuous updates
			locationUpdateButton.Click += async delegate {
				if (apiClient.IsConnected)
				{
					locationTextView.Text = "Requesting Location Updates";
					var locRequest = new LocationRequest();

					// Setting location priority to PRIORITY_HIGH_ACCURACY (100)
					locRequest.SetPriority(100);

					// Setting interval between updates, in milliseconds
					// NOTE: the default FastestInterval is 1 minute. If you want to receive location updates more than 
					// once a minute, you _must_ also change the FastestInterval to be less than or equal to your Interval
					locRequest.SetFastestInterval(500);
					locRequest.SetInterval(1000);

					// pass in a location request and LocationListener
					await LocationServices.FusedLocationApi.RequestLocationUpdates (apiClient, locRequest, this);
					// In OnLocationChanged (below), we will make calls to update the UI
					// with the new location data
				}
				else
				{
					locationTextView.Text = "Client API not connected";
				}
			};
		}

		// Interface implementations

		// Implementation for IConnectionCallbacks
		public void OnConnected (Bundle connectionHint)
		{
			locationTextView.Text = "Connected!";
		}


		public void OnConnectionSuspended (int cause)
		{
			throw new System.NotImplementedException ();
		}


		// IOnConnectionFailedListener
		public void OnConnectionFailed (Android.Gms.Common.ConnectionResult result)
		{
			locationTextView.Text = "Connection failed";
		}


		// ILocationListener
		// This method returns changes in the user's location if they've been requested
		public void OnLocationChanged (Android.Locations.Location location)
		{

			locationTextView.Text = "Location updates:\n";
			DisplayLocation (location);
		}

		private void DisplayLocation(Android.Locations.Location location)
		{
			if (location != null)
			{
				locationTextView.Text += "Latitude: " + location.Latitude.ToString() + "\n";
				locationTextView.Text += "Longitude: " + location.Longitude.ToString() + "\n";
				locationTextView.Text += "Provider: " + location.Provider.ToString();
			}
			else
			{
				locationTextView.Text = "No location info available";
			}

		}
	}
}


