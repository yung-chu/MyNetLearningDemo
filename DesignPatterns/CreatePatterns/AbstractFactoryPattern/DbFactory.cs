using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactoryPattern
{
    /// <summary>
    /// 抽象工厂
    /// </summary>
    public  abstract class DbFactory
    {
        /// <summary>
        /// 产品User
        /// </summary>
        /// <returns></returns>
        public abstract  UserReport CreateUser();

        /// <summary>
        /// 产品Department
        /// </summary>
        /// <returns></returns>
        public abstract DepartmentReport CreateDepartment();
    }


    /// <summary>
    /// 具体工厂
    /// </summary>
    public class OracleFactory : DbFactory
    {
        public override UserReport CreateUser()
        {
            return new OracleUser();
        }

        public override DepartmentReport CreateDepartment()
        {
            return new OracleDepartment();
        }
    }

    /// <summary>
    /// 具体工厂
    /// </summary>
    public class SqlServerFactory : DbFactory
    {
        public override UserReport CreateUser()
        {
            return new SqlServerUser();
        }

        public override DepartmentReport CreateDepartment()
        {
            return new SqlServerDepartment();
        }
    }


    public class User
    {
        public int Id { get; set; }
    }

    public class Department
    {
        public int Id { get; set; }
    }

}
