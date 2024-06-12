public class Solution {
    public static void Main(string[] args)
    {
        //int[] nums = [1,3,5,4,7];
        //int[] nums = [2,2,2];
        int[] nums = [1,1,1,2,2,2,3,3,3];
        //int[] nums = [1,2,3,1,2,3,1,2,3];
        //int[] nums = [49,40,-90,-71,-35,-9,12,-78,-33,-53];
        int res = new Solution().FindNumberOfLIS(nums);
    }
    //Dictionary<int,int> memo = new Dictionary<int, int>();
    public int FindNumberOfLIS(int[] nums) {
        int ans = 0;
        int[] count = new int[nums.Length];
        int[] length = new int[nums.Length];
        //memo.Add(nums.Length-1,1);
        //count[nums.Length-1]++;
        for(int i = 0;i<nums.Length;i++)
        {
            List<int> res = new List<int>();
            res.Add(nums[i]);
            Backtrack(nums,i,res,count,length);
        }
        int maxLen = 0;
        foreach(var a in length)
        {
            if(maxLen<a)
            {
                maxLen = a;
            }
        }   
        for (int i = 0; i < nums.Length; i++) {
            if (length[i] == maxLen) {
                ans += count[i];
            }
        }     
        return ans;
    }
    public void Backtrack(int[] nums, int i, List<int> res, int[] count, int[] length)
    {
        if(length[i]!=0)
            return;

        length[i] = 1;
        count[i]++;
        for(int j = 0;j<i;j++)
        {
            if(nums[j]<nums[i])
            {
                res.Add(nums[j]);
                Backtrack(nums,j,res,count,length);
                if(length[i] < length[j]+1)
                {
                    length[i] = length[j]+1;
                    count[i] = 0;
                }
                if(length[i] == length[j]+1)
                {
                    count[i] = count[i]+count[j];
                }
                res.RemoveAt(res.Count-1);
            }
        }
        
    }
}