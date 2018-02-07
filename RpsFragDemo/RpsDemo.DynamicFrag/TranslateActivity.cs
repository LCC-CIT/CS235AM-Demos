using Android.App;
using Android.OS;

namespace RpsDemo.DynamicFrag
{
	[Activity (Label = "TranslateActivity", ParentActivity = typeof(MainActivity))]			
	public class TranslateActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Translate);
            ActionBar.SetDisplayShowHomeEnabled(true);  // Enable the "up" button

			FragmentTransaction ft = FragmentManager.BeginTransaction ();
			var frag = FragmentManager.FindFragmentById (Resource.Id.fragContainer); 
			if (frag!= null)
				ft.Remove (frag);  
			ft.Add (Resource.Id.fragContainer, new TextFrag());
			ft.Commit ();
					}
	}
}

