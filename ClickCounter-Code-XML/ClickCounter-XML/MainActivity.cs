using Android.App;
using Android.Widget;
using Android.OS;

namespace ClickCounterXML
{
	[Activity(Label = "@string/app_name", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button aButton = FindViewById<Button>(Resource.Id.aButton);
			TextView aLabel = FindViewById<TextView>(Resource.Id.aLabel);

			aButton.Click += delegate { aLabel.Text = $"{count++} taps!"; };
		}
	}
}

