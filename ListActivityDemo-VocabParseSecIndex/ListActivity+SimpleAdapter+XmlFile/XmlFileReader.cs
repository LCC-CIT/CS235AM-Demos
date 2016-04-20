using System;
using System.Collections.Generic;
using Android.Runtime;
using System.Xml;
using System.IO;

namespace ListActivitySimpleAdapterXmlFile
{
	public class XmlFileReader
	{
		List<IDictionary<string,object>> vocabList;

		public List<IDictionary<string, object>> VocabList { get { return vocabList; } }

		public XmlFileReader (Stream xmlStream)
		{
			// SimpleAdapter requires a list of JavaDictionary<string,object> objects
			vocabList = new List<IDictionary<string, object>>(); 

			/*
			//for testing
			var item1 = new JavaDictionary<string, object> ();
			item1.Add ("spanish", "mono");
			item1.Add ("english", "monkey");
			item1.Add ("pos", "noun");
			vocabList.Add(item1);
			var item2 = new JavaDictionary<string, object> ();
			item2.Add ("spanish", "agua");
			item2.Add ("english", "water");
			item2.Add ("pos", "noun");
			vocabList.Add(item2);
			var item3 = new JavaDictionary<string, object> ();
			item3.Add ("spanish", "saltar");
			item3.Add ("english", "to jump");
			item3.Add ("pos", "verb");
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
						case "word":
						// New word
							word = new JavaDictionary<string, object> ();
							break;
						case "spanish":
							// Add spanish word
							if (reader.Read () && word != null) {
								word.Add ("spanish", reader.Value.Trim ());
							}
							break;
						case "english":
							// Add english word
							if (reader.Read () && word != null) {
								word.Add ("english", reader.Value.Trim ());
							}
							break;
						case "pos":
							// Add part of speech
							if (reader.Read () && word != null) {
								word.Add ("pos", reader.Value.Trim ());
							}
							break;
						}
					} else if (reader.Name == "word") {  
						// reached </word>
						vocabList.Add(word);
						word = null;
					}
						
				}
			}
		
		}
	}
}

