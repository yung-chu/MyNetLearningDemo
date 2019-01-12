using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrentCollectionExample
{
    /// <summary>
    /// https://blog.csdn.net/q3585914/article/details/79231268 
    /// </summary>
    public class ConcurrentQueueExample
    {
        
        //private static readonly IList<Product> Products = new List<Product>();
        private static readonly ConcurrentQueue<Product> Products = new ConcurrentQueue<Product>();

        public static void  GetProductsCount()
        {
           var task1= Task.Factory.StartNew(AddProducts);
           var task2 = Task.Factory.StartNew(AddProducts);
           var task3 = Task.Factory.StartNew(AddProducts);
           Task.WaitAll(task1, task2, task3);//同步执行

           Console.WriteLine(Products.Count);
        }

        private static void AddProducts()
        {
            for (int i = 0; i < 1000; i++)
            {
                Product product = new Product {Name = "name" + i, Category = "Category" + i, SellPrice = i};
                // Products.Add(product);
                Products.Enqueue(product);
            }

            Task.Delay(1000);
        }
    }

    public  class Product
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public int SellPrice { get; set; }
    }

}
