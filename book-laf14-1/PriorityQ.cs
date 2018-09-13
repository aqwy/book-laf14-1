using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace book_laf14_1
{
    class PriorityQ
    {
        private Edge[] queArray;
        private int size;
        private readonly int MAX_SIZE = 20;
        public PriorityQ()
        {
            queArray = new Edge[MAX_SIZE];
            size = 0;
        }
        public void insert(Edge item)
        {
            int j;
            for (j = 0; j < size; j++)
            {
                if (item.distance >= queArray[j].distance)
                    break;
            }
            for (int k = size - 1; k >= 0; k--)
            {
                queArray[k + 1] = queArray[k];
            }
            queArray[j] = item;
            size++;
        }
        public Edge removeMin()
        {
            return queArray[--size];
        }
        public void removeN(int n)
        {
            for (int i = n; i < size - 1; i++)
            {
                queArray[i] = queArray[i + 1];
            }
            size--;
        }
        public Edge peekMin()
        {
            return queArray[size - 1];
        }
        public int getSize()
        {
            return size;
        }
        public bool isEmpty()
        {
            return (size == 0);
        }
        public Edge peekN(int n)
        {
            return queArray[n];
        }
        public int find(int findDex)
        {
            for (int i = 0; i < size; i++)
            {
                if (queArray[i].destVert == findDex)
                    return i;
            }
            return -1;
        }
    }
}
