using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverPattern
{
    /// <summary>
    /// 抽象观察者
    /// </summary>
    public abstract class Observer
    {
        public abstract void Update();
    }

    /// <summary>
    /// 具体观察者
    /// </summary>
    public class PlayGame : Observer
    {
        private string Name { get; set; }

        private ConcreteSubjectBoss ConcreteSubjectBoss { get; set; }

        public PlayGame(string name, ConcreteSubjectBoss concreteSubjectBoss)
        {
            Name = name;
            ConcreteSubjectBoss = concreteSubjectBoss;
        }

        public override void Update()
        {
            Console.WriteLine($"{Name}看到{ConcreteSubjectBoss.SubjectBossState}：关闭游戏，继续工作");
        }
    }


    public class WatchMovie : Observer
    {
        private string Name { get; set; }

        private ConcreteSubjectBoss ConcreteSubjectBoss { get; set; }

        public WatchMovie(string name, ConcreteSubjectBoss concreteSubjectBoss) 
        {
            Name = name;
            ConcreteSubjectBoss = concreteSubjectBoss;
        }

        public override void Update()
        {
            Console.WriteLine($"{Name} {ConcreteSubjectBoss.SubjectBossState}：关闭视频，继续工作");
        }
    }

}
