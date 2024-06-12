using System.Diagnostics.Tracing;

namespace LCDeleteLeafNodesWithTargetValue;

class Program
{
    static void Main(string[] args)
    {
        /*TreeNode t1 = new TreeNode(1);
        TreeNode t2 = new TreeNode(2);
        TreeNode t3 = new TreeNode(3);
        TreeNode t4 = new TreeNode(2);
        TreeNode t5 = new TreeNode(2);
        TreeNode t6 = new TreeNode(4);
        t1.left = t2;
        t1.right = t3;
        t2.left = t4;
        t3.left = t5;
        t3.right = t6;*/

        /*TreeNode t1 = new TreeNode(1);
        TreeNode t2 = new TreeNode(1);
        TreeNode t3 = new TreeNode(1);*/

        TreeNode t1 = new TreeNode(3);
        TreeNode t2 = new TreeNode(3);
        TreeNode t3 = new TreeNode(6);
        TreeNode t4 = new TreeNode(6);
        TreeNode t5 = new TreeNode(3);
        TreeNode t6 = new TreeNode(5);
        t1.left = t2;
        t1.right = t3;
        t2.left = t4;
        t2.right = t5;
        t3.left = t6;

        Program p = new Program();
        var res = p.RemoveLeafNodes(t1,3);
    }

    public TreeNode RemoveLeafNodes(TreeNode root, int target) {
        if(root == null)
            return null;
        
        while(LeafNodeWithtarget(root,target))
        {
            if(root != null && root.left == null && root.right == null && root.val == target)
            {
                return null;
            }
            DFS(root.left,root.right,root,target);
        }
        return root;
    }
    
    public void DFS(TreeNode lnode, TreeNode rnode, TreeNode parent, int target)
    {
        if(lnode!= null && lnode.left == null && lnode.right == null && lnode.val == target)
        {
            parent.left = null;
        }
        if(rnode != null && rnode.left == null && rnode.right == null && rnode.val == target)
        {
            parent.right = null;
        }

        if(parent.left != null)
            DFS(lnode.left,lnode.right,lnode,target);
        if(parent.right != null)
            DFS(rnode.left,rnode.right,rnode,target);
    }
    
    public bool LeafNodeWithtarget(TreeNode node, int target) {
        if(node!= null && node.left == null && node.right == null && node.val == target)
            return true;
        
        bool val1=false; bool val2=false;
        if(node!= null && node.left != null)
        val1 =  LeafNodeWithtarget(node.left,target);

        if(node!= null && node.right != null)
        val2 =  LeafNodeWithtarget(node.right,target);

        return val1 || val2;
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
