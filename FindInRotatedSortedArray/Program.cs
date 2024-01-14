using System;
using System.Collections.Generic;

namespace FindInRotatedSortedArray
{
    class Program
    {
        public int resInd;
        static void Main(string[] args)
        {
            List<int> A = new List<int>(){4,5,6,7,0,1,2};
            Program p =new Program();
            int res = p.search(A,3);
            Console.WriteLine(res);
        }

        public int search(List<int> A, int B) 
        {
            if(A.Count == 0)
            return -1;

            if(A.Count == 1 && A[0]==B)
            return 0;

            if(A.Count == 1 && A[0]!=B)
            return -1;

            int lo = 0;
            int hi = A.Count-1;
            int mid = (lo+hi)/2;
            resInd = -1;
            BinarySearch(A,lo,hi,mid,B);

            return resInd;
        }

        public void BinarySearch(List<int> A, int lo, int hi, int mid, int B)
        {
            if(lo<=hi)
            {
                if(A[mid] == B)
                {
                    resInd = mid;
                }
                else if(A[lo] > A[hi])
                {
                    BinarySearch(A,lo,mid-1,(lo+mid-1)/2,B);
                    BinarySearch(A,mid+1,hi,(hi+mid+1)/2,B);
                }
                else if(A[mid]> B)
                {
                    BinarySearch(A,lo,mid-1,(lo+mid-1)/2,B);
                }
                else
                {
                    BinarySearch(A,mid+1,hi,(hi+mid+1)/2,B);
                }
            }
        }
    }
}
