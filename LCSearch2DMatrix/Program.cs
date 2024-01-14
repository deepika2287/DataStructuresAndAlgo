using System;

namespace LCSearch2DMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public bool SearchMatrix(int[][] matrix, int target) {
            if(matrix.Length == 1 && matrix[0].Length == 1)
            {
                if(matrix[0][0] == target)
                    return true;
                else
                    return false;
            }
            bool result = false;
            int rowIdx = 0;
            if(matrix.Length == 1)
            {
                rowIdx = 0;
            }
            else
            {
                int top = 0;
                int bottom = matrix.Length - 1;
                while(top<=bottom)
                {
                    rowIdx = top + (bottom-top)/2;
                    if(target == matrix[rowIdx][0])
                        return true;
                    if(target>matrix[rowIdx][0])
                    {
                        if(target<matrix[rowIdx][matrix[0].Length-1])
                        {
                            break;
                        }
                        top = rowIdx + 1;
                    }
                    else
                    {
                        bottom = rowIdx - 1;
                    }
                }
            }
            int left = 0;
            int right = matrix[0].Length;
            int colIdx;
            while(left<=right)
            {
                colIdx = left + (right-left)/2;
                if(target==matrix[rowIdx][colIdx])
                {
                    result = true;
                    break;
                }
                if(target<matrix[rowIdx][colIdx])
                {
                    right = colIdx-1;
                }
                else
                {
                    left = colIdx+1;
                }
            }
            return result;
        }
    }
}
