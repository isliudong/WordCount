using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WordCount
{
    class  Read
    {
        public int sum=0;//字符数
        public int row = 0;
        public String[] word;
        public String[] words;
        
        public String ReadText(String path,int wordlenth)
        {
            StreamReader sr = new StreamReader(path, Encoding.Default);
            while(sr.Read()!=-1)
            {
                sum++; 
                
            }
            row= sr.ReadToEnd().Split('\n').Length;
        
            sr.BaseStream.Seek(0, SeekOrigin.Begin);//重置流指针
            row = sr.ReadToEnd().Split('\n').Length;//行数统计
            sr.BaseStream.Seek(0, SeekOrigin.Begin);
            word = Regex.Split(sr.ReadToEnd(), @"\W+");//
            words = new string[word.Length-wordlenth];
            words[0] = word[1];
            

            for(int i=0;i<word.Length-wordlenth;i++)
            {
                for (int j = i; j <= i+wordlenth-1; j++)
                { words[i] = words[i] + " "+word[j]; }
            }
            sr.BaseStream.Seek(0, SeekOrigin.Begin);//重置流指针
            return sr.ReadToEnd();
        }
    }
}
