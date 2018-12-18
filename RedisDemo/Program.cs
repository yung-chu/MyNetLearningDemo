using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using RedisDemo.Helper;
using StackExchange.Redis;

namespace RedisDemo
{
    /// <summary>
    /// https://www.cnblogs.com/nsky/p/8358488.html
    /// </summary>
    class Program
    {
        static IDatabase db = RedisManager.Instance.GetDatabase();
        static void Main(string[] args)
        {



        }
    }



    public class RedisDemo
    {
        static IDatabase db = RedisManager.Instance.GetDatabase();
        public static void StringOperation()
        {
            db.StringSet("name", "张三");
            db.StringSet("age", 90);

            string name = db.StringGet("name");
            string age = db.StringGet("age");
            Console.WriteLine($"name:" + name + "age:" + age);

            //INCR key 对存储在指定key的数值执行原子的加1操作
            //http://www.redis.cn/commands/incr.html
            string value = "张三";
            db.StringIncrement(value);

            //过期时间
            // http://www.redis.cn/commands/expire.html
            TimeSpan interval = DateTime.Now.AddSeconds(10) - DateTime.Now;
            RedisDemo.db.KeyExpire(value, interval);


            Console.WriteLine(RedisDemo.db.StringGet(value));



        }

        public static void TransactionOperator()
        {

            db.StringSet("name", "张三");
            db.StringSet("age", 90);

            string name = db.StringGet("name");
            string age = db.StringGet("age");
            Console.WriteLine("name:" + name);
            Console.WriteLine("age:" + age);


            ITransaction trans = db.CreateTransaction();

            //锁定RedisKey=name RedisValue=张三的缓存
            trans.AddCondition(Condition.StringEqual("name", name));
            Console.WriteLine("begin trans");
            trans.StringSetAsync("name", "Tom");

            //执行任务前修改
            db.StringSet("name", "zhuyong");

            bool isExec = trans.Execute(); //提交事物，name才会修改成功 name = Tom

            Console.WriteLine("事物执行结果：" + isExec);


            Console.WriteLine("name:" + name);
            Console.WriteLine("age:" + age);

            Console.WriteLine("end trans");


        }


    }
}
