using System;

namespace LCRotatematrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int len = 5;
            int[][] matrix = new int[len][];

            for(int i = 0;i<matrix.Length;i++)
            {
                matrix[i] = new int[len];
            }
            int count = 1;
            for(int i = 0;i<len;i++)
            {
                for(int j = 0;j<len;j++)
                {
                    matrix[i][j] = count++;
                }
            }
            for(int i = 0;i<len;i++)
            {
                for(int j = 0;j<len;j++)
                {
                    string s = "";
                    if(matrix[i][j]<10)
                    {
                        s = " " + matrix[i][j];
                    }
                    else
                    {
                        s = matrix[i][j].ToString();
                    }
                    Console.Write(s + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            new Program().Rotate(matrix);
            for(int i = 0;i<len;i++)
            {
                for(int j = 0;j<len;j++)
                {
                    string s = "";
                    if(matrix[i][j]<10)
                    {
                        s = " " + matrix[i][j];
                    }
                    else
                    {
                        s = matrix[i][j].ToString();
                    }
                    Console.Write(s + " ");
                }
                Console.WriteLine();
            }
        }

        //transpose and reverse
        //transpose means reflecting on a diagonal
        public void Rotate(int[][] matrix) {
            int n = matrix.Length;

            for(int i=0;i<n;i++)
            {
                for(int j=i;j<n;j++)
                {
                    if( i != j)
                    {
                        int temp = matrix[i][j];
                        matrix[i][j] = matrix[j][i];
                        matrix[j][i] = temp;
                    }
                }
            }
            for(int i=0;i<n;i++)
            {
                for(int j=0;j<n/2;j++)
                {
                    int temp = matrix[i][j];
                    matrix[i][j] = matrix[i][n-j-1];
                    matrix[i][n-j-1] = temp;
                }
            }

        }

        //shortcut method
        /*public void Rotate(int[][] matrix) {
            int n = matrix.Length;
            
            for(int i = 0;i<n/2;i++)
            {
                for(int j = i;j<n-i-1;j++)
                {
                    int temp = matrix[i][n-j-1];
                    matrix[i][n-j-1] = matrix[j][i];
                    matrix[j][i] = matrix[n-i-1][j];
                    matrix[n-i-1][j] = matrix[n-j-1][n-i-1];
                    matrix[n-j-1][n-i-1] = temp;
                    /*for(int a = 0;a<n;a++)
                    {
                        for(int b = 0;b<n;b++)
                        {
                            string s = "";
                            if(matrix[a][b]<10)
                            {
                                s = " " + matrix[a][b];
                            }
                            else
                            {
                                s = matrix[a][b].ToString();
                            }
                            Console.Write(s + " ");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                }
                
                
            }
        }*/
    }
}
