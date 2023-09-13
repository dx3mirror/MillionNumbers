using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Миллион_наименьших_чисел
{
    class Program
    {
        public class MinHeap
        {
            private int[] _heap;
            private int _size;

            public MinHeap(int[] arr)
            {
                _heap = new int[arr.Length];
                _size = 0;

                foreach (int num in arr)
                {
                    Add(num);
                }
            }

            public void Add(int num)
            {
                _heap[_size] = num;
                HeapifyUp(_size);
                _size++;
            }

            public int RemoveMin()
            {
                if (_size == 0)
                {
                    throw new InvalidOperationException("Heap is empty");
                }

                int min = _heap[0];
                _heap[0] = _heap[_size - 1];
                _size--;
                HeapifyDown(0);

                return min;
            }

            private void HeapifyUp(int index)
            {
                int parentIndex = (index - 1) / 2;

                while (index > 0 && _heap[index] < _heap[parentIndex])
                {
                    Swap(index, parentIndex);
                    index = parentIndex;
                    parentIndex = (index - 1) / 2;
                }
            }

            private void HeapifyDown(int index)
            {
                int leftChildIndex = 2 * index + 1;
                int rightChildIndex = 2 * index + 2;
                int smallestIndex = index;

                if (leftChildIndex < _size && _heap[leftChildIndex] < _heap[smallestIndex])
                {
                    smallestIndex = leftChildIndex;
                }

                if (rightChildIndex < _size && _heap[rightChildIndex] < _heap[smallestIndex])
                {
                    smallestIndex = rightChildIndex;
                }

                if (smallestIndex != index)
                {
                    Swap(index, smallestIndex);
                    HeapifyDown(smallestIndex);
                }
            }
            static void Main(string[] args)
            {
                int[] numbers = new int[1000000000];

                // заполнение массива numbers

                MinHeap minHeap = new MinHeap(numbers);

                for (int i = 0; i < 1000000; i++)
                {
                    int min = minHeap.RemoveMin();
                    Console.WriteLine(min);
                }
            }

            private void Swap(int index1, int index2)
            {
                int temp = _heap[index1];
                _heap[index1] = _heap[index2];
                _heap[index2] = temp;
            }
        }
        
    }
}
