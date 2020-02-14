using System;
using System.Collections.Generic;
using System.Numerics;
using NUnit.Framework;
using static IntegerExtensions.FibonacciNumbers;

namespace IntegerExtensions.Tests
{
    [TestFixture]
    public class FibonacciNumbersTests
    {
        [Test]
        public void GetFibonacciNumbers_InvalidCount_ThrowArgumentException() =>
            Assert.Throws<ArgumentException>(() => new List<BigInteger>(GetFibonacciNumbers(1)));

        [Test]
        public void GetFibonacciNumbersTests()
        {
            var expected = new List<BigInteger> { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, };
            var actual = GetFibonacciNumbers(20);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetFibonacciNumbersTests2()
        {
            var expected = new List<BigInteger> { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765, 10946, 
                17711, 28657, 46368, 75025, 121393, 196418, 317811, 514229, 832040, 1346269, 2178309, 3524578, 5702887, 9227465, 14930352, 24157817, 
                39088169, 63245986, 102334155 };
            var actual = GetFibonacciNumbers(41);
            Assert.AreEqual(expected, actual);
        }
    }
}