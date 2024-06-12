using System;
using System.Collections.Generic;
using System.Linq;

namespace LCCOmbinationSum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //int[] arr = new int[]{2,3,6,7};
            int[] arr = new int[]{2};
            var ans = new Program().CombinationSum(arr,1);
        }

        public IList<IList<int>> CombinationSum(int[] candidates, int target) {
            IList<IList<int>> ans = new List<IList<int>>();
            List<int> l = new List<int>();
            for(int i = 0;i<candidates.Length;i++)
            {
                l.Add(candidates[i]);
                BackTrack(ans,candidates,target,l,i);
                l.RemoveAt(l.Count-1);
            }
            return ans;
        }
        public void BackTrack(IList<IList<int>> ans,int[] candidates,int target, List<int> l,int i)
        {
            if(l.Sum() == target)
            {
                ans.Add(new List<int>(l));
                return;
            }
            if(l.Sum()>target)
            {
                return;
            }
            for(int j = i;j<candidates.Length;j++)
            {
                l.Add(candidates[j]);
                BackTrack(ans,candidates,target,l,j);
                l.RemoveAt(l.Count-1);
            }
        }
    }
}
