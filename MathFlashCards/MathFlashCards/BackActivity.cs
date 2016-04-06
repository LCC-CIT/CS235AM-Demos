using System;
using System.Collections.Generic;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace MathFlashCards
{
	[Activity (Label = "Back", LaunchMode = Android.Content.PM.LaunchMode.SingleInstance)]			
	public class BackActivity : Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.Back);

			int answer = Intent.Extras.GetInt ("Answer");
			TextView answerTextView = FindViewById<TextView> (Resource.Id.answerTextView);
			answerTextView.Text = answer.ToString ();

			Button showFrontButton = FindViewById<Button> (Resource.Id.showFrontButton);
			showFrontButton.Click += delegate {
				var toFront = new Intent (this, typeof(FrontActivity));
				StartActivity (toFront);
			};
		}
	}
}

