namespace LCHouseRobber3;

class Program
{
    static void Main(string[] args)
    {
        TreeNode t1 = new TreeNode(3);
        TreeNode t2 = new TreeNode(4);
        TreeNode t3 = new TreeNode(5);
        TreeNode t4 = new TreeNode(1);
        TreeNode t5 = new TreeNode(3);
        TreeNode t6 = new TreeNode(1);
        t1.left = t2;
        t1.right = t3;
        t2.left = t4;
        t2.right = t5;
        t3.right = t6;

        Program p = new Program();
        Console.WriteLine(p.Rob(t1));
    }
    public int Rob(TreeNode root) {
        SubTree t = RecursiveHelper(root);
        return Math.Max(t.withValue,t.withoutValue);
    }
    public SubTree RecursiveHelper(TreeNode root)
    {
        if(root == null)
        {
            return new SubTree(0,0);
        }

        SubTree left = RecursiveHelper(root.left);
        SubTree right = RecursiveHelper(root.right);
        
        int includeRoot = root.val + left.withoutValue + right.withoutValue;
        int excludeRoot = Math.Max(left.withValue,left.withoutValue) + Math.Max(right.withValue,right.withoutValue);
        
        return new SubTree(includeRoot,excludeRoot);
    }
}
public class SubTree
{
    public int withValue;
    public int withoutValue;
    public SubTree(int a,int b)
    {
        withValue = a;
        withoutValue = b;
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
