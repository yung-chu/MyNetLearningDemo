using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Configuration;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;

namespace WebApplication
{
    public class DapperHelper
    {
        public static string ConnectionStr
        {
            get
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables().Build();
     

                return builder.GetConnectionString("Default");
            }
        }


        public static int Insert(Person person)
        {
            try
            {
                //appsettings.json 始终复制
                IDbConnection connection = new SqlConnection(ConnectionStr);
                return connection.Execute("Insert into person(Id2,Name) values (@Id2,@Name)", person);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        public static int Query()
        {
            IDbConnection connection = new SqlConnection(ConnectionStr);
            return connection.QuerySingle("select count(0) from Person");
        }

    }
}
