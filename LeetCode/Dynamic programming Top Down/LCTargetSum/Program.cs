namespace LCTargetSum;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        int[] nums = new int[]{1,1,1}; int target = 1;
        Program p = new Program();
        Console.WriteLine(p.FindTargetSumWays(nums,target));
    }
    
    public int FindTargetSumWays(int[] nums, int target) {
        int total = 0;
        for(int i = 0;i<nums.Length;i++)
        {
            total += nums[i];
        }
        int[][] DP = new int[nums.Length][];
        int numPosSum = (2*total) + 1; 
        for(int i = 0;i<nums.Length;i++)
        {
            DP[i] = new int[numPosSum];
            for(int j=0;j<numPosSum;j++)
            {
                DP[i][j] = -1;
            }
        }
        BackTrack(nums, target, total, 0,0,DP);
        
        return DP[0][total];
    }
    private static int BackTrack(int[] nums, int target, int total, int i, int sum, int[][] DP)
    {
        if(i>=nums.Length) {
            if(sum == target)
                return 1;
            else
                return 0;
        }
        if(DP[i][sum+total]!=-1)
            return DP[i][sum+total];

        DP[i][sum+total] = BackTrack(nums, target, total, i+1, sum+nums[i],DP) + BackTrack(nums, target,total, i+1, sum-nums[i],DP);

        int numPosSum = (2*total) + 1; 
        for(int a = 0;a<nums.Length;a++)
        {
            for(int j=0;j<numPosSum;j++)
            {
                Console.Write(DP[a][j] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        return DP[i][sum+total];
    }
    /*public int FindTargetSumWays(int[] nums, int target) {
        return BackTrack(nums, 0, 0, target);
    }
    static int BackTrack(int[] nums,int i, int sum, int target) {
        if(i>=nums.Length) {
            if(sum == target)
                return 1;
            else
                return 0;
        }

        return BackTrack(nums,i+1,sum+nums[i],target) + BackTrack(nums,i+1,sum-nums[i],target);
    }*/
}
