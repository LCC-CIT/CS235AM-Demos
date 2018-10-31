using System;
using Android.Widget;
using System.Collections.Generic;
using Android.Content;

namespace ListActivitySimpleAdapterXmlFile
{
	public class VocabAdapter : SimpleAdapter, ISectionIndexer
	{
		List<IDictionary<string, object>> dataList;
		String[] sections;
		Java.Lang.Object[] sectionsObjects;
		Dictionary<string, int> partOfSpeechIndex; 

		public VocabAdapter (Context context, 
			List<IDictionary<string, object>> data, 
			Int32 resource, String[] from, 
			Int32[] to) : base(context, data, resource, from, to)
		{
			dataList = data;
			// Sort list by Part Of Speech (pos) field
			dataList.Sort((x, y) => String.Compare((string)x[XmlVocabFileParser.POS], (string)y[XmlVocabFileParser.POS]));
			BuildSectionIndex ();
		}

        // ---- Implementation of ISectionIndexer  -------

		public int GetPositionForSection(int section)
		{
			return partOfSpeechIndex [sections [section]];
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
			partOfSpeechIndex = new Dictionary<string, int>();		// Dictionaray will contain section names
			for (var i = 0; i < Count; i++)
			{
				// Use the pos field as a key
				var key = (string)dataList[i][XmlVocabFileParser.POS];
				if (!partOfSpeechIndex.ContainsKey(key))
				{
					partOfSpeechIndex.Add(key, i);
				} 
			}

			// Get the count of sections
			sections = new string[partOfSpeechIndex.Keys.Count];
			// Copy section names into the sections array
			partOfSpeechIndex.Keys.CopyTo(sections, 0);

			// Copy section names into a Java object array
			sectionsObjects = new Java.Lang.Object[sections.Length];
			for (var i = 0; i < sections.Length; i++)
			{
				sectionsObjects[i] = new Java.Lang.String(sections[i]);
			}
		} 
		
	}
}

