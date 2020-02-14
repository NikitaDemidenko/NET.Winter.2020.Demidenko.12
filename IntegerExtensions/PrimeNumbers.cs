using System;
using System.Collections.Generic;
using System.Numerics;

namespace IntegerExtensions
{
    /// <summary>Provides method to get prime numbers.</summary>
    public static class PrimeNumbers
    {
        /// <summary>Minimum count of prime numbers.</summary>
        public const int MinCountOfPrimeNumbers = 1;

        /// <summary>Gets prime numbers.</summary>
        /// <param name="count">Count of prime numbers.</param>
        /// <returns>Returns a sequence of prime numbers.</returns>
        /// <exception cref="System.ArgumentException">Thrown when count is less than one.</exception>
        public static IEnumerable<int> GetPrimeNumbers(int count)
        {
            if (count < MinCountOfPrimeNumbers)
            {
                throw new ArgumentException("Numbers' count must be greater than zero.");
            }

            bool isPrime;
            for (int i = 0, currentNumber = 2; i < count; currentNumber++)
            {
                isPrime = true;
                int sqrtCurrentNumber = (int)Math.Sqrt(currentNumber);
                for (int divider = 2; divider <= sqrtCurrentNumber; divider++)
                {
                    if (currentNumber % divider == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                {
                    yield return currentNumber;
                    i++;
                }
            }
        }
    }
}
