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
    public class Program
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
                        int randomInt = GenerateRandomInt(1, 11);

                        // Drum roll for fun
                        DrumRoll(400);
                        DisplayRandomInt(randomInt);

                        break;
                    
                    // Today's Date in Short Date String format
                    case "2":

                        // Very condensed calls to print date after converting
                        PrintTodaysDate(ConvertDateToString(GetTodaysDate()));

                        break;
                    
                    // List of 10 Dino Names
                    case "3":

                        // Create list & order by name using LINQ
                        List<Dino> dinoList = CreateDinoList();
                        dinoList = SortDinoList(dinoList);

                        // Output random dino name
                        Print(RandomDinoName(dinoList, RandomIndex(dinoList)));
                        

                        break;

                    // Read a string & perform a random action on it
                    case "4":

                        // Prompt & Take Input
                        string inputString = ReceiveInput();

                        // Perform random action on input string & output resultant string
                        Print(PerformRandomAction(GenerateRandomDinoActions(), inputString, RandomIndex(GenerateRandomDinoActions())));

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

        public static int GenerateRandomInt(int min, int max)
        {
            return rnd.Next(min, max);
        }
        public static void DisplayRandomInt(int randomInt)
        {
            Console.WriteLine($"\nYour lucky number is: {randomInt}\n");
        }
        public static void DrumRoll(int timeToWaste)
        {
            Console.WriteLine("Drum roll please...");
            for (int i = 0; i < 2; i++)
            {
                Console.Write(". ");
                Thread.Sleep(timeToWaste);
            }
        }
        public static DateTime GetTodaysDate()
        {
            return DateTime.Now;
        }
        public static string ConvertDateToString(DateTime date)
        {
            return date.ToShortDateString();
        }
        public static void PrintTodaysDate(string shortDate)
        {
            Console.WriteLine($"Today's date is: {shortDate}\n");
        }
        public static List<Dino> CreateDinoList()
        {
            return Dino.GenerateDinos();
        }
        public static List<Dino> SortDinoList(List<Dino> dinoList)
        {
            return dinoList.OrderBy(a => a.Name).ToList();
        }
        public static int RandomIndex<T>(List<T> list)
        {
            return rnd.Next(list.Count);
        }
        public static string RandomDinoName(List<Dino> dinoList, int randIndex)
        {
            Dino dino = dinoList.ElementAt(randIndex);
            return dino.Name;
        }
        public static void Print(string textString)
        {
            Console.WriteLine($"{textString}\n");
        }
        public static string ReceiveInput()
        {
            Console.Write("Please enter a string: ");
            return Console.ReadLine();
        }
        public static List<Func<string, string>> GenerateRandomDinoActions()
        {
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
            return randomActions;
        }
        public static string PerformRandomAction(List<Func<string, string>> randomActions, string inputString, int randIndex)
        {
            return randomActions[randIndex](inputString);
        }

    }
}
