// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
public class Solution {
    public int LeastInterval(char[] tasks, int n) {
        Dictionary<char,int> dict = new Dictionary<char, int>();
        
        for(int i=0;i<tasks.Length;i++)
        {
            if(!dict.ContainsKey(tasks[i]))
            {
                dict.Add(tasks[i],1);
            }
            else
            {
                dict[tasks[i]]++;
            }
        }
        PriorityQueue<int,int> pq = new PriorityQueue<int, int>();
        foreach(var d in dict)
        {
            pq.Enqueue(d.Value,d.Value);
        }
        int cpuCycles = 0;
        while(pq.Count>0)
        {
            var item = pq.Dequeue();
            if(item>2)
            {
                item--;
                pq.Enqueue(item,item);
            }
            cpuCycles++;
        }
        return cpuCycles;
    }
}