using System;
using System.Collections.Generic;
using System.Text;

namespace ObserverPattern
{
    /// <summary>
    /// 抽象主题(Subject)
    /// 把所有观察者对象的引用保存在一个列表中，并提供增加和删除观察者对象的操作，
    /// 抽象主题角色又叫做抽象被观察者角色，一般由抽象类或接口实现
    /// </summary>
    public abstract  class  SubjectBoss
    {
        private readonly List<Observer> _observers = new List<Observer>();

        public void Attach(Observer observer)
        {
            _observers.Add(observer);
        }

        public void Detach(Observer observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var item in _observers)
            {
                item.Update();
            }
        }
    }

    /// <summary>
    /// 具体主题角色（ConcreteSubject）：实现抽象主题接口，具体主题角色又叫做具体被观察者角色。
    /// </summary>
    public class ConcreteSubjectBoss : SubjectBoss
    {
        public string SubjectBossState { get; set; }
    }
}
