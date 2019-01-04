using System;

namespace AdapterPatterns
{
    /// <summary>
    /// [适配器模式(Adapter)]将一个类的接口转换成客户希望的另外一个接口
    /// Adapter模式使得原本由于接口不兼容而不能一起工作的那些类可以一起工作
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Target target=new Adapter();
            target.Request();
        }
    }


    /// <summary>
    /// 目标类
    /// </summary>
    public abstract  class Target
    {
        public virtual void Request()
        {
            Console.WriteLine("说英语");
        }
    }

    /// <summary>
    /// 适配者
    /// </summary>
    public class Adaptee
    {
        public void SepcificRequest()
        {
            Console.WriteLine("说中文");
        }
    }

    /// <summary>
    /// 适配器
    /// </summary>
    public class Adapter: Target
    {
        private readonly Adaptee _adaptee=new Adaptee();
        public override void Request()
        {
            _adaptee.SepcificRequest();
            Console.WriteLine("翻译成英语");
        }
    }
}
