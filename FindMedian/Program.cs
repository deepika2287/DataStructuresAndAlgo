using System;
using System.Collections.Generic;
using System.Linq;

namespace FindMedian
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());
            List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();
            int result = findMedian(arr);

            Console.WriteLine(result);
        }

        public static int findMedian(List<int> arr)
        {
            int median = int.MinValue;
            
            Sort(arr,0,arr.Count()-1);
            median = arr[(arr.Count()-1)/2];
            return median;
        }
        public static void Sort(List<int> arr, int lo, int hi)
        {
            if(hi<=lo) return;
            int mid = lo + (hi-lo)/2;
            Sort(arr,lo,mid);
            Sort(arr,mid+1,hi);
            if(arr[mid+1]>arr[mid]) return;
            MergeSort(arr,lo,mid,hi);
        }
        public static void MergeSort(List<int> arr, int lo,int mid, int hi)
        {
            int[] aux = new int[hi-lo+1];
            int i = lo;
            int j = mid+1;
            int k = 0;

            while(i<=mid && j<= hi)
            {
                if(arr[i] < arr[j])
                {
                    aux[k] = arr[i];
                    i++;
                }
                else
                {
                    aux[k] = arr[j];
                    j++;
                }
                k++;
            }
            while(i<=mid)
            {
                aux[k] = arr[i];
                i++; k++;
            }
            while(j<=hi)
            {
                aux[k] = arr[j];
                j++; k++;
            }

            for(int a = 0;a<aux.Length;a++)
            {
                arr[lo+a] = aux[a];
            }
        }
    }
}
