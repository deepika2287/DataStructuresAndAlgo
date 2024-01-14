using System;
using System.Collections.Generic;
using System.Linq;

namespace LCMinGenMutation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string startGene = "AACCGGTT";
            string endGene = "AACCGCTA";
            string[] bank = new string[]{"AACCGGTA","AACCGCTA","AAACGGTA"};
            int res = new Program().MinMutation(startGene,endGene,bank);
        }
        public int MinMutation(string startGene, string endGene, string[] bank) {
            Queue<Node> queue = new Queue<Node>();
            List<string> visited = new List<string>();
            queue.Enqueue(new Node(startGene,0));
            visited.Add(startGene);
            char[] chars = new char[4]{'A','C','G','T'};
            while(queue.Count > 0)
            {
                Node s = queue.Dequeue();
                if(s.value == endGene)
                    return s.level;
                for(int i = 0;i<startGene.Length;i++)
                {
                    for(int j = 0;j<4;j++)
                    {
                        string next = s.value.Substring(0,i) + chars[j] + s.value.Substring(i+1);
                        if(bank.Contains(next) && !visited.Contains(next))
                        {
                            queue.Enqueue(new Node(next,s.level+1));
                            visited.Add(next);
                        }
                    }
                }
            }
            return -1;
        }
        public class Node
        {
            public string value;
            public int level;
            public Node(string s, int l)
            {
                value = s;
                level = l;
            }
        }
    }
}
