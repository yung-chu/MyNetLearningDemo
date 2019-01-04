using System;

namespace DecoratorPattern
{
    /// <summary>
    /// 穿什么有这么重要?　　
    /// 动态地给一个对象添加一些额外的职责。就扩展功能而言， 它比生成子类方式更为灵活。
    /// https://blog.csdn.net/nicepainkiller/article/details/83898486
    /// https://www.cnblogs.com/revoid/p/9486668.html#6
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            ComponentPerson componentPerson = new ConcreteComponentPerson();
            //第一种装扮
            var concreteDecoratorCoat = new ConcreteDecoratorCoat();
            concreteDecoratorCoat.SetComponent(componentPerson);
            concreteDecoratorCoat.Show();

            Console.WriteLine("*******************");

            //第二种装扮
             var concreteDecoratorHair = new ConcreteDecoratorHair();
            concreteDecoratorHair.SetComponent(concreteDecoratorCoat);
            concreteDecoratorHair.Show();


            Console.ReadKey();
        }
    }
}
