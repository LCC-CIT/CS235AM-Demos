
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace MathFlashCards
{
	public class BackFragment : Fragment
	{
		private bool isInDualPane = false;

		// Constructors

		public BackFragment() : base()
		{
		}

		public BackFragment(bool isInDualPane) : base()
		{
			this.isInDualPane = isInDualPane;
		}

		// Life-cycle callback mathods

		public override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

		}


		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			// Use this to return your custom view for this Fragment
			var view = inflater.Inflate(Resource.Layout.BackFragment, container, false);

			var answerTextView = view.FindViewById<TextView>(Resource.Id.answerTextView);

			var newQuestionButton = view.FindViewById<Button> (Resource.Id.newQuestionButton);
			newQuestionButton.Click += delegate(object sender, System.EventArgs e) {
				answerTextView.Text = "";
				if (isInDualPane) {
					((FrontActivity)Activity).ShowNewProblem ();
				} else {
					var front = new Intent (Activity, typeof(FrontActivity));
					StartActivity (front);
				}
			};

			return view;
		}

	}
}


