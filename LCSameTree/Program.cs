using System;

namespace LCSameTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            TreeNode n1 = new TreeNode(1);
            TreeNode n2 = new TreeNode(2);
            TreeNode n3 = new TreeNode(3);
            n1.left = n2; n1.right = n3;
            TreeNode n4 = new TreeNode(1);
            TreeNode n5 = new TreeNode(2);
            //TreeNode n6 = new TreeNode(3);
            n4.left = n5; //n4.right = n6;

            bool res = new Program().IsSameTree(n1,n4);
        }
        public bool IsSameTree(TreeNode p, TreeNode q) {
            if(p == null && q ==  null)
                return true;
            if((p == null && q != null) || (p != null && q == null))
                return false;
            
            if(p.val != q.val)
                return false;
            else
            {
                bool l = IsSameTree(p.left,q.left);
                bool r = IsSameTree(p.right,q.right);
                return l&&r;
            }
        }
    }
    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}
