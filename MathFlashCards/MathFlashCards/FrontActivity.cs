using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace MathFlashCards
{
	[Activity (Label = "Front", MainLauncher = true, Icon = "@mipmap/icon", LaunchMode = Android.Content.PM.LaunchMode.SingleInstance)]
	public class FrontActivity : Activity
	{
		MathQuiz quiz = new MathQuiz();

		protected override void OnCreate (Bundle savedInstanceState)
		{
			// This is only called when the activity is first created
			base.OnCreate (savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Front);

			// Display the two numbers to add
			var firstNumberTextView = FindViewById<TextView> (Resource.Id.firstNumberTextView);
			firstNumberTextView.Text = quiz.FirstNumber.ToString ();

			var secondNumberTextView = FindViewById<TextView> (Resource.Id.secondNumberTextView);
			secondNumberTextView.Text = quiz.SecondNumber.ToString ();

			// Show the BackActivity and send it the answer
			Button button = FindViewById<Button> (Resource.Id.myButton);
			
			button.Click += delegate {
				var back = new Intent(this, typeof(BackActivity));
				// Note: Intent is both a class and a property name, be sure you have a using statement

				back.PutExtra("Answer", quiz.Sum);
				StartActivity(back);
			};
		}


		// This is called every time the "Show Front" button is clicked, or
		// the system back button is clicked (when the BackActivity is running).
		protected override void OnResume ()
		{
			base.OnResume ();

			quiz.MakeRandomNumbers ();

			TextView firstNumberTextView = FindViewById<TextView> (Resource.Id.firstNumberTextView);
			firstNumberTextView.Text = quiz.FirstNumber.ToString();

			var secondNumberTextView = FindViewById<TextView> (Resource.Id.secondNumberTextView);
			secondNumberTextView.Text = quiz.SecondNumber.ToString();

		}
	}
}


