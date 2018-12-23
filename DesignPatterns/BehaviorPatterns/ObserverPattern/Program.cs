using System;

namespace ObserverPattern
{
    /// <summary>
    /// https://www.cnblogs.com/revoid/p/9486668.html#14
    /// http://www.cnblogs.com/zhili/p/ObserverPattern.html
    /// 老板回来，我不知道模式(观察者模式)
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
