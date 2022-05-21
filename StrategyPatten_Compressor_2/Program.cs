// create a WinRAR clone创建一个WinRAR克隆
//WINRAR can compress and decompress ZIP or RAR filesWINRAR可以压缩和解压ZIP或RAR文件

// we want to use strategy pattern when SOME things in our classes will always be the same 当我们的类有些东西总是相同，我们想要使用策略模式
// but some things in our classes will probably be different但是我们班的一些东西可能会不同

ZipCompressor zipCompressor = new ZipCompressor();
zipCompressor.ComPress(new List<string> { "fanFiction.txt", "fanFiction2.txt", "fanFiction2891798123.txt" });
public abstract class Compressor
{
    public CompressionStrategy CompressionStrategy { get; set; }
    public ExtractionStrategy ExtractionStrategy { get; set; }
    public void ComPress(List<string> filename)
    {
        CompressionStrategy.Compress(filename);
    }

    public void Extract(string filename)
    {
        ExtractionStrategy.Extract(filename);
    }
}


public class ZipCompressor : Compressor
{
    public ZipCompressor()
    {
        CompressionStrategy = new CompressLossless();
        ExtractionStrategy=new ExtractionWIthRecoveryFile();
    }
}

public class RarCompressor : Compressor
{
    public RarCompressor()
    {
        CompressionStrategy = new CompressLossy();
        ExtractionStrategy = new ExtractionWIthRecoveryFile();
    }
}


//STRATEGIES策略
//COMPRESSION STRATEGIES压缩策略
public interface CompressionStrategy//压缩策略
{
    public void Compress(List<string> fileName);
}

public class CompressLossless : CompressionStrategy//无损压缩
{
    public void Compress(List<string> fileName)
    {
        fileName.ForEach(f =>
        {
            Console.WriteLine($"Compressing {f} in lossless format");
        });
    }
}

public class CompressLossy : CompressionStrategy//有损压缩
{
    public void Compress(List<string> fileName)
    {
        fileName.ForEach(f =>
        {
            Console.WriteLine($"Compressing {f} in lossy format");//以有损格式压缩{f}
        });
    }
}


public interface ExtractionStrategy//提取、解压策略
{
    public void Extract(string fileName);
}
public class ExtractionWIthRecoveryFile : ExtractionStrategy//提取、解压策略
{
    public void Extract(string fileName)
    {
        Console.WriteLine($"Extracting {fileName} from recovery file.");//从恢复文件中提取{fileName}。
    }
}
public class Client//客户
{

}


//public interface Compressor//压缩
//{
//    void Compress();
//    void Extract();
//}


//public class LittleCompressor : Compressor//小型压缩
//{

//}
//public class TinyCompressor : LittleCompressor//微型压缩
//{

//}