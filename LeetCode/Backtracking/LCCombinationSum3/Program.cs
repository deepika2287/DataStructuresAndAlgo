namespace LCCombinationSum3;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Program p = new Program();
        var res = p.CombinationSum3(3,9);
        foreach(var v in res)
        {
            foreach(var i in v)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
    public IList<IList<int>> CombinationSum3(int k, int n) {
        IList<IList<int>> res = new List<IList<int>>();
        BackTrack(k,n,new List<int>(),res,1);
        return res;
    }
    static void BackTrack(int k,int n,List<int> temp,IList<IList<int>> res,int i)
    {
        if(n==0 && temp.Count==k)
        {
            res.Add(new List<int>(temp));
            return;
        }
        if(n<0 || temp.Count == k)
        {
            return;
        }
        for(int j = i;j<10;j++)
        {
            temp.Add(j);
            BackTrack(k,n-j,temp,res,j+1);
            temp.RemoveAt(temp.Count-1);
        }
    }

    //exclude and include method
    /*static void BackTrack(int k,int n,List<int> temp,IList<IList<int>> res,int i)
    {
        if(n==0 && temp.Count==k)
        {
            res.Add(new List<int>(temp));
            return;
        }
        if(i>9 || temp.Count == k)
        {
            return;
        }
        
        BackTrack(k,n,temp,res,i+1);
        if(n-i>=0)
        {
            temp.Add(i);
            BackTrack(k,n-i,temp,res,i+1);
            temp.RemoveAt(temp.Count-1);
        }
    }*/
}
