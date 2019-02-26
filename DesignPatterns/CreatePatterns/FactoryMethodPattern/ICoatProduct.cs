using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethodPattern
{
    /// <summary>
    /// 抽象产品角色
    /// </summary>
    public interface ICoatProduct
    {
        void ShowCoat();
    }

    /// <summary>
    /// 具体产品类
    /// </summary>
    public class BusinessCoat : ICoatProduct
    {
        public void ShowCoat()
        {
            Console.WriteLine("这件是商务上衣");
        }
    }


    /// <summary>
    /// 具体产品类
    /// </summary>
    public class FashionCoat : ICoatProduct
    {
        public void ShowCoat()
        {
            Console.WriteLine("这件是时尚上衣");
        }
    }
}
