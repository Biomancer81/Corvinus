// <copyright file="ExtendedQueue.cs" company="Corvinus Software">
// Copyright (c) Corvinus Software. All rights reserved.
// </copyright>

namespace Corvinus.Collections.Generic
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;

    public class ExtendedQueue<T> : IEnumerable<T>, IReadOnlyCollection<T>
    {
        private Queue<T> _queue;
        private EventHandler<QueueEventArgs> _enqueued;
        private EventHandler<QueueEventArgs> _dequeued;
        private EventHandler<QueueEventArgs> _cleared;

        public ExtendedQueue()
        {
            _queue = new Queue<T>();
        }

        public ExtendedQueue(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity), capacity, "Argument Out of Range. Need Non-Negative Number");

            _queue = new Queue<T>(capacity);
        }

        public ExtendedQueue(IEnumerable<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));

            _queue = new Queue<T>(collection);
        }

        public event EventHandler<QueueEventArgs> Cleared
        {
            add { _cleared += value; }
            remove { _cleared -= value; }
        }

        public event EventHandler<QueueEventArgs> Dequeued
        {
            add { _dequeued += value; }
            remove { _dequeued -= value; }
        }

        public event EventHandler<QueueEventArgs> Enqueued
        {
            add { _enqueued += value; }
            remove { _enqueued -= value; }
        }

        public int Count
        {
            get { return _queue.Count; }
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _queue.CopyTo(array, arrayIndex);
        }

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

        public IEnumerator<T> GetEnumerator()
        {
            return _queue.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _queue.GetEnumerator();
        }

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

        public void Clear()
        {
            _queue.Clear();
            _cleared?.Invoke(this, new QueueEventArgs(true));
        }

        public T Peek()
        {
            return _queue.Peek();
        }

        public bool Contains(T item)
        {
            return _queue.Contains(item);
        }

        public T[] ToArray()
        {
            return _queue.ToArray();
        }

        public override string ToString()
        {
            return _queue.ToString();
        }

    }
}
