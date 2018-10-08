This app simulates flash cards for learning math and demonstrates the use of fragments. A math problem is displayed in one fragment. When the user presses "Show answer", another fragment
shows the answer.

There are two versions of this app:

* v2 - Has buttons on both the first and second activities that launch the other activity. This version has activities with LaunchMode = SingleInstance and usies statically loaded fragments<br>
Concepts demonstrated:
  * Managing activity launch mode
  * Using activity life-cycle callbacks
  * Specifying fragment classes in the AXML layouts for the Activities
  * Loading different configurations of fragments based on screen size and orientation
    * Small size works with Nexus 5 (4.95in, 1080 x 1920 XXHDPI)
    * Large size works with Nexus 7, 2013 (7.02in, 1200 x 1920 XHDPI)
* v3 - Same as v2, but fragments are loaded programmatically
  * Using the FragmentManager
  * Adding and removing fragments from Activities using a FragmentTransaction object
  * Implementing event handlers in the Fragments (instead of the Activities)
  * Using code to Manage single-pane vs. dual-pane layouts
  * Passing information between fragments

----

Note: This app is just one app in the class demo repository. To get the source code for this app you will need to clone or download the whole repository.

This demo was written by Brian Bird for CS235AM, Android App Development, at Lane Community College.
Read more about the course here: <https://birdsbits.wordpress.com/2014/09/09/xamarin-android-course>
