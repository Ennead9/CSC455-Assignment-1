using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC455_Assignment_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool keepRunning = true;

            while (keepRunning)
            {
                // Display options/console menu
                Console.WriteLine("Welcome! Please select an option (or press 'Q' to quit)");
                Console.WriteLine("1) Random Integer");
                Console.WriteLine("2) Today's Date");
                Console.WriteLine("3) Dino Names");
                Console.WriteLine("4) Random String Action");
                Console.WriteLine("Q) Quit\n");

                Console.Write("Your option: ");

                // Read from user
                string userInput = Console.ReadLine();

                // Handle input
                switch (userInput)
                {

                    // Random int
                    case "1":
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
