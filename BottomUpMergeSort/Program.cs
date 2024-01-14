using System;

namespace BottomUpMergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[n];
            for(int i = 0 ; i < n; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }

            MergeSort(arr);

            for(int i = 0 ; i < n; i++)
            {
                Console.Write(arr[i] + " "); 
            }

        }
        public static void MergeSort(int[] arr)
        {
            int n = arr.Length;
            //total complexity is NlogN
            for(int sz = 1; sz<n ;sz=sz+sz) // complexity O(logN) as sz is increasing by 2^sz
            {
                for(int lo = 0 ; lo < n-sz; lo = lo + sz+sz) //complexity is O(N)
                {
                    Console.WriteLine("lo = " + lo + " mid = " + (lo+sz-1) + " hi = " + Math.Min(lo +sz +sz-1,n-1)); 
                    Merge(arr,lo,Math.Min(lo +sz +sz-1,n-1),lo+sz-1);
                }
            }
        }

        public static void Merge(int[] arr, int lo, int hi, int mid)
        {
            int[] aux = new int[hi-lo+1];
            int i = lo;
            int k = 0;
            int m = mid+1;
            while(i<=mid && m<=hi)
            {
                if(arr[i]<arr[m])
                {
                    aux[k] = arr[i];
                    i++;
                }
                else
                {
                    aux[k] = arr[m];
                    m++;
                }
                k++;
            }
            while(i<=mid)
            {
                aux[k] = arr[i];
                i++;
                k++;
            }
            while(m<=hi)
            {
                aux[k] = arr[m];
                m++;
                k++;
            }

            for(int a = 0 ; a<aux.Length; a++)
            {
                arr[lo+a] = aux[a];
            }
        }

    }
}
