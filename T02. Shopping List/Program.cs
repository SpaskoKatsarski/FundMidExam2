using System;
using System.Collections.Generic;
using System.Linq;

namespace T02._Shopping_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> shoppingList = Console.ReadLine()
                .Split('!', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command = Console.ReadLine();
            while (command != "Go Shopping!")
            {
                string[] cmdArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string action = cmdArgs[0];

                if (action == "Urgent")
                {
                    string item = cmdArgs[1];

                    if (CheckIfListContainsGivenItem(shoppingList, item))
                    {
                        command = Console.ReadLine();
                        continue;
                    }

                    shoppingList.Insert(0, item);
                }
                else if (action == "Unnecessary")
                {
                    string item = cmdArgs[1];

                    if (!CheckIfListContainsGivenItem(shoppingList, item))
                    {
                        command = Console.ReadLine();
                        continue;
                    }

                    shoppingList.Remove(item);
                }
                else if (action == "Correct")
                {
                    string oldItem = cmdArgs[1];
                    string newItem = cmdArgs[2];

                    if (!CheckIfListContainsGivenItem(shoppingList, oldItem))
                    {
                        command = Console.ReadLine();
                        continue;
                    }

                    int indexOfOldItem = shoppingList.IndexOf(oldItem);
                    shoppingList.Insert(indexOfOldItem, newItem);
                    shoppingList.Remove(oldItem);
                }
                else if (action == "Rearrange")
                {
                    string item = cmdArgs[1];

                    if (!CheckIfListContainsGivenItem(shoppingList, item))
                    {
                        command = Console.ReadLine();
                        continue;
                    }

                    shoppingList.Add(item);
                    shoppingList.Remove(item);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", shoppingList));
        }

        static bool CheckIfListContainsGivenItem (List<string> list, string item)
        {
            return list.Contains(item);
        }
    }
}
