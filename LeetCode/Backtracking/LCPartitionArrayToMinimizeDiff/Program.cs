namespace LCPartitionArrayToMinimizeDiff;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        int[] nums = [2,-1,0,4,-2,-9];
        //int[] nums = [-32,32];
        //int[] nums = [3,9,7,3];
        Program p = new Program();
        Console.WriteLine(p.MinimumDifference(nums));
    }
    int minDiff = Int32.MaxValue;
    public int MinimumDifference(int[] nums) {
        List<int> temp = new List<int>();
        int totalSum = 0;
        for(int i = 0;i<nums.Length;i++)
        {
            totalSum = totalSum + nums[i];
        }
        Backtrack(nums,0,0,0,temp);
        for(int i=0; i<=temp.Count/2; i++) 
            minDiff=Math.Min(minDiff, Math.Abs(totalSum-temp[i]-temp[i]));
        return minDiff;
    }
    public void Backtrack(int[] nums,int i,int l, int sum, List<int> temp)
    {
        if(l == nums.Length/2 )
        {
            temp.Add(sum);
            return;
        }

        if(i >= nums.Length)
            return;
        
        Backtrack(nums,i+1,l+1,sum+nums[i],temp);

        Backtrack(nums,i+1,l,sum,temp);        
    }
    public int FindSum(int[] nums,List<(int,int)> temp)
    {
        int sum = 0;
        for(int i = 0; i < nums.Length;i++)
        {
            if(!temp.Contains((i,nums[i])))
            {
                sum = sum + nums[i];
            }
        }
        return sum;
    }
    
}
// below solution is not getting time out
// https://leetcode.com/problems/partition-array-into-two-arrays-to-minimize-sum-difference/solutions/3213827/java-eli5-explanation-meet-in-the-middle-two-pointer
