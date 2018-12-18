using System;
using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using WebApplication;

namespace MqConsumer
{
    /// <summary>
    /// https://www.cnblogs.com/LiangSW/p/6428313.html
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
         
            using (var channel = MqHelper.GetConnection().CreateModel()) // 创建通道
            {
                //定义队列
                channel.QueueDeclare(queue:"NET", durable: true, exclusive: false, autoDelete:false, arguments: null);
                //公平分配(在处理并确认前一条消息之前，不要向队列发送新消息)
                channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);
                //事件基本消费者
                var consumber = new EventingBasicConsumer(channel);
    
                consumber.Received += (sender, e) =>
                {
                    try
                    {
                        var user = JsonConvert.DeserializeObject<User>(Encoding.UTF8.GetString(e.Body));
                        //Incr
                        var database = RedisManager.Instance.GetDatabase();
                        var flag = database.StringIncrement(user.Id.ToString());


                        if (flag == 1)
                        {
                            //用户的第一次请求,为有效请求
                            //下面开始入库,这里使用List做为模拟
                            Console.WriteLine($"{user.Id}标识为{flag} {user.Name}");

                            DapperHelper.Insert(new Person() { Id2 = user.Id.ToString(), Name = user.Name });

                            //添加入库标识
                            database.StringIncrement($"{user.Id.ToString()}入库");

                            Console.WriteLine("入库成功");

                        }

                        //用户的N次请求,为无效请求,消息被消费
                        channel.BasicAck(e.DeliveryTag, false);
                    }

                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                };

                Console.WriteLine("开始工作");
                //启动消费者 设置为手动应答消息
                channel.BasicConsume("NET", false, consumber);
                Console.ReadKey();

            }

        }
    }
}
