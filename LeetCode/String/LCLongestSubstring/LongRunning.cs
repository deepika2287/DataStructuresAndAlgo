using System.Collections.Generic;
using System;
class Solution1
{
/*public int LengthOfLongestSubstring1(string s) {
            int len = 0;
            char[] arr = s.ToCharArray();
            if(arr.Length == 0)
                return 0;
            int maxLen = len;
            int i = 0;
            int j = 0;
            Dictionary<char,char> dict = new Dictionary<char, char>();
            while(i < arr.Length)
            {
                
                if(!dict.ContainsKey(arr[i]))
                {
                    dict.Add(arr[i],arr[i]);
                    i++;
                    len++;
                    if(maxLen<len)
                        maxLen = len;
                }
                else
                {
                    //i = dict.Values.ToList().IndexOf(arr[i])+1;
                    i = arr.ToList().IndexOf(arr[i],j,dict.Count())+1;
                    j = i;
                    len = 0;
                    dict.Clear();
                }
            }
            return maxLen;
        }*/
}