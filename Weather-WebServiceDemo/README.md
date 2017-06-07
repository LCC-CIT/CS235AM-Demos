
These projects demonstrate calling a REST web service, parsing the results and displaying them. There are three projects:

  * __Weather.Rest:__ A class library that calls a REST web service, can get either an XML or JSON result, and parses the result. This project uses:
    * The WebClient class from the .NET Library
    * The XmlReader class from the .NET Library
    * The JsonConvert class from Newtonsoft (available through Nuget)
  * __Weatehr.Dos:__ A console app used to test the Weather.Rest project
  * __Weather.Droid:__ An Android app that displays a weather forecast using the Weather.Rest library 
    
The weather data is provided by [Weather Underground](https://www.wunderground.com). 
To use the Weather Undergroud API, you will need to obtain a key. A [free key](https://www.wunderground.com/weather/api/) is avialable.
--------------------------
Note: This app is just one app in the class demo repository.
To get the source code for this app you will need to
clone or download the whole repository.
----------------------------------
This demo was written for CS235AM, Android App Development, at Lane Community College.
Read more about the course here: https://birdsbits.wordpress.com/2014/09/09/xamarin-android-course
