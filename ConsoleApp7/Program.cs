
namespace WordCount
{
    class Program
    {
        static void Main(string[] args)
        {           
            int wordlength=1;
            int outnum=0;
            string outpath="/";
            string path=null;                                     
            for(int i=0;i<args.Length;i++)
            {
                if (args[i] == "-l")//路径参数
                { path = args[i + 1]; i++; }
                else if (args[i] == "-m")//参数设定统计的词组长度
                { wordlength = int.Parse(args[i+1]); i++; }
                else if (args[i] == "-n")//参数设定输出的单词数量
                { outnum = int.Parse(args[i + 1]); i++; }
                else if (args[i] == "-o")//参数设定生成文件的存储路径
                { outpath = args[i + 1]; i++; }


            }
            new Do().doing(path, wordlength, outnum, outpath);
            
        }
    }
}
