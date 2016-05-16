# CS235AM-Demos
Demo Xamarin Android apps for CS235AM at LCC

Note: All these apps are in one repository, so you will
need to download or clone the whole repository even if you
only want code for one app.

##Directory

* Apps with multiple screens using Intent objects
  * AgeCalc
  * MathFlashCards (4 projects)
    * v0: Two activities with just one pair of layouts for portrait orientation
    * v1: Same as v0, but with LaunchMode of FrontActivity set to SingleInstance
    * v2: Same as v1, but using fragments for large and normal screen sizes and both orientations
    * v3: Same as v2, but fragments are loaded programmatically instead of statically
  * GuessMyNumber (not working yet)
* App that saves activity state using OnSaveInstanceState
 * ToDo-SaveInstanceState, uses XmlSerializer to save and restore object state
* Apps that use a ListActivity with fast scrolling
  * ListActivityDemo-VocabularyParseSectionIndex, 3 projects:
    * CustomAdapterDemo: Custom adapter class defined and used for string array
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
  * Weather-WebServiceDemo - Not finished yet

I wrote these apps for use with a class I teach at Lane Community College, CS235AM, Intermediate Mobile Applications Development: Android. Read more about the class and find out how to enroll here: https://birdsbits.wordpress.com/2014/09/09/xamarin-android-course/

Read the rest of my blog, BirdsBits, here:
https://birdsbits.wordpress.com
