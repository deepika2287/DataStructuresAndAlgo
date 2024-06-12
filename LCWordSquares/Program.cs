using System;
using System.Collections.Generic;

namespace LCWordSquares
{
    class Program
    {
        Dictionary<string,string> dict = new Dictionary<string,string>();
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string[] words = new string[]{"aa","bb"};
            var res = new Program().WordSquares(words);
        }
        
    public IList<IList<string>> WordSquares(string[] words) {
         IList<IList<string>> res = new List<IList<string>>();
            foreach(string s in words)
            {
                List<string> lst = new List<string>();
                RecursiveHelper(words,s,lst,res,0);
            }
            return res;
    }
    public void RecursiveHelper(string[] words,string s,List<string> lst, IList<IList<string>> res,int idx)
        {
            if(idx == words[0].Length)
            {
               dict.Add(String.Join(',', lst),String.Join(',', lst));
               res.Add(new List<string>(lst));    
               return;
            }
            foreach(string str in words)
            {     
                lst.Add(str);
                if(!dict.ContainsKey(String.Join(',', lst)) && CheckValidity(lst))
                {
                    RecursiveHelper(words,s,lst,res,idx+1);
                }
                lst.RemoveAt(lst.Count-1);
            }
        }
        public bool CheckValidity(List<string> lst)
        {
            for(int i=0;i<lst.Count;i++)
            {
                for(int j=0;j<lst.Count;j++)
                {
                    if(i!=j)
                    {
                        if(lst[i][j] != lst[j][i])
                            return false;
                    }
                }
            }
            return true;
        }
    }
}
