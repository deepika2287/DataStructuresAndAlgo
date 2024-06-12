public class Solution {
    public static void Main()
    {
        int[] nums = [1,5,2];
        bool res = new Solution().PredictTheWinner(nums);
    }
    bool ans  = false;
    public bool PredictTheWinner(int[] nums) {
        Backtrack(nums,0,nums.Length-1,true,0,0);
        return ans;
    }
    public void Backtrack(int[] nums, int left, int right, bool player,int count1, int count2)
    {
        if(right<left)
        {
            ans = count1>=count2?true:false;
            return;
        }
        if(!ans)
        {
                if(player)
                {
                    Backtrack(nums, left+1, right, !player,count1+nums[left],count2);
                    Backtrack(nums, left, right-1, !player,count1+nums[right],count2);
                }
                else
                {
                    Backtrack(nums, left+1, right, !player,count1,count2+nums[left]);   
                    Backtrack(nums, left, right-1, !player,count1,count2+nums[right]);   
                }
        }
        
    }
}