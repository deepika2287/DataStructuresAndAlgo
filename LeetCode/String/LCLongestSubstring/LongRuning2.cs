using System;
using System.Collections.Generic;
class Solution2
{
/*public int LengthOfLongestSubstring2(string s) {
            int len = 1;
            char[] arr = s.ToCharArray();
            if(arr.Length == 0)
                return 0;
            int i = 1;
            int j = 0;
            char c = arr[j];
            bool flag = false;
            int maxLen = len;
            while(i<arr.Length)
            {
                int k;
                for(k=j;k<i;k++)
                {
                    if(arr[k]==arr[i])
                    {
                        //len = 0;
                        flag = true;
                        break;
                    }
                }
                if(!flag)
                {
                    i++;
                    len++;
                    if(maxLen<len)
                        maxLen = len;
                }
                else
                {
                    j = k+1;
                    i=j+1;
                    len=1;
                    flag = false;
                }
            }
            
            return maxLen;
        }*/
}