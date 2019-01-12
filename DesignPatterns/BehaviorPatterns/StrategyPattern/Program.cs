using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyPattern
{
    class Program
    {
        //http://www.cnblogs.com/zhili/p/StragetyPattern.html
        static void Main(string[] args)
        {
           var concreteStrategyA = new ConcreteStrategyA();
           var concreteStrategyB = new ConcreteStrategyB();
           new Context(concreteStrategyB).Implement();

        }
    }
}
