using System;
using System.Collections.Generic;
using GenericsDemo.Interfaces;

namespace GenericsDemo
{
    public static class EnumerableSequences
    {
        /// <summary>
        /// Filters collection by filter.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="predicate">The filter.</param>
        /// <returns>Returns new filtered collection.</returns>
        /// /// <exception cref="ArgumentNullException">Thrown when source or predicate is null.</exception>
        public static IEnumerable<TSource> FilterBy<TSource>(this IEnumerable<TSource> source, IPredicate<TSource> predicate)
        {
            if (source is null)
            {
                throw new ArgumentNullException($"{nameof(source)} cannot be null.");
            }

            if (predicate is null)
            {
                throw new ArgumentNullException($"{nameof(predicate)} cannot be null.");
            }

            foreach (var item in source)
            {
                if (predicate.IsMatch(item))
                {
                    yield return item;
                }
            }
        }

        /// <summary>Transforms the specified collection.</summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="source">Source collection.</param>
        /// <param name="transformer">Transformer.</param>
        /// <returns>Returns transformed collection.</returns>
        /// <exception cref="ArgumentNullException">Thrown when source or transformer is null.</exception>
        public static IEnumerable<TResult> Transform<TSource, TResult>(this IEnumerable<TSource> source, ITransformer<TSource, TResult> transformer)
        {
            if (source is null)
            {
                throw new ArgumentNullException($"{nameof(source)} cannot be null.");
            }

            if (transformer is null)
            {
                throw new ArgumentNullException($"{nameof(transformer)} cannot be null.");
            }

            foreach (var item in source)
            {
                yield return transformer.Transform(item);
            }
        }

        /// <summary>Orders collection according to comparer.</summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="comparer">The comparer.</param>
        /// <returns>Returns new ordered collection.</returns>
        /// <exception cref="ArgumentNullException">Thrown when source or comparer is null.</exception>
        public static IEnumerable<TSource> OrderAccordingTo<TSource>(this IEnumerable<TSource> source, System.Collections.Generic.IComparer<TSource> comparer)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (comparer == null)
            {
                throw new ArgumentNullException(nameof(comparer));
            }

            var array = source.ToArray();

            Array.Sort(array, comparer);
            foreach (var item in array)
            {
                yield return item;
            }
        }

        /// <summary>Gets typed collection.</summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="source">Source.</param>
        /// <returns>Returns new typed array.</returns>
        /// <exception cref="ArgumentNullException">Thrown when source is null.</exception>
        public static IEnumerable<TResult> TypeOf<TResult>(this IEnumerable<object> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            foreach (var item in source)
            {
                if (item.GetType() == typeof(TResult))
                {
                    yield return (TResult)item;
                }
            }
        }

        /// <summary>Reverses the specified collection.</summary>
        /// <typeparam name="T">Type of collection.</typeparam>
        /// <param name="source">Source.</param>
        /// <returns>Returns new reversed collection.</returns>
        /// <exception cref="ArgumentNullException">Thrown when source is null.</exception>
        public static IEnumerable<T> Reverse<T>(this IEnumerable<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            var array = new List<T>(source);

            for (int i = array.Count - 1; i >= 0; i--)
            {
                yield return array[i];
            }
        }

        private static T[] ToArray<T>(this IEnumerable<T> source)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            int count = 0;
            foreach (var item in source)
            {
                count++;
            }

            var array = new T[count];
            int i = 0;
            foreach (var item in source)
            {
                array[i++] = item;
            }

            return array;
        }

        private static void Swap<T>(ref T left, ref T right)
        {
            T tmp = left;
            left = right;
            right = tmp;
        }
    }
}