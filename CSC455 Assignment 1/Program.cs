using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CSC455_Assignment_1
{
    public class Dino
    {
        public string Name {  get; set; }
        public string Period { get; set; }
        public string Diet { get; set; }

        // Constructor
        public Dino(string name, string period, string diet)
        {
            Name = name;
            Period = period;
            Diet = diet;
        }

        //Generate list of Dinos
        public static List<Dino> GenerateDinos()
        {
            return new List<Dino>
            {
                new Dino("Placerias", "Triassic", "Herbivore"),
                new Dino("Eoraptor", "Triassic", "Omnivore"),
                new Dino("Proganchelys", "Triassic", "Herbivore"),
                new Dino("Cryptoclidus", "Jurassic", "Carnivore"),
                new Dino("Vulcanodon", "Jurassic", "Herbivore"),
                new Dino("Dimorphodon", "Jurassic", "Carnivore"),
                new Dino("Pterodactyl", "Jurassic", "Carnivore"),
                new Dino("Triceratops", "Cretaceous", "Herbivore"),
                new Dino("Utahraptor", "Cretaceous", "Carnivore"),
                new Dino("Tyrannosaurus", "Cretaceous", "Carnivore"),
            };
        }
    }
    internal class Program
    {
        // Random instance
        private static Random rnd = new Random();

        static void Main(string[] args)
        {

            bool keepRunning = true;    // Bool for exiting menu loop

            // Welcome message
            Console.WriteLine("Welcome! Please select an option (or press 'Q' to quit)");

            // Loop to let user keep interacting until finished
            while (keepRunning)
            {
                // Display options/console menu
                Console.WriteLine("1) Random Integer\n2) Today's Date\n3) Dino Names\n4) Random String Action\nQ) Quit");
                Console.Write("Please select an option: ");

                // Read option from user
                string userInput = Console.ReadLine();
                Console.WriteLine();

                // Handle input (repeatedly)
                switch (userInput)
                {
                    // Random integer from 1 to 10
                    case "1":
                        int randomInt = rnd.Next(1, 11);

                        // Drum roll for fun
                        Console.WriteLine("Drum roll please...");
                        for(int i = 0; i < 2; i++)
                        {
                            Console.Write(". ");
                            Thread.Sleep(400);
                        }
                        Console.WriteLine($"\nYour lucky number is: {randomInt}\n");
                        break;
                    
                    // Today's Date in Short Date String format
                    case "2":
                        DateTime date = DateTime.Now;
                        var shortDate = date.ToShortDateString();
                        Console.WriteLine($"Today's date is: {shortDate}\n");

                        break;
                    
                    // List of 10 Dino Names
                    case "3":
                        
                        // Create list & order by name using LINQ
                        List<Dino> dinoList = Dino.GenerateDinos();
                        dinoList = dinoList.OrderBy(a => a.Name).ToList();

                        // Output random dino name
                        int randIndex = rnd.Next(dinoList.Count);
                        Dino dino = dinoList.ElementAt(randIndex);
                        Console.WriteLine($"{dino.Name}\n");

                        break;

                    // Read a string & perform a random action on it
                    case "4":

                        // Prompt input
                        Console.Write("Please enter a string: ");
                        string inputString = Console.ReadLine();

                        // Potential actions to be performed
                        var randomActions = new List<Func<string, string>>
                        {
                            str => new string(str.Reverse().ToArray()), // Reverse string
                            str => str.ToLower(), // Make all lowercase
                            str => str.ToUpper(), // Make all uppercase
                            str => str.Contains("j") ? "Contains the letter 'j'" : "Does not contain the letter 'j'",
                            str => str.EndsWith(".") ? "You have correct punctuation, nice!" : "You forgot a '.' at the end!",
                            str => str.Length.ToString(), // Return length
                            str => str.Replace(" ", ""), // Remove spaces
                            str => str.PadLeft(15, '*'),
                            str => $"Sum of ASCII values of input: {str.Sum(c => (int)c)}",
                            str => $"Unique characters: {new string(str.Distinct().ToArray())}",
                        };

                        // Perform random action on input string & output resultant string
                        int randomIndex = rnd.Next(randomActions.Count);
                        string result = randomActions[randomIndex](inputString);
                        Console.WriteLine($"{result}\n");

                        break;

                    // Quit
                    case "Q":
                    case "q":
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;

                    default:
                        Console.WriteLine("Please enter a valid option\n");
                        break;
                }
            }

        }
    }
}
