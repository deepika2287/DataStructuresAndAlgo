public class Solution {
    public static void Main(string[] args)
    {
        int[] nums = [22,1,74,51,18,38,9,44,88,12];
        var res = new Solution().LargestDivisibleSubset(nums);
    }
    IList<int> res;
    IList<int> ret;
    public IList<int> LargestDivisibleSubset(int[] nums) {
        res = new List<int>();
        ret = new List<int>();
        if(nums.Length == 1)
        {
            ret.Add(nums[0]);
            return ret;
        }
        if(nums.Length == 2)
        {
            if(nums[0]%nums[1] == 0 || nums[1]%nums[0] == 0)
            {
                ret = new List<int>(nums);
                return ret;
            }
            else
            {
                ret.Add(nums[0]);
                return ret;
            }
        }
       
        for(int i = 0;i<nums.Length;i++)
        {
            res.Add(nums[i]);
            BackTrack(nums,i);       
            res.Clear();
        }
        if(ret.Count > 0)
        {
            return ret;
        }
        else
        {
            ret.Add(nums[0]);
            return ret;
        }   
    }
    public void BackTrack(int[] nums, int i)
    {
        
        for(int j = i+1;j<nums.Length;j++)
        {
            bool flag = true;
            if(!res.Contains(nums[j]) && (nums[i]%nums[j] == 0 || nums[j]%nums[i] == 0))
            {
                for(int a = 0;a<res.Count;a++)
                {
                    if(res[a]%nums[j] == 0 || nums[j]%res[a] == 0)
                    {
                        continue;
                    }
                    else
                    {
                        flag = false;
                        break;
                    }
                }
                if(flag)
                {
                    res.Add(nums[j]);
                    BackTrack(nums,j);
                    if(res.Count>ret.Count)
                    {
                        ret = new List<int>(res);
                    }
                    res.RemoveAt(res.Count-1);
                }
            }
        }
    }
}