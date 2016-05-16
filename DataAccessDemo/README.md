This app shows you how to use an SQLite Database and SQLite.Net ORM. There are three projects in the solution:
* DAL - Data Access Layer. A .NET Library project that contains the data model for the ORM and the SQLite.NET package (just one source code file). The two files in this project are linked in the DAL folders of the other two projects.
* Console - A .NET Console app that parses Stock data files (csv) and puts the data into a SQLite database file in the Assets folder of the Android project.
* Android - An Android app that displays the stock data in a ListView.

Note: This app is just one app in the class demo repository.
To get the source code for this app you will need to
clone or download the whole repository.

This demo was written for CS235AM, Android App Development, at Lane Community College.
Read more about the course here: https://birdsbits.wordpress.com/2014/09/09/xamarin-android-course
