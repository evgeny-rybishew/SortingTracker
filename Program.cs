﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SortingTracker
{

    class Sort<T> where T : IComparable<T>
    {
        public delegate void sort(T array);
        public delegate bool Mode(T x, T y);



        public static void Bubble(T[] array, Mode cmp)
        {
            for (int i = 0; i < array.Length; i++)
                for (int j = 0; j < array.Length - 1; j++)
                    if (cmp(array[j], array[j + 1]))
                    {
                        T hold = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = hold;
                    }
        }



        public static void Selection(T[] array, Mode cmp)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int best = i;
                for (int j = i + 1; j < array.Length; j++)
                {

                    if (cmp(array[best], array[j]))
                    {
                        best = j;
                    }
                }
                T dummy = array[i];
                array[i] = array[best];
                array[best] = dummy;
            }
        }


        public static void Insertion(T[] array, Mode cmp)
        {
            T key;
            int i = 0;
            for (int j = 1; j < array.Length; j++)
            {
                key = array[j];
                i = j - 1;
                while (i >= 0 && cmp(array[i], key))
                {
                    array[i + 1] = array[i];
                    i = i - 1;
                    array[i + 1] = key;
                }
            }
        }


        public static void Merge(T[] array, Mode cmp)
        {
            _Merge(array, 0, array.Length - 1, cmp);
        }


        private static void _Merge(T[] array, int left, int right, Mode cmp)
        {
            if (left >= right)
                return;

            int middle = (left + right) / 2;
            _Merge(array, left, middle, cmp);
            _Merge(array, middle + 1, right, cmp);

            T[] temp = new T[right - left + 1];

            int leftpos = left;
            int rightpos = middle + 1;
            int temppos = 0;

            while ((leftpos <= middle) && (rightpos <= right))
                temp[temppos++] = cmp(array[leftpos], array[rightpos]) ? array[rightpos++] : array[leftpos++];

            while (leftpos <= middle)
                temp[temppos++] = array[leftpos++];

            while (rightpos <= right)
                temp[temppos++] = array[rightpos++];

            for (int i = 0; i < temp.Length; i++)
                array[left + i] = temp[i];


        }


        public static bool Acs(T x, T y)
        {
            return x.CompareTo(y) > 0;
        }
        public static bool Dec(T x, T y)
        {
            return x.CompareTo(y) < 0;
        }

    }


    class Program
    {
        static void Main(string[] args)
        {

            int[] array = { 1, 32, 4, 5 };

            Sort<int>.Merge(array, Sort<int>.Acs);
            foreach (int i in array)
                Console.Write(i + " ");
            Console.WriteLine();
        }
    }
}
