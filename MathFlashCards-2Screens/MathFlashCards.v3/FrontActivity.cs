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

			FragmentTransaction ft = FragmentManager.BeginTransaction ();
			var frontFrag = FragmentManager.FindFragmentById (Resource.Id.normalFragment);
			// Is there a fragment in the frame layout?
			if (frontFrag != null)
				ft.Remove (frontFrag);
			frontFrag = new FrontFragment ();
			ft.Add (Resource.Id.normalFragment, frontFrag);
			ft.Commit ();

			var answerTextView = FindViewById<TextView>(Resource.Id.answerTextView);

					// See if we're loading two fragments 
			bool  isDualPane = false;
			// Only the dual pane layout has a reset button
			var resetButton = FindViewById<Button>(Resource.Id.takeMeBackButton);
			if (resetButton != null) {
				isDualPane = true; 

				resetButton.Click += delegate(object sender, System.EventArgs e) {
					MakeNewProblem();
					answerTextView.Text = "";
				};
			}
			
			Button showAnswerButton = FindViewById<Button> (Resource.Id.showAnswerButton);
			showAnswerButton.Click += delegate {
				if(isDualPane)  {
					      answerTextView.Text = quiz.CalcSum().ToString();
				}
				else {
					    var back = new Intent(this, typeof(BackActivity));
					    back.PutExtra("Answer", quiz.CalcSum());
					    StartActivity(back);
				} 
			}; 

		}


		protected override void OnResume ()
		{
			base.OnResume ();

			MakeNewProblem ();
		}


		private void MakeNewProblem() {
			quiz.MakeRandom ();

			TextView firstNumberTextView = FindViewById<TextView> (Resource.Id.firstNumberTextView);
			firstNumberTextView.Text = quiz.FirstNumber.ToString();

			var secondNumberTextView = FindViewById<TextView> (Resource.Id.secondNumberTextView);
			secondNumberTextView.Text = quiz.SecondNumber.ToString();
		}
	}
}


