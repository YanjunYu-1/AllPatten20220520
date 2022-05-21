/*
 关于鸭子的练习_2
 */
MallardDuck mallard = new MallardDuck();
mallard.Display();
RedheadDuck redhead = new RedheadDuck();
redhead.Fly();
RubberDuck rubber = new RubberDuck();
rubber.Quack();

public interface Quackable
{
    void Quack();
}
public interface Flyable
{
    void Fly();
}

public abstract class Duck
{
    public virtual void Swim()
    {
        Console.WriteLine("The duck swims.");
    }
    public abstract void Display();
}

public class MallardDuck : Duck//野鸭子，绿头鸭
{
    public override void Display()
    {
        Console.WriteLine("This duck looks like a mallard.");
    }
}
public class RedheadDuck : Duck, Quackable, Flyable//红头鸭
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
public class RubberDuck : Duck,Quackable
{
    public void Quack()
    {
        Console.WriteLine("我是RubberDuck继承接口以后实例化的Quack");
    }
    public override void Display()
    {
        Console.WriteLine("This rubber duck squeaks。这只橡皮鸭会吱吱叫");
    }
}