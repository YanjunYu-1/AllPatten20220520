/*
 ► At a Honda dealership, people can choose to buy a car from a large selection of new cars.
► 在本田经销商处，人们可以从大量新车中选择购买汽车。

► All new cars have properties like (Year, Model, Base Price, Color, Body Type).
► 所有新车都具有（年份、型号、基本价格、颜色、车身类型）等属性。

► After choosing the car they want, customers can select from a wide range of upgrades.
► 客户选择想要的汽车后，可以从多种升级中进行选择。

► Upgrades include (Leather Seats, Ignition Button, Hybrid Engine), each upgrade costs extra money.
► 升级包括（真皮座椅、点火按钮、混合引擎），每次升级都需要额外付费。

► Create an OOP design to model this system.
► 创建一个 OOP 设计来对该系统建模。

► Add “Alloy Rims” to the set of upgrade
► 将“合金轮辋”添加到升级组
 */

Vehicle myCar = new HondCivic();
myCar = new AddOnAlloyRims(myCar);
myCar = new AddOnHybridEngine(myCar);
myCar = new AddOnIgnitionButton(myCar);
myCar = new AddOnLeatherSeats(myCar);

Console.WriteLine(myCar.Year() + " " + myCar.Model() + " " + myCar.Color() + " " + myCar.BodyType() + ",total price is " + myCar.BasePrice());
public abstract class Vehicle
{
    protected int _year { get; set; }
    public virtual int Year()
    {
        return _year;
    }

    protected string _model { get; set; }
    public virtual string Model()
    {
        return _model;
    }
    protected double _basePrice { get; set; }
    public virtual double BasePrice()
    {
        return _basePrice;
    }

    protected string _color { get; set; }

    public virtual string Color()
    {
        return _color;
    }

    protected string _bodyType { get; set; }

    public virtual string BodyType()
    {
        return _bodyType;
    }
}

public class HondCivic : Vehicle
{
    public HondCivic()
    {
        _year = 2022;
        _model = "HondCivic";
        _basePrice = 18000;
        _color = "Blue";
        _bodyType = "car";
    }
}
public class DodgeRan : Vehicle
{
    public DodgeRan()
    {
        _year = 2021;
        _model = "DodgeRan";
        _basePrice = 26000;
        _color = "Red";
        _bodyType = "Truck";
    }
}

public abstract class AddOnDecorator : Vehicle
{
    public Vehicle Vehicle { get; set; }
    public abstract override int Year();
    public abstract override string Model();
    public abstract override double BasePrice();
    public abstract override string Color();
    public abstract override string BodyType();
}

public class AddOnHybridEngine : AddOnDecorator
{
    public AddOnHybridEngine(Vehicle vehicle)
    {
        Vehicle = vehicle;
    }
    public override double BasePrice()
    {
        return Vehicle.BasePrice() + 3000;
    }

    public override string BodyType()
    {
        return Vehicle.BodyType();
    }

    public override string Color()
    {
        return Vehicle.Color();
    }

    public override string Model()
    {
        return Vehicle.Model() + "add on Hybrid Engine";
    }

    public override int Year()
    {
        return Vehicle.Year();
    }
}
public class AddOnLeatherSeats : AddOnDecorator
{
    public AddOnLeatherSeats(Vehicle vehicle)
    {
        Vehicle = vehicle;
    }
    public override double BasePrice()
    {
        return Vehicle.BasePrice() + 5000;
    }

    public override string BodyType()
    {
        return Vehicle.BodyType();
    }

    public override string Color()
    {
        return Vehicle.Color();
    }

    public override string Model()
    {
        return Vehicle.Model() + "add on Leather Seats";
    }

    public override int Year()
    {
        return Vehicle.Year();
    }
}
public class AddOnIgnitionButton : AddOnDecorator
{
    public AddOnIgnitionButton(Vehicle vehicle)
    {
        Vehicle = vehicle;
    }
    public override double BasePrice()
    {
        return Vehicle.BasePrice() + 8000;
    }

    public override string BodyType()
    {
        return Vehicle.BodyType();
    }

    public override string Color()
    {
        return Vehicle.Color();
    }

    public override string Model()
    {
        return Vehicle.Model() + "add on Ignition Button";
    }

    public override int Year()
    {
        return Vehicle.Year();
    }
}
public class AddOnAlloyRims : AddOnDecorator
{
    public AddOnAlloyRims(Vehicle vehicle)
    {
        Vehicle = vehicle;
    }
    public override double BasePrice()
    {
        return Vehicle.BasePrice() + 12000;
    }

    public override string BodyType()
    {
        return Vehicle.BodyType();
    }

    public override string Color()
    {
        return Vehicle.Color();
    }

    public override string Model()
    {
        return Vehicle.Model() + "add on Alloy Rims";
    }

    public override int Year()
    {
        return Vehicle.Year();
    }
}