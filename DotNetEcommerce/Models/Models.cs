using System;

namespace DotNetEcommerce.Models
{
    public class Constants
    {
        public static string ItemList="ItemList";
    }
    public class Order
    {
        public string Amount { get; set; }
        public string VirtualId { get; set; }
    }

    public class Product
    {
        public decimal Price { get; set; }
        public string Name { get; set; }
    }
}
