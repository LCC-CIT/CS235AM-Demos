using System;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace IntentDemo
{
	[Activity (Label = "AgeActivity", LaunchMode = Android.Content.PM.LaunchMode.SingleInstance)]			
	public class AgeActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Age);

			var tvName = FindViewById<TextView> (Resource.Id.tvName);
			tvName.Text = Intent.GetStringExtra (MainActivity.EXTRA_NAME);

			var tvBirthday = FindViewById<TextView> (Resource.Id.tvBirthday);
			//tvBirthday.Text = Intent.GetStringExtra ("Birthday");  // either of these works
			tvBirthday.Text = Intent.Extras.GetString(MainActivity.EXTRA_BIRTHDAY);   

			var tvAge = FindViewById<TextView> (Resource.Id.tvAge);
			tvAge.Text = Intent.GetIntExtra (MainActivity.EXTRA_AGE, 0).ToString();
		}
	}
}







