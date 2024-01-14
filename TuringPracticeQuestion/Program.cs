using System;
using System.Collections.Generic;
using System.Linq;
namespace TuringPracticeQuestion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //string[] ops = new string[]{"5","2","C","D","+"};
            //string animals = "dog cat donkey cat donkey monkey donkey pig";
            //string[] f = new string[2]{"donkey","cat"};
            int[] k = new int[]{3,0,1,1,9,7};
            int output = new Program().Solution(k,7,2,3);
            Console.WriteLine(output);
        }

        public int Solution(int[] k, int x, int y, int z)
        {
            int count = 0;
            for(int i = 0;i<k.Length-2;i++)
            {
                for(int j=i+1;j<k.Length-1;j++)
                {
                    for(int n=j+1;n<k.Length;n++)
                    {
                        if( Math.Abs(k[i]-k[j]) <= x && Math.Abs(k[j]-k[n])<=y && Math.Abs(k[i]-k[n])<=z)
                        {
                            count++;
                            Console.WriteLine(k[i] + "," + k[j] + "," + k[n]);
                        }
                    }
                }
            }
            return count;
        }
       /* public string Solution(string animals, string[] f)
        {
            //string res = "";
            List<string> input = animals.ToLower().Split(' ').ToList();
            List<string> forbidden = f.ToList();
            input.Sort();
            int count = 0;
            int maxCount = 0;
            int index = 0;
            for(int i = 1;i<input.Count;i++)
            {
                if(input[i] == input[i-1] && !forbidden.Contains(input[i]))
                {
                    count++;
                }
                else
                {
                    count = 0;
                }
                if(maxCount<=count)
                {
                    maxCount = count;
                    index = i;
                }
            }
            return input[index];
        }*/
    }
}
