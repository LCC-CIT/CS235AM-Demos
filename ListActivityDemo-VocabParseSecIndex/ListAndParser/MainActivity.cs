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

			vocabItems = new List<VocabItem>();		// Our list adapter will use this (lists are nicer to work with than arrays)

			// parse the spanish-english vocabulary file
			const int NUMBER_OF_FIELDS = 3;	   // The text file will have 3 fields, English word, Spanish word, and part of speech.
			TextParser parser = new TextParser (",", NUMBER_OF_FIELDS);	   // instantiate our general purpose text file parser object.
			List<string[]> stringArrays;    // The parser generates a List of string arrays. Each array represents one line of the text file.
			stringArrays= parser.ParseText (Assets.Open(@"spanish-english.csv"));     // Open the file as a stream and parse all the text

			// Sort the List of string arrays
			stringArrays.Sort((x, y) => String.Compare(x[2], y[2],	  // provide a comparator method for the array element containing pos		
				StringComparison.Ordinal));      // Sorts on part of speech using the comparator above. The rows need to be in order for the indexer to work.

			// Copy the List of strings into our List of VocabItem objects
			foreach(string[] wordInfo in stringArrays)    
				vocabItems.Add(new VocabItem(wordInfo[0], wordInfo[1], wordInfo[2]));

			// Instantiate our custom listView adapter
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



