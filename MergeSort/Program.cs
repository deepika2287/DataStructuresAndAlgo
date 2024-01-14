using System;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[n];
            for(int i = 0; i<n ; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine()); 
            }
            Sort(arr);
        }

        public static void Sort(int[] arr)
        {
            int lo = 0;
            int hi = arr.Length-1;
            InternalSort(arr,lo,hi);

            //print
            for(int i = lo;i<=hi;i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }

        public static void InternalSort(int[] arr, int lo, int hi)
        {
            if(hi <= lo) return;
            int mid = lo + (hi-lo)/2;
            Console.WriteLine("lo = " + lo + " mid = " + mid + " hi = " + hi); 
            InternalSort(arr,lo,mid);
            InternalSort(arr,mid+1,hi);
            Merge(arr,lo,mid,hi);
        }

        public static void Merge(int[] arr, int i, int n, int j)
        {
            int[] aux = new int[j-i+1];
            int lo = i;
            int m = n+1;
            int k =0;
            while(i<=n && m<=j)
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

            while(i<=n)
            {
                aux[k]=arr[i];
                k++;
                i++;
            }
            while(m<=j)
            {
                aux[k] = arr[m];
                m++;
                k++;
            }
            
            //update arr from aux
            for(int a = 0;a<aux.Length;a++)
            {
                arr[lo+a] = aux[a];
            }
        }
    }
}
