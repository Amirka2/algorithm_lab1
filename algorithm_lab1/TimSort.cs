﻿using System;
namespace algorithm_lab1
{
    public class TimSort : Algorithm
    {
        public TimSort(int[] array) : base(array)
        {
        }
        public override void Calculate()
        {
            int[] arr = Array;
            int n = Array.Length;
            int RUN = GetMinrun(Array.Length);
            // Sort individual subarrays of size RUN
            for (int i = 0; i < n; i += RUN)
                InsertionSort(arr, i, Math.Min((i + RUN - 1), (n - 1)));

            // Start merging from size RUN (or 32).
            // It will merge
            // to form size 64, then
            // 128, 256 and so on ....
            for (int size = RUN; size < n; size = 2 * size)
            {

                // Pick starting point of
                // left sub array. We
                // are going to merge
                // arr[left..left+size-1]
                // and arr[left+size, left+2*size-1]
                // After every merge, we increase
                // left by 2*size
                for (int left = 0; left < n;
                                      left += 2 * size)
                {

                    // Find ending point of left sub array
                    // mid+1 is starting point of
                    // right sub array
                    int mid = left + size - 1;
                    int right = Math.Min((left + 2 * size - 1), (n - 1));

                    // Merge sub array arr[left.....mid] &
                    // arr[mid+1....right]
                    if (mid < right)
                        Merge(arr, left, mid, right);
                }
            }
            Console.WriteLine();
        }
        private int GetMinrun(int n)
        {
            int r = 0;
            while (n >= 64)
            {
                r |= n & 1;
                n >>= 1; // == n / 2
            }
            return n + r;
        }
        public void Merge(int[] arr, int l,
                                   int m, int r)
        {
            // original array is broken in two parts
            // left and right array
            int len1 = m - l + 1, len2 = r - m;
            int[] left = new int[len1];
            int[] right = new int[len2];
            for (int x = 0; x < len1; x++)
                left[x] = arr[l + x];
            for (int x = 0; x < len2; x++)
                right[x] = arr[m + 1 + x];

            int i = 0;
            int j = 0;
            int k = l;

            // After comparing, we merge those two array
            // in larger sub array
            while (i < len1 && j < len2)
            {
                if (left[i] <= right[j])
                {
                    arr[k] = left[i];
                    i++;
                }
                else
                {
                    arr[k] = right[j];
                    j++;
                }
                k++;
            }

            // Copy remaining elements
            // of left, if any
            while (i < len1)
            {
                arr[k] = left[i];
                k++;
                i++;
            }

            // Copy remaining element
            // of right, if any
            while (j < len2)
            {
                arr[k] = right[j];
                k++;
                j++;
            }
        }
        public void InsertionSort(int[] arr, int left, int right)
        {
            for (int i = left + 1; i <= right; i++)
            {
                int temp = arr[i];
                int j = i - 1;
                while (j >= left && arr[j] > temp)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = temp;
            }
        }
    }
}
