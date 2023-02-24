using System;
using System.IO;
using Assignment2.Management;

namespace Assignment2.Models
{
    public class Tweet
    {
        //FIELD:
        private static int CURRENT_ID;    // number to be used in setting the id of this tweet


        //PROPERTIES:
        // - those properties have absent setter
        public string From { get; }      // originator of this tweet

        public string To { get; }        // intended recipient of this tweet. 

        public string Body { get; }      // actual message body of this tweet            

        public string Tag { get; }       // hash tag of this tweet. 

        public string Id { get; }        // uniquely identify a tweet.


        //CONSTRUCTORS:
        public Tweet (string from, string to, string body, string tag) 
        {
            //a.	Assigns the arguments to the appropriate properties. 

            From = from;
            To = to;
            Body = body;
            Tag = tag;

            //b.	Sets the Id property using the class variable CURRENT_ID. 
            Id = CURRENT_ID.ToString();

            //c.	CURRENT_ID is then incremented 
            ++CURRENT_ID;  
        }
        
        public Tweet(string from, string to, string body, string tag, string id) //Called by Tweet Parse().
        {
            // a.Assigns the arguments to the appropriate properties.
            From = from;
            To = to;
            Body = body;
            Tag = tag;
            Id = id;
        }


        //METHOD_1:
        //returns a string representation of itself
        public override string ToString() 
        {
            string updatedBody = Body;

            // Check if the length of the body exceeds 40 letters
            if (Body.Length > 40) {
                updatedBody = updatedBody.Substring(0, 40);      // it will show only the first 40 indexes       
            }
            
            // returns a string representation of itself
            return $"  From: {From}\n" +
                       $"  To: {To} \n" +
                       $"  Message: {updatedBody}\n" +   
                       $"  Tag: {Tag}  \n" +
                       $"  Id: {Id}\n";
        }


        //METHOD_2: 
        //creates a Tweet object when loading the tweets from a file
        public static Tweet Parse(string line)  //receives a line
        {            
            string[] columns = line.Split(new char[] { '\t' });    //separates line into columns
            Tweet tweetOrderedByColumns = new Tweet(columns[1], columns[2], columns[3], columns[0], columns[4]);

            return tweetOrderedByColumns;
        }


    }
}
