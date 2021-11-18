using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pathfinding
{
    class PriorityQueue<T>
    {
        private T[] tree = new T[25];
        private IComparer<T> comparer;
        public int Count { get; private set; }
        public bool IsEmpty() => Count == 0;
        public bool Contains(T item) => tree.Contains(item);


        public PriorityQueue(IComparer<T> comparer)
        {
            this.comparer = comparer ?? Comparer<T>.Default;
            Count = 0;
        }

        public void Enqueue(T value)
        {
            //Increase the count
            //If we reach the capacity of the queue increase it
            Count++;

            if (Count == tree.Length)
            {
                Resize();
            }

       
            tree[Count] = value;

            HeapifyUp(Count);
        }


        public T Dequeue()
        {
        
            Sort();
            T root = tree[1];

            tree[1] = tree[Count];
            tree[Count] = default(T);

            Count--;

            HeapifyDown(1);

            return root;
        }

        
        private void Sort()
        {
            for (int i = Count / 2; i > 0; i--)
            {
                HeapifyDown(i);
            }
        }

       
        private void HeapifyUp(int index)
        {
            int parent = index / 2;

            if (parent < 1 || comparer.Compare(tree[parent], tree[1]) == 0 || comparer.Compare(tree[index], tree[parent]) == 0)
            {
                return;
            }

            if (comparer.Compare(tree[index], tree[parent]) < 0)
            {
                T temp = tree[index];
                tree[index] = tree[parent];
                tree[parent] = temp;
            }

            HeapifyUp(parent);
        }

     
        private void HeapifyDown(int index)
        {
            int leftChild = index * 2;
            int rightChild = index * 2 + 1;

            int swapIndex = 0;


            if (leftChild > Count || rightChild > Count)
            {
                return;
            }

            if (comparer.Compare(tree[leftChild], tree[rightChild]) < 0)
            {
                swapIndex = leftChild;
            }
            else
            {
                swapIndex = rightChild;
            }

    
            if (comparer.Compare(tree[swapIndex], tree[index]) < 0)
            {
                T temp = tree[index];
                tree[index] = tree[swapIndex];
                tree[swapIndex] = temp;
            }

            HeapifyDown(swapIndex);
        }


        private void Resize()
        {
            T[] temp = new T[tree.Length * 2];
            tree.CopyTo(temp, 0);
            tree = temp;
        }


    }
}
