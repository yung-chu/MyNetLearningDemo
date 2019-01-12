using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrentCollectionExample
{
    public class ConcurrentDictionaryExample
    {
        //private static readonly Dictionary<string, string> _dictionary = new Dictionary<string, string>();
        private static readonly ConcurrentDictionary<string, string> _dictionary = new ConcurrentDictionary<string, string>();

        public static ConcurrentDictionary<string, string> GetDictionary()
        {
           var task1=  Task.Run(() => AddDictionary(1, 50));
           var task2 = Task.Run(() => AddDictionary(51, 60));
           var task3 = Task.Run(() => AddDictionary(61, 70));
           Task.WaitAll(task1, task2, task3);

            return _dictionary;
        }

        private static ConcurrentDictionary<string, string> AddDictionary(int start,int end)
        {
           
            for (int i = start; i <= end; i++)
            {
                //_dictionary.Add(i.ToString(), i + "value");
                _dictionary.TryAdd(i.ToString(), i + "value");
            }

            return _dictionary;
        }
    }
}
