using System;
using System.Collections.Generic;

namespace CloneGraph
{
    class Program
    {
        Dictionary<int, Node> dict = new Dictionary<int, Node>();
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public Node CloneGraph(Node node) 
        {
            if(node==null)
                return null;
            
            Node cloned = Clone(node);

            return cloned;
        }

        public Node Clone(Node node)
        {
            if(dict.ContainsKey(node.val))
            {
                return dict[node.val];
            }
            else
            {
                Node newNode = new Node(node.val);
                dict.Add(node.val,newNode);

                for(int i = 0;i<node.neighbors.Count;i++)
                {
                    newNode.neighbors.Add(Clone(node.neighbors[i]));
                }

                return newNode;
            }
        }

        public class Node 
        {
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
}
