using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    //Time Complexity: Best -> O(n), Worst -> O(n^2)
    //Space Complexity: O(1)
    class BubbleSort : ISortingAlgorithm
    {
        public void Sort(int[] array)
        {
            bool swapped;
            for (int i = array.Length; i > 1; i--)
            {
                swapped = false;
                //Compare 2 elements if first is bigger than the second swap
                for (int j = 0; j < i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                        swapped = true;
                    }
                }
                if (!swapped)
                    break;
            }
        }
    }
}
