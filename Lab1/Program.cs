using System.Configuration;

string payMoney = ConfigurationManager.AppSettings["PayMoney"];

var TrainTicket = new TrainTicket();


Console.WriteLine("Which month's train tickets do you want to check?");
string monthStr=Console.ReadLine();
int monthInt=Convert.ToInt32(monthStr);

if(monthInt < 1 || monthInt > 12)
{
    Console.WriteLine("The number you enter should be between 1 and 12.");
}
else
{
    TrainTicket.Fee(monthInt);
}



public class TrainTicket
{
    string path = @"G:\3.MITT\软件工程和设计模式-SD-350-F21P1\AllPatten20220520\Lab1\GetResult.txt";
    public StrategyPatternTicket StrategyPatternTicket { get; set; }
    string payMoney = ConfigurationManager.AppSettings["PayMoney"];

    public double Fee(int month)
    {
        string output = "";
        if (month == 12)
        {
            StrategyPatternTicket = new December();
            output = $"{payMoney} {month} 0 {StrategyPatternTicket.Fee()}";
        }
        else if (month == 6 || month == 7)
        {
            StrategyPatternTicket = new JuneOrJuly();
            output = $"{payMoney} {month} 25 {StrategyPatternTicket.Fee()}";
        }
        else
        {
            StrategyPatternTicket = new Usual();
            output = $"{payMoney} {month} 0 {StrategyPatternTicket.Fee()}";
        }

        Console.WriteLine(output);

        try
        {
            StreamWriter writerToPath = new StreamWriter(path, true);
            writerToPath.WriteLine(output);
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

public class December : StrategyPatternTicket
{
    string payMoney = ConfigurationManager.AppSettings["PayMoney"];
    public double Fee()
    {
        return Convert.ToDouble(payMoney) * 2;
    }
}

public class JuneOrJuly : StrategyPatternTicket
{
    string payMoney = ConfigurationManager.AppSettings["PayMoney"];
    public double Fee()
    {
        return Convert.ToDouble(payMoney) * 0.75;
    }
}

public class Usual : StrategyPatternTicket
{
    string payMoney = ConfigurationManager.AppSettings["PayMoney"];
    public double Fee()
    {
        return Convert.ToDouble(payMoney);
    }
}