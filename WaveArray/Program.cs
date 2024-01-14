using System;
using System.Collections.Generic;

namespace WaveArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            List<int> arr = new List<int>();
            for(int i = 0;i<n;i++)
            {
                arr.Add(Convert.ToInt32(Console.ReadLine()));
            }
            
            List<int> sorted = Wave1(arr);      

            foreach(int a in sorted)
            {
                Console.Write(a + " ");
            }    
        }

        public static List<int> Wave1(List<int> A)
        {
            int lo = 0;
            int hi = A.Count-1;
            MergeSort(A,lo,hi);
            for(int i = 0; i<A.Count-1;i = i+2)
            {
                int temp = A[i];
                A[i] = A[i+1];
                A[i+1] = temp;
            }
            return A;
        }

        public static void MergeSort(List<int> arr, int lo, int hi)
        {
            if(hi<=lo) return;
            int mid = lo + (hi-lo)/2;
            Console.WriteLine("lo = " + lo + " mid = "+ mid + " hi = "+hi);
            MergeSort(arr,lo,mid);
            MergeSort(arr,mid+1,lo);
            Merge(arr,lo,mid,hi);
        }

        public static void Merge(List<int> arr, int lo, int mid, int hi)
        {
            int i = lo;
            int j = mid+1;
            int k = 0;
            int[] aux = new int[hi-lo+1];

            while(i<=mid && j<=hi)
            {
                if(arr[i]<arr[j])
                {
                    aux[k] = arr[i];
                    i++; k++;
                }
                else{
                    aux[k] = arr[j];
                    j++; k++;
                }
            }
            while(i<=mid)
            {
                aux[k] = arr[i];
                i++; k++;
            }
            while(j<=mid)
            {
                aux[k] = arr[j];
                j++; k++;
            }

            for(int a=0;a<=hi-lo;a++)
            {
                arr[a+lo] = aux[a];
            }
        }
    }
}
