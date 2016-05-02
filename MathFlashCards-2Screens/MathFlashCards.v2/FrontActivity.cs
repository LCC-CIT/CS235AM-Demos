using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace MathFlashCards
{
	[Activity (Label = "MathFlashCards", MainLauncher = true, Icon = "@mipmap/icon",
		LaunchMode = Android.Content.PM.LaunchMode.SingleInstance)]
	public class FrontActivity : Activity
	{
		MathQuiz quiz = new MathQuiz();

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.FrontActivity);


			Button button = FindViewById<Button> (Resource.Id.showAnswerButton);
			
			button.Click += delegate {
				var back = new Intent(this, typeof(BackActivity));
				back.PutExtra("Answer", quiz.CalcSum());
				StartActivity(back);
			};
		}

		protected override void OnResume ()
		{
			base.OnResume ();

			quiz.MakeRandom ();

			TextView firstNumberTextView = FindViewById<TextView> (Resource.Id.firstNumberTextView);
			firstNumberTextView.Text = quiz.FirstNumber.ToString();

			var secondNumberTextView = FindViewById<TextView> (Resource.Id.secondNumberTextView);
			secondNumberTextView.Text = quiz.SecondNumber.ToString();

		}
	}
}


