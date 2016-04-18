using System;
using System.Collections.Generic;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace GussMyNumber2Screens
{
	[Activity (Label = "Check Guess")]			
	public class SecondActivity : Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			int guess = int.Parse(Intent.GetStringExtra ("Guess") ?? "0");

			//if(
		}
	}
}

