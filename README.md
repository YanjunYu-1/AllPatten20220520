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