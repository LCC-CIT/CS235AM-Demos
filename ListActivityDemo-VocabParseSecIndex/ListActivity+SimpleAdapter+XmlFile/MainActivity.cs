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
		List<IDictionary<string, object>> dataList;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			var reader = new XmlFileReader(Assets.Open(@"spanish-english.xml"));
			dataList = reader.VocabList;
			ListAdapter = new SimpleAdapter (this, 
				dataList,
				Android.Resource.Layout.SimpleListItem1,
				new string[] {"spanish"},
				new int[] {Android.Resource.Id.Text1}
			);
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


