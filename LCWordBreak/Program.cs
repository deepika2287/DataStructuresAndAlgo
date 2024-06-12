using System;
using System.Collections.Generic;

namespace LCWordBreak
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string s = "abcd";
            string[] wordDict = new string[]{"a","abc","b","cd"};
            bool res = new Program().WordBreak(s,wordDict);
        }
        public bool WordBreak(string s, IList<string> wordDict) {
            bool result = false;
            Dictionary<string,bool> memo = new Dictionary<string, bool>();
            memo.Add("",true);
            result = RecursiveHelper(s,wordDict,memo);
            return result;
        }
        public bool RecursiveHelper(string s, IList<string> wordDict,Dictionary<string,bool> memo)
        {
            if(memo.ContainsKey(s))
                return memo[s];

            bool res = false;
            for(int i = 0;i<wordDict.Count;i++)
            {
                if(wordDict[i].Length<=s.Length)
                {
                    string temp = s.Substring(0,wordDict[i].Length);
                    if(wordDict[i]==temp)
                    {
                        res = RecursiveHelper(s.Substring(wordDict[i].Length),wordDict,memo);
                        if(res)
                            break;
                    }
                }
            }
            if(!memo.ContainsKey(s))
                memo.Add(s,false);
            memo[s] = res;
            return memo[s];
        }
    }
}
