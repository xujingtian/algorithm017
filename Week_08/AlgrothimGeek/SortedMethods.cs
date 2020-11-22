using System;
using System.Collections.Generic;
using System.Linq;

public class SortedMethods {

    public static List<int> SelectSort (List<int> data) {
        int minIndex, temp;
        for (var i = 0; i < data.Count - 1; i++) {
            minIndex = i;
            for (var j = i + 1; j < data.Count; j++) {
                if (data[j] < data[minIndex]) {
                    minIndex = j;
                }
            }
            temp = data[i];
            data[i] = data[minIndex];
            data[minIndex] = temp;
        }
        return data;
    }

    #region    merge sort
    public static List<int> MergeSort (List<int> data) {
        var arr = data.ToArray ();
        if (data.Count < 2) {
            return data;
        }
        int middle = (int) Math.Floor (((decimal) (data.Count / 2)));
        var left = arr.AsSpan ().Slice (0, middle).ToArray ();
        var right = arr.AsSpan ().Slice (middle).ToArray ();
        return Merge (MergeSort (left.ToList ()), MergeSort (right.ToList ()));
    }

    private static List<int> Merge (List<int> left, List<int> right) {
        var result = new List<int> ();

        while (left.Count > 0 && right.Count > 0) {
            if (left[0] <= right[0]) {
                result.Add (left[0]);
                left.RemoveAt (0);
            } else {
                result.Add (right[0]);
                right.RemoveAt (0);
            }
        }

        while (left.Count != 0) {
            result.Add (left[0]);
            left.RemoveAt (0);
        }

        while (right.Count != 0) {

            result.Add (right[0]);
            right.RemoveAt (0);
        }

        return result;
    }
    #endregion

    #region Heap sort
    private static int _count;

    public static List<int> HeapSort (List<int> data) {
        Build (data);

        for (var i = data.Count - 1; i > 0; i--) {
            Swap (data, 0, i);
            _count--;
            Heapify (data, 0);
        }
        return data;
    }
    private static void Build (List<int> data) { // 建立大顶堆
        _count = data.Count;
        for (var i = (int) Math.Floor (((decimal) (_count / 2))); i >= 0; i--) {
            Heapify (data, i);
        }
    }

    private static void Heapify (List<int> data, int i) {
        int left = 2 * i + 1,
            right = 2 * i + 2,
            largest = i;

        if (left < _count && data[left] > data[largest]) {
            largest = left;
        }

        if (right < _count && data[right] > data[largest]) {
            largest = right;
        }

        if (largest != i) {
            Swap (data, i, largest);
            Heapify (data, largest);
        }
    }

    private static void Swap (List<int> data, int i, int j) {
        var temp = data[i];
        data[i] = data[j];
        data[j] = temp;
    }
    #endregion
}