// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;
public class Solution {
    public static void Main(string[] args)
    {
        int[] nums = [1,-1];
        int k = 1;
        
        var res = new Solution().MaxSlidingWindow(nums,k);
    }
    public int[] MaxSlidingWindow(int[] nums, int k) 
    {
        int[] res = new int[nums.Length - k + 1];
        Dictionary<int,int> dict= new Dictionary<int, int>();
        List<int> heap = new List<int>();
        for(int i = 0;i<k;i++)
        {
            if(!dict.ContainsKey(nums[i]))
            {
                dict.Add(nums[i],i);
            }
            else
            {
                dict[nums[i]] = i;
            }
            heap.Add(nums[i]);
        }
        int idx = (heap.Count-1)/2;
        for(int i = idx;i>=0;i--)
        {
            MaxHeapify(heap,i);
        }
        res[0] = heap[0];
        int resIdx = 1;
        //1,3,-1,-3,5,3,6,7
        for(int i = k;i<nums.Length;i++)
        {
            //dict.Remove(nums[i-k]);
            if(!dict.ContainsKey(nums[i]))
            {
                dict.Add(nums[i],i);
            }
            else
            {
                dict[nums[i]] = i;
            }
            int maxValIdx = dict[heap[0]];
            if(maxValIdx >= i-k+1)
            {
                AddToHeap(heap,nums[i]);
            }
            else
            {
                while(maxValIdx < i-k+1)
                {
                    Remove(heap,0);
                    if(heap.Count>0)
                    {
                        maxValIdx = dict[heap[0]];
                    }
                    else
                    {
                        break;
                    }
                }
                AddToHeap(heap,nums[i]);
            }
            res[resIdx++] = heap[0];
        }
        return res;
    }

    private static void AddToHeap(List<int> heap,int val)
    {
        heap.Add(val);
        int index = heap.Count - 1;
        int parent = (index - 1) / 2;
        while (parent >= 0 && heap[parent] < heap[index])
        {
            int temp = heap[parent];
            heap[parent] = heap[index];
            heap[index] = temp;
            index = parent;
            parent = (parent - 1) / 2;
        }
    }

    public void Remove(List<int> nums, int idx)
    {
        nums[0] = nums[nums.Count-1];
        nums.RemoveAt(nums.Count-1);
        MaxHeapify(nums,0);
    }
    public void MaxHeapify(List<int> nums,int idx)
    {
        int lCIdx = 2*idx+1;
        int rCIdx = 2*idx+2;
        int largest = idx;
        if(lCIdx<nums.Count && nums[lCIdx]>nums[largest])
            largest = lCIdx;
        if(rCIdx<nums.Count && nums[rCIdx]>nums[largest])
            largest = rCIdx;
        if(largest!=idx)
        {
            int temp = nums[largest];
            nums[largest] = nums[idx];
            nums[idx]=temp;
            MaxHeapify(nums,largest);
        }
    }
    public class Node
    {
        public int value;
        public int index;
    }
}