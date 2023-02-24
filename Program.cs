using System;
using System.IO;
using Assignment2.Models;
using Assignment2.Management;


namespace Assignment2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Testing:


            TweetManager.Initialize();

            TweetManager.ShowAll();

            //TweetManager.ShowAll("WETHENORTH");

        }
    }
}
