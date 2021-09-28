using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace OKVGU.Structures
{
    public class PriorityQueue<TPriority, TValue> : IEnumerable<TValue>, IEnumerable<KeyValuePair<TPriority, TValue>>
    {
        private readonly SortedDictionary<TPriority, Queue<TValue>> _storage;
        public PriorityQueue() : this(Comparer<TPriority>.Default)
        {

        }
        public PriorityQueue(IComparer<TPriority> comparer)
        {
            _storage = new SortedDictionary<TPriority, Queue<TValue>>(comparer);
        }
        public int Count
        {
            get;
            private set;
        }
        public void Enqueue(TPriority priority, TValue value)
        {
            if (!_storage.TryGetValue(priority, out var queue))
                _storage[priority] = queue = new Queue<TValue>();
            queue.Enqueue(value);
            Count++;

        }
        public TValue Dequeue()
        {
            if (Count == 0)
                throw new InvalidOperationException("Queue is empty");
            var queue = _storage.First();
            var value = queue.Value.Dequeue();
            if (queue.Value.Count == 0)
                _storage.Remove(queue.Key);
            Count--;
            return value;
        }
        public IEnumerator<KeyValuePair<TPriority, TValue>> GetEnumerator()
        {
            var values = from pair in _storage
                       from value in pair.Value
                       select new KeyValuePair<TPriority, TValue>(pair.Key, value);
            return values.GetEnumerator();
        }
        IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator()
        {
            var values = _storage.SelectMany(pair => pair.Value);
            return values.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}