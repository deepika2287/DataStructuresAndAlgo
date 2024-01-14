using System;
using System.Linq;
using System.Text;

namespace LCMultiplyStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            Console.WriteLine(new Program().Multiply("123","456"));
        }
        public string Multiply(string num1, string num2) {
            char[] res = new char[num1.Length + num2.Length];
            for(int i = 0;i<res.Length;i++)
                res[i] = '0' ;
            
            char[] n1;
            char[] n2;
            if(num1.Length >= num2.Length)
            {
                n1 = num1.Reverse().ToArray<char>();
                n2 = num2.Reverse().ToArray<char>();                 
            }
            else
            {
                n2 = num1.Reverse().ToArray<char>();
                n1 = num2.Reverse().ToArray<char>();
            }
            
            int len = 0;
            while(len<n2.Length)
            {
                int carry = 0;
                int n3 = 0;
                //StringBuilder s = new StringBuilder();
                char[] s = new char[n1.Length+1];
                for(int i = 0;i<s.Length;i++)
                    s[i] = '0' ;
                for(int i = 0;i<n1.Length;i++)
                {
                    int num = (n2[len] - '0') * (n1[i] - '0') + carry;
                    n3 = num%10;
                    carry = num/10;
                    //res[i+len] = (char)((res[i+len] - '0') + n3);
                    //s = s.Append(n3);
                    s[i] = n3.ToString()[0];
                }
                if(carry>0)
                {
                    s[s.Length -1] = carry.ToString()[0];
                    //s.Append(carry);
                }
                carry = 0;
                //int tempLen = len;
                //Console.WriteLine(s);
                for(int i = 0;i<s.Length;i++)
                {
                    int sum = s[i] - '0' + res[i+len] - '0' + carry;
                    res[i+len] = (sum%10).ToString()[0];
                    carry = sum/10;
                }
                if(carry > 0)
                {
                    res[s.Length+len] = carry.ToString()[0];
                }
                len++;
            }
            //StringBuilder result = new StringBuilder();
            int idx = res.Length-1;
            while(idx > 0)
            {
                if(res[idx] == '0')
                {
                    idx--;
                }
                else
                {
                    break;
                }
            }
            char[] result = new char[idx+1];
            for(int i = idx;i>=0;i--)
            {
                result[idx-i] = res[i];
            }
                
            return new string(result);
        }
    }
}
