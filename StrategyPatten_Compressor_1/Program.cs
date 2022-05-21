// create a WinRAR clone创建一个WinRAR克隆
//WINRAR can compress and decompress ZIP or RAR filesWINRAR可以压缩和解压ZIP或RAR文件

public interface Compressor//压缩
{
    void Compress();
}

public class RARCompress : Compressor
{
    public int FileSize;
    public void Compress()
    {
        //compress to rar
    }
}

public class ZipCompress : Compressor
{
    public void Compress()
    {
        //compress to rar
    }
}

public class Client//客户
{

}