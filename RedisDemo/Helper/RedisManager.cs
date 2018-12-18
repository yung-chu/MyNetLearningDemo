using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;

namespace RedisDemo.Helper
{
    /// <summary>
    /// StackExchange.Redis
    /// 单例
    /// </summary>
    public class RedisManager
    {
        private RedisManager() { }
        private static ConnectionMultiplexer instance;
        private static readonly object locker = new object();

        public static string ConnectionStr
        {
            get
            {
                var  builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables().Build();


                return builder.GetConnectionString("Redis");
            }
        }

        /// <summary>
        /// 单例模式获取redis连接实例
        /// </summary>
        public static ConnectionMultiplexer Instance
        {
            get
            {
                lock (locker)
                {

                    if (instance == null)
                    {
                        if (instance == null)
                            instance = ConnectionMultiplexer.Connect(ConnectionStr); 
                    }
                }
                return instance;
            }
        }
    }
}
