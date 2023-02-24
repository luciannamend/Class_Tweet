using System;
using System.IO;
using System.Collections.Generic;
using Assignment2.Models;

namespace Assignment2.Management
{
    class TweetManager
    {
        //FIELDS:
        private static List<Tweet> TWEETS;     //Collection of all tweets in the system
        private static string FILENAME = "Assignment_02_TweetFile.txt";    


        //CONSTRUCTOR:
        static TweetManager()
        {
            //a.	Initialize the tweets field to a new list of tweets
            TWEETS = new List<Tweet>();

            //b.	Opens the file specified by the filename field for reading (Assignment_02_TweetFile.txt)
            string filePath = @$"{Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName).FullName}\{FILENAME}"; //searchs for file (*bin*) using methods 
            bool doesFileExists = File.Exists(filePath);

            if (doesFileExists)
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)     //c. i.	Reads one line from the file Using a looping
                {
                    //Console.WriteLine(line);   //TEST

                    Tweet tweet = Tweet.Parse(line);        //c. ii.	Passes this line to Parse() to create a tweet object

                    TWEETS.Add(tweet);                      //c. iii.	The resulting object is added to the tweet collection
                }

                return;
            }

            Console.WriteLine($"File {FILENAME} not found in {filePath}");


        }

        //METHOD_1:
        public static void Initialize()
        {
            //a.	Assigns the TWEETS field
            TWEETS = new List<Tweet>();

            //b.    Creates about 5 tweets objects and add them to the tweet collection
            Tweet tweet1 = new Tweet(from: "Drake", to: "Bieber", body: "FIRST Go Leafs! Go!", tag: "Leafs");
            Tweet tweet2 = new Tweet(from: "Tory", to: "Drake", body: "Yes Toronto will get them!", tag: "Leafs");
            Tweet tweet3 = new Tweet(from: "Drake", to: "Obama", body: "Go Raptors! Go!", tag: "WeTheNorth");
            Tweet tweet4 = new Tweet(from: "Trudeau", to: "Obama", body: "Toronto is the greatest city!", tag: "WeTheNorth");
            Tweet tweet5 = new Tweet(from: "Tory", to: "Drake", body: "Yes Toronto will get them!", tag: "Leafs");

            TWEETS.Add(tweet1);
            TWEETS.Add(tweet2);
            TWEETS.Add(tweet3);
            TWEETS.Add(tweet4);
            TWEETS.Add(tweet5);
        }

        //METHOD_2
        public static void ShowAll()
        {
            //displays all the tweets in the collection.

            foreach (Tweet tweet in TWEETS)
            {
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine(tweet);
                Console.WriteLine("----------------------------------------------------------");
            }
        }

        //METHOD_3
        public static void ShowAll(string tag)
        {
            //Displays all tweets with >tag matching< the argument (must be case in-sensitive.)
            foreach (Tweet tweet in TWEETS)
            {
                if (tweet.Tag.ToLower() == tag.ToLower()) {
                    Console.WriteLine(tweet);
                }
            }
        }
    }
}
