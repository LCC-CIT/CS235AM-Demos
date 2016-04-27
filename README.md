# CS235AM-Demos
Demo apps for the Android app dev course

Note: All these apps are in one repository, so you will
need to download or clone the whole repository even if you
only want code for one app.

##Directory

* Apps with multiple screens using Intent objects
  * AgeCalc
  * MathFlashCards
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
