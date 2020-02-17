using System;
using GenericQueue;
using Notebook;
using NUnit.Framework;
using System.Collections.Generic;

namespace GenericQueue.Tests
{
    public class QueueTests
    {
        private struct Point
        {
            public Point(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }

            public int X { get; set; }
            public int Y { get; set; }
        }


        Queue<int> integerQueue = new Queue<int>();
        Queue<string> stringQueue = new Queue<string>();
        Queue<Point> pointQueue = new Queue<Point>();
        Queue<Note> noteQueue = new Queue<Note>();
        Queue<double> emptyQueue = new Queue<double>();

        [SetUp]
        public void Setup()
        {
            integerQueue.Enqueue(1);
            integerQueue.Enqueue(2);
            integerQueue.Enqueue(3);

            stringQueue.Enqueue("first");
            stringQueue.Enqueue("second");
            stringQueue.Enqueue("third");

            pointQueue.Enqueue(new Point(1, 1));
            pointQueue.Enqueue(new Point(2, 2));
            pointQueue.Enqueue(new Point(3, 3));

            noteQueue.Enqueue(new Note("first", "first in queue"));
            noteQueue.Enqueue(new Note("second", "second in queue"));
            noteQueue.Enqueue(new Note("third", "third in queue"));
        }

        [Order(1)]
        [Test]
        public void NegativeCapacityTests() =>
            Assert.Throws<ArgumentException>(() => new Queue<float>(-2));

        [Order(2)]
        [Test]
        public void DequeueEmptyQueue() =>
            Assert.Throws<InvalidOperationException>(() => emptyQueue.Dequeue());

        [Order(3)]
        [Test]
        public void PeekEmptyQueue() =>
            Assert.Throws<InvalidOperationException>(() => emptyQueue.Peek());

        [Order(4)]
        [Test]
        public void PeekTests()
        {
            Assert.AreEqual(integerQueue.Peek(), 1);
            Assert.AreEqual(stringQueue.Peek(), "first");
            Assert.AreEqual(pointQueue.Peek(), new Point(1, 1));
            Assert.AreEqual(noteQueue.Peek(), new Note("first", "first in queue"));
        }

        [Order(5)]
        [Test]
        public void GetEnumerator_IntegerQueue_Tests()
        {
            var expected = new List<int> { 1, 2, 3 };
            var actual = new List<int>();
            foreach (var item in integerQueue)
            {
                actual.Add(item);
            }

            CollectionAssert.AreEqual(expected, actual);
        }

        [Order(6)]
        [Test]
        public void GetEnumerator_StringQueue_Tests()
        {
            var expected = new List<string> { "first", "second", "third" };
            var actual = new List<string>();
            foreach (var item in stringQueue)
            {
                actual.Add(item);
            }

            CollectionAssert.AreEqual(expected, actual);
        }

        [Order(7)]
        [Test]
        public void GetEnumerator_PointQueue_Tests()
        {
            var expected = new List<Point> { new Point(1, 1), new Point(2, 2), new Point(3, 3) };
            var actual = new List<Point>();
            foreach (var item in pointQueue)
            {
                actual.Add(item);
            }

            CollectionAssert.AreEqual(expected, actual);
        }

        [Order(8)]
        [Test]
        public void GetEnumerator_NoteQueue_Tests()
        {
            var expected = new List<Note> { new Note("first", "first in queue"), new Note("second", "second in queue"), new Note("third", "third in queue") };
            var actual = new List<Note>();
            foreach (var item in noteQueue)
            {
                actual.Add(item);
            }

            CollectionAssert.AreEqual(expected, actual);
        }

        [Order(9)]
        [Test]
        public void DequeueTests()
        {
            Assert.That(integerQueue.Dequeue() == 1 && integerQueue.Count == 2);
            Assert.That(stringQueue.Dequeue() == "first" && stringQueue.Count == 2);
            pointQueue.Dequeue();
            Assert.That(pointQueue.Count == 2);
            Assert.That(noteQueue.Dequeue().Equals(new Note("first", "first in queue")) && noteQueue.Count == 2);
        }

        [Order(10)]
        [TestCase(ExpectedResult = new [] { 1, 2, 3})]
        public int[] ToArrayTests()
        {
            return integerQueue.ToArray();
        }

        [Order(11)]
        [Test]
        public void ContainsTests()
        {
            Assert.That(integerQueue.Contains(2));
            Assert.That(!integerQueue.Contains(10));
            Assert.That(stringQueue.Contains("first"));
            Assert.That(!stringQueue.Contains("fourth"));
            Assert.That(pointQueue.Contains(new Point(2, 2)));
            Assert.That(!pointQueue.Contains(new Point(5, 2)));
            Assert.That(noteQueue.Contains(new Note("third", "third in queue")));
            Assert.That(!noteQueue.Contains(new Note("fifth", "third in queue")));
        }
    }
}