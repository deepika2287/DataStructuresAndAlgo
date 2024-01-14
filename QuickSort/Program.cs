using System;

namespace QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[n];
            for(int i = 0;i<n;i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            int lo = 0;
            int hi = n-1;
            QuickSort(arr,lo,hi);

            for(int i = 0;i<n;i++)
            {
                Console.Write(arr[i] + " ");
            }
        }

        public static void QuickSort(int[] arr, int lo, int hi)
        {
            if(hi<=lo) return;
            int j = Partition(arr,lo,hi);
            
            Console.WriteLine();
            QuickSort(arr,lo,j-1);
            QuickSort(arr,j+1,hi);
        }

        public static int Partition(int[] arr, int lo, int hi)
        {
            int i = lo+1; int j = hi;
            //Console.WriteLine("outer function i = " + i + " j = " + j);
            while(i<=j)
            {
               // Console.WriteLine("inside loop i = " + i + " j = " + j);
                while(arr[i]<arr[lo])
                {
                    i++;
                    if(i>=hi) 
                    {
                        break;
                    }
                }

                while(arr[j]>arr[lo])
                {
                    j--;
                    if(j<=lo)
                    {
                        break;
                    }
                }
                if(i>=j)
                {break;}
                //swap i and j elements
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }

            //swap j element with lo
            int t = arr[j];
            arr[j] = arr[lo];
            arr[lo] = t;

            return j;
        }
    }
}
