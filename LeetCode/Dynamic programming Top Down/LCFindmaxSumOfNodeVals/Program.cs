namespace LCFindmaxSumOfNodeVals;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
    public long MaximumValueSum(int[] nums, int k, int[][] edges) {
        long[][] DP = new long[nums.Length][];
        for(int i = 0;i<nums.Length;i++)
        {
            DP[i] = new long[2];

            for(int j = 0;j<2;j++)
            {
                DP[i][j] = -1;
            }
        }

        return DFS(nums,k,edges,0,1,DP);
    }

    public long DFS(int[] nums, int k, int[][] edges, int index, int isEven, long[][] DP)
    {
        if(index == nums.Length)
        {
            return isEven == 1 ? 0 : Int32.MinValue;
        }
        if(DP[index][isEven] != -1)
        {
            return DP[index][isEven];
        }

        long val1  = nums[index] + DFS(nums,k,edges,index+1,isEven,DP);

        long val2 = (nums[index]^k) + DFS(nums,k,edges,index+1,isEven^1,DP);

        return DP[index][isEven] = Math.Max(val1,val2);
    }
}
