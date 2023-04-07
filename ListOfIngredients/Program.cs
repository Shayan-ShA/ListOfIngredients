using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace ListOfIngredients
{
    public class Program
    {
        public static readonly int numberOfMenuItems = 5;
        public static List<string> menuList = new List<string> { "Bread", "Cereal", "Dip", "Jam", "Juice", "Raw", "Salad", "Salsa", "Tofu", "Wine" };
        public static SortedSet<string> pickedList = new SortedSet<string>();

        // Randomly picking requested number of items from the menu items 
        // This information could come from the front end
        public static void PickedListFiller(int numberOfMenuItems)
        {
            var i = 0;
            Random rnd = new Random();
            while (i < numberOfMenuItems)
            {
                var idx = rnd.Next(0, menuList.Count);
                if (!pickedList.Contains(menuList[idx]))
                {
                    pickedList.Add(menuList[idx]);
                    i++;
                }
            }
        }

        static void Main(string[] args)
        {
            // First form of displaying all the ingredients needed to make the picked items from the menu
            // All the ingredients can be printed using the sorted set data structure ordered alphabetically
            var ingredientsNeeded = new SortedSet<string>();

            // Second form of displaying all the ingredient needed to make the picked items from the menu
            // Printing format: Menu item : All the ingredients 
            // Ordered alphabetically as the menu and the pipe delimited list of ingredients is ordered
            var dict = new Dictionary<string, SortedSet<string>>();

            // Randomly picking requested number of items from the menu items  
            PickedListFiller(numberOfMenuItems);

            // Filling the keys of a dictionary with the ordered picked menu itams and initializing the values 
            // as sortedset data structure to fill with the ingredients value while reading the text file
            SortedSet<string>.Enumerator em = pickedList.GetEnumerator();
            while (em.MoveNext())
            {
                dict[em.Current] = new SortedSet<string>();
            }

            // Read through the entire text file to fill 
            // If space complexity was not an issue, all the ingredients for all of the menu items could be stored
            // in a dictionary which decreases the time complexity substantially
            using (StreamReader file = new StreamReader("Menu_Items_With_Ingredients"))
            {
                string ln;

                while ((ln = file.ReadLine()) != null)
                {
                    string[] subStrings = ln.Split('|');
                    if (pickedList.Contains(subStrings[1]))
                    {
                        ingredientsNeeded.Add(subStrings[0]);
                        dict[subStrings[1]].Add(subStrings[0]);
                    }
                }
                file.Close();

                Console.WriteLine("List of the picked menue items: ");
                Console.WriteLine(String.Join(",", pickedList) + Environment.NewLine);

                Console.WriteLine("First form of displaying the ingredients needed to make the picked menu items: ");
                Console.WriteLine(String.Join(",", ingredientsNeeded) + Environment.NewLine);

                Console.WriteLine("Second form of displaying the ingredients needed to make the picked menu items: ");
                Console.WriteLine("Formart: Menu item: Required ingredients ");
                foreach (KeyValuePair<string, SortedSet<string>> kvp in dict)
                {
                    if (kvp.Value.Count == 0)
                    {
                        Console.WriteLine("{0}:{1}", kvp.Key, "N/A");
                    }
                    else
                    {
                        Console.WriteLine("{0}:{1}", kvp.Key, String.Join(",", kvp.Value));
                    }
                }
            }
        }
    }
}