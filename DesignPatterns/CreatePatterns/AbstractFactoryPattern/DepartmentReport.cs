using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactoryPattern
{
    /// <summary>
    /// 抽象产品
    /// </summary>
    public abstract class DepartmentReport
    {
        public abstract void Insert(Department department);
        public abstract void Select(int id);
    }

    public  class OracleDepartment : DepartmentReport
    {
        public override void Insert(Department department)
        {
            Console.WriteLine("oracle 插入部门");
        }

        public override void Select(int id)
        {
            Console.WriteLine("oracle 查询部门");
        }
    }

    public class SqlServerDepartment : DepartmentReport
    {
        public override void Insert(Department department)
        {
            Console.WriteLine("sqlserver 插入部门");
        }

        public override void Select(int id)
        {
            Console.WriteLine("sqlserver 查询部门");
        }
    }
}
