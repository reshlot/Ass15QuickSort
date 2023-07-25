using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace QuickSortAss
{
    internal class Program
    {
        static void QuickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = Partition(arr, low, high);

                QuickSort(arr, low, pivotIndex - 1);
                QuickSort(arr, pivotIndex + 1, high);
            }
        }

        static int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    Swap(arr, i, j);
                }
            }

            Swap(arr, i + 1, high);

            return i + 1;
        }

        static void MergeSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int mid = (low + high) / 2;

                MergeSort(arr, low, mid);
                MergeSort(arr, mid + 1, high);

                Merge(arr, low, mid, high);
            }
        }

        static void Merge(int[] arr, int low, int mid, int high)
        {
            int n1 = mid - low + 1;
            int n2 = high - mid;

            int[] leftArr = new int[n1];
            int[] rightArr = new int[n2];

            for (int i = 0; i < n1; i++)
            {
                leftArr[i] = arr[low + i];
            }

            for (int j = 0; j < n2; j++)
            {
                rightArr[j] = arr[mid + 1 + j];
            }

            int k = low;
            int p = 0;
            int q = 0;

            while (p < n1 && q < n2)
            {
                if (leftArr[p] <= rightArr[q])
                {
                    arr[k] = leftArr[p];
                    p++;
                }
                else
                {
                    arr[k] = rightArr[q];
                    q++;
                }
                k++;
            }

            while (p < n1)
            {
                arr[k] = leftArr[p];
                p++;
                k++;
            }

            while (q < n2)
            {
                arr[k] = rightArr[q];
                q++;
                k++;
            }
        }

        static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }


        static bool IsSorted(int[] arr)
        {
            int n = arr.Length;
            for (int i = 1; i < n; i++)
            {
                if (arr[i] < arr[i - 1])
                    return true;
            }
            return false;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of elements in the array:");
            int n = Convert.ToInt32(Console.ReadLine());

            int[] arr = new int[n];

            Console.WriteLine("Enter the elements of the array:");

            for (int i = 0; i < n; i++)
            {
                Console.Write($"Element {i + 1}: ");
                int element;
                while (!int.TryParse(Console.ReadLine(), out element))
                {
                    Console.WriteLine("Invalid input. Please enter an integer:");
                    Console.Write($"Element {i + 1}: ");
                }
                arr[i] = element;
            }

            int[] quickSortArr = (int[])arr.Clone();
            int[] mergeSortArr = (int[])arr.Clone();

            Console.WriteLine("Quicksorted Array are:");
            QuickSort(quickSortArr, 0, n - 1);
            PrintArray(quickSortArr);

            Console.WriteLine("Merge Sorted Array are:");
            MergeSort(mergeSortArr, 0, n - 1);
            PrintArray(mergeSortArr);


            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
           
            PrintArray(arr);
            stopwatch.Stop();
            Console.WriteLine($"\nArray sorted or not: \t {IsSorted(arr)}\n");

            Console.WriteLine($"Array Size {arr.Length} Time Taken  {stopwatch.Elapsed.TotalMilliseconds} milliseconds");

            Console.ReadKey();
        }
        
    }
}