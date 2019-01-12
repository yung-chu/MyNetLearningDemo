using System;

namespace StrategyPattern
{
    //环境角色（Context）：持有一个Strategy类的引用
    internal class Context
    {
        private readonly Strategy _strategy;
        public Context(Strategy strategy)
        {
            _strategy = strategy;
        }

        public void Implement()
        {
            _strategy.AlgorithmImplement();
        }
    }

    //抽象策略角色（Strategy）：这是一个抽象角色，通常由一个接口或抽象类来实现。
    //此角色给出所有具体策略类所需实现的接口。
    internal abstract class Strategy
    {
        public abstract void AlgorithmImplement();
    }


    //具体策略角色（ConcreteStrategy）：包装了相关算法或行为。
    internal class ConcreteStrategyA : Strategy
    {
        public override void AlgorithmImplement()
        {
            Console.WriteLine("算法A实现");
        }
    }

    internal class ConcreteStrategyB : Strategy
    {
        public override void AlgorithmImplement()
        {
            Console.WriteLine("算法B实现");
        }
    }

}
