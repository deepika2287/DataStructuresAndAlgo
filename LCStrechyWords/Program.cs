// See https://aka.ms/new-console-template for more information
public class Solution {
    public static void Main(string[] args)
    {
        //string s = "heeellooo";
        //string[] words = ["hello", "hi", "helo"];
        string s = "heeelllooo";
        string[] words = ["hellllo"];
        int res = new Solution().ExpressiveWords(s,words);
    }
    public int ExpressiveWords(string s, string[] words) {
        int res = 0;
        for(int i = 0;i<words.Length;i++)
        {
            if(StrechyWord(s,words[i]))
                res++;
        }
        return res;
    }
    public bool StrechyWord(string s,string word)
    {
        int sIdx = 0;
        int wIdx = 0;
        if(s.Length<word.Length)
        return false;

        while(sIdx<s.Length && wIdx<word.Length)
        {
            char sCh = s[sIdx];
            char wCh = word[wIdx];
            int sCount = 0;
            int wCount = 0;
            if(sCh == wCh)
            {
                
                while(sIdx <s.Length && s[sIdx] == sCh)
                {
                    sIdx++;
                    sCount++;
                }
                while(wIdx<word.Length && word[wIdx] == wCh)
                {
                    wIdx++;
                    wCount++;
                }
                if(wIdx>sIdx)
                    return false;
                if(wCount>sCount)
                    return false;
                if(sCount == wCount || sCount>=3)
                    continue;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }
        if(sIdx != s.Length || wIdx != word.Length)
            return false;

        return true;
    }
    public class Node
    {
        public char ch;
        public int count;
    }
}
