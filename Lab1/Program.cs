using System.Configuration;



var TrainTicket = new TrainTicket();


Console.WriteLine("Which month's train tickets do you want to check?");
string monthStr=Console.ReadLine();
int monthInt=Convert.ToInt32(monthStr);

TrainTicket.Fee(monthInt);


//while (monthInt < 1 || monthInt > 12)
//{
//    Console.WriteLine("请输入六位数学号");
    
//}

//Convert.ToInt32(Console.ReadLine());




public class TrainTicket
{
    string path = @"G:\3.MITT\软件工程和设计模式-SD-350-F21P1\AllPatten20220520\Lab1\GetResult.txt";
    public StrategyPatternTicket StrategyPatternTicket { get; set; }
    int payMoney = 50;

    public double Fee(int month)
    {
        string saveRecordLine = "";
        if (month == 12)
        {
            StrategyPatternTicket = new December();
            saveRecordLine = $"{payMoney} {month} 0 {StrategyPatternTicket.Fee()}";
        }
        else if (month == 6 || month == 7)
        {
            StrategyPatternTicket = new JuneOrJuly();
            saveRecordLine = $"{payMoney} {month} 25 {StrategyPatternTicket.Fee()}";

        }
        else
        {
            StrategyPatternTicket = new Usual();
            saveRecordLine = $"{payMoney} {month} 0 {StrategyPatternTicket.Fee()}";

        }

        Console.WriteLine(saveRecordLine);

        try
        {
            StreamWriter writerToPath = new StreamWriter(path, true);
            writerToPath.WriteLine(saveRecordLine);
            writerToPath.Close();
        }
        catch (IOException e)
        {
            Console.WriteLine(e.Message);
        }


        return StrategyPatternTicket.Fee();
    }


}

public interface StrategyPatternTicket
{
    public double Fee();
}

public class Usual : StrategyPatternTicket
{
    int payMoney = 50;

    public double Fee()
    {

        return Convert.ToDouble(payMoney);
    }
}

public class JuneOrJuly : StrategyPatternTicket
{
    int payMoney = 50;
    public double Fee()
    {
        return Convert.ToDouble(payMoney) * 0.75;
    }
}

public class December : StrategyPatternTicket
{
    int payMoney = 50;
    public double Fee()
    {
        return Convert.ToDouble(payMoney) * 2;
    }
}