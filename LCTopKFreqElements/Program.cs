using System;
using System.Collections.Generic;
using System.Linq;

namespace LCTopKFreqElements
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int[] nums = new int[]{4,4,5,5,5,3,3,3,6,6,6,6,6,7,7,7,7,7};
            int[] res = new Program().TopKFrequent(nums,3);
        }
        public int[] TopKFrequent(int[] nums, int k) {
            int[] res = new int[k];
            Dictionary<int,int> dict = new Dictionary<int, int>();
            for(int i = 0;i<nums.Length;i++)
            {
                if(dict.ContainsKey(nums[i]))
                {
                    dict[nums[i]] += 1;
                }
                else
                {
                    dict.Add(nums[i],1);
                }
            }
            var sortedDict = dict.OrderByDescending(x=>x.Value);
            int idx = 0;
            foreach(var d in sortedDict)
            {
                res[idx] = d.Key;
                idx++;
                if(idx == k)
                    break;
            }
            /*SortedList<int,List<int>> sl = new SortedList<int, List<int>>();
            for(int i = 0;i<nums.Length;i++)
            {
                if(!sl.ContainsKey(dict[nums[i]]))
                {
                    sl.Add(dict[nums[i]],new List<int>());
                    if(!sl[dict[nums[i]]].Contains(nums[i]))
                        sl[dict[nums[i]]].Add(nums[i]);
                }
                else
                {
                    if(!sl[dict[nums[i]]].Contains(nums[i]))
                        sl[dict[nums[i]]].Add(nums[i]);
                }
            }
            int idx=0;
            for(int i = 0;i<k;i++)
            {
                int count = sl.Last().Value.Count;
                int key = sl.Last().Key;
                for(int j=0;j<count && j<k;j++)
                {
                    res[idx] = sl[key][j];
                    idx++;
                    if(idx == k)
                        return res;
                }
                if(idx == k)
                    return res;
                sl.RemoveAt(sl.Count-1);
            }*/
            return res;
        }
    }
}
