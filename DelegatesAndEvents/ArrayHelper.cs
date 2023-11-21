using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
    internal static class ArrayHelper
    {
        public static T[] Sum<T>(T[] array1, T[] array2, Func<T, T, T> sum2Elements)
        {
            if (array1 is null)
            {
                throw new ArgumentNullException(nameof(array1));
            }

            if (array2 is null)
            {
                throw new ArgumentNullException(nameof(array2));
            }

            if (sum2Elements is null)
            {
                throw new ArgumentNullException(nameof(sum2Elements));
            }

            if (array1.Length != array2.Length)
            {
                throw new ArgumentException("Arrays must have the same length.");
            }

            T[] result = new T[array1.Length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = sum2Elements(array1[i], array2[i]);
            }

            return result;
        }
    }
}
