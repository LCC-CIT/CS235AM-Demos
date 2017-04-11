This is an example of a multi-screen app. It simulates flash cards.
A math problem is displayed. When the user presses "Show answer", another activity
is launched and the answer is shown (as if they had turned over the card to see the answer).

There are four versions of this app:
* v0 - has a button on the first activity that launches the second activity. To go back to the first activity, use the system back button, **or** the "up" button on the ActionBar.<br>
Concepts demonstrated:
  * Starting a new activity using an intent
  * Resuming an existing activity using an intent
  * Sending information to another activity via an intent
  * Navigation "up" to a parent activity using the ActionBar < button
* v1 - has buttons on both the first and second activities that launch the other activity. This version has activities with LaunchMode = SingleInstance.<br>
Concepts demonstrated:
  * Managing activity launch mode
  * Using activity life-cycle callbacks
* v2 - Uses StartActivityForResult in the first activity
  * The second activity has buttons for "I was right" and "I was wrong". These use the SetResult and Finish methods to return a result.
  * The first activity overrides OnActivityResult to get back the result.
Note: This app is just one app in the class demo repository.
To get the source code for this app you will need to
clone or download the whole repository.

This demo was written by Brian Bird for CS235AM, Android App Development, at Lane Community College.
Read more about the course here: https://birdsbits.wordpress.com/2014/09/09/xamarin-android-course
