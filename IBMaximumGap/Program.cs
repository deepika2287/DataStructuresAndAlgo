using System;
using System.Collections.Generic;
namespace IBMaximumGap
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            List<int> A = new List<int>();
            for(int i = 0;i < n;i++)
            {
                A.Add(Convert.ToInt32(Console.ReadLine()));
            }
            
            Console.WriteLine(maximumGap(A));
            
        }

        public static int maximumGap(List<int> A) {
           int max = 0;
            for(int a = 0; a< A.Count; a++)
            {
                int i = a;
                int j = A.Count-1;
                int res1 = 0;
                while(j>=i)
                {
                    if(A[i]>A[j])
                    {
                        j--;
                    }
                    else{
                        res1 = j-i;
                        break;
                    }
                }
                if(res1>max)
                max = res1;
                
            }
            

            return max;
        }

    }
}
