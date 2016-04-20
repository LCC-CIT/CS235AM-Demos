using System;
using Android.Widget;
using System.Collections.Generic;
using Android.Content;

namespace ListActivitySimpleAdapterXmlFile
{
	public class VocabAdapter : SimpleAdapter, ISectionIndexer
	{
		IList<IDictionary<string, object>> dataList;
		String[] sections;
		Java.Lang.Object[] sectionsObjects;
		Dictionary<string, int> alphaIndex; 

		public VocabAdapter (Context context, 
			IList<IDictionary<string, object>> data, 
			Int32 resource, 
			String[] from, 
			Int32[] to) : base(context, data, resource, from, to)
		{
			dataList = data;
			BuildSectionIndex ();
		}

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
			for (var i = 0; i < Count; i++)
			{
				// Use the part of speech as a key
				var key = (string)dataList[i]["pos"];
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

