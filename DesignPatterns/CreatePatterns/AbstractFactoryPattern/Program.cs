using System;

namespace AbstractFactoryPattern
{
    /// <summary>
    /// 就不能不换DB模式(抽象工厂模式),
    /// 提供一个创建一系列相关或相互依赖对象的接口，而无需指定它们具体的类。
    /// https://www.cnblogs.com/revoid/p/9486668.html#15
    /// http://www.cnblogs.com/zhili/p/AbstractFactory.html
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            DbFactory factory = new SqlServerFactory();
            //具体产品A
            var department = factory.CreateDepartment();
            department.Select(1);

            factory =new OracleFactory();
            var user = factory.CreateDepartment();
            user.Select(1);
        }
    }
}
