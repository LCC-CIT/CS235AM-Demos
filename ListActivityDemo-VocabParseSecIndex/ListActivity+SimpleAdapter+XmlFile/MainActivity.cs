using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using System.Collections.Generic;
using Android.Runtime;

namespace ListActivitySimpleAdapterXmlFile
{
	[Activity (Label = "ListActivity+SimpleAdapter+XmlFile", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : ListActivity
	{
		List<IDictionary<string, object>> vocabList;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// SimleAdapter requires a list of JavaDictionary<string,object> objects
			vocabList = new List<IDictionary<string, object>>(); 
			var item1 = new JavaDictionary<string, object> ();
			item1.Add ("Spanish", "mono");
			item1.Add ("English", "monkey");
			item1.Add ("PartOfSpeech", "noun");
			vocabList.Add(item1);
			var item2 = new JavaDictionary<string, object> ();
			item2.Add ("Spanish", "agua");
			item2.Add ("English", "water");
			item2.Add ("PartOfSpeech", "noun");
			vocabList.Add(item2);
			var item3 = new JavaDictionary<string, object> ();
			item3.Add ("Spanish", "saltar");
			item3.Add ("English", "to jump");
			item3.Add ("PartOfSpeech", "verb");
			vocabList.Add(item3);
	
			ListAdapter = new SimpleAdapter (this, 
				vocabList,
				Android.Resource.Layout.SimpleListItem1,
				new string[] {"Spanish"},
				new int[] {Android.Resource.Id.Text1}
			);
		}

		protected override void OnListItemClick(ListView l,
			View v,
			int position,
			long id)
		{
			string word = (string)((JavaDictionary<string,object>)ListView.GetItemAtPosition(position))["English"];
			Android.Widget.Toast.MakeText(this,
				word,
				Android.Widget.ToastLength.Short).Show();
		}

	}



}


