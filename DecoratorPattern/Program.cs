Beverage myCoffee = new Coffee();
myCoffee.MIllilitres = 160;
myCoffee=new AddOnSaltedCarame(myCoffee);
Console.WriteLine(myCoffee);
Console.WriteLine(myCoffee.Cost()+" "+myCoffee.Description());
Console.WriteLine(myCoffee.MIllilitres);

public abstract class Beverage//抽象类
{
    //protected受保护的  virtual虚拟的
    protected string _description { get; set; }
    public virtual string Description()
    {
        return _description;
    }
    protected double _cost { get; set; }
    public virtual double Cost()
    {
        return _cost;
    }
    //可以添加一些之后才进行完善的属性，即任意时候都可以在外部进行设置的属性
    public virtual int MIllilitres { get; set; }
    //abstract抽象类中只能有abstract抽象或者Virtual虚假的属性
    //如果是抽象的必须实现，但是虚拟的不需要实现
    //(1)此处需注意@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
}

public class Coffee : Beverage
{
    public Coffee()
    {
        _description = "Arabica Coffee-咖啡";
        _cost = 1.25;
    }
}
public class Latte : Beverage//拿铁
{
    public Latte()
    {
        _description = "Latte Coffee-拿铁";
        _cost = 1.5;
    }
}
public class Espresso : Beverage
{
    public Espresso()
    {
        _description = "Espresso-浓缩咖啡";
        _cost = 1.75;
    }
}
public class Tea : Beverage
{
    public Tea()
    {
        _description = "Loose Leaf Tea-散叶茶";
        _cost = 0.5;
    }
}
public class Smoothie : Beverage//Smoothie冰沙
{
    public Smoothie()
    {
        _description = "Fruit Smoothie-水果冰沙";
        _cost = 3.5;
    }
}


//build one class out of many classes to add theri functionality从许多类中构建一个类来添加它们的功能
public abstract class AddOnDecorator : Beverage//Decorator装饰
{
    //whatever beverage this decorates is the property任何饮料都有装饰这个属性
    public Beverage Beverage { get; set; }
    public abstract override string Description();
    public abstract override double Cost();
    //注意，如果这里不是abstract，而是virtual，行不行(2)@@@@@@@@@@@@

    //public override int MIllilitres
    //{
    //    get { return Beverage.MIllilitres; }
    //    set { Beverage.MIllilitres = value; }
    //}
    //注意区分两种赋值的方法(3)@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    public override int MIllilitres
    {
        get => Beverage.MIllilitres;
        set => Beverage.MIllilitres = value;
    }

    //public override int MIllilitres
    //{
    //    get => base.MIllilitres;
    //    set => base.MIllilitres = value;
    //}
}

public class AddOnSaltedCarame : AddOnDecorator//加盐焦糖
{
    //此处将Beverage当成参数传入，应该是在添加这些装饰时先进入Beverage，调取内部基本数据，例如成分和价格，然后与装饰后的数据进行数学运算（4）@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    public AddOnSaltedCarame(Beverage beverage)
    {
        Beverage = beverage;
    }
    public override double Cost()
    {
        return Beverage.Cost() + 1.00;
    }

    public override string Description()
    {
        return Beverage.Description() + ",salted Carame-咸和焦糖l";
    }
}
public class AddOnSugar : AddOnDecorator
{
    public AddOnSugar(Beverage beverage)
    {
        Beverage =  beverage;
    }
    public override double Cost()
    {
        return Beverage.Cost() + 0.05;
    }

    public override string Description()
    {
        return Beverage.Description() + ",Sugar糖";
    }
}
public class AddOnCream : AddOnDecorator
{
    public AddOnCream(Beverage beverage)
    {
        Beverage = beverage;
    }
    public override double Cost()
    {
        return Beverage.Cost() + 0.1;
    }

    public override string Description()
    {
        return Beverage.Description() + ",Cream奶油";
    }
}
public class AddOnSpeakingDrink : AddOnDecorator
{
    public AddOnSpeakingDrink(Beverage beverage)
    {
        Beverage = beverage;
    }
    public override double Cost()
    {
        return Beverage.Cost() + 5.00;
    }

    public override string Description()
    {
        return Beverage.Description + ",and it talks to you.";
    }
}