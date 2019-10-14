using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount
{
    class Write
    {
        public void write(string[] s, string l,int count,int zifu,int huangshu,int cihui)
        {
            FileStream fileStream1 = new FileStream(l, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            fileStream1.Close();

            using (StreamWriter sw = new StreamWriter(l))
            {
                sw.Flush();
                for (int i = 0; i < s.Length; i++)
                {
                    sw.WriteLine(s[i]);
                }

            

                sw.WriteLine("单词数：" +count);//单词数
                sw.WriteLine("字符数："+zifu );
                sw.WriteLine("行数："+huangshu );
                sw.WriteLine("词汇量："+cihui);
                sw.WriteLine("词组频统计(字典序)：");
                sw.Close();
            }
            
        }
    }
}
