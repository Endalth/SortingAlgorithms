using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    //Time Complexity: O(nlogn)
    //Space Complexity: O(n)
    class MergeSort : ISortingAlgorithm
    {
        public void Sort(int[] array)
        {
            for (int curr_size = 1; curr_size < array.Length; curr_size *= 2)
            {
                for (int left_start = 0; left_start < array.Length - 1; left_start += 2 * curr_size)
                {
                    int mid = Math.Min(left_start + curr_size - 1, array.Length - 1);

                    int right_end = Math.Min(2 * curr_size + left_start - 1, array.Length - 1);

                    Merge(array, left_start, mid, right_end);
                }
            }
        }

        private void Merge(int[] array, int l, int m, int r)
        {
            int i, j, k;
            int n1 = m - l + 1;
            int n2 = r - m;
            
            //Create temp arrays
            int[] L = new int[n1];
            int[] R = new int[n2];

            //Copy data to temp arrays
            for (i = 0; i < n1; i++)
                L[i] = array[l + i];
            for (j = 0; j < n2; j++)
                R[j] = array[m + j + 1];

            i = 0;
            j = 0;
            k = l;

            //Merge temp arrays back into array while sorting
            while(i < n1 && j < n2)
            {
                if(L[i] <= R[j])
                {
                    array[k] = L[i];
                    i++;
                }
                else
                {
                    array[k] = R[j];
                    j++;
                }
                k++;
            }

            //Copy remaining elements
            while(i < n1)
            {
                array[k] = L[i];
                i++;
                k++;
            }

            while (j < n2)
            {
                array[k] = R[j];
                j++;
                k++;
            }

        }
    }
}
