namespace LCFindmaxGold;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Program program= new Program();
        //int[][] grid = new int[][] { new int[]{ 0,6,0},new int[]{5,8,7},new int[]{0,9,0}};
        int[][] grid = new int[][] { new int[]{ 1,0,7},new int[]{2,0,6},new int[]{3,4,5},new int[]{0,3,0},new int[]{9,0,20}};
        int res = program.GetMaximumGold(grid);
        Console.WriteLine(res);
    }
    int MaxGold = 0;
    public int GetMaximumGold(int[][] grid) {
        int m = grid.Length;
        int n = grid[0].Length;
        bool[][] visited = new bool[m][];
        for (int i = 0;i<m;i++)
        {
            visited[i] = new bool[n];
        }
        for(int i = 0; i < m; i++)
        {
            for(int j = 0;j<n;j++)
            {
                if(grid[i][j] != 0)
                {
                    visited[i][j] = true;
                    BackTrack(grid,visited,i,j,grid[i][j]);
                    visited[i][j] = false;
                }
            }
        }
        return MaxGold;
    }

    private void BackTrack(int[][] grid,bool[][] visited, int i, int j, int gold)
    {
        if(gold > MaxGold)
        {
            MaxGold = gold;
        }
        int m = grid.Length;
        int n = grid[0].Length;
        if(i+1 < m && !visited[i+1][j] && grid[i+1][j] != 0)
        {
            visited[i+1][j] = true;
            BackTrack(grid,visited,i+1,j,grid[i+1][j]+gold);
            visited[i+1][j] = false;
        }
        if(j+1 < n && !visited[i][j+1] && grid[i][j+1] != 0)
        {
            visited[i][j+1] = true;
            BackTrack(grid,visited,i,j+1,grid[i][j+1]+gold);
            visited[i][j+1] = false;
        }
        if(i-1 >= 0 && !visited[i-1][j] && grid[i-1][j] != 0)
        {
            visited[i-1][j] = true;
            BackTrack(grid,visited,i-1,j,grid[i-1][j]+gold);
            visited[i-1][j] = false;
        }
        if(j-1 >= 0 && !visited[i][j-1] && grid[i][j-1] != 0)
        {
            visited[i][j-1] = true;
            BackTrack(grid,visited,i,j-1,grid[i][j-1]+gold);
            visited[i][j-1] = false;
        }
    }
}
