
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
	[Activity (Label = "Back")]			
	public class BackActivity : Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.Back);

			int answer = Intent.Extras.GetInt("Answer");
			TextView answerTextView = FindViewById<TextView> (Resource.Id.answerTextView);
			answerTextView.Text = answer.ToString ();
		}
	}
}

