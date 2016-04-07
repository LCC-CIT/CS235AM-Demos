using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace MathFlashCards
{
	// No launch mode is specified, but there is no other activity that starts this activity
	// so duplicagte instances won't be created
	[Activity (Label = "Front", MainLauncher = true, Icon = "@mipmap/icon")]
	public class FrontActivity : Activity
	{
		MathQuiz quiz = new MathQuiz();

		protected override void OnCreate (Bundle savedInstanceState)
		{
			// This is called when the acivity is created - which will be once, when the app is started
			base.OnCreate (savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Front);

			quiz.MakeRandomNumbers ();

			// Show the BackActivity and send it the answer
			Button button = FindViewById<Button> (Resource.Id.myButton);
			
			button.Click += delegate {
				var back = new Intent(this, typeof(BackActivity));
				// Note: Intent is both a class and a property name, be sure you have a using statement

				back.PutExtra("Answer", quiz.Sum);
				StartActivity(back);
			};
		}


		// This is called every time the system back button is clicked, and
		// it is called after onCreate the first time the activity is launched
		protected override void OnResume ()
		{
			base.OnResume ();

			quiz.MakeRandomNumbers ();

			// Display the two numbers to add
			TextView firstNumberTextView = FindViewById<TextView> (Resource.Id.firstNumberTextView);
			firstNumberTextView.Text = quiz.FirstNumber.ToString();

			var secondNumberTextView = FindViewById<TextView> (Resource.Id.secondNumberTextView);
			secondNumberTextView.Text = quiz.SecondNumber.ToString();

		}
	}
}


