using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

// MathFlashCards.v3
// This version doesn't have a button on BackActivity's UI
// By Brian Bird, May 2, 2016

namespace MathFlashCards
{
	[Activity (Label = "MathFlashCards", MainLauncher = true, Icon = "@mipmap/icon",
		LaunchMode = Android.Content.PM.LaunchMode.SingleInstance)]
	public class FrontActivity : Activity
	{
		internal MathQuiz quiz = new MathQuiz();
		internal bool isDualPane = false;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.FrontActivity);

			// Load the first fragment
			var frontFrag = FragmentManager.FindFragmentById (Resource.Id.frontFragment);
			FragmentTransaction ft = FragmentManager.BeginTransaction ();
			// Is there a fragment in the frame layout?
			if (frontFrag != null)
				ft.Remove (frontFrag);
			frontFrag = new FrontFragment ();
			ft.Add (Resource.Id.frontFragment, frontFrag);
			ft.Commit ();

			// Load the second fragment, if a dual-pane layout is loaded
			var backFrag = FragmentManager.FindFragmentById (Resource.Id.backFragment);
			ft = FragmentManager.BeginTransaction ();
			// Is there a fragment in the frame layout?
			if (backFrag != null)
				ft.Remove (backFrag);
			frontFrag = new BackFragment ();
			ft.Add (Resource.Id.backFragment, backFrag);
			ft.Commit ();


			var answerTextView = FindViewById<TextView>(Resource.Id.answerTextView);

			// See if we're loading two fragments 
			// Only the dual pane layout has a reset button
			var newQuestionButton = FindViewById<Button>(Resource.Id.newQuestionButton);
			if (newQuestionButton != null) {
				isDualPane = true; 

				newQuestionButton.Click += delegate(object sender, System.EventArgs e) {
					MakeNewProblem();
					answerTextView.Text = "";
				};
			}
			

		}


		protected override void OnResume ()
		{
			base.OnResume ();

			MakeNewProblem ();
		}


		public void MakeNewProblem() {
			quiz.MakeRandom ();

			TextView firstNumberTextView = FindViewById<TextView> (Resource.Id.firstNumberTextView);
			firstNumberTextView.Text = quiz.FirstNumber.ToString();

			var secondNumberTextView = FindViewById<TextView> (Resource.Id.secondNumberTextView);
			secondNumberTextView.Text = quiz.SecondNumber.ToString();
		}


		public void ShowAnswer() {
			var answerTextView = FindViewById<TextView>(Resource.Id.answerTextView);
			answerTextView.Text = quiz.CalcSum().ToString();
		}

	}
}


