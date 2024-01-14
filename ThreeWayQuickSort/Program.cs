using System;

namespace ThreeWayQuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[n];
            for(int i = 0;i < n;i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            QuickSort(arr,0,n-1);
            for(int i = 0;i < n;i++)
            {
                Console.Write(arr[i] + " ");
            }
        }

        public static void QuickSort(int[] arr, int lo, int hi)
        {
            if(hi<=lo) return;

            int lt = lo;
            int i = lo;
            int gt = hi;
            int v = arr[lo];


            while(i<=gt)
            {
                if(arr[i]<v)
                {
                    //swap ith element with lt
                    int temp = arr[i];
                    arr[i] = arr[lt];
                    arr[lt] = temp;

                    i++; lt++;
                }
                else if(arr[i] > v)
                {
                    int temp = arr[i];
                    arr[i] = arr[gt];
                    arr[gt] = temp;
                    gt--;
                }
                else
                {
                    i++;
                }
            }
            QuickSort(arr,lo,lt-1);
            QuickSort(arr,gt+1,hi);
        }
    }
}
