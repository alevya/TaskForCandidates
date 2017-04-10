using System.Collections;
using System.Threading;

namespace Tasks.Task1
{
    public class SafeQueue<T>
    {
        #region Init
        private readonly Queue _queue;
        private readonly object _lockObject;

        public SafeQueue()
        {
            _queue = new Queue();
            _lockObject = _queue.SyncRoot;
        }
        #endregion

        #region Operation

        public void Push(T item)
        {
            lock (_lockObject)
            {
                _queue.Enqueue(item);
                Monitor.Pulse(_lockObject);
            }
        }

        public T Pop()
        {
            lock (_lockObject)
            {
                while (_queue.Count == 0)
                {
                    Monitor.Wait(_lockObject);
                }
                
                return (T)_queue.Dequeue();
            }
        }
        #endregion

    }
}
