using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CSC455_Assignment_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();  // Prep for random numbers
            bool keepRunning = true;    // Bool for exiting menu loop

            // Welcome message
            Console.WriteLine("Welcome! Please select an option (or press 'Q' to quit)");

            while (keepRunning)
            {
                // Display options/console menu
                Console.WriteLine("1) Random Integer");
                Console.WriteLine("2) Today's Date");
                Console.WriteLine("3) Dino Names");
                Console.WriteLine("4) Random String Action");
                Console.WriteLine("Q) Quit\n");

                Console.Write("Please select an option: ");

                // Read from user
                string userInput = Console.ReadLine();

                // Handle input
                switch (userInput)
                {

                    // Random int
                    case "1":
                        int randomInt = rnd.Next(1, 11); // Generate random int between 1 and 10
                        Console.WriteLine("Drum roll please...");
                        for(int i = 0; i < 4; i++)
                        {
                            Console.Write(". ");
                            Thread.Sleep(600);
                        }
                        Console.WriteLine($"\nYour lucky number is: {randomInt}\n");

                        break;
                    
                    // Today's Date
                    case "2":
                        break;
                    
                    // Dino Names
                    case "3":
                        break;

                    // Random String Action
                    case "4":
                        break;

                    // Quit
                    case "Q":
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                }
            }

        }
    }
}
