using System;
using System.Collections.Generic;

namespace LCLongestSubStrWith2Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //string s = "leeeetttccooooodddeee";
            string s = "eceba";
            int res = new Program().LengthOfLongestSubstringTwoDistinct(s);
        }
        public int LengthOfLongestSubstringTwoDistinct(string s) {
                    // initialize the window (left = 0, right will iterate)
        var left = 0;
        var max = 0;
        var distincts = new Dictionary<char, int>();

        for(var right = 0; right < s.Length; right++)
        {
            // pre-process the new input (we can`t ensure it will be valid here)
            // in this case: add the char to teh chars counter
            if(distincts.ContainsKey(s[right]))
                distincts[s[right]]++;
            else
                distincts.Add(s[right], 1);
            
            // if the window is invalid, run it until it become valid again
            // in this case: remove the left chars until ths distincs charss be <= 2
            while(distincts.Count > 2)
            {
                distincts[s[left]]--;
                if(distincts[s[left]] == 0)
                    distincts.Remove(s[left]);
                left++;
            }

            // process (here it will be valid for sure)
            // in this case: just counting the substring legth
            var len = right - left + 1;
            max = Math.Max(len, max);
        }

        return max;
        }
    }
}
