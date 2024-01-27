using System;
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
                Console.WriteLine("Q) Quit");
                Console.Write("Please select an option: ");

                // Read from user
                string userInput = Console.ReadLine();
                Console.WriteLine();

                // Handle input
                switch (userInput)
                {
                    // Random integer from 1 to 10
                    case "1":
                        int randomInt = rnd.Next(1, 11); // Generate int
                        Console.WriteLine("Drum roll please...");
                        // Drum roll for fun
                        for(int i = 0; i < 4; i++)
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
                    
                    // Dino Names
                    case "3":
                        List<Dino> dinoList = Dino.GenerateDinos();
                        
                        // Order by name using LINQ
                        dinoList = dinoList.OrderBy(a => a.Name).ToList();

                        // Print ordered list out to console
                        foreach (var dino in dinoList)
                            Console.WriteLine($"{dino.Name}");

                        Console.WriteLine("\n");

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
