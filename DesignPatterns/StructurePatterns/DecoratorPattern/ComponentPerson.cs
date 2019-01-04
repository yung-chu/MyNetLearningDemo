using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorPattern
{
    /// <summary>
    /// 抽象构件：给出一个抽象接口，以规范准备接受附加责任的对象。
    /// </summary>
    public abstract class ComponentPerson
    {
        public abstract void Show();
    }

    /// <summary>
    /// 具体构件：定义一个将要接收附加责任的类。
    /// </summary>
    public class ConcreteComponentPerson : ComponentPerson
    {
        public override void Show()
        {
           Console.WriteLine("我是小朱...");
        }
    }

    /// <summary>
    /// 装饰（Dicorator）角色：持有一个构件（Component）对象的实例，并定义一个与抽象构件接口一致的接口。
    /// </summary>
    public class BaseDecorator: ComponentPerson
    {
        private  ComponentPerson _componentPerson;

        public void SetComponent(ComponentPerson componentPerson)
        {
            _componentPerson = componentPerson;
        }


        public override void Show()
        {
            _componentPerson?.Show();
        }
    }
}
