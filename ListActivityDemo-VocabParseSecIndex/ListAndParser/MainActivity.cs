using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using CustomAdapterDemo;
using System.Collections.Generic;

namespace ListAndParser
{
	[Activity (Label = "ListAndParser", MainLauncher = true)]
	public class MainActivity : ListActivity
	{
		List<VocabItem> vocabItems;		// Since we're using a custom adapter we can use a List instead of an array

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			vocabItems = new List<VocabItem>();		// Lists are more convenient than arrays

			const int NUMBER_OF_FIELDS = 3;	 // The text file will have 3 fields, English word, Spanish word, part of speech, per line
			TextParser parser = new TextParser (",", NUMBER_OF_FIELDS);	// We will use this to get all the vocab info from the file
			var vocabList = parser.ParseText (Assets.Open(@"spanish-english.csv"));		// Open the file as a stream and parse all the text
			vocabList.Sort((x, y) => String.Compare(x[2], y[2],					// sort on part of speech so the section indexer will work.
			                                        StringComparison.Ordinal));

			// Copy the List of strings into our List of VocabItem objects
			foreach(string[] wordInfo in vocabList)
				vocabItems.Add(new VocabItem(wordInfo[0], wordInfo[1], wordInfo[2]));

			// Instantiate our custome list adapter
			ListAdapter = new VocabAdapter (this, vocabItems);

			// This is all you need to do to enable fast scrolling
			ListView.FastScrollEnabled = true;
		}

		// Pop up a toast that shows the English translation of the Spanish word
		protected override void OnListItemClick(ListView l,
		                                        View v,
		                                        int position,
		                                        long id)
		{
			string word = vocabItems[position].English;
			Android.Widget.Toast.MakeText(this,
			                              word,
			                              Android.Widget.ToastLength.Short).Show();
		}

	}

}



