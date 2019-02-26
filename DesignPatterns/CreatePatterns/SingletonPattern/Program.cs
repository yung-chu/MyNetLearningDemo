using System;

namespace SingletonPattern
{
    /// <summary>
    /// 单例模式，保证一个类仅有一个实例，并提供一个访问它的全局访问点。
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            var  instance1 = Singleton.GetInstance();
            var instance2 = Singleton.GetInstance();
            Console.WriteLine(instance1== instance2);

        }

        /// <summary>
        /// 双重判空加锁，饱汉模式（懒汉式），用到的时候再去实例化
        /// </summary>
        public class Singleton
        {
            private static Singleton _instance;
            private static readonly object syncLock = new object();

            private Singleton()
            {
            }

            public static Singleton GetInstance()
            {
                if (_instance == null)
                {
                    lock (syncLock)
                    {
                        if (_instance == null)
                        {
                            _instance = new Singleton();
                        }
                    }
                }

                return _instance;
            }

        }
    }
}
