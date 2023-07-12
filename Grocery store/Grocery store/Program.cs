using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace Grocery_store
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            List<Item> items = new List<Item>();

            StreamReader streamReader = new StreamReader("Products.txt");

            string line = streamReader.ReadLine();
       

            while (line != null)
            {
                List<string> itemInfo = line.Split(',').ToList();

                Item current = new Item(int.Parse(itemInfo[0]), itemInfo[1], itemInfo[2], double.Parse(itemInfo[3]), int.Parse(itemInfo[4]));

                items.Add(current);

                line = streamReader.ReadLine();
            }
            streamReader.Close();

            string exit = "";
            int option = 0;

            while (exit.ToUpper() != "N5O")
            {
                Console.WriteLine("Choose an option (1-4)");
                Console.WriteLine("1 - Add a new product to the store");
                Console.WriteLine("2 - Buy an item");
                Console.WriteLine("3 - Check availability");
                Console.WriteLine("4 - See all items");
                Console.WriteLine("5 - Exit");

                option = int.Parse(Console.ReadLine());
                if (option == 1)
                {
                    Console.WriteLine("Enter item information:");
                    Console.Write("ProductId: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.Write("Product name: ");
                    string name = Console.ReadLine();
                    Console.Write("Product category: ");
                    string cat = Console.ReadLine();
                    Console.Write("Product price: ");
                    double pr = double.Parse(Console.ReadLine());
                    Console.Write("Product quantity: ");
                    int qu = int.Parse(Console.ReadLine());

                    PromtWriter(id, name, cat, pr, qu, items);
                }
                else if (option == 2)
                {
                    Console.Write("Product name: ");
                    string prompt = Console.ReadLine();

                    bool found = false;

                    foreach (Item item in items)
                    {
                        if (item.Name.Equals(prompt, StringComparison.OrdinalIgnoreCase))
                        {
                            found = true;

                            Console.WriteLine("Product exists in the list, how many do you want?");
                            int amount = int.Parse(Console.ReadLine());

                            if (item.Quantity >= amount)
                            {
                                Console.WriteLine($"Product exists and the quantity is sufficient and the price is {item.Price * amount}");
                                RemoveItemFromFile(item.Name, amount);
                            }
                            else
                            {
                                Console.WriteLine("Not enough in stock");
                            }

                            break;
                        }
                    }

                    if (!found)
                    {
                        Console.WriteLine("Product is not available");
                    }

                }
                else if (option == 3)
                {
                    Console.Write("Product name: ");
                    string prompt = Console.ReadLine();

                    bool found = false;

                    foreach (Item item in items)
                    {
                        if (item.Name.Equals(prompt, StringComparison.OrdinalIgnoreCase))
                        {
                            found = true;

                            Console.WriteLine($"Quantity available: {item.Quantity}, and the price per item is {item.Price}");
                            break;
                        }
                    }

                    if (!found)
                    {
                        Console.WriteLine("Product is not available");
                    }
                }
                else if (option == 4)
                {
                    foreach (Item item in items)
                    {
                        Console.WriteLine($"Product ID: {item.ProductId}, Product Name: {item.Name}, Product Category: {item.Cayegory}, Product Price: {item.Price}, Product Quantity: {item.Quantity}");
                    }

                }
                else if (option == 5)
                {
                    Console.WriteLine("Exiting the program...");
                    break;
                }
                else
                {
                    Console.WriteLine("There is no such option");
                }

                Console.WriteLine("Do you want to continue? (Yes/No)");
                exit = Console.ReadLine();
            }

        }
        static void PromtWriter(int productId, string name, string category, double price, int quantity, List<Item> items)
        {
            Item newItem = new Item(productId, name, category, price, quantity);
            items.Add(newItem); // Add the new item to the list

            using (StreamWriter writer = new StreamWriter("Products.txt", true))
            {
                writer.WriteLine($"{productId},{name},{category},{price},{quantity}");
            }
        }
        static void RemoveItemFromFile(string productName, int quantity)
        {
            List<string> lines = File.ReadAllLines("Products.txt").ToList();

            for (int i = 0; i < lines.Count; i++)
            {
                string[] itemInfo = lines[i].Split(',');

                if (itemInfo.Length >= 5)
                {
                    string name = itemInfo[1];
                    int availableQuantity = int.Parse(itemInfo[4]);

                    if (name.Equals(productName, StringComparison.OrdinalIgnoreCase) && availableQuantity >= quantity)
                    {
                        availableQuantity -= quantity;
                        itemInfo[4] = availableQuantity.ToString();

                        lines[i] = string.Join(",", itemInfo);
                        break;
                    }
                }
            }
            File.WriteAllLines("Products.txt", lines);
        }
    }
}
