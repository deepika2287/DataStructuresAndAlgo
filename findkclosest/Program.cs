using System;
using System.Collections.Generic;
using System.Linq;

namespace findkclosest
{
    class Program
    {
        static void Main(string[] args)
        { 
            int[] arr = new int[]{1,3,5,7,9};
            Program p =new Program();
            p.FindClosestElements(arr,3,-1);
            Console.WriteLine("Hello World!");
        }

        public IList<int> FindClosestElements(int[] arr, int k, int x) 
        {
            List<int> res = new List<int>();
            int indexX = -1;
            int lo = 0;
            int hi = arr.Length-1;
            int mid = (lo+hi)/2;
            if(!(x<arr[0]) && !(x>arr[arr.Length-1]))
            {
                indexX = BinarySearch(arr,0,arr.Length-1,mid,x);
            }
            else if(x<arr[0])
            {
                indexX = -1;
            }
            else
            {
                indexX = hi;
            }
            int i = indexX;
            int j = indexX+1;

            while(i>=0 && j<=hi && k>0)
            {
                if(Math.Abs(x-arr[i]) <= Math.Abs(x-arr[j]))
                {
                    res.Add(arr[i]);
                    i--;                   
                }
                else
                {
                    res.Add(arr[j]);
                    j++;
                }
                k--;
            }
            while(k>0 && i>=0)
            {
                res.Add(arr[i]);
                i--; k--;
            }

            while(k>0 && j<=hi)
            {
                res.Add(arr[j]);
                j++;
                k--;
            }

            res.Sort();
            return res;    

                
        }

        private int BinarySearch(int[] arr, int lo, int hi, int mid, int x)
        {
            if(lo<=hi)
            {
                
                if(arr[mid] == x)
                {
                    return mid;
                }
                else if(arr[mid]<x)
                {
                    return BinarySearch(arr,mid+1,hi,(mid+1+hi)/2,x);
                }
                else
                {
                    
                    return BinarySearch(arr,lo,mid-1,(lo+mid-1)/2,x);
                }
            }
            else
            {
                return mid;
            }
        }

    }

}
