// if we expect some things to change about a class, and some things to stay the same and some classes can reuse the behaviour others, but not all, we should use the  strategy pattern

//如果我们期望一个类的一些东西改变，而一些东西保持不变，一些类可以重用其他类的行为，但不是全部，我们应该使用策略模式


// code against interfaces代码对接口

public class BeverageFactory
{
    public Beverage CreateBeverage(string order)
    {
        Beverage beverage;

        if (order == "coffee")
        {
            beverage = new Coffee();
            return beverage;
        }
        else if (order == "tea")
        {
            beverage = new Tea();
            return beverage;
        }
        else if (order == "espresso")
        {
            beverage = new Espresso();
            return beverage;
        }
        else
        {
            throw new Exception("That's not  a beverage");
        }
    }
}
public abstract class BeverageVendor//饮料供应商
{
    // beverage vendor ALWAYS runs the factory method and then the Pour, Lid, Sell methods饮料供应商总是先运行factory方法，然后运行Pour, Lid, Sell方法
    BeverageFactory factory;

    public Beverage MakeBeverage(string order)
    {
        Beverage beverage;
        beverage = factory.CreateBeverage(order);
        beverage.Pour();
        beverage.Lid();
        beverage.Sell();

        return beverage;
    }
}
public abstract class Beverage
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
    public virtual int MIllilitres { get; set; }
 
    public void Pour()//倒出（饮料）
    {
        Console.WriteLine($"Pouring the {Description()}");
    }
    public void Lid()
    {
        Console.WriteLine("Putting a lid on it");
    }
    public void Sell()
    {
        Console.WriteLine($"Selling the drink for {Cost()}");
    }
}

public class Coffee : Beverage
{
    public Coffee()
    {
        _description = "Arabica Coffee";
        _cost = 1.25;
    }
}
public class Tea : Beverage
{
    public Tea()
    {
        _description = "Loose Leaf Tea";
        _cost = 0.50;
    }
}
public class Espresso : Beverage
{
    public Espresso()
    {
        _description = "Espresso";
        _cost = 1.75;
    }
}


