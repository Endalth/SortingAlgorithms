using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    //Time Complexity: Best -> O(nlogn), Worst -> O(n^2)
    //Space Complexity: O(logn)
    class QuickSort : ISortingAlgorithm
    {
        public void Sort(int[] array)
        {
            QuickSortAlg(array, 0, array.Length - 1);
        }

        public void QuickSortAlg(int[] array, int left, int right)
        {
            int i = left, j = right;
            int pivot = array[(left + right) / 2];

            //Partition
            while (i <= j)
            {
                while (array[i] < pivot)
                    i++;
                while (array[j] > pivot)
                    j--;
                if (i <= j)
                {
                    int temporary = array[i];
                    array[i] = array[j];
                    array[j] = temporary;
                    i++;
                    j--;
                }
            };

            //Recursion
            if (left < j)
                QuickSortAlg(array, left, j);
            if (i < right)
                QuickSortAlg(array, i, right);
        }
    }
}
