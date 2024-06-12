namespace LCSumOfAllSubSetsXORTotal;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        int[] nums = [3,4,5,6,7,8];
        Program p = new Program();
        int res = p.SubsetXORSum(nums);
        Console.WriteLine("SubsetXORSum = ", res);
    }
    int sum = 0;
    public int SubsetXORSum(int[] nums) {
        
        BackTrack(nums,0,new List<int>());
        return sum;
    }
    public void BackTrack(int[] nums,int index,List<int> l)
    {
        if(index == nums.Length)
        {
            int xorVal = 0;
            foreach(var v in l)
            {
                xorVal = xorVal ^ v;
            }
            sum = sum+xorVal;

            return;
        }

        BackTrack(nums,index+1,l);

        l.Add(nums[index]);
        BackTrack(nums,index+1,l);
        l.RemoveAt(l.Count-1);
    }
}
