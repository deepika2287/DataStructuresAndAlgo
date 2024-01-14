using System;
using System.Collections.Generic;
using System.Reflection;

namespace EIO_MaxHeap
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int[] arr = new int[]{5,20,10,40,8,6};
            MaxHeap mh = new MaxHeap();
            mh.BuildHeap(arr);
            mh.PrintHeap();            
        }
    }
    public class MaxHeap
    {
        List<int> h;
        public MaxHeap()
        {
            h = new List<int>();
        }
        public int size()
        {
            return h.Count;
        }
        public int pIdx(int i)
        {
            return (i-1)/2;
        }
        public int lcIdx(int i)
        {
            return (2*i)+1;
        }
        public int rcIdx(int i)
        {
            return (2*i)+2;
        }
        public void Insert(int k)
        {
            h.Add(k);
            int i = size()-1;
            PercolateUp(i);
        }
        public void RemoveMax()
        {
            if(size()==1)
            {
                h.RemoveAt(0);
            }
            if(size()>1)
            {
                int i = size()-1;
                int temp = h[0];
                h[0] = h[i];
                h[i] = temp;
                h.RemoveAt(i);

                MaxHeapify(0);
            }
        }
        public void MaxHeapify(int i)
        {
                int leftChild = lcIdx(i);
                int rightChild = rcIdx(i);
                int iMax = i;

                if(leftChild<size() && h[leftChild]>h[iMax])
                {
                    iMax = leftChild;
                }
                if(rightChild<size() && h[rightChild]>h[iMax])
                {
                    iMax = rightChild;
                }

                if(iMax != i)
                {
                    int temp = h[i];
                    h[i] = h[iMax];
                    h[iMax] = temp;

                    MaxHeapify(iMax);
                }
        }
        public void PercolateUp(int i)
        {
            if(i<=0)
                return;

            if(h[pIdx(i)]<h[i])
            {
                int temp = h[i];
                h[i] = h[pIdx(i)];
                h[pIdx(i)] = temp;

                PercolateUp(pIdx(i));
            }
        }
        public void BuildHeap(int[] arr)
        {
            h.AddRange(arr);
            for(int i=(arr.Length-1)/2;i>=0;i--)
            {
                MaxHeapify(i);
            }
        }

        public void PrintHeap()
        {
            for(int i=0;i<h.Count;i++)
            {
                Console.Write(h[i] + " ");
            }
        }
    }
}
