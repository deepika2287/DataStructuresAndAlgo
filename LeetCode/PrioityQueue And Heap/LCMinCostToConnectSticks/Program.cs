// See https://aka.ms/new-console-template for more information
public class Solution {
    public static void Main(string[] args)
    {
        int[] sticks = [2,4,3,5];
        int res= new Solution().ConnectSticks(sticks);
    }
    public int ConnectSticks(int[] sticks) {
        if(sticks.Length<2) return 0;
        
        int res = 0;
        PriorityQueue<int,int> cost = new PriorityQueue<int,int>();
        //SortedList<int,int> cost = new SortedList<int,int>();
        for(int i = 0;i<sticks.Length;i++)
        {
            cost.Enqueue(sticks[i],sticks[i]);
        }
        int idx = sticks.Length;
        while(cost.Count>=2)
        {
            int t1 = cost.Dequeue();
            int t2 = cost.Dequeue();
            int temp = t1 + t2;
            res = res+temp;
            //cost.RemoveAt(0);
            //cost.RemoveAt(0);
            
            cost.Enqueue(temp,temp);
                      
            Console.WriteLine(res);
        }
        
        return res;
    }
}
