using System;

namespace SortedListToBinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode h1 = new ListNode(3);
            ListNode h2 = new ListNode(5);
            ListNode h3 = new ListNode(8);
            h1.next= h2;
            h2.next = h3;
            Program p = new Program();
            p.SortedListToBST(h1);
            Console.WriteLine("Hello World!");
        }

    public TreeNode SortedListToBST(ListNode head) {
        
        if(head==null)
            return null;
        
        ListNode r = FindMid(head);
        TreeNode root = null;
        if(r.next!=null)
        {
            root = new TreeNode(r.next.val);
            
            ListNode leftList = head;
            
            ListNode rightList = r.next.next;
            
            r.next.next = null;
            r.next = null;
            
            AddChildren(root,leftList,rightList);
        }
        else
        {
            root = new TreeNode(r.val);
        }
        
        return root;
        
    }
    
    public void AddChildren(TreeNode root, ListNode leftHead, ListNode rightHead)
    {
        if(leftHead == null && rightHead == null)
            return;
        
        if(leftHead!=null)
        {
            ListNode lMid = FindMid(leftHead);
            if(lMid.next!=null)
            {
                TreeNode l = new TreeNode(lMid.next.val);
                root.left = l;
                ListNode lLH = leftHead;
                ListNode lRH = lMid.next.next;
                lMid.next.next = null;
                lMid.next = null;
                AddChildren(root.left,lLH,lRH);
            }
            else
            {
                TreeNode l = new TreeNode(lMid.val);
                root.left = l;
                
            }
        }
        if(rightHead!=null)
        {
            ListNode rMid = FindMid(rightHead);
            if(rMid.next!=null)
            {
                TreeNode r = new TreeNode(rMid.next.val);
                root.right = r;
                ListNode rLH = rightHead;
                ListNode rRH = rMid.next.next;
                rMid.next.next = null;
                rMid.next = null;
                AddChildren(root.right,rLH,rRH);
            }
            else
            {
                TreeNode r = new TreeNode(rMid.val);
                root.right = r;
               
            }
        }
    }
    
    public ListNode FindMid(ListNode head)
    {
        ListNode n1 = head;
        ListNode n2 = head;
        ListNode n3 = n2;
        
        while(n1!=null && n1.next!=null)
        {
            n1 = n1.next.next;
            n3 = n2;
            n2 = n2.next;           
        }        
        
        return n3;
    }

    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int val=0, ListNode next=null) {
            this.val = val;
            this.next = next;
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
}
