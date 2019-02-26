using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethodPattern
{
    /// <summary>
    /// 抽象工厂
    /// </summary>
    public interface IFactory
    {
        ICoatProduct CreateCoat();
    }


    /// <summary>
    /// 具体工厂类:用于创建商务上衣类
    /// </summary>
    public class BusinessFactory : IFactory
    {
        public ICoatProduct CreateCoat()
        {
            return new BusinessCoat();
        }
    }

    /// <summary>
    /// 具体工厂类,用于创建时尚上衣
    /// </summary>
    public class FashionFactory : IFactory
    {
        public ICoatProduct CreateCoat()
        {
            return new FashionCoat();
        }
    }
}
