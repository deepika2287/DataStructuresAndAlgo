using System;

namespace LCMedianOf2SortedArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int[] nums1 = new int[]{1};
            int[] nums2 = new int[]{2,3,4};
            var res = new Program().FindMedianSortedArrays(nums1,nums2);
        }
        public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
            if(nums1.Length == 0)
            {
                if(nums2.Length == 1)
                    return (double)nums2[0];
                
                int pivot = (nums2.Length-1)/2;
                if(nums2.Length%2==0)
                {
                    return (double)(nums2[pivot] + nums2[pivot+1])/2;
                }
                else
                {
                    return(double)nums2[pivot];
                }
            }
            if(nums2.Length == 0)
            {
                if(nums1.Length == 1)
                    return (double)nums1[0];
                
                int pivot = (nums1.Length-1)/2;
                if(nums1.Length%2==0)
                {
                    return (double)(nums1[pivot] + nums1[pivot+1])/2;
                }
                else
                {
                    return(double)nums1[pivot];
                }
            }
            if(nums1.Length<nums2.Length)
                return FindMedianSortedArrays(nums2,nums1);

            int ptr1 = 0;
            int ptr2 = 0;
            int m = nums1.Length;
            int n = nums2.Length;
            int mid = (m+n)/2;
            if((m+n)%2 == 0)
            {
                mid = mid - 1;
            }
            while(ptr1+ptr2<mid)
            {
                if(ptr1 < nums1.Length && ptr2 < nums2.Length)
                {
                    if(nums1[ptr1]<=nums2[ptr2])
                        ptr1++;
                    else
                        ptr2++;
                    
                }
                else if(ptr2 < nums2.Length)
                {
                    ptr2++;
                }
                else
                {
                    ptr1++;
                }

            }
            if((m+n)%2 != 0)
            {
                if(ptr1<nums1.Length && ptr2<nums2.Length)
                {
                    if(nums1[ptr1]<nums2[ptr2])
                    {
                        return (double)nums1[ptr1];
                    }
                    else
                    {
                        return (double)nums2[ptr2];
                    }
                }
                else if(ptr2<nums2.Length)
                {
                    return (double)nums2[ptr2];
                }
                else
                {
                    return (double)nums1[ptr1];
                }
            }
            else
            {
                int n1; 
                if(ptr1<nums1.Length && ptr2<nums2.Length)
                {
                    if(nums1[ptr1] < nums2[ptr2])
                    {
                        n1 = nums1[ptr1];
                        ptr1++;
                        if(ptr1<nums1.Length && nums1[ptr1] < nums2[ptr2])
                        {
                            return (double)(n1+nums1[ptr1])/2;
                        }
                        else
                        {
                            return (double)(n1+nums2[ptr2])/2;
                        }
                    }
                    else
                    {
                        n1 = nums2[ptr2];
                        ptr2++;
                        if(ptr2<nums2.Length && nums2[ptr2] < nums1[ptr1])
                        {
                            return (double)(n1+nums2[ptr2])/2;
                        }
                        else
                        {
                            return (double)(n1+nums1[ptr1])/2;
                        }
                    }
                }
                else if(ptr2<nums2.Length)
                {
                    return (double)(nums2[ptr2]+nums2[ptr2+1])/2;
                }
                else
                {
                    return (double)(nums1[ptr1]+nums1[ptr1+1])/2;
                }
            }
        }
    }
}
