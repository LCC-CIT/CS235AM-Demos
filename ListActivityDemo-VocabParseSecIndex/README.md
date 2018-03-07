This solution contains 4 projects:
  * __CustomAdapterDemo:__ An app that is an example of implementing a custom adapter with no special ListView features. The project uses:
    * a ListActivity
    * a custom adapter class that inherits from BaseAdapter\<VocabItem\>
  * __ListActivityDemo:__ An app that is an example of using an ArrayAdapter, this project uses:
    * a ListActivity
    * the ArrayAdapter class for an array of VocabItem objects
  * __ListAndParser:__ An app that illustrates using a parser to add items from a text file to a ListView adapter
    * a ListActivity
    * a row click-event handler
    * fast scrolling and a section indexer
    * a custom adapter that inherits from BaseAdapter\<VocabItem\>
    * a custom text file parser that can parse files with any delimeter, tab, comma, colon, etc.
  * __ListActivity+SimpleAdapter+XmlFile:__ An app that illustrates using an XML parser to add items from an XML file to a ListView adapter
    * a ListActivity
    * a custom row layout, ListItem.axml
    * a row click-event handler
    * fast scrolling and a section indexer
    * a custom adapter that inherits from SimpleAdapter and uses a List of C# Dictionarly objects, List\<IDictionary\<string, object\>\>
    * a custom XML file parser that uses the .NET XmlReader

Note: This app is just one app in the class demo repository.
To get the source code for this app you will need to
clone or download the whole repository.

This demo was written for CS235AM, Android App Development, at Lane Community College
Read more about the course here: https://birdsbits.wordpress.com/2014/09/09/xamarin-android-course
