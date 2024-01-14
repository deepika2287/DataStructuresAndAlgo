using System;
using System.Collections.Generic;
using System.Linq;

namespace LCSpiralMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int[][] matrix = new int[3][];
            matrix[0] = new int[3]{1,2,3};
            matrix[1] = new int[3]{5,6,7};
            matrix[2] = new int[3]{9,10,11};
            var res = new Program().SpiralOrder(matrix);
        }
        public IList<int> SpiralOrder(int[][] matrix) {
            IList<int> result = new List<int>();
            int left = 0;
            int right = matrix[0].Length-1;
            int up = 0;
            int down = matrix.Length-1;
            int count = (right+1)*(down+1);
            while(result.Count<count)
            {
                /*if(up == down && left == right)
                {
                    result.Add(matrix[up][left]);
                }*/
                for(int i = left;i<=right;i++)
                {
                    result.Add(matrix[up][i]);
                }
                for(int i = up+1;i<=down;i++)
                {
                    result.Add(matrix[i][right]);
                }
                if(up!=down)
                for(int i = right-1;i>=left;i--)
                {
                    result.Add(matrix[down][i]);
                }
                if(left!=right)
                for(int i = down-1;i>up;i--)
                {
                    result.Add(matrix[i][left]);
                }
                left++;
                right--;
                up++;
                down--;
                
            }
            return result;
        }
    }
}
