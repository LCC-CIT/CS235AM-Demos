This is an example of a multi-screen app. The main concepts demonstrated are:
* Starting a new activity or resuming an existing activity using an intent
* Managing activity launch mode
* Sending information from one activity to another using an intent
* Using activity life-cycle events: onCreate, onResume, onNewIntent

There are four versions of this app:<br>
* v0 - has a button on the first activity that launches the second activity. 
To go back to the first activity, use the system back button.<br>
* v1 - has buttons on both the first and second activities that launch the other activity. 
This app has activities with LaunchMode = SingleInstance.<br>
* v2 - Same as v1, but using fragments for large and normal screen sizes and both orientations. 
Fragments are loaded statically (the fragment class to instantiate is specified in the AXML layout).
* v3 - Same as v2, but fragments are loaded programmatically instead of statically (not done yet)

Note: This app is just one app in the class demo repository. 
To get the source code for this app you will need to 
clone or download the whole repository.

This demo was written for CS235AM, Android App Development, at Lane Community College. 
Read more about the course here: https://birdsbits.wordpress.com/2014/09/09/xamarin-android-course

