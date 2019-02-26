using System;

namespace FactoryMethodPattern
{
    /// <summary>
    ///目的：定义一个用户创建对象的接口，让子类决定实例化哪一个类，
    /// 工厂方法模式使一个类的实例化延迟到其子类。
    /// https://www.cnblogs.com/yinxiangpei/articles/2366092.html
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            IFactory factory = new BusinessFactory();
            ICoatProduct coatProduct = factory.CreateCoat();
            coatProduct.ShowCoat();
        }
    }

}
