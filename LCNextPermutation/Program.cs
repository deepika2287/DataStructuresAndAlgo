using System;

namespace LCNextPermutation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int[] nums = new int[4]{1,3,2,1};

            new Program().NextPermutation(nums);
             for(int i = 0;i<nums.Length;i++)
            {
                Console.Write(nums[i] + ", ");
            }
        }

        public void NextPermutation(int[] nums) {
            int len = nums.Length;
            int pivot = len-1;
            int swapIndex = 0;
            for(int i = len-2;i>=0;i--)
            {
                if(nums[i]<nums[i+1])
                {
                    pivot = i;
                    break;
                }
            }
            for(int i = len-1;i>pivot;i--)
            {
                if(nums[i]>nums[pivot])
                {
                    swapIndex = i;
                    break;
                }
            }
            int temp = nums[pivot];
            nums[pivot] = nums[swapIndex];
            nums[swapIndex] = temp;

            ReverseArray(nums,pivot);
        }
        public static void ReverseArray(int[] nums, int pivot)
        {
            int len = nums.Length;
            int i;
            int j;
            if(pivot == len-1)
            {
                i = 1;
                j = len-2;
            }
            else
            {
                i = pivot+1 ;
                j = len-1;;
            }
            while(i<j)
            {
                int temp = nums[i];
                nums[i] = nums[j];
                nums[j] = temp;
                i++;j--;
            }
        }
        /*
            Identifying the Pivot: The pivot is determined as the first element from the end of the array 
            that is smaller than its successor. This marks the point where the sequence of numbers starts 
            decreasing, signaling an opportunity to rearrange the digits to find the next permutation.

            Locating the Swap Target: The next step involves finding the smallest element that is larger than
            the pivot, which is necessary for the 'next' permutation. Once this element is identified, it is 
            swapped with the pivot. This swap ensures that the sequence increases at the pivot, moving the 
            array closer to the next permutation.

            Sorting the Post-Pivot Sequence: After swapping, the remaining portion of the array, which is the 
            sequence after the pivot, is sorted in ascending order. This sorting is crucial as it rearranges
            the elements to achieve the lexicographically next permutation, ensuring the smallest possible
            permutation greater than the original.
        */
    }
}
