using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;


namespace Grocery_store
{
    internal class Program
    {
        

        static void Main(string[] args)
        {
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

            Console.WriteLine("Choose an option (1-4)");
            Console.WriteLine("1 - Add a new product to the store");
            Console.WriteLine("2 - Buy an item");
            Console.WriteLine("3 - Check availability");
            Console.WriteLine("4 - See all items");

            int option = int.Parse(Console.ReadLine());

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

                PromtWriter(id, name, cat, pr, qu);
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
                        
                    }

                    if (found)
                    {
                        Console.WriteLine("Product exists in the list, how many do you want?");
                        int amount = int.Parse(Console.ReadLine());


                        if (item.Quantity >= amount)
                        {
                            Console.WriteLine($"Product exists and the quantity is sufficient and the price is {item.Price * amount}");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Not enogh in stock");
                            break;
                        }

                    }
                    else
                    {
                        Console.WriteLine("Product is not avbailable");
                        break;
                    }
                }
               
            }

            else if (option == 3)
            {

            }

            else if (option == 4)
            {

                WriteItems();
            }
        }

        static void PromtWriter(int productId, string name, string cayegory, double price, int quantity)
        {
            using (StreamWriter writer = new StreamWriter("Products.txt", true))
            {
                writer.WriteLine($"{productId},{name},{cayegory},{price},{quantity}");
            }
        }

        static void WriteItems()
        {
            using (StreamReader reader = new StreamReader("Products.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }

               
        }
    }
}
