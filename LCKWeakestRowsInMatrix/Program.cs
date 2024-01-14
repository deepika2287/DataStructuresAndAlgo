using System;
using System.Collections.Generic;

namespace LCKWeakestRowsInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            /*int[][] mat = new int[5][];
            int[] arr1 = new int[]{1,1,0,0,0};
            int[] arr2 = new int[]{1,1,1,1,0};
            int[] arr3 = new int[]{1,0,0,0,0};
            int[] arr4 = new int[]{1,1,0,0,0};
            int[] arr5 = new int[]{1,1,1,1,1};
            mat[0] = arr1;
            mat[1] = arr2;
            mat[2] = arr3;
            mat[3] = arr4;
            mat[4] = arr5;*/

            int[][] mat = new int[3][];
            int[] arr1 = new int[]{1,0};
            int[] arr2 = new int[]{0,0};
            int[] arr3 = new int[]{1,0};
            
            mat[0] = arr1;
            mat[1] = arr2;
            mat[2] = arr3;
            

            int[] res = new Program().KWeakestRows(mat,3);
        }
        public int[] KWeakestRows(int[][] mat, int k) {
            int[] res = new int[k];
            Dictionary<int,int> dict = new Dictionary<int, int>();
            for(int i = 0;i<mat.Length;i++)
            {
                int numOne = 0;
                for(int j=0;j<mat[i].Length;j++)
                {
                    if(mat[i][j]==1)
                        numOne++;
                    else
                        break;
                }
                dict.Add(i,numOne);
            }
            SortedList<int,List<int>> sl = new SortedList<int, List<int>>();
            for(int i = 0;i<dict.Count;i++)
            {
                if(!sl.ContainsKey(dict[i]))
                {
                    sl.Add(dict[i],new List<int>());
                    sl[dict[i]].Add(i);
                }
                else
                {
                    sl[dict[i]].Add(i);
                }
            }
            int idx = 0;
            
            foreach(var s in sl)
            {
                int count = s.Value.Count;
                for(int i = 0;i<count;i++)
                {
                    res[idx] = s.Value[i];
                    idx++;
                    if(idx == k)
                        return res;
                }
            }
            
            return res;
        }
    }
}
