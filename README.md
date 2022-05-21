策略模式可以将一些具有相似特征的算法提取出来变成一个接口，这样就可以根据需要动态地实现算法的替换。说得有些抽象
```java
class ClassA{
	void sort(int arr[]){
		if(...){
			//快排
		}else if(...){
			//冒泡
		}else if(...){
			//归并
		}else if(...){
			//新添加的排序算法
		}
	}
}
```
如果大多数情况代码都要跳到第四种算法来进行排序，那就避免不了大量的比较判断。利用策略模式就能为了解决上述两种问题。

一、关于鸭子的练习

1.abstract类中只有abstract和virtual可以重写，重写是需要用override

2.继承父类的子类，如果不重写方法，实例化（instantiate）后调取方法仍然显示之前方法的内容

3.如果继承的是接口，不需要override进行覆盖，但是一定要实现接口。就是说：代码中不需要override，但是方法要重写

4.搞明白了  
```java
 public void SetFlyBehaviour(FlyBehaviour fb)
    {
        FlyBehaviour = fb;
    }
    public void SetQuackBehaviour(QuackBehaviour qb)
    {
        QuackBehaviour = qb;
    }
```

二、关于压缩软件

1.代码复用性小，要改为新的形式来写


*************************************
装饰模式是一种结构型设计模式，这种设计模式可以动态地拓展原有对象的功能，代替类的继承。若要扩展功能，装饰者提供了比继承更有弹性的替代方案。

一、关于Coffee

同属于饮料的商品都继承饮料类，就可以继承其所有的属性，建立构造函数初始化给属性赋值。

（1）abstract类中可以有int等其他类型，如果想在外面进行设置，需要现将其定义为abstract或者virtual，当子类继承后进行覆盖，并设置读取的接口

```java
  public override int MIllilitres
    {
        get { return Beverage.MIllilitres; }
        set { Beverage.MIllilitres = value; }
    }
```

（2）当代码中有override就不能再有virtual，两者不能同时存在

（3）此处3种方法，1和2得到形同的效果，3返回值是0，但是原型链中显示base就是Beverage，错误应该是出在原型链上

二、Honda（我写的和老师写的）

工厂方法模式定义了一个创建对象的接口，但由子类决定要实例化的类是哪一个，工厂方法让类把实例化推迟到子类
简单工厂，每新增加一个类，都需要修改工厂类，而工厂方法模式，新增加类，是新增加一个工厂类，让新工厂类来创建新对象