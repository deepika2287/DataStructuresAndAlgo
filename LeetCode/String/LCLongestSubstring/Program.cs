using System;

namespace LCLongestSubstring
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string s = "abcddbcbb";
            int res = new Program().LengthOfLongestSubstring(s);
            Console.WriteLine(res);
        }

        public int LengthOfLongestSubstring(string s) {
            int len = 0;
            if(string.IsNullOrEmpty(s))
                return 0;
            string subStr = "";
            int pointer = 0;

            while(pointer<s.Length)
            {
                if(subStr.Contains(s[pointer]))
                {
                    len = len<subStr.Length?subStr.Length:len;
                    subStr = subStr.Remove(0,subStr.IndexOf(s[pointer])+1);
                }
                subStr += s[pointer];
                pointer++;
                if(len<subStr.Length)
                    len = subStr.Length;
            }
            return len;
        }
    }
}
