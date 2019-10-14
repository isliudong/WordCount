using System;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;

namespace WordCount
{
    class Do
    {
        int count = 0;//单词数
        int zifushu;
        int hangshu;
        int geshu = 1;
        int cihui;
        string txt = null;
        int[] times;
        string[] wordArray;
        public Hashtable hashtable;
        Read read;
        public void doing(string path, int wordlength, int outnum, string outpath)
        {
            read = new Read();

            hashtable = new Hashtable();
            txt = read.ReadText(path,wordlength);
            for (int i = 0; i < read.word.Length; i++)
            { read.word[i] = read.word[i].ToLower(); }
            times = new int[read.word.Length];
            count = Regex.Matches(txt, "\\w+").Count;
            wordArray = Regex.Split(txt, "\"[^\"]*\"");



            /*for (int i = 0; i < wordArray.Length; i++)
            {
                Console.WriteLine("文本内容为：" + "\n" + wordArray[i]);
                if (i == wordArray.Length - 1)
                    Console.WriteLine();
            }*/
            for (int i = 0; i < read.word.Length; i++)
            {
                times[i] = 1;
            }


            for (int i = 0; i < read.words.Length; i++)
            {
                
                    if (hashtable.ContainsKey(read.words[i]))
                {
                    geshu = (int)hashtable[read.words[i]];
                    geshu++;
                    hashtable[read.words[i]] = geshu;

                }
                else
                {
                    if (read.words[i] != "")//取出split产生的空字符
                        hashtable.Add(read.words[i], times[i]);
                }
            }
            
            cihui = hashtable.Count;
            zifushu = read.sum;
            hangshu = read.row;

            Console.WriteLine("单词数：" + count);//单词数
            Console.WriteLine("字符数：" + read.sum);
            Console.WriteLine("行数：" + read.row);
            Console.WriteLine("词汇量：" + hashtable.Count);
            Console.WriteLine("词组统计(词频优先字典序)：");
            ICollection key = hashtable.Keys;//放入集合
            string[] wd = new string[hashtable.Count];
            hashtable.Keys.CopyTo(wd, 0);
            for(int i = 0; i < hashtable.Count-1; i++)
            {
                for(int j=0;j<hashtable.Count-i-1;j++)
                {
                    if((int)hashtable[wd[j]]<(int)hashtable[wd[j+1]])
                    {
                        string temp = null;
                        temp = wd[j];
                        wd[j] = wd[j + 1];
                        wd[j + 1] = temp;
                    }
                    else if((int)hashtable[wd[j]] == (int)hashtable[wd[j + 1]])
                    {
                        if (new Compare().compare(wd[j], wd[j + 1]) > 0)
                        {
                            string temp = null;
                            temp = wd[j];
                            wd[j] = wd[j + 1];
                            wd[j + 1] = temp;
                        }
                    }
                       
                }
            }
            //wd = new Compare().Orderedwords(wd);
            new Write().write(wd, outpath, count, zifushu, hangshu, cihui);
            /*if (outnum > 0)
                for (int i = 0; i < outnum; i++)
                {
                    
                    for(int j=i; j<i+wordlength;j++)
                    { Console.Write(wd[j] + ":" + hashtable[wd[j]]); }
                    Console.WriteLine();
                }*/
            for (int i = 0; i < outnum; i++)
            {
                Console.WriteLine(wd[i] + ":" + hashtable[wd[i]]);
            }


            using (StreamWriter sw = new StreamWriter(outpath))
            {
                sw.WriteLine("单词数：" + count);//单词数
                sw.WriteLine("字符数：" + zifushu);
                sw.WriteLine("行数：" + hangshu);
                sw.WriteLine("词汇量：" + cihui);
                sw.WriteLine("词组频统计(词频优先字典序)：");
                for (int i = 0; i < wd.Length; i++)
                {
                    sw.WriteLine(wd[i] + ": " + hashtable[wd[i]]);
                }
                
                sw.Close();
                Console.ReadLine();

            }
        }
    }
}

