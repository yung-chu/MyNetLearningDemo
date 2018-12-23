using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactoryPattern
{
    /// <summary>
    /// 具体工厂
    /// </summary>
    public class SqlServerFactory: IFactory
    {
        public IUser CreateUser()
        {
            return  new SqlServerUser();
        }

        public IDepartment CreateDepartment()
        {
            return new SqlServerDepartment();
        }
    }

    /// <summary>
    /// 抽象产品
    /// </summary>
    public class SqlServerUser : IUser
    {
        public void Insert()
        {
            Console.WriteLine("sqlserver 插入用户");
        }

        public void Select()
        {
            Console.WriteLine("sqlserver 查询用户");
        }
    }
    public class SqlServerDepartment : IDepartment
    {
        public void Insert()
        {
            Console.WriteLine("sqlserver 插入部门");
        }

        public void Select()
        {
            Console.WriteLine("sqlserver 查询部门"); ;
        }
    }
}
