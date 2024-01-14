using System;
using System.Collections.Generic;
using System.Linq;

namespace LCWordLadder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string beginWord = "hit";
            string endWord = "cog";
            string[] wordList = new string[]{"hot","dot","dog","lot","log","cog"};
            int res = new Program().LadderLength(beginWord,endWord,wordList);
        }
        public int LadderLength(string beginWord, string endWord, IList<string> wordList) {
            if(!wordList.Contains(endWord))
                return 0;
            Dictionary<string,List<string>> dict = new Dictionary<string, List<string>>();
            for(int i = 0;i<wordList.Count;i++)
            {
                string s = wordList[i];
                for(int j = 0;j<beginWord.Length;j++)
                {
                    string key = s.Substring(0,j) + '*' + s.Substring(j+1);
                    if(!dict.ContainsKey(key))
                    {
                        dict.Add(key,new List<string>());
                    }
                    dict[key].Add(s);
                }
            }
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(new Node(beginWord,1));
            List<string> visited = new List<string>();
            visited.Add(beginWord);
            while(q.Count>0)
            {
                Node node = q.Dequeue();
                if(node.value == endWord)
                    return node.level;
                
                for(int i = 0;i<node.value.Length;i++)
                {
                    string s = node.value.Substring(0,i) + '*' + node.value.Substring(i+1);
                    if(dict.ContainsKey(s))
                    {
                        List<string> l = dict[s];
                        foreach(string str in l)
                        {
                            if(!visited.Contains(str))
                            {
                                visited.Add(str);
                                q.Enqueue(new Node(str,node.level+1));
                            }
                        }
                    }
                }
            }
            return 0;
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
