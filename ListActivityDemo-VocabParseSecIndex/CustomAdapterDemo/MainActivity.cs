using Android.App;
using Android.OS;

namespace CustomAdapterDemo
{
	[Activity (Label = "CustomAdapterDemo", MainLauncher = true)]
	public class MainActivity : ListActivity
	{
		VocabItem[] vocab;  // array of VocabItem objects

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			vocab = new VocabItem[5];
			vocab[0] = new VocabItem("mono", "monkey");
			vocab [1] = new VocabItem ("agua", "water");
			vocab [2] = new VocabItem ("si", "yes");
			vocab [3] = new VocabItem ("banyo", "bathroom");
			vocab [4] = new VocabItem ("cerveza", "beer");

			// Set our view from the "main" layout resource
	//		SetContentView (Resource.Layout.Main);

			ListAdapter = new VocabAdapter (this, vocab);
		}
	}
}
