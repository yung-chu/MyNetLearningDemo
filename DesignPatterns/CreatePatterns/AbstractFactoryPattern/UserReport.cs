using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactoryPattern
{
    /// <summary>
    /// 抽象产品
    /// </summary>
    public abstract class UserReport
    {
        public abstract void Insert(User user);
        public abstract void Select(int id);
    }

    /// <summary>
    /// 具体产品
    /// </summary>
    public  class OracleUser : UserReport
    {
        public override void Insert(User user)
        {
            Console.WriteLine("oracle 插入用户");
        }

        public override void Select(int id)
        {
            Console.WriteLine("oracle 查询用户");
        }
    }


    public  class SqlServerUser : UserReport
    {
        public override void Insert(User user)
        {
            Console.WriteLine("sqlserver 插入用户");
        }

        public override void Select(int id)
        {
            Console.WriteLine("sqlserver 查询用户");
        }
    }
}
