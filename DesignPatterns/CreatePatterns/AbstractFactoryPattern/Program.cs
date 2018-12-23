using System;

namespace AbstractFactoryPattern
{
    /// <summary>
    /// 就不能不换DB模式(抽象工厂模式)
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            IFactory factory = new OracleFactory();//OracleFactory
            //具体产品A
            var department = factory.CreateDepartment();
            department.Select();
            department.Insert();

            var user = factory.CreateUser();
            user.Select();
            user.Insert();
        }
    }
}
