# CS235AM-Demos
Xamarin Android demo apps for CS235AM at LCC

Note: All these apps are in one repository, so you will
need to download or clone the whole repository even if you only want code for one app.

##Directory

* Apps with single screens - basic ui example, 2 projects:
	* ClickCounter-Code-XML
		* ClickCounter-Code - UI created in C# code
		* ClickCounter-XML - UI declared in XML
* Apps with multiple screens using Intent objects
	* AgeCalc - Two activities, TextEdit, and a DatePicker
  	* MathFlashCards (4 projects)
  		* v0: Two activities with just one pair of layouts for portrait orientation
    	* v1: Same as v0, but with LaunchMode of FrontActivity set to SingleInstance
    	* v2: Same as v1, but using fragments for large and normal screen sizes and both orientations
    	* v3: Same as v2, but fragments are loaded programmatically instead of statically
  * GuessMyNumber (not working yet)
* App that saves activity state using OnSaveInstanceState
 * ToDo-SaveInstanceState, uses XmlSerializer to save and restore object state
* Apps that use a ListActivity with fast scrolling
  * ListActivityDemo-VocabularyParseSectionIndex, 4 projects:
    	* CustomAdapterDemo: Custom adapter class defined and used for string array
    	* ListActivity+SimpleAdapter+XmlFile: Custom adapter for List<IDictionary<string, object>>, XML parser 
    	* ListActivityDemo: Uses pre-defined ArrayAdapter class for an array of Objects
    	* ListAndParser: Uses a custom adapter with a section indexer
* Apps that have both portrait and landscape layouts
  * RpsLayoutDemo - Rock, Paper, Scissors game - 2 projects:
    	* RpsDemo-LinearLayouts
    	* RpsDemo-RelativeLayouts
* Apps that use Fragments
  * HelloFragment
  * MathFlashCards - see v2 and v3 of this solution above
  * RpsFragDemo
* Apps that use an SQLite Database and SQLite.Net ORM
  * DataAccessDemo - Displays stock price history in a ListView
  * DataAccessExercise - built on DataAccessDemo, includes a Spinner, DatePicker and complex queries
* Apps that consume a WebService
  * Stocks+WebService - Not finished. Can someone help me find a free Stock price Web Service?
  * Weather-WebServiceDemo - SOAP and REST web services are both working in the Console project
* Apps that demonstrate getting locaiton information
  * GeolocationDemo
    * FusedLocationProvider - Demonstrates getting location using the Google Play Services Fused Location Provider API
    * XamarinGeolocator - Demonstrates getting location using the Xamarin cross-platform Geolocator plug-in

I wrote these apps for use with a class I teach at Lane Community College, CS235AM, Intermediate Mobile Applications Development: Android. Read more about the class and find out how to enroll here: https://birdsbits.wordpress.com/2014/09/09/xamarin-android-course/

Read the rest of my blog, BirdsBits, here:
https://birdsbits.wordpress.com
