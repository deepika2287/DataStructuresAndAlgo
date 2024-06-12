namespace LCSortColor;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        //int[] nums = [2,0,2,1,1,0];
        //int[] nums = [2,0,1];
        int[] nums = [1,0,2,0,1,2];
        Program p = new Program();
        p.SortColors(nums);
        for(int i = 0;i<nums.Length;i++)
        {
            Console.Write(nums[i] + " ");
        }
    }
    public void SortColors(int[] nums) {
        int i = 0;
        int k = 0;
        int j = nums.Length-1;
        while(k<=j)
        {
            if(nums[k] == 2)
            {
                int temp = nums[k];
                nums[k] = nums[j];
                nums[j] = temp;
                j--;
            }
            else if(nums[k] == 0)
            {
                int temp = nums[i];
                nums[i] = nums[k];
                nums[k] = temp;
                i++; k++;
            }
            else
            {
                k++;
            }
            
        }
    }
}
