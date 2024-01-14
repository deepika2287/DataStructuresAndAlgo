using System;
using System.Collections.Generic;

namespace LCPopulateNextRightPtr
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Node t1 = new Node(1);
            Node t2 = new Node(2);
            Node t3 = new Node(3);
            Node t4 = new Node(4);
            Node t5 = new Node(5);
            Node t6 = new Node(6);
            Node t7 = new Node(7);
            Node t8 = new Node(8);

            t1.left = t2;
            t1.right = t3;

            t2.left = t4;
            t2.right = t5;

            t3.right = t6;

            t4.left = t7;

            t6.right = t8;

            Node root= new Program().Connect(t1);
        }
        //DFS solution - not working
        public Node Connect(Node root) {
            Node temp = root;
            DFS(temp,null);
            return root;
        }

        public void DFS(Node node, Node root)
        {
            if(root == null)
            {
                node.next = null;
            }
            else
            {
                if(root.left == node)
                {
                    if(root.right != null)
                    {
                        node.next = root.right;
                    }
                    else if(root.next != null)
                    {
                        node.next = FindNextSibling(root);
                    }
                    else
                    {
                        node.next = null;
                    }
                }
                else
                {
                    if(root.next != null)
                    {
                        node.next = FindNextSibling(root);
                    }
                    else
                    {
                        node.next = null;
                    }
                }
            }
            if(node.left != null)
            {
                DFS(node.left, node);
            }
            if(node.right != null)
            {
                DFS(node.right, node);
            }
        }

        public Node FindNextSibling(Node node)
        {
            if(node.next != null)
            {
                if(node.next.left != null)
                    return node.next.left;
                if(node.next.right != null)
                    return node.next.right;
                
                return FindNextSibling(node.next);
            }
            return null;
        }

        //queue solution
        /*public Node Connect(Node root) {
            Queue<Node1> queue = new Queue<Node1>();
            queue.Enqueue(new Node1(root,1));
            while(queue.Count>0)
            {
                Node1 temp = queue.Dequeue();

                if(queue.Count>0 && queue.Peek().level == temp.level)
                {
                    temp.node.next = queue.Peek().node;
                }
                else
                {
                    temp.node.next = null;
                }
                if(temp.node.left != null)
                {
                    queue.Enqueue(new Node1(temp.node.left,temp.level+1));
                }
                if(temp.node.right !=null)
                {
                    queue.Enqueue(new Node1(temp.node.right,temp.level+1));
                }
            }
            return root;
        }

        public class Node1
        {
            public Node node;
            public int level;

            public Node1(Node node, int level)
            {
                this.node = node;
                this.level = level;
            }
        }*/
    }
    public class Node {
        public int val;
        public Node left;
        public Node right;
        public Node next;

        public Node() {}

        public Node(int _val) {
            val = _val;
        }

        public Node(int _val, Node _left, Node _right, Node _next) {
            val = _val;
            left = _left;
            right = _right;
            next = _next;
        }
    }
}
