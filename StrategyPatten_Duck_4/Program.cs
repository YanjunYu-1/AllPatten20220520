/*
 关于鸭子的练习_4
 */
MallardDuck mallard = new MallardDuck();
mallard.PerformFly();


FlyWithRocket newMallard = new FlyWithRocket();//var newMallard = new FlyWithRocket();一样效果
mallard.SetFlyBehaviour(newMallard);//mallard.SetFlyBehaviour(new FlyWithRocket());可以省略上面一行，一样效果
mallard.PerformFly();

public interface QuackBehaviour
{
    void Quack();
}
public class QuackLikeADuck : QuackBehaviour
{
    public void Quack()
    {
        Console.WriteLine("Quack quack");
    }
}
public class QuackWithSqueak : QuackBehaviour
{
    public void Quack()
    {
        Console.WriteLine("Squeak squack");//吱吱叫。
    }
}
public class QuackMute : QuackBehaviour
{
    public void Quack()
    {
        Console.WriteLine("There is no sound");
    }
}

public interface FlyBehaviour
{
    void Fly();
}
public class FlyWithWings : FlyBehaviour//用翅膀飞
{
    public void Fly()
    {
        Console.WriteLine("The bird flies");
    }
}
public class FlyCannotFly : FlyBehaviour
{
    public void Fly()
    {
        Console.WriteLine("The bird can't fly");
    }
}
public class FlyWithRocket : FlyBehaviour
{
    public void Fly()
    {
        Console.WriteLine("The duck somehow employs rocket propulsion");//鸭子以某种方式使用火箭推进
    }
}

public abstract class Duck
{
    public FlyBehaviour FlyBehaviour { get; set; }
    public QuackBehaviour QuackBehaviour { get; set; }

    //接收传入值，确定进入哪个类
    public void SetFlyBehaviour(FlyBehaviour fb)
    {
        FlyBehaviour = fb;
    }
    public void SetQuackBehaviour(QuackBehaviour qb)
    {
        QuackBehaviour = qb;
    }

    public void PerformFly()
    {
        FlyBehaviour.Fly();
    }

    public void PerformQuack()
    {
        QuackBehaviour.Quack();
    }
    public abstract void Display();
    public void Swim()
    {
        Console.WriteLine("All ducks can swim,including this one.");
    }
}

public class MallardDuck : Duck//野鸭子，绿头鸭
{
    public MallardDuck()
    {
        FlyBehaviour = new FlyWithWings();
        QuackBehaviour = new QuackLikeADuck();
    }
    public override void Display()
    {
        Console.WriteLine("Mallard Duck said: This duck looks like a mallard.");
    }
}
public class RubberDuck : Duck
{
    public RubberDuck()
    {
        FlyBehaviour = new FlyCannotFly();
        QuackBehaviour = new QuackWithSqueak();

    }
    public void Quack()
    {
        Console.WriteLine("我是RubberDuck继承接口以后实例化的Quack");
    }
    public override void Display()
    {
        Console.WriteLine("This rubber duck squeaks。这只橡皮鸭会吱吱叫");
    }
}

public class RedheadDuck : Duck//红头鸭
{
    public override void Display()
    {
        Console.WriteLine("This duck has red feathers on its head,I guess.");
    }

    public void Fly()
    {
        Console.WriteLine("我是RedheadDuck继承接口以后实例化的Fly");
    }

    public void Quack()
    {
        Console.WriteLine("我是RedheadDuck继承接口以后实例化的Quack");
    }
}