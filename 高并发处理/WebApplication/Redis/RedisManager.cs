using System;
using System.Collections.Generic;
using System.Text;
using StackExchange.Redis;

namespace WebApplication
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
                            instance = ConnectionMultiplexer.Connect("10.99.59.47:7000"); //这里应该配置文件，不过这里演示就没写
                    }
                }
                return instance;
            }
        }
    }
}
