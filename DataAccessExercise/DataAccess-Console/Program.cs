// Demo of using SQLite-net ORM by Brian Bird, 5/20/13
// Converted to an exercise starter and completed by Brian Bird 5/12/16
// Updated to use the SQLite-net Nuget package and better path determination by Brian Bird 11/11/18

using System;
using SQLite;
using System.IO;
using System.Collections.Generic;
using DataAccess_Library;

namespace DataAccess_Console
{
    class MainClass
    {
        static string solutionDir;
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello SQLite-net data exercise!");

            // We're using a db file in the Android project's Assets folder
            string currentDir = Directory.GetCurrentDirectory ();
            // Truncate the path so it's the path to the solution folder
            solutionDir = currentDir.Remove(currentDir.IndexOf("DataAccess-Console", StringComparison.CurrentCulture));
            // Console.WriteLine(solutionDir);
            string dbPath = solutionDir + @"DataAccess-Android/Assets/stocks.db3";
            var db = new SQLiteConnection(dbPath);

            // Create a Stocks table
            db.DropTable<Stock>();
            if (db.CreateTable<Stock>() == 0)
            {
                // A table already exixts, delete any data it contains
                db.DeleteAll<Stock>();
            }

            AddStocksToDb(db, "GOOG", "Google", "GoogleStocks.csv");
            AddStocksToDb(db, "EA", "Electronic Arts", "EAStocks.csv");
            AddStocksToDb(db, "SNE", "Sony", "SonyStocks.csv");
        }

        private static void AddStocksToDb(SQLiteConnection db, string symbol, string name, string file)
        {
            // parse the stock csv file
            const int NUMBER_OF_FIELDS = 7;    // The text file will have 7 fields, The first is the date, the last is the adjusted closing price
            TextParser parser = new TextParser(",", NUMBER_OF_FIELDS);     // instantiate our general purpose text file parser object.
            List<string[]> stringArrays;    // The parser generates a List of string arrays. Each array represents one line of the text file.
            // Open the file as a stream and parse all the text
            stringArrays = parser.ParseText(File.Open(solutionDir + @"DataAccess-Console/CsvFiles/" + file, FileMode.Open));

            // Don't use the first array, it's a header
            stringArrays.RemoveAt(0);

            // Show the first date in Ticks
            DateTime firstDate = Convert.ToDateTime(stringArrays[0][0]);
            Console.WriteLine("Beginning Date: {0} = {1} Ticks", firstDate.ToString(), firstDate.Ticks);

            // Copy the List of strings into our Database
            int pk = 0;
            foreach (string[] stockInfo in stringArrays)
            {
                pk += db.Insert(new Stock()
                {
                    Symbol = symbol,
                    Name = name,
                    Date = Convert.ToDateTime(stockInfo[0]),
                    ClosingPrice = decimal.Parse(stockInfo[6])
                });
                // Give an update every 100 rows
                if (pk % 100 == 0)
                    Console.WriteLine("{0} {1} rows inserted", pk, symbol);
            }
            // Show the final count of rows inserted
            Console.WriteLine("{0} {1} rows inserted", pk, symbol);

        }
    }
}
