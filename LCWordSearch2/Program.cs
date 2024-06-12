using System;
using System.Collections.Generic;
namespace LCWordSearch2
{
    class Program
    {
        public int m;
        public int n;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //[["o","a","a","n"],["e","t","a","e"],["i","h","k","r"],["i","f","l","v"]]
            //[["a","b","c"],["a","e","d"],["a","f","g"]]
            string[] words = new string[]{"abcdefg","gfedcbaaa","eaabcdgfa","befa","dgc","ade"};
            char[][] board = new char[3][];
           
            board[0] = new char[]{'a','b','c'};
            board[1] = new char[]{'a','e','d'};
            board[2] = new char[]{'a','f','g'};

            var res = new Program().FindWords(board,words);
        }
        public IList<string> FindWords(char[][] board, string[] words) {
            IList<string> res = new List<string>();
            m = board.Length;
            n = board[0].Length;
            bool[][] visited = new bool[m][];
            for(int i = 0;i<m;i++)
            {
                visited[i] = new bool[n];
            }
            foreach(string s in words)
            {
                for(int a=0;a<m;a++)
                {
                    for(int b=0;b<n;b++)
                    {
                        if(board[a][b] == s[0] && !res.Contains(s))
                        {
                            FindWord(board,s,1,a,b,visited,res,s[0].ToString());
                        }
                        if(res.Contains(s))
                                break;
                    }
                    if(res.Contains(s))
                                break;
                }
            }
            return res;
        }
        public void FindWord(char[][] board, string word,int idx,int i, int j,bool[][] visited,IList<string> res,string temp)
        {
            if(idx == word.Length)
            {
                res.Add(word);
                return;
            }
            visited[i][j] = true;
            if(i+1<m && !visited[i+1][j] && !res.Contains(word) && board[i+1][j]==word[idx])
                FindWord(board,word,idx+1,i+1,j,visited,res,temp+word[idx]);
            if(i-1>=0 && !visited[i-1][j] && !res.Contains(word) && board[i-1][j]==word[idx])
                FindWord(board,word,idx+1,i-1,j,visited,res,temp+word[idx]);
            if(j+1<n && !visited[i][j+1] && !res.Contains(word) && board[i][j+1]==word[idx])
                FindWord(board,word,idx+1,i,j+1,visited,res,temp+word[idx]);
            if(j-1>=0 && !visited[i][j-1] && !res.Contains(word) && board[i][j-1]==word[idx])
                FindWord(board,word,idx+1,i,j-1,visited,res,temp+word[idx]);
            visited[i][j] = false;
        }
    }
}
