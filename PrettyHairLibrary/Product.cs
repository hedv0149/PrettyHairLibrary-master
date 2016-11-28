using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrettyHairLibrary
{
    public class Product
    {
        private double _price;
        private int _amount;
        public Product(int id, string description, double price, int amount)
        {
            ID = id;
            Description = description;
            Price = price;
            Amount = amount;
        }

        public int ID { get; set; }
        public string Description { get; set; }
        public double Price { get { return _price; } set { if (value < 0) { throw new Exception("Please input a price that is greater than or equal to 0."); } else { _price = value; } } }
        public int Amount { get { return _amount; } set { if (value < 0) { throw new Exception("Please input an amount that is greater than or equal to 0."); } else { _amount = value; } } }
        public override string ToString()
        {
            string output = "Product ID: " + ID +
                            "Product description: " + Description +
                            "Product price: " + Price +
                            "Product amount: " + Amount;
            return output;
        }
    }
}
