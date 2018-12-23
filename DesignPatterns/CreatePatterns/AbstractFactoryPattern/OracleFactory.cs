using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactoryPattern
{
   /// <summary>
   /// 具体工厂
   /// </summary>
    public class OracleFactory: IFactory
    {
        public IUser CreateUser()
        {
            return new OracleUser();
        }

        public IDepartment CreateDepartment()
        {
            return new OracleDepartment();
        }
    }

    /// <summary>
    /// 抽象产品
    /// </summary>
    public class OracleUser : IUser
    {
        public void Insert()
        {
           Console.WriteLine("oracle 插入用户");
        }

        public void Select()
        {
            Console.WriteLine("oracle 查询用户");
        }
    }

    public class OracleDepartment : IDepartment
    {
        public void Insert()
        {
            Console.WriteLine("oracle 插入部门");
        }

        public void Select()
        {
            Console.WriteLine("oracle 插入部门");
        }
    }

}
