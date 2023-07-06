using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Grocery_store
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Reader();


        }

        static void Reader()
        {
            StreamReader streamReader = new StreamReader("Products.txt");

            List<Item> items = new List<Item>();

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
