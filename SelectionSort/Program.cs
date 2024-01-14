using System;

namespace SelectionSort
{
    class Program
    {
        static void Main(string[] args)
        {


            int n = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[n];
            for(int i = 0; i<n;i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }

            for(int i = 0;i<n;i++)
            { 
                int minindex = i;
                for(int j = i+1;j<n;j++)
                {
                    //find min from j to n
                    if(arr[minindex]>arr[j])
                        minindex=j;
                }
                //swap arr[i] with min if min < arr[i]
                if(arr[minindex]<arr[i])
                {
                    int swap = arr[i];
                    arr[i]=arr[minindex];
                    arr[minindex] = swap;
                }
            }
            //print arr
            Console.WriteLine();
            for(int i = 0 ;i<n;i++)
            {
                Console.Write(arr[i] + "  ");
            }
            Console.WriteLine();
        }
    }
}
