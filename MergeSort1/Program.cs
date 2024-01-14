/*
1. following merge sort program is optimized to minimize calls to merge function
2. further optimization can be done by appying insertion sort 
   if subarray size is less than 7 or some constant number. 
   this will save space as it uses inplace swap.
   Merge sort has too much overhead for small arrays of size 2,3,4. it includes recursive calls and
   so much opying in auxillary array.
*/

using System;

namespace MergeSort1
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
            int[] aux = new int[arr.Length];
            InternalSort(arr,aux,lo,hi);
            //print
            for(int i = lo;i<=hi;i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }

        public static void InternalSort(int[] arr,int[] aux, int lo, int hi)
        {
            if(hi <= lo ) //optimization for small arrays using insertion sort - hi <= lo + (cutoff-1)
            {
                //InsertionSort(arr,lo,hi);
                return;
            }
            int mid = lo + (hi-lo)/2;
            Console.WriteLine("lo = " + lo + " mid = " + mid + " hi = " + hi); 
            InternalSort(arr,aux,lo,mid);
            InternalSort(arr,aux,mid+1,hi);
            if(arr[mid]<=arr[mid+1]) 
            {
                //tested with below input 
                //first half contains less than 50 and second half conains more than 50. so call to merge function is saved
                /*10
                10
                2
                27
                44
                22
                52
                90
                89
                50
                63*/

                Console.WriteLine("early return saves time!!");
                return;
            }
            Merge(arr,aux,lo,mid,hi);
        }

        public static void Merge(int[] arr,int[] aux, int i, int n, int j)
        {
            int lo = i;
            int m = n+1;
            int k = i;
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
            for(int a = lo; a<=j; a++)
            {
                arr[a] = aux[a];
            }
        }
    }
}
