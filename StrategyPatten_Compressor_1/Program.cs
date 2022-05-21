// create a WinRAR clone创建一个WinRAR克隆
//WINRAR can compress and decompress ZIP or RAR filesWINRAR可以压缩和解压ZIP或RAR文件

//以此形式要建立多个类，代码复用性小，要改为新的形式来写

public interface Compressor//压缩
{
    void Compress();
}

public class RARCompress : Compressor
{
    public int FileSize;//文件大小
    public enum BinarySize { };//32 bit or 64 bit?
    public string EncodingType;//编码类型
    public void Compress()
    {
        //compress to rar
    }
}

public class ZipCompress : Compressor
{
    public string Metadata { get; set; }//元数据
    public void Compress()
    {
        //compress to rar
    }
}

public class Client//客户
{

}