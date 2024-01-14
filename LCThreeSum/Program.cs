using System;
using System.Collections.Generic;
namespace LCThreeSum
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] nums = new int[]{-1,0,1,2,-1,-4};
            //int[] nums = new int[]{3,0,-2,-1,1,2};
            //int[] nums = new int[]{-1,0,1,2,-1,-4,-2,-3,3,0,4};
            //int[] nums = new int[]{0,0,0,0};
            int[] nums = new int[]{1,1,-2};
            IList<IList<int>> res = new Program().ThreeSum(nums);

            for(int i = 0;i<res.Count;i++)
            {
                for(int j = 0;j<res[i].Count;j++)
                {
                    Console.Write(res[i][j] + ", ");
                }
                Console.WriteLine();
            }
        }

        public IList<IList<int>> ThreeSum(int[] nums) {
            IList<IList<int>> res = new List<IList<int>>();
            List<int> sortedNums = new List<int>();
            sortedNums.AddRange(nums);
            sortedNums.Sort();
            for(int i = 0; i<sortedNums.Count && sortedNums[i]<=0; i++)
            {
                if(i+2<sortedNums.Count && sortedNums[i] == 0)
                {
                    if(sortedNums[i]+sortedNums[i+1]+sortedNums[i+2] == 0)
                    {
                        res.Add(new List<int>{nums[0],nums[1],nums[2]});
                    }
                }
                List<int> seen = new List<int>();
                for(int j = i+1;j<sortedNums.Count;j++)
                {
                    int complement = -(sortedNums[i]+sortedNums[j]);
                    if(seen.Contains(complement))
                    {
                        res.Add(new List<int>{sortedNums[i],sortedNums[j],complement});
                    }
                    seen.Add(sortedNums[j]);
                    while(j+1<sortedNums.Count && sortedNums[j]==sortedNums[j+1])
                        j++;
                }
                if(i+1<sortedNums.Count)
                while(i+1<sortedNums.Count && sortedNums[i]==sortedNums[i+1])
                        i++;
            }

            return res;
        }
        //solution with sorting the array and 2 pointer method   
        /*public IList<IList<int>> ThreeSum(int[] nums) {
            IList<IList<int>> res = new List<IList<int>>();
            if(nums.Length == 3)
            {
                if(nums[0]+nums[1]+nums[2] == 0)
                {
                    res.Add(new List<int>{nums[0],nums[1],nums[2]});
                }
                return res;
            }
            int outIdx = 0;
            int left = outIdx+1;
            int right = nums.Length-1;
            List<int> sortedNums = new List<int>();
            sortedNums.AddRange(nums);
            sortedNums.Sort();
            while(outIdx<nums.Length-1)
            {
                if(sortedNums[outIdx] > 0)
                    break;
                left = outIdx+1;
                right = nums.Length-1;
                while(left<right)
                {
                    if(sortedNums[outIdx] + sortedNums[left] + sortedNums[right] == 0)
                    {
                        res.Add(new List<int>{sortedNums[outIdx],sortedNums[left],sortedNums[right]});
                        
                        left++;
                        right--;
                        while(left<right && sortedNums[left] == sortedNums[left-1])
                            left++;
                        while(left<right && sortedNums[right] == sortedNums[right+1])
                            right--;    
                    }
                    else
                    {
                        if((sortedNums[left] + sortedNums[right]) > -sortedNums[outIdx])
                        {
                            right--;
                        }
                        else
                        {
                            left++;
                        }
                    }
                }
                outIdx++;
                while(outIdx<sortedNums.Count && sortedNums[outIdx] == sortedNums[outIdx-1])
                    outIdx++;
            }
            
            return res;
        }*/
    }
}
