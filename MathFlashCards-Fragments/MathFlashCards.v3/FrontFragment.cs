
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
	public class FrontFragment : Fragment
	{
		private bool isInDualPane = false;

		// Constructors

		public FrontFragment() : base()
		{
			// Nothing to do
		}

		public FrontFragment(bool isInDualPane) : base()
		{
			this.isInDualPane = isInDualPane;
		}

		// Life-cycle callback methods

		public override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			// Use this to return your custom view for this Fragment
			var view = inflater.Inflate(Resource.Layout.FrontFragment, container, false);
			var frontActivity = (FrontActivity)Activity;

			Button showAnswerButton = view.FindViewById<Button> (Resource.Id.showAnswerButton);
			showAnswerButton.Click += delegate {
				if(isInDualPane)  {
					frontActivity.ShowAnswer();
				}
				else {
					var back = new Intent(frontActivity, typeof(BackActivity));
					back.PutExtra("Answer", frontActivity.quiz.CalcSum());
					StartActivity(back);
				} 
			}; 

			return view;
		}
	}
}

