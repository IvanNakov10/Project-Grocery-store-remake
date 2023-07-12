using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Grocery_store
{
    internal class Item
    {
        private int productId;
        private string name;
        private string cayegory;
        private double price;
        private int quantity;

        public Item(int productId, string name, string cayegory, double price, int quantity)
        {
            this.productId = productId;
            this.name = name;
            this.cayegory = cayegory;
            this.price = price;
            this.quantity = quantity;
        }

        public int ProductId { get => productId; set => productId = value; }
        public string Name { get => name; set => name = value; }
        public string Cayegory { get => cayegory; set => cayegory = value; }
        public double Price { get => price; set => price = value; }
        public int Quantity { get => quantity; set => quantity = value; }

       
    }


}
