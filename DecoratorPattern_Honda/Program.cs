//Decorator Pattern Review
Vehicle MyCivic = new Civic();
MyCivic = new UpgradeLeatherSeats(MyCivic);
MyCivic = new UpgradeHybridEngine(MyCivic);

Console.WriteLine(MyCivic.GrandTotal());
Console.WriteLine(MyCivic.Year);
Console.WriteLine(MyCivic.Model);
Console.WriteLine(MyCivic.Colour);
Console.WriteLine(MyCivic.BodyType);


public abstract class Vehicle
{
    public virtual DateTime Year { get; set; } = DateTime.Now;
    //（1）@@@@@@@@@@@只有在建立时赋值，下面abstract class Upgrade中才能找到相应的值，如果没有赋值，查询结果应该是0001/1/1 0:00:00
    public virtual string Model { get; set; }

    //add a "Trim" property

    protected virtual double BasePrice { get; set; }
    public virtual double GrandTotal()
    {
        return BasePrice;
    }

    public virtual string Colour { get; set; }
    public virtual string BodyType { get; set; }
}

public class Civic : Vehicle//城市版
{
    public Civic()
    {
        //Year = new DateTime(DateTime.Now.Year);//(2)两者有什么区别？@@@@@@@@@@@效果相同
        Year = DateTime.Now;
        Model = "Honda Civic";
        Colour = "Slate Grey";
        BodyType = "Sedan";//轿车
        BasePrice = 28000;
    }
}

public class Accord : Vehicle//协议
{
    public Accord()
    {
        Year = new DateTime(DateTime.Now.Year);
        Model = "Honda Accord";
        Colour = "Rainbow";
        BodyType = "Big Sedan";
        BasePrice = 35000;
    }
}
public abstract class Upgrade: Vehicle//升级
{
    public Vehicle Vehicle { get; set; }
    public abstract override double GrandTotal();

    public override DateTime Year
    {
        get { return base.Year; }
        set { base.Year = value; }
    }
    public override string Model
    {
        get { return Vehicle.Model; }
        set { Vehicle.Model = value; }
    }
    public override string Colour
    {
        get { return Vehicle.Colour; }
        set { Vehicle.Colour = value; }
    }
    public override string BodyType
    {
        get { return Vehicle.BodyType; }
        set { Vehicle.BodyType = value; }
    }
}

public class UpgradeLeatherSeats : Upgrade
{
    public UpgradeLeatherSeats(Vehicle vehicle)
    {
        Vehicle = vehicle;
    }

    public override double GrandTotal()
    {
        return Vehicle.GrandTotal() + 800;
    }
}

public class UpgradeIgnitionButton : Upgrade
{
    public UpgradeIgnitionButton(Vehicle vehicle)
    {
        Vehicle = vehicle;
    }

    public override double GrandTotal()
    {
        return Vehicle.GrandTotal() + 200;
    }
}

public class UpgradeHybridEngine : Upgrade
{
    public UpgradeHybridEngine(Vehicle vehicle)
    {
        Vehicle = vehicle;
    }

    public override double GrandTotal()
    {
        return Vehicle.GrandTotal() + 4000;
    }
}