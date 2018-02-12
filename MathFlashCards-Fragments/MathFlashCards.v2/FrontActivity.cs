using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Content.Res;
using Android.Content.PM;

// MathFlashCards.v2
// This version uses fragments that are specified in the AXML layouts for
// the Activities (FrontActivity.axml and BackActivity.axml)
// By Brian Bird, May 2, 2016

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

            // Only use landscape orientation for large (tablet) screens
            // This is becuase my one layout for large sceens looks better in landscape
            if ((Application.ApplicationContext.Resources.Configuration.ScreenLayout & ScreenLayout.SizeMask) == ScreenLayout.SizeLarge)
            {
                RequestedOrientation = ScreenOrientation.Landscape;
            }

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.FrontActivity);

			// See if we're loading two fragments
			bool isDualPane = false;
			// Only the dual pane layout has a takeMeBack button and answer TextView
			var resetButton = FindViewById<Button> (Resource.Id.takeMeBackButton);
			var answerTextView = FindViewById<TextView>(Resource.Id.answerTextView);
			if (resetButton != null)
			{
				isDualPane = true;

				resetButton.Click += delegate {
					answerTextView.Text = "";
					ShowNewQuestion();
				};
			}
			
			var showAnswerButton = FindViewById<Button> (Resource.Id.showAnswerButton);
			
			showAnswerButton.Click += delegate {
				if(isDualPane)   // for dual-pane send answer to other fragment
				{
					answerTextView.Text = quiz.CalcSum().ToString();
				}
				else  // For single-pane, launch the other activity
				{
					var back = new Intent(this, typeof(BackActivity));
					back.PutExtra("Answer", quiz.CalcSum());
					StartActivity(back);
				}
			};
		}


		protected override void OnResume ()
		{
			base.OnResume ();

			ShowNewQuestion ();
		}


		private void ShowNewQuestion()
		{
			quiz.MakeRandom ();

			TextView firstNumberTextView = FindViewById<TextView> (Resource.Id.firstNumberTextView);
			firstNumberTextView.Text = quiz.FirstNumber.ToString();

			var secondNumberTextView = FindViewById<TextView> (Resource.Id.secondNumberTextView);
			secondNumberTextView.Text = quiz.SecondNumber.ToString();
		}
	}
}


