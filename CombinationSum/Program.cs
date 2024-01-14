using System;
using System.Collections.Generic;
namespace CombinationSum
{
    class Program
    {
        
        IList<IList<int>> res = new List<IList<int>>();
        static void Main(string[] args)
        {
            int[] c = new int[]{10,1,2,7,6,1,5};
            Program p = new Program();
            p.CombinationSum2(c,8);
        }

        public IList<IList<int>> CombinationSum2(int[] candidates, int target) 
        {  
            res = new List<IList<int>>();   
            Array.Sort(candidates);    
            FindNums(candidates,target,0,new List<int>(),0);  
            return res;
        }

        public void FindNums(int[] candidates, int target, int i, List<int> r, int sum)
        {
            if(sum == target)
            {
                    res.Add(new List<int>(r));
             
                return;
            }
            if(sum>target)
            {
                return;
            }

            //     List<int> r= new List<int>();
            for(int j = i;j<candidates.Length;j++)
            {
                if(j > i && candidates[j] == candidates[j-1]) 
                {
                    continue;
                }

                r.Add(candidates[j]);
                FindNums(candidates,target,j+1,r,sum+candidates[j]);
                r.RemoveAt(r.Count-1);

            }
            
        }
    }
}
