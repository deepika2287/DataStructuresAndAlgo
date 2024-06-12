namespace LCUniquePaths;

class Program
{
    static void Main(string[] args)
    {
        Program p = new Program();
        Console.WriteLine(p.UniquePaths(3,2));
    }
    public int UniquePaths(int m, int n) {
        
        int[][] grid = new int[m][];
        for(int i = 0;i<m;i++)
        {
            grid[i] = new int[n];
            for(int j = 0;j<n;j++)
            {
                grid[i][j] = 0;
            }
        }
        grid[0][0] = 1;
        if(m>1)
        {
            for(int i = 1;i<m;i++ )
            grid[i][0] = 1;
        }
        if(n > 1)
        {
            for(int j = 1;j<n;j++)
            grid[0][j] = 1;
        }
        for(int i = 1;i<m;i++)
        {
            for(int j = 1;j<n;j++)
            {
                grid[i][j] = grid[i-1][j] + grid[i][j-1];
            }
        }
        
        return grid[m-1][n-1];
    }
    //top down approach
    /*public int UniquePaths(int m, int n) {
        int[][] grid = new int[m][];
        for(int i = 0;i<m;i++)
        {
            grid[i] = new int[n];
            for(int j = 0;j<n;j++)
            {
                grid[i][j] = -1;
            }
        }
        return RecuriveHelper(m, n, 0 , 0, grid);
    }
    public int RecuriveHelper(int m, int n, int i, int j, int[][] grid)
    {
        if(i==m-1 && j==n-1)
            return 1;
        if(i == m || j == n)
            return 0;
        if(grid[i][j] != -1)
            return grid[i][j];
        
        grid[i][j] = RecuriveHelper(m,n,i+1,j,grid) + RecuriveHelper(m,n,i,j+1,grid);
        return grid[i][j];
    }*/
}
