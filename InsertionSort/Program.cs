using System;

namespace InsertionSort
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

            Sort(arr);

            for(int i = 0 ; i < n; i++)
            {
                Console.Write(arr[i] + " "); 
            }
        }

        public static void Sort(int[] arr)
        {
            int n = arr.Length;

            for(int i = 1 ;i<n;i++)
            {
                for(int j = i;j>0;j--)
                {
                    if(arr[j]<arr[j-1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j-1];
                        arr[j-1] = temp;
                    }
                    else
                    {
                        //no need for further comparisons once arr[j] > arr[j-1]
                        //because arr is sorted from 0 to j-1 in previous iteration
                        Console.WriteLine(arr[j-1] + " " + arr[j] + " Yay!!");
                        break;
                    }
                    
                }
            }
        }
    }
}
