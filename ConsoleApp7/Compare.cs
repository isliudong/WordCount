using System;

namespace WordCount
{
    class Compare
    {
        //单词比较算法
        public  int compare(String str1, String str2)
        {
            int length1 = str1.Length;
            int length2 = str2.Length;

            int limit = Math.Min(length1, length2);

            char[] a = str1.ToCharArray();
            char[] b = str2.ToCharArray();
            
            for (int i = 0; i < limit; i++)
            {
                char c1 = (char)(a[i] >= 'a' ? a[i] : (a[i] + 32));
                char c2 = (char)(b[i] >= 'a' ? b[i] : (b[i] + 32));
                if (c1 != c2)
                {
                    return c1 - c2;
                }
            }

            return length1 - length2;

        }
        
        public string[] Orderedwords(string[] word)
        {
            
            for (int i=0;i<word.Length-1;i++)
            {
                for(int j=0;j<word.Length-i-1;j++)
                if (compare(word[j], word[j + 1]) > 0)
                {            
                    string temp=null;
                    temp = word[j];
                    word[j] = word[j + 1];
                    word[j + 1] = temp;
                }
            }
            return word;
        }
    }
}
