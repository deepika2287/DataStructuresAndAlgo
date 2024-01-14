using System;
using System.Collections.Generic;
namespace LCCloneGraph
{
    class Program
    {
        Dictionary<Node,Node> visited = new Dictionary<Node, Node>();
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        public Node CloneGraph(Node node) {
            if(node==null)
                return node;
            if(visited.ContainsKey(node))
            {
                return visited[node];
            }
            Node clonedNode = new Node(node.val,new List<Node>());
            visited.Add(node,clonedNode);
            foreach(Node n in node.neighbors)
            {
                clonedNode.neighbors.Add(CloneGraph(n));
            }
            return clonedNode;
        }
        
    }
    public class Node {
        public int val;
        public IList<Node> neighbors;

        public Node() {
            val = 0;
            neighbors = new List<Node>();
        }

        public Node(int _val) {
            val = _val;
            neighbors = new List<Node>();
        }

        public Node(int _val, List<Node> _neighbors) {
            val = _val;
            neighbors = _neighbors;
        }
    }
}
