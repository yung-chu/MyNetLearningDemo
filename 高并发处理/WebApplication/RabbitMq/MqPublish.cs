﻿using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace WebApplication
{
    /// <summary>
    /// 发布者
    /// </summary>
    public class MqPublish
    {
        public const string QueueName = "NET";
        public static IList<User> UserList = new List<User>();


        /// <summary>
        /// 添加到队列
        /// </summary>
        public static void AddQueue(User user)
        {
            //创建一个channel
            using (var channel = MqHelper.GetNewConnection().CreateModel())
            {
                //json序列化
                var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(user));

                //发布消息
                channel.BasicPublish(String.Empty, QueueName, null, bytes);
            }
        }
    }
}