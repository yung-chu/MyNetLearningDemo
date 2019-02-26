using System;

namespace ObserverPattern
{
    /// <summary>
    /// https://www.cnblogs.com/revoid/p/9486668.html#14
    /// http://www.cnblogs.com/zhili/p/ObserverPattern.html
    /// https://github.com/WeihanLi/DesignPatterns/tree/master/BehaviorPattern/ObserverPattern
    /// 老板回来，我不知道模式(观察者模式)
    /// 观察者模式又叫做 发布订阅（Publish/Subscribe）
    /// 定义对象间的一种一对多的依赖关系,以便当一个对象的状态发生改变时,
    /// 所有依赖于它的对象都得到通知并自动刷新
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //具体主题
            var concreteSubject = new ConcreteSubjectBoss();

            var playGame = new PlayGame("小明", concreteSubject);
            var watchMovie = new WatchMovie("小朱", concreteSubject);
            concreteSubject.Attach(playGame);
            concreteSubject.Attach(watchMovie);

            concreteSubject.SubjectBossState = "老板过来了";
            concreteSubject.Notify();

            concreteSubject.SubjectBossState = "老板过来了";
            concreteSubject.Detach(watchMovie);
            concreteSubject.Notify();
        }
    }
}
