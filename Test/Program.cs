Combat Combat=new Combat();
Combat.Fight();


public class Combat//战争
{
    public void Fight()
    {
        Person goodHero = new Warrior();
        Person badHero = new GiantEnemy();
        goodHero = new AddOnBracelet(goodHero);
        goodHero = new AddOnGlovet(goodHero);
        int num = 1;

        if (badHero.HP() > 80)
        {
            int GoodHeroHP = goodHero.HP();
            int BadHeroHP = badHero.HP();
            //信息提示
            Console.WriteLine("You are now going to fight the Boss, please add new equipment");
            Console.WriteLine("1. Add bracelets");
            Console.WriteLine("2. Add gloves");
            //接收选择
            var UpgradeWeapons = Console.ReadLine();
            //加载选择的装备
            if (UpgradeWeapons == "1")
            {
                goodHero = new AddOnBracelet(goodHero);
            }
            else
            {
                goodHero = new AddOnGlovet(goodHero);
            }


            //开始战斗
            while (GoodHeroHP > 0 && BadHeroHP > 0)
            {
                Console.WriteLine($"Round {num} : before the fight");
                Console.WriteLine($"The hero's name is{goodHero.Name()}");
                Console.WriteLine($"The hero's HP is{GoodHeroHP}");
                Console.WriteLine($"The hero's damage is{goodHero.BaseDamage()}");
                Console.WriteLine("-------------------");
                Console.WriteLine($"The monster's name is{badHero.Name()}");
                Console.WriteLine($"The monster's health is{BadHeroHP}");
                Console.WriteLine($"The monster's damage is{badHero.BaseDamage()}");
                Console.WriteLine();
                Console.WriteLine("***************************");

                GoodHeroHP -= badHero.BaseDamage();
                BadHeroHP -= goodHero.BaseDamage();
                Console.WriteLine($"Round {num} : after the fight");
                Console.WriteLine($"The hero's name is{goodHero.Name()}");
                Console.WriteLine($"The hero's HP is{GoodHeroHP}");
                Console.WriteLine($"The hero's damage is{goodHero.BaseDamage()}");
                Console.WriteLine("-------------------");
                Console.WriteLine($"The monster's name is{badHero.Name()}");
                Console.WriteLine($"The monster's health is{BadHeroHP}");
                Console.WriteLine($"The monster's damage is{badHero.BaseDamage()}");
                Console.WriteLine();
                Console.WriteLine("***************************");
                num++;
                if (GoodHeroHP < 0)
                {
                    Console.WriteLine("The Enemy was won!");
                }
                else if(BadHeroHP < 0)
                {
                    Console.WriteLine("The Hero was won!");
                }
            }
        }
        else
        {
            int GoodHeroHP = goodHero.HP();
            int BadHeroHP = badHero.HP();
            //开始战斗
            while (GoodHeroHP > 0 && BadHeroHP > 0)
            {
                Console.WriteLine($"Round {num} : before the fight");
                Console.WriteLine($"The hero's name is{goodHero.Name()}");
                Console.WriteLine($"The hero's HP is{GoodHeroHP}");
                Console.WriteLine($"The hero's damage is{goodHero.BaseDamage()}");
                Console.WriteLine("-------------------");
                Console.WriteLine($"The monster's name is{badHero.Name()}");
                Console.WriteLine($"The monster's health is{BadHeroHP}");
                Console.WriteLine($"The monster's damage is{badHero.BaseDamage()}");
                Console.WriteLine();
                Console.WriteLine("***************************");

                GoodHeroHP -= badHero.BaseDamage();
                BadHeroHP -= goodHero.BaseDamage();
                Console.WriteLine($"Round {num} : after the fight");
                Console.WriteLine($"The hero's name is{goodHero.Name()}");
                Console.WriteLine($"The hero's HP is{GoodHeroHP}");
                Console.WriteLine($"The hero's damage is{goodHero.BaseDamage()}");
                Console.WriteLine("-------------------");
                Console.WriteLine($"The monster's name is{badHero.Name()}");
                Console.WriteLine($"The monster's health is{BadHeroHP}");
                Console.WriteLine($"The monster's damage is{badHero.BaseDamage()}");
                Console.WriteLine();
                Console.WriteLine("***************************");
                num++;
                if (GoodHeroHP < 0)
                {
                    Console.WriteLine("The Enemy was won!");
                }
                else
                {
                    Console.WriteLine("The Hero was won!");
                }
            }
        }
    }
}
public abstract class Person
{
    protected string _name { get; set; }
    public virtual string Name()
    {
        return _name;
    }

    protected int _hp { get; set; }
    public virtual int HP()
    {
        return _hp;
    }

    protected int _baseDamage { get; set; }
    public virtual int BaseDamage()
    {
        return _baseDamage;
    }
}

//good hero
public class Warrior : Person//战士
{
    public Warrior()
    {
        _name = "Warrior";
        _hp = 100;
        _baseDamage = 20;
    }
}
public class Enchanter : Person//魔法师
{
    public Enchanter()
    {
        _name = "Enchanter";
        _hp = 80;
        _baseDamage = 40;
    }
}

//bad hero
public class Monster : Person//怪兽
{
    public Monster()
    {
        _name = "Monster";
        _hp = 50;
        _baseDamage = 10;
    }
}
public class GiantEnemy : Person//巨型敌人
{
    public GiantEnemy()
    {
        _name = "GiantEnemy";
        _hp = 180;
        _baseDamage = 20;
    }
}

public abstract class Upgrade : Person
{
    public Person Person { get; set; }
    public abstract override string Name();
    public abstract override int HP();
    public abstract override int BaseDamage();
}

public class AddOnBracelet : Upgrade
{
    public AddOnBracelet(Person person)
    {
        Person = person;
    }
    public override int BaseDamage()
    {
        return Person.BaseDamage() + 20;
    }

    public override int HP()
    {
        return Person.HP();
    }

    public override string Name()
    {
        return Person.Name();
    }
}
public class AddOnGlovet : Upgrade//添加手套
{
    public AddOnGlovet(Person person)
    {
        Person = person;
    }
    public override int BaseDamage()
    {
        return Person.BaseDamage() + 40;
    }

    public override int HP()
    {
        return Person.HP();
    }

    public override string Name()
    {
        return Person.Name();
    }
}