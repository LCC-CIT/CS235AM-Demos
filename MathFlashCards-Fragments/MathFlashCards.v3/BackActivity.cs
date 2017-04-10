
using System;
using System.Collections.Generic;
using System.Linq;
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

			SetContentView (Resource.Layout.BackActivity);

			// Load the back fragment
			Fragment backFrag = FragmentManager.FindFragmentById (Resource.Id.backFragment);
			FragmentTransaction ft = FragmentManager.BeginTransaction ();
			// Is there a fragment in the frame layout?
			if (backFrag != null)
				ft.Remove (backFrag);
			backFrag = new BackFragment (false);
			ft.Add (Resource.Id.backFragment, backFrag);
			ft.Commit ();
		}

		protected override void OnResume ()
		{
			base.OnResume ();

			int answer = Intent.Extras.GetInt ("Answer");
			var answerTextView = FindViewById<TextView> (Resource.Id.answerTextView);
			answerTextView.Text = answer.ToString ();
		}

		protected override void OnNewIntent (Intent intent)
		{
			base.OnNewIntent (intent);
			Intent = intent;
		}
	}
}

