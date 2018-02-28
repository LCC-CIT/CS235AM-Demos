using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace RpsDemo.HardCodedFrag
{
	public class TextFrag : Fragment
	{
		public override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
            // load the fragment layout
            var view = inflater.Inflate(Resource.Layout.TextFrag, container, false);

            // get the name of the hand position from the activity's intent
            var name = Activity.Intent.GetStringExtra("hand_position_name");
            TextView nameTextView = view.FindViewById<TextView>(Resource.Id.handTextView);
            nameTextView.Text = name;
            return view;

		}


	}
}

