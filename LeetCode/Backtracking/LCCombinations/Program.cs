using System;
using System.Collections.Generic;

namespace LCCombinations
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var res = new Program().Combine(2,1);
        }
        public IList<IList<int>> Combine(int n, int k) {
            IList<IList<int>> ans  = new List<IList<int>>();

            if(n == 1 && k == 1)
            {
                ans.Add(new List<int>(){1});
                return ans;
            }
            
            IList<int> l = new List<int>();
            for(int i = 1;i<=n;i++)
            {  
                l.Add(i);
                BackTrack(ans,n,k,i,l);  
                l.RemoveAt(l.Count-1);
            }
            return ans;
        }
        public void BackTrack(IList<IList<int>> ans , int n, int k, int i,IList<int> l)
        {
            if(l.Count == k)
            {
                ans.Add(new List<int>(l));
                return;
            }
            for(int j = i+1;j<=n;j++)
            {
                l.Add(j);
                BackTrack(ans,n,k,j,l);
                l.RemoveAt(l.Count-1);
            }
        }
    }
}
