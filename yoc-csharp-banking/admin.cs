﻿// Chaim Straus

using System;
using System.Collections.Generic;

namespace yoc_csharp_banking
{
    class admin
        // admin run script
    {
        // defaults
        public static List<string> validOptions = new List<string> { "add user", "display data" };
        public static List<string> dataFields = new List<string> { "id", "name", "password (SHA256)", "balance"};
        public static void options()
            // admin option
        {

            // display all options
            Console.WriteLine("Valid options: ");
            foreach (string option in validOptions)
            {
                Console.WriteLine($"    {option}");
            }

            // get their choice
            string chosen = Console.ReadLine().ToLower();

            // do stuff based on their choice
            switch (chosen)
            {
                case "add user":
                    userManagement.addUser();
                    break;
                case "display data":
                    // displaying data is _slightly_ difficult so it's a longer code
                    Array data = userManagement.displayData();
                    int counter = 1;
                    foreach (string field in dataFields)
                    {
                        Console.Write($"{field} | ");
                    }
                    Console.WriteLine();

                    // since data is returned as a flat array we need to iterate through and print every 4 to a line
                    foreach (string point in data)
                    {
                        Console.Write(point);
                        if (counter % 4 == 0)
                        {
                            Console.WriteLine();
                        }
                        else
                            Console.Write(" | ");
                        counter++;
                    }

                    Console.WriteLine("\nPress enter to exit:");
                    Console.ReadLine();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine($"I'm sorry, but {chosen} is not a valid option.");
                    Console.WriteLine("What would you like to do?");
                    options();
                    break;
            }
        }
    }
}
