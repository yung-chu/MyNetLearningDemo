using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorPattern
{
    /// <summary>
    /// 具体装饰者（Sticker和Accessories）角色：负责给构件对象 ”贴上“附加的责任。
    /// </summary>
    public class ConcreteDecoratorCoat : BaseDecorator
    {
        public override void Show()
        {
            base.Show();
            Console.WriteLine("穿着外套");
        }
    }
}
