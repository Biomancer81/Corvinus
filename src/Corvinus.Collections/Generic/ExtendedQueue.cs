// <copyright file="ExtendedQueue.cs" company="Corvinus Software">
// Copyright (c) Corvinus Software. All rights reserved.
// </copyright>

namespace Corvinus.Collections.Generic
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using Corvinus.Collections;

    /// <summary>
    /// Extends <see cref="Queue{T}"/> to add some event handlers.
    /// </summary>
    /// <typeparam name="T">Any object that can be added to a collection.</typeparam>
    [DebuggerTypeProxy(typeof(ExtendedQueueDebugView<>))]
    [DebuggerDisplay("Count = {Count}")]
    [Serializable]
    public class ExtendedQueue<T> : IEnumerable<T>, IReadOnlyCollection<T>
    {
        private Queue<T> _queue;
        private EventHandler<QueueEventArgs> _enqueued;
        private EventHandler<QueueEventArgs> _dequeued;
        private EventHandler<QueueEventArgs> _cleared;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtendedQueue{T}"/> class.
        /// </summary>
        public ExtendedQueue() => _queue = new Queue<T>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtendedQueue{T}"/> class.
        /// </summary>
        /// <param name="capacity">Maximum capacity of the <see cref="ExtendedQueue{T}"/>.</param>
        public ExtendedQueue(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity), capacity, "Argument Out of Range. Need Non-Negative Number");

            _queue = new Queue<T>(capacity);
        }

        /// <summary>
        /// /// Initializes a new instance of the <see cref="ExtendedQueue{T}"/> class.
        /// </summary>
        /// <param name="collection">An <see cref="IEnumerable{T}"/> collection of object to add to the <see cref="ExtendedQueue{T}"/>.</param>
        public ExtendedQueue(IEnumerable<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));

            _queue = new Queue<T>(collection);
        }

        /// <summary>
        ///  Triggered on <see cref="ExtendedQueue{T}"/>.Clear().
        /// </summary>
        public event EventHandler<QueueEventArgs> Cleared
        {
            add { _cleared += value; }
            remove { _cleared -= value; }
        }

        /// <summary>
        ///  Triggered on <see cref="ExtendedQueue{T}"/>.Dequeue().
        /// </summary>
        public event EventHandler<QueueEventArgs> Dequeued
        {
            add { _dequeued += value; }
            remove { _dequeued -= value; }
        }

        /// <summary>
        ///  Triggered on <see cref="ExtendedQueue{T}"/>.Enqueue().
        /// </summary>
        public event EventHandler<QueueEventArgs> Enqueued
        {
            add { _enqueued += value; }
            remove { _enqueued -= value; }
        }

        /// <summary>
        /// Gets the current count of items in the <see cref="ExtendedQueue{T}"/>. 
        /// </summary>
        public int Count
        {
            get { return _queue.Count; }
        }

        /// <summary>
        /// Copies contents of the <see cref="ExtendedQueue{T}"/> to provided array.
        /// </summary>
        /// <param name="array">The array of type T, to copy items into.</param>
        /// <param name="arrayIndex">Starting index of the copy.</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            _queue.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Adds an object to the end of the <see cref="ExtendedQueue{T}"/>
        /// </summary>
        /// <param name="item">Object to be added to the <see cref="ExtendedQueue{T}"/>.</param>
        public void Enqueue(T item)
        {
            if (item != null) {
                _queue.Enqueue(item);
                _enqueued?.Invoke(this, new QueueEventArgs(true));
            }
            else
            {
                _enqueued?.Invoke(this, new QueueEventArgs(false));
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through <see cref="ExtendedQueue{T}"/>.
        /// </summary>
        /// <returns>An <see cref="IEnumerator{T}"/>.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return _queue.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through <see cref="ExtendedQueue{T}"/>.
        /// </summary>
        /// <returns>An <see cref="IEnumerator"/>.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _queue.GetEnumerator();
        }

        /// <summary>
        /// Removes and returns the object at the beginning of the <see cref="ExtendedQueue{T}"/>.
        /// </summary>
        /// <returns>An object of type T.</returns>
        public T Dequeue()
        {
            if (_queue.Count > 0)
            {
                _dequeued?.Invoke(this, new QueueEventArgs(true));
                return _queue.Dequeue();
            }
            else
            {
                _dequeued?.Invoke(this, new QueueEventArgs(false));
            }

            return default;
        }

        /// <summary>
        /// Removes all objects from the <see cref="ExtendedQueue{T}"/>.
        /// </summary>
        public void Clear()
        {
            _queue.Clear();
            _cleared?.Invoke(this, new QueueEventArgs(true));
        }

        /// <summary>
        /// Returns the object at the beginning of the <see cref="ExtendedQueue{T}"/> without removing it.
        /// </summary>
        /// <returns>An object of type T.</returns>
        public T Peek()
        {
            return _queue.Peek();
        }

        /// <summary>
        /// Determines whether an element is in the <see cref="ExtendedQueue{T}"/>.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>A boolean indicating if the <see cref="ExtendedQueue{T}"/> contains the item.</returns>
        public bool Contains(T item)
        {
            return _queue.Contains(item);
        }

        /// <summary>
        /// Copies the <see cref="ExtendedQueue{T}"/> elements into an array.
        /// </summary>
        /// <returns>An array of type T</returns>
        public T[] ToArray()
        {
            return _queue.ToArray();
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A <see cref="string"/>.</returns>
        public override string ToString()
        {
            return _queue.ToString();
        }

    }
}
