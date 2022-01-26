using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using CustomStackDemo.CustomCollections.Components;

namespace CustomStackDemo.CustomCollections
{
    public class CustomStack<T> : IEnumerable<T>
    {
        internal CustomStackNode<T> head;
        internal int count;

        private CustomStackNode<T> Head
        {
            get
            {
                if (IsEmpty)
                    throw new NotImplementedException();
                return head;
            }
        }

        public bool IsEmpty => head is null;
        public int Count => count;

        public CustomStack()
        {
            head = null;
            count = 0;
        }

        public CustomStack(T item) : this()
        {
            this.Push(item);
        }

        public CustomStack(T[] items) : this()
        {
            Array.ForEach(items, item => this.Push(item));
        }

        public struct Enumerator : IEnumerator<T>, IDisposable
        {
            private CustomStack<T> _stack;
            private CustomStackNode<T> _node;
            private T _current;
            private int _index;

            public T Current => _current;

            object IEnumerator.Current => _current;

            public Enumerator(CustomStack<T> customStack)
            {
                _stack = customStack;
                _node = customStack.head;
                _current = default;
                _index = 0;
            }

            public void Dispose()
            {
                throw new NotImplementedException();
            }

            public bool MoveNext()
            {
                throw new NotImplementedException();
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => new Enumerator(this);

        public IEnumerator<T> GetEnumerator()
            => new Enumerator(this);

        public T Peek() => Head.Value;

        public void Push(T item)
        {
            var box = new CustomStackNode<T>(item) { Next = head };
            head = box;
            count++;
        }

        public T Pop()
        {
            var node = Head;
            head = node.Next;
            count--;
            return node.Value;
        }

    }
}
