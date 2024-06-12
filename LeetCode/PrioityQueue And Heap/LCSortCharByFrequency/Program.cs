using System.Text;

namespace LCSortCharByFrequency;

class Program
{
    static void Main(string[] args)
    {
        string s = "Aabb";
        Program p = new Program();
        string res = p.FrequencySortUsingDict(s);
        Console.WriteLine(res);
    }
    
    public string FrequencySortUsingDict(string s)
    {
        Dictionary<char,int> dict = new Dictionary<char,int>();
        for(int i = 0; i < s.Length; i++)
        {
            if(dict.ContainsKey(s[i]))
            {
                dict[s[i]]++;
            }
            else
            {
                dict.Add(s[i],1);
            }
        }
        dict = dict.OrderByDescending(x=>x.Value).ToDictionary();
        StringBuilder res = new StringBuilder();
        for(int i = 0; i < dict.Count;i++)
        {
            StringBuilder st = new StringBuilder();
            for(int j = 0; j < dict.ElementAt(i).Value; j++)
            {
                st = st.Append(dict.ElementAt(i).Key);
            }
            res = res.Append(st);
        }
        return res.ToString();
    }
    public string FrequencySort(string s) {
        int[][] arr = new int[75][];
        for(int i = 0;i<75;i++)
        {
            arr[i] = new int[2];
            arr[i][0] = i;
            arr[i][1] = 0;
        }
        for(int i=0;i<s.Length;i++ )
        {
            int index = s[i] - '0';
            arr[index][1]++;
        }
        int N = 75;
        for(int i = (N-1)/2;i>=0;i--)
        {
            Heapify(arr,N,i);
        } 
        for(int i = 0;i<N;i++)
        {
            var temp = arr[0];
            arr[0] = arr[N-i-1];
            arr[N-i-1] = temp;
            Heapify(arr,N-i-1,0);
        }
        string res = "";
        for(int i = N-1;i>=0;i--)
        {
            if(arr[i][1]>0)
            {
                string st = "";
                char temp = (char)(arr[i][0] + (int)'0');
                for(int j = 0;j<arr[i][1];j++)
                {
                    st = st + temp;
                }
                res = res + st;
            }
            else
            {
                break;
            }
        }
        return res;  
    }
    public static void Heapify(int[][] arr, int n, int i)
        {
            int parent = i;
            int leftchild = (2*i)+1;
            int rightchild = (2*i)+2;

            if(leftchild<n && arr[leftchild][1] > arr[parent][1])
            {
                parent = leftchild;
            }
            if(rightchild<n && arr[rightchild][1] > arr[parent][1])
            {
                parent = rightchild;
            }

            if(parent!=i)
            {
                var temp = arr[i];
                arr[i] = arr[parent];
                arr[parent] = temp;
                Heapify(arr,n,parent);
            }
        }
}
