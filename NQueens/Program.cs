using System;

namespace NQueens
{
    class Program
    {
        public int ans;
        static void Main(string[] args)
        {
            Program p = new Program();
            int res = p.TotalNQueens(4);
            Console.WriteLine(res);
        }

        public int TotalNQueens(int n) 
        {
            ans = 0;
            bool[][] visited = new bool[n][];
            for(int i = 0;i<n;i++)
            {
                visited[i] = new bool[n];
            }
            for(int i = 0;i<n;i++)
            {       
                visited[i][0] = true;        
                ans = ans + PlaceQueen(1,visited);
                visited[i][0] = false;
            }
            return ans;        
        }
        public int PlaceQueen(int j, bool[][] visited)
        {
            if(j>=visited.Length)
                return 1;
            int solutions = 0;
            for(int i = 0;i<visited.Length;i++)
            {
                if(!IsPosValid(visited,i,j))
                {
                    continue;
                }
                visited[i][j] = true;
                solutions = solutions + PlaceQueen(j+1,visited);
                visited[i][j] = false;
            }

            return solutions;
        }

        public bool IsPosValid(bool[][] visited, int i, int j)
        {
            if(i >= visited.Length || j>= visited.Length)
                return false;

            int x = i; int y = j;    
            //check rows
            for(int a=0;a<visited.Length;a++)
            {
                if(visited[a][y])
                    return false;
            }

            //check cols
            for(int a=0;a<visited.Length;a++)
            {
                if(visited[i][a])
                    return false;
            }

            x=i;y=j;
            //check left upper diagonal
            while(x>=0 && y>=0)
            {
                if(visited[x][y])
                    return false;
                
                x--;y--;
            }
            x=i;y=j;

            //check left lower diagonal
            while(x<visited.Length && y>=0)
            {
                if(visited[x][y])
                    return false;

                x++;y--;
            }
            x=i;y=j;    
            //check right upper diagonal
            while(y<visited.Length && x>=0)
            {
                if(visited[x][y])
                    return false;

                x--;y++;
            }
            x=i;y=j;
            //check right lower diagonal
            while(x<visited.Length && y<visited.Length)
            {
                if(visited[x][y])
                    return false;

                x++;y++;
            }
            return true;    
        }
    }
}
