namespace LCMinNumOfRefuelingStops;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        int target = 100;
        int startFuel = 10;
        int[][] stations = [[10,60],[20,30],[30,30],[60,40]];
        Program p = new Program();
        int res = p.MinRefuelStops(target,startFuel,stations);
        Console.WriteLine(res);
    }
    int minStops;
    public int MinRefuelStops(int target, int startFuel, int[][] stations) {
        int n = stations.Length;
        // Initialize an array to store the maximum distance that can be travelled
        // for each number of refuelling stops.
        int[][] memo = new int[n+1][];
        for(int i = 0;i<n+1;i++)
        {
            memo[i] = new int[n+1];
            for(int j = 0;j<n+1;j++)
            {
                memo[i][j] = -1;
            }
        }
        // Find the maximum distance that can be travelled for each number of refuelling stops.
        for(int i = 0; i <= n; i++)
             minRefuelStopsHelper(n, i, startFuel, stations,memo);
        int result = -1;
        // Find the minimum number of refuelling stops needed by iterating over maxD
        // and finding the first value that is greater than or equal to the target distance.
        /*for(int i = 0;i<maxD.Length;i++)
        {
            Console.Write(maxD[i] + " ");
        }*/
        for(int i = 0; i <= n; i++) {
            if(memo[n][i] >= target){
                result = i;
                break;
            } 
        }
        return result;
    }
    public int minRefuelStopsHelper(int index, int used, int curFuel, int[][] stations,int[][] memo)
    {
        
        if(used==0)
        {
            memo[index][used] = curFuel;
            return memo[index][used];
        }
        if(used>index)
        {
            memo[index][used] = int.MinValue;
            return memo[index][used];
        }
        if(memo[index][used]!=-1)
        {
            return memo[index][used];
        }
        int result1 = minRefuelStopsHelper(index-1,used,curFuel,stations,memo);

        int result2 = minRefuelStopsHelper(index-1,used-1,curFuel,stations,memo);

        return memo[index][used] =  Math.Max(result1, result2<stations[index-1][0]?int.MinValue:result2+stations[index-1][1]);
        
    }
}
