namespace LCCombinationSum2;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        int[] candidates = [4,1,1,4,4,4,4,2,3,5]; 
        int target = 10;
        Program p = new Program();
        var res = p.CombinationSum2(candidates,target);
        Console.WriteLine(res.Count);
    }
    public IList<IList<int>> CombinationSum2(int[] candidates, int target) {
        IList<IList<int>> res = new List<IList<int>>();
        Array.Sort(candidates);
        BackTrack(candidates,target,res,0,0,new List<int>());
        return res;
    }
    public static void BackTrack(int[] candidates, int target, IList<IList<int>> res,int i, int sum, List<int> temp)
    {
        if(sum == target)
        {
            foreach(var l in res)
            {
                if(temp.SequenceEqual(l))
                {
                    return;
                }
            }
            res.Add(new List<int>(temp));
            return;
        }
        if(i == candidates.Length)
        {
            return;
        }
        BackTrack(candidates,target,res,i+1,sum,temp);
        temp.Add(candidates[i]);
        BackTrack(candidates,target,res,i+1,sum+candidates[i],temp);
        temp.RemoveAt(temp.Count-1);
    }
}
