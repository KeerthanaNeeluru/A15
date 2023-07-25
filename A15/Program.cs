using System;
using System.Diagnostics;

public class SortingAlgorithms
{
    public static void QuickSort(int[] array)
    {
        if (array == null || array.Length <= 1)
            return;

        QuickSortRecursive(array, 0, array.Length - 1);
    }

    private static void QuickSortRecursive(int[] array, int low, int high)
    {
        if (low < high)
        {
            int pivotIndex = Partition(array, low, high);
            QuickSortRecursive(array, low, pivotIndex - 1);
            QuickSortRecursive(array, pivotIndex + 1, high);
        }
    }

    private static int Partition(int[] array, int low, int high)
    {
        int pivotValue = array[high];
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (array[j] < pivotValue)
            {
                i++;
                Swap(array, i, j);
            }
        }

        Swap(array, i + 1, high);
        return i + 1;
    }

    public static void MergeSort(int[] array)
    {
        if (array == null || array.Length <= 1)
            return;

        int[] tempArray = new int[array.Length];
        MergeSortRecursive(array, tempArray, 0, array.Length - 1);
    }

    private static void MergeSortRecursive(int[] array, int[] tempArray, int low, int high)
    {
        if (low < high)
        {
            int mid = (low + high) / 2;
            MergeSortRecursive(array, tempArray, low, mid);
            MergeSortRecursive(array, tempArray, mid + 1, high);
            Merge(array, tempArray, low, mid, high);
        }
    }

    private static void Merge(int[] array, int[] tempArray, int low, int mid, int high)
    {
        for (int i = low; i <= high; i++)
        {
            tempArray[i] = array[i];
        }

        int left = low;
        int right = mid + 1;
        int current = low;

        while (left <= mid && right <= high)
        {
            if (tempArray[left] <= tempArray[right])
            {
                array[current] = tempArray[left];
                left++;
            }
            else
            {
                array[current] = tempArray[right];
                right++;
            }
            current++;
        }

        int remaining = mid - left;
        for (int i = 0; i <= remaining; i++)
        {
            array[current + i] = tempArray[left + i];
        }
    }

    private static void Swap(int[] array, int i, int j)
    {
        int temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }
}

public class Program
{
    
    public static void Main(string[] args)
    {
        // int[] array1 = { 48, 19, 57, 32, 84, 71, 87, 6, 39, 1, 66, 97, 61, 92, 63, 22, 50, 43, 9, 79 };
        //int[] array2 = { 48, 19, 57, 32, 84, 71, 87, 6, 39, 1, 66, 97, 61, 92, 63, 22, 50, 43, 9, 79 }   ;
        int[] array1 = { 36, 82, 5, 16, 77, 68, 25, 31, 43, 27, 49, 69, 80, 94, 44, 2, 53, 18, 11, 62, 33, 3, 56, 20, 42, 65, 17, 79, 76, 60 };
        int[] array2 = { 36, 82, 5, 16, 77, 68, 25, 31, 43, 27, 49, 69, 80, 94, 44, 2, 53, 18, 11, 62, 33, 3, 56, 20, 42, 65, 17, 79, 76, 60 }   ;

        Stopwatch sw1 =new Stopwatch();
        Stopwatch sw2=new Stopwatch();
        Console.WriteLine("Original Array 1: " + string.Join(", ", array1));
        sw1.Start();
        SortingAlgorithms.QuickSort(array1);
        sw1.Stop();
        Console.WriteLine("QuickSorted Array 1: " + string.Join(", ", array1));

        Console.WriteLine("\nOriginal Array 2: " + string.Join(", ", array2));
        sw2.Start();
        SortingAlgorithms.MergeSort(array2);
        sw2.Stop();
        Console.WriteLine("MergeSorted Array 2: " + string.Join(", ", array2));

        Console.WriteLine($"Time taken to sort the array using quick sort {sw1.Elapsed.TotalMilliseconds}");
        Console.WriteLine($"Time taken to sort the array using merge sort {sw2.Elapsed.TotalMilliseconds}");

        Console.ReadKey();
    }
}
