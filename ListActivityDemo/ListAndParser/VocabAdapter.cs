using System;
using Android.Widget;
using System.Collections.Generic;
using Android.App;
using CustomAdapterDemo;
using Android.Views;

namespace ListAndParser
{

	// Cutom list adapter class
	public class VocabAdapter : BaseAdapter<VocabItem>, ISectionIndexer	// Don't forget to inherit from the interface too!
	{
		List<VocabItem> items;	// List of vocabluary words (includes Spanish, English and part of speech)
		Activity context;		// The activity we are running in

		public VocabAdapter(Activity c, List<VocabItem> i ) : base()
		{
			items = i;
			context = c;
			BuildSectionIndex();
		}

		public override long GetItemId(int position)
		{
			return position;
		}

		public override VocabItem this[int position]
		{
			get { return items [position];}
		}

		public override int Count
		{
			get { return items.Count;}
		}

		public override View GetView (int position, 
			View convertView, 
			ViewGroup parent)
		{
			View view = convertView;
			if (view == null)
				view = context.LayoutInflater.Inflate (
					Android.Resource.Layout.TwoLineListItem,
					null);
			view.FindViewById<TextView> (Android.Resource.Id.Text1).Text
			= items [position].Spanish;
			view.FindViewById<TextView> (Android.Resource.Id.Text2).Text
			= items [position].PartOfSpeech;
			return view;
		}

		// -- Code for the ISectionIndexer implementation follows --
		String[] sections;
		Java.Lang.Object[] sectionsObjects;
		Dictionary<string, int> alphaIndex; 

		public int GetPositionForSection(int section)
		{
			return alphaIndex [sections [section]];
		}

		public int GetSectionForPosition(int position)
		{
			return 1;
		}

		public Java.Lang.Object[] GetSections()
		{
			return sectionsObjects;
		}

		private void BuildSectionIndex()
		{
			alphaIndex = new Dictionary<string, int>();		// Map sequential numbers
			for (var i = 0; i < items.Count; i++)
			{
				// Use the part of speech as a key
				var key = items[i].PartOfSpeech;
				if (!alphaIndex.ContainsKey(key))
				{
					alphaIndex.Add(key, i);
				} 
			}

			// Get the count of sections
			sections = new string[alphaIndex.Keys.Count];
			// Copy section names into the sections array
			alphaIndex.Keys.CopyTo(sections, 0);

			// Copy section names into a Java object array
			sectionsObjects = new Java.Lang.Object[sections.Length];
			for (var i = 0; i < sections.Length; i++)
			{
				sectionsObjects[i] = new Java.Lang.String(sections[i]);
			}
		} 

	} 
}

