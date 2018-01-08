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

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.FrontActivity);

			// see if a dual-pane layout is loaded
			bool isDualPane = (FindViewById (Resource.Id.backFragment) != null);
				
			// Load the front fragment
			Fragment frontFrag = FragmentManager.FindFragmentById (Resource.Id.frontFragment);
			FragmentTransaction ft = FragmentManager.BeginTransaction ();
			// Is there a fragment in the frame layout?
			if (frontFrag != null)
				ft.Remove (frontFrag);
			frontFrag = new FrontFragment (isDualPane);
			ft.Add (Resource.Id.frontFragment, frontFrag);
			ft.Commit ();

			// Load the back fragment, if a dual-pane layout is loaded
			if(isDualPane) {
				var backFrag = FragmentManager.FindFragmentById (Resource.Id.backFragment);
				ft = FragmentManager.BeginTransaction ();
				// Is there a fragment in the frame layout?
				if (backFrag != null)
					ft.Remove (backFrag);
				backFrag = new BackFragment (isDualPane);
				ft.Add (Resource.Id.backFragment, backFrag);
				ft.Commit ();
			}
		}


		protected override void OnResume ()
		{
			base.OnResume ();

			ShowNewProblem ();
		}


		// Can be called by code in a fratment
		public void ShowNewProblem() {
			quiz.MakeRandom ();

			TextView firstNumberTextView = FindViewById<TextView> (Resource.Id.firstNumberTextView);
			firstNumberTextView.Text = quiz.FirstNumber.ToString();

			var secondNumberTextView = FindViewById<TextView> (Resource.Id.secondNumberTextView);
			secondNumberTextView.Text = quiz.SecondNumber.ToString();
		}

		// called by code in a fragment
		public void ShowAnswer() {
			var answerTextView = FindViewById<TextView>(Resource.Id.answerTextView);
			answerTextView.Text = quiz.CalcSum().ToString();
		}

	}
}


