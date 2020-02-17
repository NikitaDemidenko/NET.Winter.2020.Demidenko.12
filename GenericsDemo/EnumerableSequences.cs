using System;
using System.Collections.Generic;
using GenericsDemo.Interfaces;

namespace GenericsDemo
{
    public static class EnumerableSequences
    {
        /// <summary>
        /// Filters array by filter.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="predicate">The filter.</param>
        /// <returns>Filtered array.</returns>
        public static TSource[] FilterBy<TSource>(this TSource[] source, IPredicate<TSource> predicate)
        {
            if (source is null)
            {
                throw new ArgumentNullException($"{nameof(source)} cannot be null.");
            }

            if (source.Length is 0)
            {
                throw new ArgumentException($"{nameof(source)} cannot be empty.");
            }

            if (predicate is null)
            {
                throw new ArgumentNullException($"{nameof(predicate)} cannot be null.");
            }

            var filteredSource = new List<TSource>();

            foreach (var item in source)
            {
                if (predicate.IsMatch(item))
                {
                    filteredSource.Add(item);
                }
            }

            return filteredSource.ToArray();
        }

        /// <summary>Transforms the specified array.</summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="source">Source array.</param>
        /// <param name="transformer">Transformer.</param>
        /// <returns>Returns transformed array.</returns>
        /// <exception cref="ArgumentNullException">Thrown when source or transformer is null.</exception>
        /// <exception cref="ArgumentException">Thrown when source's length is zero.</exception>
        public static TResult[] Transform<TSource, TResult>(this TSource[] source, ITransformer<TSource, TResult> transformer)
        {
            if (source is null)
            {
                throw new ArgumentNullException($"{nameof(source)} cannot be null.");
            }

            if (source.Length is 0)
            {
                throw new ArgumentException($"{nameof(source)} cannot be empty.");
            }

            if (transformer is null)
            {
                throw new ArgumentNullException($"{nameof(transformer)} cannot be null.");
            }

            TResult[] resultArray = new TResult[source.Length];
            int i = 0;

            foreach (var item in source)
            {
                resultArray[i++] = transformer.Transform(item);
            }

            return resultArray;
        }

        /// <summary>Orders array according to comparer.</summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="comparer">The comparer.</param>
        /// <returns>Returns new ordered array.</returns>
        /// <exception cref="ArgumentNullException">Thrown when source or comparer is null.</exception>
        public static TSource[] OrderAccordingTo<TSource>(this TSource[] source, Interfaces.IComparer<TSource> comparer)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (comparer == null)
            {
                throw new ArgumentNullException(nameof(comparer));
            }

            TSource[] result = new TSource[source.Length];
            Array.Copy(source, result, source.Length);
            for (int i = 0; i < source.Length - 1; i++)
            {
                for (int j = i + 1; j < source.Length; j++)
                {
                    if (comparer.Compare(result[i], result[j]) > 0)
                    {
                        Swap(ref result[i], ref result[j]);
                    }
                }
            }

            return result;
        }

        /// <summary>Gets typed array.</summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="source">Source.</param>
        /// <returns>Returns new typed array.</returns>
        /// <exception cref="ArgumentNullException">Thrown when source is null.</exception>
        public static TResult[] TypeOf<TResult>(this object[] source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            TResult[] result = new TResult[source.Length];
            for (int i = 0; i < source.Length; i++)
            {
                result[i] = (TResult)source[i];
            }

            return result;
        }

        /// <summary>Reverses the specified array.</summary>
        /// <typeparam name="T">Type of array.</typeparam>
        /// <param name="source">Source.</param>
        /// <returns>Returns new reversed array.</returns>
        /// <exception cref="ArgumentNullException">Thrown when source is null.</exception>
        public static T[] Reverse<T>(this T[] source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            T[] result = new T[source.Length];
            Array.Copy(source, result, source.Length);

            for (int i = 0, j = result.Length; i < j / 2; i++)
            {
                Swap(ref result[i], ref result[j - i - 1]);
            }

            return result;
        }

        private static void Swap<T>(ref T left, ref T right)
        {
            T tmp = left;
            left = right;
            right = tmp;
        }
    }
}