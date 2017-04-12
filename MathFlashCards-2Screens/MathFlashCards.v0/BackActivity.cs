using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace MathFlashCards
{
	[Activity (Label = "Card Back", ParentActivity = typeof(FrontActivity))]			
	public class BackActivity : Activity
	{
		// This method is only called the first time this activity is launched
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.Back);
            ActionBar.SetDisplayShowHomeEnabled(true);  // Enable the "up" button

            int answer = Intent.Extras.GetInt (FrontActivity.EXTRA_ANSWER);
			var answerTextView = FindViewById<TextView> (Resource.Id.answerTextView);
			answerTextView.Text = answer.ToString ();
		}
	}
}

