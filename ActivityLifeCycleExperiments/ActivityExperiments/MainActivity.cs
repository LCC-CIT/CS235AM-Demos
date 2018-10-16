using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Util;

namespace ActivityExperiments
{
    //	[Activity (Label = "MainActivity", MainLauncher = true, LaunchMode = Android.Content.PM.LaunchMode.SingleInstance)]
    [Activity(Label = "MainActivity", MainLauncher = true)]
    public class MainActivity : Activity
	{

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button btnStart = FindViewById<Button> (Resource.Id.startButton);
			
			btnStart.Click += delegate {
				Intent mainIntent = new Intent(this, typeof(SecondActivity));
				StartActivity(mainIntent);
			};

			Log.Debug(GetType().FullName, "In OnCreate");
		}

        protected override void OnStart()
        {
            base.OnStart();
            Log.Debug(GetType().FullName, "In OnStart");
        }

        protected override void OnResume()	
		{
			base.OnResume ();
			Log.Debug(GetType().FullName, "In OnResume");
		}

		protected override void OnRestart()	
		{
			base.OnRestart ();
			Log.Debug(GetType().FullName, "In OnRestart");
		}

		protected override void OnPause()
		{
			base.OnPause ();
			Log.Debug(GetType().FullName, "In OnPause");
		}

		protected override void OnStop()
		{
			base.OnStop ();
			Log.Debug(GetType().FullName, "In OnStop");
		}

		protected override void OnDestroy()
		{
			base.OnDestroy ();
			Log.Debug(GetType().FullName, "In OnDestroy");
		}

	}
}


