using System;

namespace LCPlusOne
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int[] digits = new int[]{9,9,9};

            new Program().PlusOne(digits);
        }

        public int[] PlusOne(int[] digits) {
            int[] res;
            int n = digits.Length - 1;
            int sum = digits[n] + 1;
            int carry = sum/10;
            int num = sum%10;
            
            if(carry>0)
            {
                while(carry>0 && n>0)
                {
                    digits[n] = 0;
                    sum = digits[n-1] + 1;
                    carry = sum/10;
                    n--;
                }
                if(carry>0)
                {
                    res = new int[digits.Length+1];
                    res[0] = 1;
                    digits[0] = 0;
                    for(int j = 1;j<res.Length;j++)
                    {
                        res[j] = digits[j-1];
                    }
                    return res;
                }
                else
                {
                    digits[n] = digits[n]+1;
                }
            }
            else
            {
                digits[n] = sum;
                return digits;
            }
            return digits;
        }
    }
}
