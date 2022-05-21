/*
 关于鸭子的练习
 */
MallardDuck mallard=new MallardDuck();
mallard.Fly();
RedheadDuck redhead=new RedheadDuck();
redhead.Fly();
RubberDuck rubber=new RubberDuck();
rubber.Fly();


public abstract class Duck
{
    //abstract类中只有abstract和virtual可以重写
    public virtual void Quack()//鸭子叫
    {
        Console.WriteLine("Quack!");
    }
    public virtual void Swim()
    {
        Console.WriteLine("The duck swims.");
    }
    public virtual void Fly()
    {
        Console.WriteLine("The duck flies.");
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
public class RedheadDuck : Duck//红头鸭
{
    public override void Display()
    {
        Console.WriteLine("This duck has red feathers on its head,I guess.");
    }
}
public class RubberDuck : Duck//橡胶鸭
{
    public override void Quack()
    {
        Console.WriteLine("The rubber duck squeaks");//这只橡皮鸭吱吱叫
    }
    public override void Fly()
    {
        Console.WriteLine("The rubber duck cannot fly.");//橡皮鸭不会飞
    }
    public override void Display()
    {
        Console.WriteLine("This rubber duck squeaks。这只橡皮鸭会吱吱叫");
    }
}