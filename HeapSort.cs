using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    //Time Complexity: O(nlogn)
    //Space Complexity: O(1)
    class HeapSort : ISortingAlgorithm
    {
        public void Sort(int[] array)
        {
            //Build heap(rearrange array)
            for (int i = array.Length / 2 - 1; i >= 0; i--)
                Heapify(array, array.Length, i);

            for (int i = array.Length - 1; i >= 0; i--)
            {
                //Move current root to end
                int temp = array[0];
                array[0] = array[i];
                array[i] = temp;

                //Call max heapify on the reduced heap
                Heapify(array, i, 0);
            }
        }

        private void Heapify(int[] array, int n, int i)
        {
            int largest = i; //Initialize largest as root
            int l = 2 * i + 1;
            int r = 2 * i + 2;

            if (l < n && array[l] > array[largest])
                largest = l;
            if (r < n && array[r] > array[largest])
                largest = r;

            //If largest is not root
            if(largest != i)
            {
                int temp = array[i];
                array[i] = array[largest];
                array[largest] = temp;

                Heapify(array, n, largest);
            }
        }
    }
}
