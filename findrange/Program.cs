using System;
using System.Collections.Generic;

namespace findrange
{
    
    class Program
    {

        public int leftIndex;
	    public int rightIndex;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public List<int> searchRange(List<int> A, int B)
        {
            int lo = 0;
            int hi = A.Count-1;

            leftIndex = int.MaxValue;
            rightIndex = int.MinValue;

            BinarySearch(A,lo,hi,B);

            if(leftIndex == int.MaxValue) leftIndex = -1;
            if(rightIndex == int.MinValue) rightIndex = -1;

            List<int> res = new List<int>();
            res.Add(leftIndex);
            res.Add(rightIndex);

            return res;
        }

        public void BinarySearch(List<int> A, int lo, int hi, int B)
        {
            if(hi>lo)
            {
                int mid = (lo+hi)/2;
                if(A[mid] == B)
                {
                    leftIndex = Math.Min(leftIndex,mid);
                    rightIndex = Math.Max(rightIndex, mid);
                    BinarySearch(A,lo,mid-1,B);
                    BinarySearch(A,mid+1,hi,B);
                }
                else if( A[mid] > B)
                {
                    BinarySearch(A,lo,mid-1,B);
                }
                else
                {
                    BinarySearch(A,mid+1,hi,B);
                }
            }
            
        }

    }
}
