﻿using System;

namespace GenericQueue
{
    /// <summary>Represents a first-in, first-out collection of objects.</summary>
    /// <typeparam name="T">Specifies the type of elements in the queue.</typeparam>
    public class Queue<T>
    {
        private T[] array;
        private int head;
        private int tail;
        private int size;
        private int growthCoefficient = 5;

        /// <summary>Initializes a new instance of the <see cref="Queue{T}"/> class.</summary>
        public Queue()
        {
            this.array = Array.Empty<T>();
            this.size = 0;
        }

        /// <summary>Initializes a new instance of the <see cref="Queue{T}"/> class.</summary>
        /// <param name="capacity">The initial number of elements that the queue can contain.</param>
        /// <exception cref="ArgumentException">Thrown when capacity is negative.</exception>
        public Queue(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentException("Capacity must be non-negative.");
            }

            this.array = new T[capacity];
            this.head = 0;
            this.tail = 0;
            this.size = 0;
        }

        /// <summary>Gets the number of elements contained in the queue.</summary>
        /// <value>The number of elements contained in the queue.</value>
        public int Count
        {
            get { return this.size; }
        }

        /// <summary>Adds an object to the end of the queue.</summary>
        /// <param name="item">The object to add to the queue.</param>
        public void Enqueue(T item)
        {
            if (this.array.Length == this.size)
            {
                Array.Resize(ref this.array, this.size + this.growthCoefficient);
            }

            this.array[this.tail++] = item;
            this.size++;
        }

        /// <summary>Removes and returns the object at the beginning of the queue.</summary>
        /// <returns>The object that is removed from the beginning of the queue.</returns>
        /// <exception cref="InvalidOperationException">Thrown when queue is empty.</exception>
        public T Dequeue()
        {
            if (this.size == 0)
            {
                throw new InvalidOperationException();
            }

            T output = this.array[this.head];
            this.array[this.head++] = default;
            this.size--;
            return output;
        }

        /// <summary>Removes all objects from the queue.</summary>
        public void Clear()
        {
            Array.Clear(this.array, this.head, this.size);
            this.head = 0;
            this.tail = 0;
            this.size = 0;
        }

        /// <summary>Returns the object at the beginning of the queue without removing it.</summary>
        /// <returns>The object at the beginning of the queue.</returns>
        /// <exception cref="InvalidOperationException">Thrown when queue is empty.</exception>
        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return this.array[this.head];
        }

        /// <summary>Gets the enumerator.</summary>
        /// <returns>Returns an enumerator that iterates through the queue.</returns>
        public Iterator GetEnumerator()
        {
            return new Iterator(this);
        }

        /// <summary>Enumerates the elements of a queue.</summary>
        public struct Iterator
        {
            private readonly Queue<T> queue;
            private int currentIndex;

            /// <summary>Initializes a new instance of the <see cref="Iterator"/> struct.</summary>
            /// <param name="queue">The queue.</param>
            /// <exception cref="ArgumentNullException">Thrown when queue is null.</exception>
            public Iterator(Queue<T> queue)
            {
                this.queue = queue ?? throw new ArgumentNullException(nameof(queue));
                this.currentIndex = this.queue.head - 1;
            }

            /// <summary>Gets the element at the current position of the enumerator.</summary>
            /// <value>Current element.</value>
            /// <exception cref="InvalidOperationException">The enumerator is positioned before the first element of the collection or after the last element.</exception>
            public T Current
            {
                get
                {
                    if (this.currentIndex == this.queue.head - 1 || this.currentIndex == this.queue.tail + 1)
                    {
                        throw new InvalidOperationException();
                    }

                    return this.queue.array[this.currentIndex];
                }
            }

            /// <summary>Resets currentIndex.</summary>
            public void Reset()
            {
                this.currentIndex = this.queue.head - 1;
            }

            /// <summary>Advances the enumerator to the next element of the queue.</summary>
            /// <returns>true if the enumerator was successfully advanced to the next element; false if the enumerator has passed the end of the collection.</returns>
            public bool MoveNext()
            {
                return ++this.currentIndex < this.queue.tail;
            }
        }
    }
}
