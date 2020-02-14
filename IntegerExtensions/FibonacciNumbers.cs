using System;
using System.Collections.Generic;
using System.Numerics;

namespace IntegerExtensions
{
    /// <summary>Provides method to get Fibonacci numbers.</summary>
    public static class FibonacciNumbers
    {
        /// <summary>Minimum count of Fibonacci nummbers.</summary>
        public const int MinCountOfFibonacciNummbers = 2;

        /// <summary>Gets Fibonacci numbers.</summary>
        /// <param name="count">Count of Fibonacci numbers.</param>
        /// <returns>Returns a sequence of Fibonacci numbers.</returns>
        /// <exception cref="System.ArgumentException">Thrown when count is less than <see cref="MinCountOfFibonacciNummbers"/>.</exception>
        public static IEnumerable<BigInteger> GetFibonacciNumbers(int count)
        {
            if (count < MinCountOfFibonacciNummbers)
            {
                throw new ArgumentException("Count of numbers must be greater than one.");
            }

            BigInteger prevNumber = 0;
            BigInteger currentNumber = 1;
            for (int i = 0; i < count; i++)
            {
                yield return prevNumber;

                BigInteger newNumber = prevNumber + currentNumber;
                prevNumber = currentNumber;
                currentNumber = newNumber;
            }
        }
    }
}
