using System;
using System.Collections.Generic;
using Android.Runtime;

namespace ListActivitySimpleAdapterXmlFile
{
	public class ReadXmlFile
	{
		List<IDictionary<string,object>> vocabList;

		public List<IDictionary<string, object>> VocabList { get { return vocabList; } }

		public ReadXmlFile ()
		{
			// SimleAdapter requires a list of JavaDictionary<string,object> objects
			vocabList = new List<IDictionary<string, object>>(); 
			//for testing
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
		}


	}
}

