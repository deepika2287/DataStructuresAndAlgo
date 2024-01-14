using System;

namespace LCNumberOfIslands
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            char[][] grid = new char[4][];
            for(int a=0;a<4;a++)
            {
                grid[a] = new char[5];
            }
            grid[0][0] = '1';
            grid[0][1] = '1';
            grid[0][2] = '1';
            grid[0][3] = '1';
            grid[0][4] = '0';

            grid[1][0] = '1';
            grid[1][1] = '1';
            grid[1][2] = '0';
            grid[1][3] = '1';
            grid[1][4] = '0';

            grid[2][0] = '1';
            grid[2][1] = '1';
            grid[2][2] = '0';
            grid[2][3] = '0';
            grid[2][4] = '0';

            grid[3][0] = '0';
            grid[3][1] = '0';
            grid[3][2] = '0';
            grid[3][3] = '0';
            grid[3][4] = '0';
            
            Console.WriteLine(new Program().NumIslands(grid));
        }

        public int NumIslands(char[][] grid) {
            int numIslands = 0;
            int row = grid.Length;
            int col = grid[0].Length;
            bool[][] visited = new bool[row][];
            for(int i =0;i<grid.Length;i++)
            {
                visited[i] = new bool[col];
            }
            for(int i = 0;i<row;i++)
            {
                for(int j = 0;j<col;j++)
                {
                    if(!visited[i][j] && grid[i][j] == '1')
                    {
                        DFS(grid,visited,i,j,row,col);
                        numIslands++;
                    }
                }
            }
            return numIslands;
        }
        public void DFS(char[][] grid,bool[][] visited,int i, int j, int row, int col)
        {
            if(visited[i][j])
                return;

            visited[i][j] = true;
            if(i+1<row && !visited[i+1][j] && grid[i+1][j] == '1')
            {
                DFS(grid,visited,i+1,j,row,col);
            }
            if(i-1>=0 && !visited[i-1][j] && grid[i-1][j] == '1')
            {
                DFS(grid,visited,i-1,j,row,col);
            }
            if(j+1<col && !visited[i][j+1] && grid[i][j+1] == '1')
            {
                DFS(grid,visited,i,j+1,row,col);
            }
            if(j-1>=0 && !visited[i][j-1] && grid[i][j-1] == '1')
            {
                DFS(grid,visited,i,j-1,row,col);
            }
        }
    }
}
