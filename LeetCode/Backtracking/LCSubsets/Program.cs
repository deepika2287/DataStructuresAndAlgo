namespace LCSubsets;

class Program
{
    static void Main(string[] args)
    {
        int[] nums = [1,2,3];
        Program p = new Program();
        var res = p.Subsets(nums);
        Console.WriteLine("Number of subsets = " + res.Count);
        foreach(var l in res)
        {
            foreach(var i in l)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
    public IList<IList<int>> Subsets(int[] nums) {
        var list = new List<IList<int>>();
        Backtrack(nums, 0, list, new List<int>());
        return list;
    }
    public void Backtrack(int[] nums,int index, List<IList<int>> list, List<int> temp)
    {
        if(index == nums.Length)
        {
            list.Add(new List<int>(temp));
            return;
        }

        Backtrack(nums, index+1,list,temp);

        temp.Add(nums[index]);
        Backtrack(nums,index+1,list,temp);
        temp.RemoveAt(temp.Count-1);
    }
}
