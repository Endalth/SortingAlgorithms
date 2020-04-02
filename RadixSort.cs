using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    //Time Complexity: O(nk)
    //Space Complexity: O(n+k)
    class RadixSort : ISortingAlgorithm
    {
        public void Sort(int[] array)
        {
            int m = array[0];

            //Find maximum to know the number of digits
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > m)
                    m = array[i];
            }

			//Do counting sort for every digit
            for (int exp = 1; m / exp > 0; exp *= 10)
            {
                CountingSort(array, exp);
            }
        }

        private void CountingSort(int[] array, int exp)
        {
            int[] output = new int[array.Length];
            int[] count = new int[10];

            //Store count of occurrences
            for (int i = 0; i < array.Length; i++)
                count[(array[i] / exp) % 10]++;

            //Change count[i] so that it contains actual position of element
            for (int i = 1; i < count.Length; i++)
                count[i] += count[i - 1];

            //Build the output array
            for (int i = array.Length - 1; i >= 0; i--)
            {
                output[count[(array[i] / exp) % 10] - 1] = array[i];
                count[(array[i] / exp) % 10]--;
            }

            //Copy output to array so that it contains sorted numbers
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = output[i];
            }
        }
    }
}
