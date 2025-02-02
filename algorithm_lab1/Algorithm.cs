﻿using System;
namespace algorithm_lab1
{
    public abstract class Algorithm
    {
        public int[] Array { get; private set; }

        public Algorithm()
        {
        }
        public Algorithm(int[] array)
        {
            Array = (int[])array.Clone();
        }

        public virtual void Calculate()
        {
            Console.WriteLine("Parent's class method worked!");
        }

        protected void Swap(int i, int j)
        {
            int temp = Array[i];
            Array[i] = Array[j];
            Array[j] = temp;
        }
    }
}
