using System;
using System.Collections.Generic;
using Android.Runtime;
using System.Xml;
using System.IO;

namespace ListActivitySimpleAdapterXmlFile
{
	public class XmlVocabFileParser
	{
		// constants to use for XML element names and dictionary keys
		public const string SPANISH = "spanish";
		public const string ENGLISH = "english";
		public const string POS = "pos"; // part of speech
		public const string WORD = "word";   // XML element containing spanish, english, and pos elements

		// This list will be filled with dictionary objects
		List<IDictionary<string,object>> vocabList;   // backing variable for VocabList property

		public List<IDictionary<string, object>> VocabList { get { return vocabList; } }

		public XmlVocabFileParser (Stream xmlStream)
		{
			// SimpleAdapter requires a list of JavaDictionary<string,object> objects
			vocabList = new List<IDictionary<string, object>>(); 

			/*
			//for testing
			var item1 = new JavaDictionary<string, object> ();
			item1.Add (SPANISH, "mono");
			item1.Add (ENGLISH, "monkey");
			item1.Add ("partOfSpeech", "noun");
			vocabList.Add(item1);
			var item2 = new JavaDictionary<string, object> ();
			item2.Add (SPANISH, "agua");
			item2.Add (ENGLISH, "water");
			item2.Add (ENGLISH, "noun");
			vocabList.Add(item2);
			var item3 = new JavaDictionary<string, object> ();
			item3.Add (SPANISH, "saltar");
			item3.Add (ENGLISH, "to jump");
			item3.Add (ENGLISH, "verb");
			vocabList.Add(item3);
			*/
		
			// Parse the xml file and fill the list of JavaDictionary objects with vocabulary data
			using (XmlReader reader = XmlReader.Create (xmlStream)) {
				JavaDictionary<string, object> word = null;
				while (reader.Read ()) {
					// Only detect start elements.
					if (reader.IsStartElement ()) {
						// Get element name and switch on it.
						switch (reader.Name) {
						case WORD:
						// New word
							word = new JavaDictionary<string, object> ();
							break;
						case SPANISH:
							// Add spanish word
							if (reader.Read () && word != null) {
								word.Add (SPANISH, reader.Value.Trim ());
							}
							break;
						case ENGLISH:
							// Add english word
							if (reader.Read () && word != null) {
								word.Add (ENGLISH, reader.Value.Trim ());
							}
							break;
						case POS:
							// Add part of speech
							if (reader.Read () && word != null) {
								word.Add (POS, reader.Value.Trim ());
							}
							break;
						}
					} else if (reader.Name == WORD) {  
						// reached </word>
						vocabList.Add(word);
						word = null;
					}
						
				}
			}
		
		}
	}
}

