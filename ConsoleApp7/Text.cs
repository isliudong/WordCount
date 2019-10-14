using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    class Text
    {
        public void fun()
        {
            var text = "Youth is asnot a time \nof (life";
            string[] words = Regex.Split(text, @"\W+");//这句代码就是将文本转为单词，但是需要添加这一句引用  using System.Text.RegularExpressions;
            var i = 0;
            foreach (var word in words)
            {
                i++;
                Console.WriteLine("第{0}个单词是:{1}", i, word);
            }
            for (int j = 0; j < words.Length; j++)
            {
                Console.WriteLine(words[j]);
                if (j == words.Length - 1)
                    Console.WriteLine();
            }
            Console.WriteLine("这个句子由{0}个单词组成", words.Length);
            Console.ReadKey();
        }

    }
}
