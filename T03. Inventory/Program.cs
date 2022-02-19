using System;
using System.Collections.Generic;
using System.Linq;

namespace T03._Inventory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> inventory = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command = Console.ReadLine();
            while (command != "Craft!")
            {
                string[] cmdArgs = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                // The second element will always be '-', so we must always avoid it (it stands on index 1).
                string action = cmdArgs[0];

                if (action == "Collect")
                {
                    string item = cmdArgs[2];

                    if (CheckIfContains(inventory, item))
                    {
                        command = Console.ReadLine();
                        continue;
                    }

                    inventory.Add(item);
                }
                else if (action == "Drop")
                {
                    string item = cmdArgs[2];

                    if (!CheckIfContains(inventory, item))
                    {
                        command = Console.ReadLine();
                        continue;
                    }

                    inventory.Remove(item);
                }
                else if (action == "Combine")
                {
                    // Combine Items - {old_item}:{new_item}
                    //    0      1   2           3
                    // We should get the 3rd index and make it an array, then split it by ':' and get the elements separated 

                    string[] combinedArray = cmdArgs[3].Split(':', StringSplitOptions.RemoveEmptyEntries);

                    string oldItem = combinedArray[0];
                    string newItem = combinedArray[1];

                    if (!CheckIfContains(inventory, oldItem))
                    {
                        command = Console.ReadLine();
                        continue;
                    }

                    // a b c d e
                    // something after 'b' (index 1)
                    inventory.Insert(inventory.IndexOf(oldItem) + 1, newItem);
                }
                else if (action == "Renew")
                {
                    string item = cmdArgs[2];

                    inventory.Add(item);
                    inventory.Remove(item);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", inventory));
        }

        static bool CheckIfContains(List<string> list, string element)
        {
            return list.Contains(element);
        }
    }
}
