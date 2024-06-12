using System;
using System.Collections.Generic;
using System.Text;

namespace LCGenerateParantheses
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var ans = new Program().GenerateParenthesis(3);
        }

        //divide and conquer
        public IList<string> GenerateParenthesis(int n) {
            IList<string> ans  = new List<string>();
            if(n == 0)
            {
                ans.Add("");
                return ans;
            }
            if(n==1)
            {
                ans.Add("()");
                return ans;
            }
            
            for(int i = n-1;i>=0;i--)
            {
                IList<string> l = GenerateParenthesis(i);
                IList<string> r = GenerateParenthesis(n-i-1);
                foreach(String l_str in l){
    		        foreach(String r_str in r){
        		        ans.Add("(" + l_str + ")" + r_str);
    		        }
    	        }
            }
            
            return ans;
        }
        //BackTrack Solution
        /*public IList<string> GenerateParenthesis(int n) {
            IList<string> ans = new List<string>();
            BackTrack(ans,"",0,0,n);
            return ans;
        }
        public void BackTrack(IList<string> ans, string currStr, int leftCount, int rightCount, int n)
        {
            if(currStr.Length == 2*n)
            {
                ans.Add(currStr);
            }
            if(leftCount<n)
            {
                currStr = currStr + "(";
                BackTrack(ans,currStr,leftCount+1,rightCount,n);
                currStr = currStr.Remove(currStr.Length-1);
            }
            if(leftCount>rightCount)
            {
                currStr = currStr + ")";
                BackTrack(ans,currStr,leftCount,rightCount+1,n);
                currStr = currStr.Remove(currStr.Length-1);
            }
        }*/
    }
}
