// <copyright file="ExtendedQueue.cs" company="Corvinus Collective">
// Copyright (c) Corvinus Collective. All rights reserved.
// </copyright>

namespace Corvinus.Collections
{
    using System;
    using System.Collections;
    using System.Text;

    /// <summary>
    /// Extends a <see cref="Queue"/> that has events to watch Enqueued, Dequeued, and Cleared.
    /// </summary>
    public class ExtendedQueue : Queue
    {
        private EventHandler<QueueEventArgs> _enqueued;
        private EventHandler<QueueEventArgs> _dequeued;
        private EventHandler<QueueEventArgs> _cleared;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtendedQueue"/> class.
        /// </summary>
        public ExtendedQueue() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtendedQueue"/> class.
        /// </summary>
        /// <param name="capacity">Maximum capacity of the <see cref="ExtendedQueue"/>.</param>
        public ExtendedQueue(int capacity) : base(capacity)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtendedQueue"/> class.
        /// </summary>
        /// <param name="capacity">Maximum capacity of the <see cref="ExtendedQueue"/>.</param>
        /// <param name="growthFactor">Growth factor of the <see cref="ExtendedQueue"/>.</param>
        public ExtendedQueue(int capacity, float growFactor) : base(capacity, growFactor)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtendedQueue"/> class.
        /// </summary>
        /// <param name="col">An <see cref="ICollection"/> to generate the new queue from.</param>
        public ExtendedQueue(ICollection col) : base(col)
        {
        }

        /// <summary>
        ///  Triggered on <see cref="ExtendedQueue"/>.Clear().
        /// </summary>
        public event EventHandler<QueueEventArgs> Cleared
        {
            add { _cleared += value; }
            remove { _cleared -= value; }
        }

        /// <summary>
        ///  Triggered on <see cref="ExtendedQueue"/>.Dequeue().
        /// </summary>
        public event EventHandler<QueueEventArgs> Dequeued
        {
            add { _dequeued += value; }
            remove { _dequeued -= value; }
        }

        /// <summary>
        ///  Triggered on <see cref="ExtendedQueue"/>.Enqueue().
        /// </summary>
        public event EventHandler<QueueEventArgs> Enqueued
        {
            add { _enqueued += value; }
            remove { _enqueued -= value; }
        }

        /// <summary>
        /// Removes all objects from the <see cref="ExtendedQueue"/>
        /// </summary>
        public override void Clear()
        {
            base.Clear();
            _cleared?.Invoke(this, new QueueEventArgs(true));
        }

        /// <summary>
        /// Removes and returns the object at the beginning of the <see cref="ExtendedQueue"/>.
        /// </summary>
        /// <returns></returns>
        public override object Dequeue()
        {
            if(Count > 0)
            {
                _dequeued?.Invoke(this, new QueueEventArgs(true));
            }
            else
            {
                _dequeued?.Invoke(this, new QueueEventArgs(false));
            }
                
            return base.Dequeue();
        }

        /// <summary>
        /// Adds an object to the end of the <see cref="ExtendedQueue"/>
        /// </summary>
        /// <param name="obj">Object to add to the queue.</param>
        public override void Enqueue(object obj)
        {
            base.Enqueue(obj);
            _enqueued?.Invoke(this, new QueueEventArgs(true));
        }
    }
}
