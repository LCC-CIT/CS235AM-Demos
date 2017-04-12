using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

// MathFlashCards v1

namespace MathFlashCards
{
	// the LaunchMode is SingleInstance, so we will only ever get one instance 
	// of this activity in the system back-stack
	[Activity (Label = "Card Back", LaunchMode = Android.Content.PM.LaunchMode.SingleInstance)]			
	public class BackActivity : Activity
	{
		// This method is only called the first time this activity is launched
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.Back);

			Button showFrontButton = FindViewById<Button> (Resource.Id.showFrontButton);
			showFrontButton.Click += delegate {
				var toFront = new Intent (this, typeof(FrontActivity));
				StartActivity (toFront);
			};
		}

		// this method is called when the activity is either:
		// a) resumed by clicking the system's back button, or
		// b) resumed by clicking the button on FrontActivity
		protected override void OnResume ()
		{
			base.OnResume ();

			int answer = Intent.Extras.GetInt (FrontActivity.EXTRA_ANSWER);
			var answerTextView = FindViewById<TextView> (Resource.Id.answerTextView);
			answerTextView.Text = answer.ToString ();
		}

		// The only instance of the Intent that gets stored in the Intent property is the first one
		// (the first one is the one that initially started the activity)
		// This method is called whenever a new intent is sent to this activity and 
		// we are setting the activity's Intent property with that intent so that it will be
		// available in OnResume
		protected override void OnNewIntent (Intent intent)
		{
			base.OnNewIntent (intent);
			Intent = intent;
		}
	}
}

