using System;
using System.Collections.Generic;
namespace IBMaximumGapApproach2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            List<int> arr = new List<int>();
            for(int i = 0; i<n ; i++)
            {
                arr.Add(Convert.ToInt32(Console.ReadLine())); 
            }
            int m = maximumGap(arr);
            Console.WriteLine(m);
        }

        public static int maximumGap(List<int> A) {
            int max = 0;
            List<MaximumGapObj> newA = new List<MaximumGapObj>();
            for(int i = 0; i<A.Count; i++)
            {
                MaximumGapObj m = new MaximumGapObj(A[i],i);
                newA.Add(m);
            }
            Sort(newA,0,newA.Count-1);
           /* for(int i = 0;i<newA.Count;i++)
            {
                Console.Write("["+newA[i].value + "," +newA[i].index+"] ");
            }*/
            int[] maxIndecesArr = new int[newA.Count];
            int mInd = -1;
            for(int i =newA.Count-1;i>=0;i--)
            {
                mInd = Math.Max(mInd, newA[i].index);
                maxIndecesArr[i] = mInd;
            }
            int tempMax = 0;
            for(int i =0;i<newA.Count;i++)
            {             
                tempMax = maxIndecesArr[i] - newA[i].index;
                if(tempMax > max)
                    max = tempMax;
                
            }

            return max;
        }
       
        public static void Sort(List<MaximumGapObj> arr, int lo, int hi)
        {
            if(hi <= lo ) 
            {
                return;
            }
            int mid = lo + (hi-lo)/2;
            Sort(arr,lo,mid);
            Sort(arr,mid+1,hi);
            if(arr[mid].value <= arr[mid+1].value) 
            {
                return;
            }
            Merge(arr,lo,mid,hi);
        }

        public static void Merge(List<MaximumGapObj> arr, int lo, int mid, int hi)
        {
            List<MaximumGapObj> aux = new List<MaximumGapObj>();
            for(int b = 0;b<hi-lo+1;b++)
            {
                aux.Add(new MaximumGapObj());
            }
            int i = lo;
            int k = 0;
            int j = mid+1;
             while(i<=mid && j<= hi)
             {
                 if(arr[i].value<arr[j].value)
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
                 aux[k] = arr[i]; i++; k++;
             }
             while(j<=hi)
             {
                 aux[k] = arr[j]; j++; k++;
             }

             for(int c = 0;c<aux.Count;c++)
             {
                 arr[c+lo] = aux[c];
             }
        }
    }
    class MaximumGapObj
    {
        public int value;
        public int index;
        public MaximumGapObj(int v, int i)
        {
            value = v;
            index = i;
        }
        public MaximumGapObj()
        {

        }
    }
}
