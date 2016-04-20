using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using System.Collections.Generic;
using Android.Runtime;

namespace ListActivitySimpleAdapterXmlFile
{
	[Activity (Label = "ListActivity SimpleAdapter XmlFile", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : ListActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			var reader = new XmlFileReader(Assets.Open(@"spanish-english.xml"));
			var dataList = reader.VocabList;
			ListAdapter = new VocabAdapter (this, 
				dataList,
				Android.Resource.Layout.TwoLineListItem,
				new string[] {"spanish", "pos"},
				new int[] {Android.Resource.Id.Text1, Android.Resource.Id.Text2}
			);

			// This is all you need to do to enable fast scrolling
			ListView.FastScrollEnabled = true;

		}


		protected override void OnListItemClick(ListView l,
			View v,
			int position,
			long id)
		{
			string word = (string)((JavaDictionary<string,object>)ListView.GetItemAtPosition(position))["english"];
			string pos = (string)((JavaDictionary<string,object>)ListView.GetItemAtPosition(position))["pos"];
			Android.Widget.Toast.MakeText(this,
				word + ", " + pos,
				Android.Widget.ToastLength.Short).Show();
		}

	}



}


