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
		}
	}
}

