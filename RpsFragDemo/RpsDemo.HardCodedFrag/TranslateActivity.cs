using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace RpsDemo.HardCodedFrag
{
	[Activity (Label = "TranslateActivity", ParentActivity = typeof(MainActivity))]			
	public class TranslateActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Translate);
            ActionBar.SetDisplayHomeAsUpEnabled(true);

			var name = Intent.GetStringExtra("hand_position_name");
			TextView nameTextView = FindViewById<TextView> (Resource.Id.handTextView);
			nameTextView.Text = name;
		}
	}
}

