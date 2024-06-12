using System;
using System.Collections.Generic;
using System.Linq;
namespace LCSnakesAndLadders
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int[][] board = new int[6][];
            //[[-1,-1,-1,-1,-1,-1],
            // [-1,-1,-1,-1,-1,-1],
            // [-1,-1,-1,-1,-1,-1],
            // [-1,35,-1,-1,13,-1],
            // [-1,-1,-1,-1,-1,-1],
            // [-1,15,-1,-1,-1,-1]]
            /*board[0] = new int[6]{-1,-1,-1,-1,-1,-1};
            board[1] = new int[6]{-1,-1,-1,-1,-1,-1};
            board[2] = new int[6]{-1,-1,-1,-1,-1,-1};
            board[3] = new int[6]{-1,35,-1,-1,13,-1};
            board[4] = new int[6]{-1,-1,-1,-1,-1,-1};
            board[5] = new int[6]{-1,15,-1,-1,-1,-1};*/
            board[0] = new int[6]{-1,-1,30,14,15,-1};
            board[1] = new int[6]{23,9,-1,-1,-1,9};
            board[2] = new int[6]{12,5,7,24,-1,30};
            board[3] = new int[6]{10,-1,-1,-1,25,17};
            board[4] = new int[6]{32,-1,28,-1,-1,32};
            board[5] = new int[6]{-1,-1,23,-1,13,19};
            
           /* int[][] board = new int[4][];
            board[0] = new int[4]{-1,1,2,-1};
            board[1] = new int[4]{2,13,15,-1};
            board[2] = new int[4]{-1,10,-1,-1};
            board[3] = new int[4]{-1,6,2,8};
            //[[-1,1,2,-1],[2,13,15,-1],[-1,10,-1,-1],[-1,6,2,8]]
            int[][] board = new int[3][];
            board[0] = new int[3]{-1,4,-1};
            board[1] = new int[3]{6,2,6};
            board[2] = new int[3]{-1,3,-1};
            int[][] board = new int[5][];
            board[0] = new int[5]{-1,15,9,1,-1};
            board[1] = new int[5]{-1,-1,10,5,19};
            board[2] = new int[5]{18,-1,23,9,-1};
            board[3] = new int[5]{1,13,-1,16,20};
            board[4] = new int[5]{-1,10,10,25,13};*/
        
            int ans  = new Program().SnakesAndLadders(board);
        }

        public int SnakesAndLadders(int[][] board) {
            int res = -1;
            int len = board.Length;
            int minMoves = len*len;
            Dictionary<int,List<int>> graph = new Dictionary<int, List<int>>();
            for(int i = 1;i<=minMoves;i++)
            {
                graph.Add(i,new List<int>());
            }
            bool flag = true;
            int n = 1;
            for(int i=len-1;i>=0;i--)
            {
                if(flag)
                {
                    for(int j = 0;j<len;j++)
                    {
                        if(board[i][j] != -1)
                        {
                            graph[n].Add(board[i][j]);
                        }
                        n++;
                    }
                    flag = !flag;
                }
                else
                {
                    for(int j = len-1;j>=0;j--)
                    {
                        if(board[i][j] != -1)
                        {
                            graph[n].Add(board[i][j]);
                        }
                        n++;
                    }
                    flag = !flag;
                }
            }
            //print the graph
            foreach(var n1 in graph)
            {
                Console.Write(n1.Key + "->");
                foreach(var n2 in n1.Value)
                {
                    Console.Write(n2 + "->");
                }
                Console.WriteLine();
            }
            //flatten the graph
            List<int> l = new List<int>();
            for(int i = 1;i<=minMoves;i++)
            {
                if(graph[i].Count != 0)
                {
                    int j = i;
                    while(graph[j].Count>0 && !l.Contains(j) )
                    {
                        l.Add(j);
                        j = graph[j][0];
                    }
                    graph[i][0] = j;
                    l.Clear();
                }
            }
            for(int i = 1;i<=minMoves;i++)
            {
                if(graph[i].Count == 0)
                {
                    for(int j = 1;j<=6;j++)
                    {
                        if(i+j<=minMoves)
                        {
                            if(graph[i+j].Count > 0)
                            {
                                if(!graph[i].Contains(graph[i+j][0]))
                                    graph[i].AddRange(graph[i+j]);
                            }
                            else
                            {
                                if(!graph[i].Contains(i+j))
                                    graph[i].Add(i+j);
                            }
                        }
                    }
                }
            }
            Console.WriteLine("-----------------------------");
            foreach(var n1 in graph)
            {
                Console.Write(n1.Key + "->");
                foreach(var n2 in n1.Value)
                {
                    Console.Write(n2 + "->");
                }
                Console.WriteLine();
            }
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(new Node()
            {
                value = 1,
                distance = 0
            });
            bool[] visited = new bool[minMoves+1];
            visited[1] = true;
            while(q.Count>0)
            {
                Node currNode = q.Dequeue();
                if(currNode.value == minMoves)
                {
                    res = currNode.distance;
                    break;
                }
                foreach(int neighbour in graph[currNode.value])
                {
                    if(!visited[neighbour] && neighbour != currNode.value)
                    {
                        q.Enqueue(new Node()
                        {
                            value = neighbour,
                            distance = currNode.distance+1
                        });
                    }
                    visited[neighbour] = true;
                }
            }
            return res;
        }
        public class Node
        {
            public int value;
            public int distance;
        }
    }
}
