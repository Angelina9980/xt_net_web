﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TASK3_3_1_SUPER_ARRAY
{
    public static class ArrayExtensions
    {
        public delegate double ElementImprover(double element);
        public delegate double ArrayValues(double[] array);
        public static double[] Modify(this double[] sourceArray, ElementImprover improver)
        {
            if (sourceArray == null || sourceArray.Length == 0)
                throw new ArgumentException("Array cannot be null or empty");

            double[] newArray = new double[sourceArray.Length];

            for (int i = 0; i < sourceArray.Length; i++)
            {
                newArray[i] = improver.Invoke(sourceArray[i]);
            }
            return newArray;
        }
        public static double SearchElements(this double[] sourceArray, ArrayValues value)
        {
            if (sourceArray == null || sourceArray.Length == 0)
                throw new ArgumentException("Array cannot be null or empty");

            return value.Invoke(sourceArray);
        }
        public static double GetSumOfElements(this double[] array)
        {
            return array.Sum();
        }

        public static double GetAvarageValue(this double[] array)
        {
            return array.Average();
        }

        public static double GetOftRepeatedElement(this double[] array)
        {
            double mostRepeated = array.GroupBy(item => item).OrderByDescending(g => g.Count()).First().Key;
            return mostRepeated;
        }

    }
}
