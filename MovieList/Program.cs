using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieList
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Movie List Application!");
            MakeLineSpace(1);

            // Set Up List of Movies and valid categories
            List<Movie> movies = new List<Movie>
            {
                new Movie("The Fantastics", "Animated"), new Movie("Montana Smith and the Diamond Cranium", "Drama"),
                new Movie("Begin, Player Two!", "Sci-Fi"), new Movie("Sherlock Lost His Hat", "Horror"),
                new Movie("Astral Walk: New Start", "Sci-Fi"), new Movie("Peeved Avians", "Animated"),
                new Movie("Voxels", "Horror"), new Movie("The Workplace: Overtime and Out of Coffee", "Drama"),
                new Movie("Grover Cleaveland: A Tale of Two Non-Consequtive Terms", "Animated"), new Movie("That", "Horror")
            };
            List<string> categories = new List<string>
            {
                "Animated", "Drama", "Sci-Fi", "Horror"
            };

            // Application Loop
            bool done = false;
            while (!done)
            {
                // Display the amount of available movies and category options
                Console.WriteLine("There are currently {0} movies available for viewing.", movies.Count);
                Console.WriteLine("Which category are you interested in?");
                MakeLineSpace(1);
                int categoryMenuCount = 0;
                foreach (string c in categories) 
                {
                    Console.WriteLine("    {0}. {1}", categoryMenuCount + 1, categories[categoryMenuCount]);
                    categoryMenuCount++;
                }
                MakeLineSpace(1);

                // Menu Selection Loop
                bool menuInputValid = false;
                int selectInt = -1;
                while (!menuInputValid)
                {
                    // User selects a number shown in the menu above, runs that value-1 for a matching index in the category list.
                    // Valid values are non-blank and integers.
                    // Integers outside the range are considered invalid.
                    string selectStr = PromptForInput("Please enter a number shown above: ");
                    try
                    {
                        selectInt = int.Parse(selectStr);
                        if (selectInt < 1 || selectInt > categories.Count)
                        {
                            Console.WriteLine("Error: Integer option not available. Please enter an integer shown above.");
                        }
                        else
                        {
                            menuInputValid = true;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Error: Non-Integer input. Please enter an integer shown above.");
                    }
                }
                MakeLineSpace(1);
                
                // Search the categories for the appropriate selection and then display a list of movies that match the category
                for (int i = 0; i < categories.Count; i++)
                {
                    if (i == selectInt-1)
                    {
                        SearchListByCategory(movies, categories[i]);
                    }
                }

                // Continue Prompy via AskToContinue call
                done = AskToContinue();
                MakeLineSpace(1);
            };
        }

        // Goes through the given list of Movies for Movie instances that have a category that matches the given string
        public static void SearchListByCategory(List<Movie> movies, string category)
        {
            Console.WriteLine("Searching for '{0}' Movies...", category);
            MakeLineSpace(1);
            List<Movie> results = new List<Movie>();
            foreach (Movie m in movies)
            {
                if ((m.Category).Equals(category))
                {
                    results.Add(m);
                }
            }
            if (results.Count == 0)
            {
                Console.WriteLine("No movies were found of category '{0}'", category);
            }
            else
            {
                results = SortListByTitle(results);
                foreach (Movie m in results)
                {
                    Console.WriteLine("    " + m.Title);
                }
            }
            MakeLineSpace(1);
            Console.WriteLine("Done. {0} movie(s) were found.", results.Count);
            MakeLineSpace(1);
        }

        // Takes a Movie List and sorts all elements by their name values.
        public static List<Movie> SortListByTitle(List<Movie> list)
        {
            List<Movie> sortedList = list.OrderBy(x => x.Title).ToList();
            return sortedList;
        }

        // ============================================================================================================================
        // Formatting Methods: Provides common functionality for most input-oriented console applications

        // Prompts user for an input, with the message parameter serving as context. Returns the string generated by the user's input.
        // Does not allow blank inputs, and will repeat until an input is given.
        public static string PromptForInput(string message)
        {
            while (true)
            {
                Console.Write(message);
                string userInput = (Console.ReadLine()).Trim();
                if (userInput.Length > 0)
                {
                    return userInput;
                }
            }
        }

        // Prompts user if they want to continue using the program. 
        // If yes, then let the loop iterate. Otherwise, stop the loop by setting done to true.
        public static bool AskToContinue()
        {
            while (true)
            {
                string inputStr = PromptForInput("Would you like to continue using the Movie List Application? (y/n) ");
                inputStr = inputStr.Trim().ToLower();
                if (inputStr.Equals("y"))
                {
                    Console.Clear();
                    return false;
                }
                else if (inputStr.Equals("n"))
                {
                    Console.WriteLine($"Thank you for using the Movie List Application! Have a nice day!");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Error: Please input y/Y or n/N.");
                }
            }
        }

        // Adds empty lines in console for formatting
        public static void MakeLineSpace(int x)
        {
            for (int i = 0; i < x; i++)
            {
                Console.WriteLine(" ");
            }
        }
    }
}
