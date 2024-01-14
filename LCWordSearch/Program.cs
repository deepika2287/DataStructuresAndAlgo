using System;

namespace LCWordSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            char[][] board = new char[3][];
            char[] row1 = new char[]{'A','B','C','E'};
            char[] row2 = new char[]{'S','F','C','S'};
            char[] row3 = new char[]{'A','D','E','E'};
            board[0] = row1;
            board[1] = row2;
            board[2] = row3;
            //char[][] board = new char[1][];
            //board[0] = new char[1];
            //board[0][0] = 'A';
            bool ans = new Program().Exist(board,"ABCCED");
        }
        public bool Exist(char[][] board, string word) {
            bool flag = false;
            bool[][] visited = new bool[board.Length][];
            for(int i = 0;i<board.Length;i++)
            {
                visited[i] = new bool[board[0].Length];
            }
            for(int i = 0;i<board.Length;i++)
                for(int j = 0;j<board[0].Length;j++)
                    DFS(board,word,board[i][j].ToString(),i,j,visited,ref flag);
            return flag;
        }
        public void DFS(char[][] board, string word, string str, int i, int j,bool[][] visited,ref bool flag)
        {
            if(str == word)
            {
                flag = true;
                return;
            }
            if(str.Length>word.Length)
            {
                return;
            }
            visited[i][j] = true;
            if(i+1<board.Length && !visited[i+1][j])
                DFS(board,word,str + board[i+1][j],i+1,j,visited,ref flag);
            if(i-1>=0 && !visited[i-1][j])
                DFS(board,word,str + board[i-1][j],i-1,j,visited,ref flag);
            if(j+1<board[0].Length && !visited[i][j+1])
                DFS(board,word,str + board[i][j+1],i,j+1,visited,ref flag);
            if(j-1>=0 && !visited[i][j-1])
                DFS(board,word,str + board[i][j-1],i,j-1,visited,ref flag);

            visited[i][j] = false;
            //return false;
        }
    }
}
