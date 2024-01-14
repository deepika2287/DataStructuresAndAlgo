using System;

namespace LCLinkedListAddNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ListNode l1 = new ListNode(2);
            ListNode l2 = new ListNode(4);
            ListNode l3 = new ListNode(3);
            l1.next = l2;
            l2.next = l3;

            ListNode l4 = new ListNode(5);
            ListNode l5 = new ListNode(6);
            ListNode l6 = new ListNode(4);
            l4.next = l5;
            l5.next = l6;

            ListNode l7 = new Program().AddTwoNumbers(l1,l4);
            while(l7!=null)
            {
                Console.Write(l7.val + ", ");
                l7=l7.next;
            }
        }

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
            ListNode result = null;
            ListNode temp = null;
            int carryover = 0;
            int sum =0;
            while(l1 != null || l2 != null)
            {
                if(l1!=null && l2!=null)
                {
                    sum = l1.val+l2.val+carryover;
                }
                else if(l1 == null)
                {
                    sum = l2.val+carryover;
                }
                else if(l2 == null)
                {
                    sum = l1.val+carryover;
                }
                
                if(sum > 9)
                {
                    carryover = 1;
                    sum = sum-10;
                }
                else{
                    carryover = 0;
                }
                ListNode l = new ListNode(sum);
                if(result == null && temp == null)
                {
                    result = l;
                    temp = l;
                }
                else{
                    temp.next = l;
                    temp = temp.next;
                }
                if(l1!=null)
                    l1=l1.next;
                if(l2!=null)
                    l2=l2.next;
            }
            if(carryover == 1)
            {
                ListNode l = new ListNode(1);
                temp.next = l;
            }
            return result;
        }
 
    }
    public class ListNode {
      public int val;
      public ListNode next;
      public ListNode(int val=0, ListNode next=null) {
          this.val = val;
          this.next = next;
      }
    }
}
