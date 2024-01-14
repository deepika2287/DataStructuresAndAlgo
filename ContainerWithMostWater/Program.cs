using System;

namespace ContainerWithMostWater
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] height = new int[]{1,8,6,2,5,4,8,3,7};
            Console.WriteLine(new Program().MaxArea(height));
        }
        public  int MaxArea(int[] height) {
            int maxArea = 0;
            int left = 0;
            int right = height.Length-1;

            while(right > left)
            {
                int minHeight = height[left] < height[right]?height[left]:height[right];
                int area = (right-left) * minHeight;
                maxArea = maxArea<area?area:maxArea;
                if(height[left]<height[right])
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }
            
            return maxArea;
        }
    }
}
