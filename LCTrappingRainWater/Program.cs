using System;

namespace LCTrappingRainWater
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int[] height = new int[]{0,1,0,2,1,0,1,3,2,1,2,1};
            Console.WriteLine(new Program().Trap(height));
        }
        public int Trap(int[] height) {
            int max = 0;
            int maxIdx = 0;
            for(int i = 0;i<height.Length;i++)
            {
                if(max<height[i])
                {
                    max = height[i];
                    maxIdx = i;
                }
            }
            int res = 0;
            max = 0;
            for(int i = 0;i<maxIdx;i++)
            {
                res = res + Math.Max(0,max-height[i]);
                if(max<height[i])
                    max = height[i];
            }
            max = 0;
            for(int i = height.Length-1;i>maxIdx;i--)
            {
                res = res + Math.Max(0,max-height[i]);
                if(max<height[i])
                    max = height[i];
            }

            return res;
        }
    }
}
