using Android.App;
using Android.Content;
using Android.OS;
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

			Button button = FindViewById<Button> (Resource.Id.takeMeBackButton);

			button.Click += delegate {
				var front = new Intent(this, typeof(FrontActivity));
				StartActivity(front);
			};
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

