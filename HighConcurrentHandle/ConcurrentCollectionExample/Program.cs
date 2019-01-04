using System;

namespace ConcurrentCollectionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**********并发集合使用***************");
            // ConcurrentQueue
            ConcurrentQueueEx1.GetProductsCount();


            Console.ReadKey();
        }
    }


}
