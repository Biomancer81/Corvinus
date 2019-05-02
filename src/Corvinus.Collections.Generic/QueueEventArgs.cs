
namespace Corvinus.Collections.Generic
{
    using System;

    public class QueueEventArgs : EventArgs
    {
        public QueueEventArgs()
        {
            IsValid = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueEventArgs"/> class.
        /// </summary>
        /// <param name="transactionValid">A valid Enqueue or Dequeue transaction has occurred.</param>
        public QueueEventArgs(bool isValid)
        {
            IsValid = isValid;
        }

        /// <summary>
        /// Gets or sets a value indicating whether a valid item has been enqueued or dequeued.
        /// </summary>
        public bool IsValid
        {
            get;
            set;
        }
    }
}
