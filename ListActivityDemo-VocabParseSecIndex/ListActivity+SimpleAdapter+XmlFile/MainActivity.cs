using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using System.Collections.Generic;
using Android.Runtime;

namespace ListActivitySimpleAdapterXmlFile
{
	[Activity (Label = "Spanish-English Vocabulary", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : ListActivity
	{

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Read and prase the vocabulary file and provide the adapter with the data
			var reader = new XmlVocabFileParser(Assets.Open(@"spanish-english.xml"));
			var dataList = reader.VocabList;
			ListAdapter = new VocabAdapter (this, 
				dataList,
				Android.Resource.Layout.SimpleListItem1,
				new string[] {XmlVocabFileParser.SPANISH},
				new int[] {Android.Resource.Id.Text1}
			);

			// This is all you need to do to enable fast scrolling
			ListView.FastScrollEnabled = true;

		}

		// Event handler for clicking on a row in the list view 
		protected override void OnListItemClick(ListView l,
			View v,
			int position,
			long id)
		{
			string word = (string)((JavaDictionary<string,object>)ListView.GetItemAtPosition(position))[XmlVocabFileParser.ENGLISH];
			string pos = (string)((JavaDictionary<string,object>)ListView.GetItemAtPosition(position))[XmlVocabFileParser.POS];
			Android.Widget.Toast.MakeText(this,
				word + ", " + pos,
				Android.Widget.ToastLength.Short).Show();
		}

	}



}


