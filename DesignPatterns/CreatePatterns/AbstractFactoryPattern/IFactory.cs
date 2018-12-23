using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactoryPattern
{
    /// <summary>
    /// 抽象工厂
    /// </summary>
    public  interface IFactory
    {
        /// <summary>
        /// 具体产品
        /// </summary>
        /// <returns></returns>
        IUser CreateUser();
        IDepartment CreateDepartment();
    }

    /// <summary>
    /// 具体产品IUser
    /// </summary>
    public interface IUser
    {
        void Insert();
        void Select();
    }

    /// <summary>
    /// 具体产品IDepartment
    /// </summary>
    public interface IDepartment
    {
        void Insert();
        void Select();
    }
}
