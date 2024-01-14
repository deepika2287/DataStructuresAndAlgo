using System;
using System.Collections.Generic;

namespace EIO_ShortestPathBtwTwoVertices
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            Graph g = new Graph(6);
            g.AddEdge(0,1);
            g.AddEdge(0,2);
            g.AddEdge(0,3);
            g.AddEdge(3,5);
            g.AddEdge(5,4);
            //g.AddEdge(2,4);

            int distance = GetShortestPath(g,0,4);
            Console.WriteLine(distance);
        }

        public static int GetShortestPath(Graph g,int source,int destination)
        {
            if(source == destination)
                return 0;

            bool[] visited = new bool[g.GetVertices()];
            int[] distance = new int[g.GetVertices()];

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(source);
            visited[source] = true;
            int current_node;
            LinkedListNode<int> temp;

            while(queue.Count>0)
            {
                current_node = queue.Dequeue();
                temp = g.GetAdjList()[current_node].First;
                while(temp!=null)
                {
                    if(!visited[temp.Value])
                    {
                        visited[temp.Value] = true;
                        distance[temp.Value] = distance[current_node] + 1;
                        queue.Enqueue(temp.Value); 
                    }
                    if(temp.Value == destination)
                        return distance[destination];

                    temp = temp.Next;
                }
            }

            return -1;
        }
    }
    public class Graph
    {
        int _vertices;
        LinkedList<int>[] _adj;
        public Graph(int v)
        {
            _vertices = v;
            _adj = new LinkedList<int>[v];
            for(int j = 0;j<v;j++)
            {
                _adj[j] = new LinkedList<int>();
            }  
        }
        public void AddEdge(int source, int destination)
        {
            if(source < _vertices && destination < _vertices && source>=0 && destination>= 0) 
            {
                _adj[source].AddFirst(destination);
            }       
        }
        public int GetVertices()
        {
            return _vertices;
        }
        public LinkedList<int>[] GetAdjList()
        {
            return _adj;
        }
    }
}
