using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Rankings(Unsorted Fastest to Slowest) Array Size = 100000 AlgorithmName(Unsorted, Reverse Sorted, Sorted)
 * 
 * Quick Sort(17ms, 6ms, 7ms) -->                       Time Complexity: Best -> O(nlogn), Worst -> O(n^2)            
 *                                                      Space Complexity: O(logn)
 *                                               
 * Radix Sort(21ms, 18ms, 15ms) -->                     Time Complexity: O(nk)                                      
 *                                                      Space Complexity: O(n+k)
 *                                               
 * Merge Sort(32ms, 24ms, 24ms) -->                     Time Complexity: O(nlogn)                                   
 *                                                      Space Complexity: O(n)
 *                                               
 * Heap Sort(59ms, 53ms, 55ms) -->                      Time Complexity: O(nlogn)                                    
 *                                                      Space Complexity: O(1)
 *                                               
 * Insertion Sort(9s 416ms, 19s 047ms, 0ms) -->         Time Complexity: Best -> O(n), Worst -> O(n^2)      
 *                                                      Space Complexity: O(1)
 *                                               
 * Selection Sort(15s 373ms, 16s 350ms, 15s 532ms) -->  Time Complexity: O(n^2)                        
 *                                                      Space Complexity: O(1)
 *                                               
 * Bubble Sort(38s 852ms, 30s 846ms, 0ms) -->           Time Complexity: Best -> O(n), Worst -> O(n^2)        
 *                                                      Space Complexity: O(1)
*/

namespace SortingAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ISortingAlgorithm> sortingAlgorithms = new List<ISortingAlgorithm>();
            sortingAlgorithms.Add(new QuickSort());
            sortingAlgorithms.Add(new RadixSort());
            sortingAlgorithms.Add(new MergeSort());
            sortingAlgorithms.Add(new HeapSort());
            sortingAlgorithms.Add(new InsertionSort());
            sortingAlgorithms.Add(new SelectionSort());
            sortingAlgorithms.Add(new BubbleSort());

            int range = 100000;
            int[] randomArray = new int[range];
            int[] reverseSortedArray = new int[range];
            int[] sortedArray = new int[range];

            Random random = new Random();
            for (int i = 0; i < range; i++)
            {
                randomArray[i] = random.Next(1, range);
                reverseSortedArray[i] = range - i;
                sortedArray[i] = i;
            }

            Stopwatch stopwatch = new Stopwatch();
            foreach (ISortingAlgorithm sortingAlgorithm in sortingAlgorithms)
            {
                int[] tempArray = (int[])randomArray.Clone();
                int[] tempArrayReverse = (int[])reverseSortedArray.Clone();
                int[] tempArraySorted = (int[])sortedArray.Clone();

                Console.WriteLine(sortingAlgorithm.GetType().Name + ": ");
                Console.WriteLine("Random Array(ms), Reverse Sorted Array(ms), Sorted Array(ms)");

                stopwatch.Restart();
                sortingAlgorithm.Sort(tempArray);
                stopwatch.Stop();
                Console.Write(stopwatch.ElapsedMilliseconds + "ms, ");

                stopwatch.Restart();
                sortingAlgorithm.Sort(tempArrayReverse);
                stopwatch.Stop();
                Console.Write(stopwatch.ElapsedMilliseconds + "ms, ");

                stopwatch.Restart();
                sortingAlgorithm.Sort(tempArraySorted);
                stopwatch.Stop();
                Console.WriteLine(stopwatch.ElapsedMilliseconds + "ms\n");
            }

            Console.ReadKey();
        }
    }
}
