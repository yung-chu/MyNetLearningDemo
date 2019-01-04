using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorPattern
{
    /// <summary>
    /// 具体装饰者
    /// </summary>
    public class ConcreteDecoratorHair : BaseDecorator
    { 
        public override void Show()
        {
            base.Show();
            Console.WriteLine("染成红色头发");
        }
    }
}
