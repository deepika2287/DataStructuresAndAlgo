using System;

namespace HeapSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[n];
            for(int i = 0; i<n ; i++)
            {
                arr[i] = (Convert.ToInt32(Console.ReadLine())); 
            }
            HeapSort(arr);
            for(int i = 0; i<n ; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }

        public static void HeapSort(int[] arr)
        {
            int n = arr.Length;
            for(int i = (n/2)-1;i>=0;i--)
            {
                Heapify(arr,n,i);
            }
            for(int i = 0;i<n;i++)
            {
                int temp = arr[0];
                arr[0] = arr[n-i-1];
                arr[n-i-1] = temp;
                Heapify(arr,n-i-1,0);
            }
        }
        public static void Heapify(int[] arr, int n, int i)
        {
            int parent = i;
            int leftchild = (2*i)+1;
            int rightchild = (2*i)+2;

            if(leftchild<n && arr[leftchild]>arr[parent])
            {
                parent = leftchild;
            }
            if(rightchild<n && arr[rightchild]>arr[parent])
            {
                parent = rightchild;
            }

            if(parent!=i)
            {
                int temp = arr[i];
                arr[i] = arr[parent];
                arr[parent] = temp;
                Heapify(arr,n,parent);
            }
        }
    }
}
