using System;
using System.Collections.Generic;

namespace Graphimplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Graph g = new Graph(4);
            g.AddEdge(0,1);
            g.AddEdge(0,2);
            g.AddEdge(1,3);
            g.AddEdge(2,3);
            //g.PrintGraph();
            BFS_traversal(g);
        }
        public static void BFS_traversal(Graph g)
        {
            bool[] visited = new bool[g.GetVertices()];
            for(int i = 0;i<g.GetVertices();i++)
            {
                if(!visited[i])
                    BFS_Helper(g,visited,i);
            }
        }
        public static void BFS_Helper(Graph g, bool[] visited, int node)
        {
            if(g.GetVertices()<1)
                return;

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(node);
            visited[node] = true;
            int current_node;
            while(queue.Count != 0)
            {
                current_node = queue.Dequeue();
                Console.Write(current_node + ", ");

                LinkedListNode<int> temp = g.GetAdjList()[current_node].First;

                while(temp!=null)
                {
                    if(!visited[temp.Value])
                    {
                        queue.Enqueue(temp.Value);
                        visited[temp.Value] = true;
                    }
                    temp = temp.Next;
                }
            }
        }
    }
    public class Graph{
        LinkedList<int>[] _adj;
        int _vertices;
        public Graph(int vertices)
        {
            _adj = new LinkedList<int>[vertices];
            this._vertices = vertices;
            for(int i = 0; i <vertices;i++)
            {
                _adj[i] = new LinkedList<int>();
            }
        }

        public void PrintGraph()
        {
            for(int i = 0;i<_vertices;i++)
            {
                var temp = _adj[i].First;
                Console.Write(i + "->");
                while(temp!=null)
                {
                    Console.Write(temp.Value + "->");
                    temp = temp.Next;
                }
                Console.WriteLine();
            }
        }
        public void AddEdge(int source, int destination)
        {
            if(source >=0 && source<_vertices && destination>=0 && destination<=_vertices)
            {
                _adj[source].AddFirst(destination);
                _adj[destination].AddFirst(source);
            }
        }

        public LinkedList<int>[] GetAdjList()
        {
            return _adj;
        }
        public int GetVertices()
        {
            return _vertices;
        }
    }
}
