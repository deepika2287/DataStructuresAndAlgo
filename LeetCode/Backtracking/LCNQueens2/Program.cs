using System;

namespace LCNQueens2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int res = new Program().TotalNQueens(4);
        }
        public int TotalNQueens(int n) {
            int res = 0;
            bool[][] board = new bool[n][];
            for(int i = 0;i<n;i++)
            {
                board[i] = new bool[n];
            }
           
                BackTrack(0,board,ref res);
            
            return res;
        }
        public void BackTrack(int row,bool[][] board, ref int res)
        {
            if(row == board.Length)
            {
                res += 1;
                return;
            }

            for(int col = 0;col<board.Length;col++)
            {
                if(IsSafe(row,col,board))
                {
                    board[row][col] = true;
                    BackTrack(row+1,board,ref res);
                    board[row][col] = false;
                }
            }
        }
        public bool IsSafe(int i, int j, bool[][] board)
        {
            //check row
            for(int a = 0;a<board.Length;a++)
            {
                if(board[i][a])
                    return false;
            }
            //check col
            for(int a = 0;a<board.Length;a++)
            {
                if(board[a][j])
                    return false;
            }
            //check diag1
            for(int a = 0;a<board.Length;a++)
            {
                if(i+a<board.Length && j+a<board.Length && board[i+a][j+a])
                    return false;
            }
            for(int a = 0;a<board.Length;a++)
            {
                if(i-a>=0 && j-a>=0 && board[i-a][j-a])
                    return false;
            }
            //check diag2
            for(int a = 0;a<board.Length;a++)
            {
                if(i+a<board.Length && j-a>=0 && board[i+a][j-a])
                    return false;
            }
            for(int a = 0;a<board.Length;a++)
            {
                if(j+a<board.Length && i-a>=0 && board[i-a][j+a])
                    return false;
            }

            return true;
        }
    }
}
