using System;
using System.Collections.Generic;

namespace IBPlusOne
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            List<int> arr = new List<int>();
            for(int i = 0; i<n ; i++)
            {
                arr.Add(Convert.ToInt32(Console.ReadLine())); 
            }
            List<int> res =  plusOne(arr);
            for(int i = 0;i<res.Count;i++)
            {
                Console.Write(res[i] + " ");
            }
        }

        public static List<int> plusOne(List<int> A)
        {
            int n = A.Count-1;
            List<int> res = new List<int>();
            bool resArrAllZeros = false;
            if(A.Count == 1 && A[0]==0)
            {
                res.Add(1);
                return res;
            }
            while(n>-1)
            {
                if(A[n] >= 0 && A[n]<9)
                {
                    A[n] = A[n] + 1;
                    break;
                }
                else
                {
                    A[n] = 0;
                    n--;
                }               
            }
            
            if(n == -1)
            {
                res.Add(1);
                for(int i=0;i<A.Count;i++)
                {
                    res.Add(0);
                }
            }

            else
            {
                bool initialZero = true;
                for(int i = 0;i<A.Count;i++)
                {
                    while(A[i] == 0 && initialZero)
                    { i++;}
                    initialZero = false;
                    res.Add(A[i]);
                }
            }
            
            
            return res;
        }
    }
}
