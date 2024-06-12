namespace LCCountSquareSubMatricesWithAllOnes;

class Program
{
    static void Main(string[] args)
    {
        int[][] matrix =
                        [
                        [0,1,1,1],
                        [1,1,1,1],
                        [0,1,1,1]
                        ];
        Program p = new Program();
        int res = p.CountSquares(matrix);
        Console.WriteLine( res);
    }
    public int CountSquares(int[][] matrix) {
        int numSquares = 0;
        int m = matrix.Length;
        int n = matrix[0].Length;
        int[][] memo = new int[m][];
        for(int i= 0;i<m;i++)
        {
            memo[i] = new int[n];
            for(int j = 0;j<n;j++)
            {
                memo[i][j] = -1;
            }
        }
        for(int i = 0;i<m;i++)
        {
            for(int j = 0;j<n;j++)
            {
                if(matrix[i][j] == 1 && memo[i][j] == -1)
                {
                    numSquares = numSquares + RecHelper(matrix,i,j,m,n,memo);
                }
                else if(memo[i][j] != -1)
                {
                    numSquares = numSquares + memo[i][j];
                }
            }
        }
        return numSquares;
    }
    public int RecHelper(int[][] matrix,int i, int j, int m, int n, int[][] memo)
    {
        if(i>=m || j>=n || matrix[i][j] == 0)
            return 0;
        
        if(memo[i][j]!=-1)
        {
            return memo[i][j];
        }
        int right = RecHelper(matrix,i,j+1,m,n,memo);
        int bottom = RecHelper(matrix,i+1,j,m,n,memo);
        int bottomRight = RecHelper(matrix,i+1,j+1,m,n,memo);

        return memo[i][j] =  1 + Math.Min(right, Math.Min(bottom, bottomRight));
    }
}
