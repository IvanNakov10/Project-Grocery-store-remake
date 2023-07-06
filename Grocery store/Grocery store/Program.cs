﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Grocery_store
{
    internal class Program
    {
        List<Item> items = new List<Item>();

        void Main(string[] args)
        {
            Reader();

            Console.WriteLine("Choose an option (1-4)");
            Console.WriteLine("1 - Add a new product to the store");
            Console.WriteLine("2 - Sell an item");
            Console.WriteLine("3 - Check availability");
            Console.WriteLine("4 - See all items");

            int option = int.Parse(Console.ReadLine());

            if (option == 1)
            {

            }

            else if (option == 2)
            {

            }

            else if (option == 3)
            {

            }

            else if (option == 4)
            {

            }

            StreamReader streamWriter = new StreamReader("Products.txt");

            using (streamWriter)
            {
                foreach (Item it in items)
                {

                }
            }

            void Reader()
            {
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
            }

        }
    }
}
