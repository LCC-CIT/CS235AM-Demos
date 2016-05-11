// Example of using SQLite-net ORM
// Brian Bird, 5/20/13

using System;
using SQLite;
using System.IO;
//using DataAccess.DAL; 
using DataAccess.DAL;
using System.Collections.Generic;

namespace L2Ch3.ConsoleApp
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Hello SQLite-net Data!");

            // parse the spanish-english vocabulary file
            const int NUMBER_OF_FIELDS = 7;    // The text file will have 3 fields, English word, Spanish word, and part of speech.
            TextParser parser = new TextParser(",", NUMBER_OF_FIELDS);     // instantiate our general purpose text file parser object.
            List<string[]> stringArrays;    // The parser generates a List of string arrays. Each array represents one line of the text file.
            stringArrays = parser.ParseText(File.Open(@"../../../DataAccessDemo/DAL/GoogleStocks.csv",FileMode.Open));     // Open the file as a stream and parse all the text

            // We're using a file in Assets instead of the one defined above
            //string dbPath = Directory.GetCurrentDirectory ();
            string dbPath = @"../../../DataAccess-Android/Assets/stocks.db3";
			var db = new SQLiteConnection (dbPath);

			// Create a Stocks table
			//if (db.CreateTable (Mono.CSharp.TypeOf(Stock)) != 0) 
			//	db.DropTable<Stock>();
			if (db.CreateTable<Stock>() == 0)
			{
				// A table already exixts, delete any data it contains
			//	db.DeleteAll<Stock> ();
			}

            // Don't use the first array, it's a header
            stringArrays.RemoveAt(0);
            // Copy the List of strings into our Database
        //    foreach (string[] stockInfo in stringArrays)
       //         db.Insert(new Stock() {
        //            Symbol = "GOOG",
        //            Name = "Google",
         //           Date = Convert.ToDateTime(stockInfo[0]),
         //           ClosingPrice = decimal.Parse(stockInfo[6]) });


			// Read the stock from the database
			// Use the Get method with a query expression
			Stock singleItem = db.Get<Stock> (x => x.Name == "Google");
			Console.WriteLine ("Stock Symbol for Google: {0}, Date: {1}, Price: {2}", singleItem.Symbol, singleItem.Date, singleItem.ClosingPrice);


		}
	}
}
