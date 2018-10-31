using Android.App;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace ListActivityDemo
{
	[Activity (Label = "ListActivityDemo", MainLauncher = true)]
	public class MainActivity : ListActivity
	{
		VocabItem[] vocab;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			vocab = new VocabItem[4];
			vocab[0] = new VocabItem("mono", "monkey");
			vocab [1] = new VocabItem ("agua", "water");
			vocab [2] = new VocabItem ("si", "yes");
			vocab [3] = new VocabItem ("banyo", "bathroom");

			ListAdapter = new ArrayAdapter<VocabItem> (this, 
			     Android.Resource.Layout.SimpleListItem1,
			     vocab);
		}

        // Row click event handler in ListActivity
		protected override void OnListItemClick(ListView l,
		     View v, int position, long id)
		{
			string word = vocab [position].English;
			Android.Widget.Toast.MakeText(this, word,
			    Android.Widget.ToastLength.Short).Show();
		}

	}
}


