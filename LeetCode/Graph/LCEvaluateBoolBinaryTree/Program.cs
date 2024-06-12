namespace LCEvaluateBoolBinaryTree;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        TreeNode t1 = new TreeNode(3);
        TreeNode t2 = new TreeNode(1);
        TreeNode t3 = new TreeNode(3);
        TreeNode t4 = new TreeNode(0);
        TreeNode t5 = new TreeNode(1);
        t1.left = t2;
        t1.right = t3;
        t3.left = t4;
        t3.right = t5;

        Program p = new Program();

        Console.WriteLine(p.EvaluateTree(t1));
    }
    public bool EvaluateTree(TreeNode root) {
        int res = DFS(root);
        return res == 0?false:true;
    }
    public static int DFS(TreeNode root) {
        if(root == null)
            return 0;
        
        if(root.val == 0)
        {
            return 0;
        }
        else if(root.val == 1)
        {
            return 1;
        }
        else
        {
            if(root.val == 2)
            {
                int value;
                if((DFS(root.left) == 1 && DFS(root.right) == 1) || (DFS(root.left) == 0 && DFS(root.right) == 1) || (DFS(root.left) == 1 && DFS(root.right) == 0) )
                {
                    value = 1;
                }
                else
                {
                    value = 0;
                }
                root.val = value;
            }
            else
            {
                int value;
                if((DFS(root.left) == 0 && DFS(root.right) == 0) || (DFS(root.left) == 0 && DFS(root.right) == 1) || (DFS(root.left) == 1 && DFS(root.right) == 0) )
                {
                    value = 0;
                }
                else
                {
                    value = 1;
                }
                root.val = value;
            }
            return root.val;
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
