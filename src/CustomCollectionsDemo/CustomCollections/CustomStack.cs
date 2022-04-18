using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomCollectionsDemo.CustomCollections;

public class CustomStack<T> : IEnumerable<T>
{
    private CustomStackNode _head;
    private int _count;

    private CustomStackNode Head
    {
        get
        {
            if (IsEmpty)
                throw new InvalidOperationException("Stack is empty.");
            return _head;
        }
    }

    public bool IsEmpty => _head is null;
    public int Count => _count;

    public CustomStack()
    {
        _head = null;
        _count = 0;
    }

    public CustomStack(T item) : this()
    {
        this.Push(item);
    }

    public CustomStack(T[] items) : this()
    {
        Array.ForEach(items, item => this.Push(item));
    }

    public T Peek()
    {
        return Head.Value;
    }

    public void Push(T item)
    {
        var box = new CustomStackNode(item) { Next = _head };
        _head = box;
        _count++;
    }

    public T Pop()
    {
        var node = Head;
        _head = node.Next;
        _count--;
        return node.Value;
    }

    IEnumerator IEnumerable.GetEnumerator()
        => new StackEnumerator(this);

    public IEnumerator<T> GetEnumerator()
        => new StackEnumerator(this);

    private class StackEnumerator : IEnumerator<T>
    {
        private readonly CustomStack<T> _stack;
        private CustomStackNode _node;
        private T _current;
        private int _index;

        public virtual T Current => GetCurrent();

        object IEnumerator.Current => GetCurrent();

        internal StackEnumerator(CustomStack<T> customStack)
        {
            _stack = customStack;
            _node = customStack.Head;
            _current = default;
        }

        public virtual bool MoveNext()
        {
            if (_node is null || _node.Next is null) return false;
            if (_index != 0) _node = _node.Next;

            _current = _node.Value;

            _index++;
            return true;
        }

        public virtual void Reset()
        {
            _node = _stack.Head;
            _index = 0;
        }

        public virtual void Dispose() { }

        private T GetCurrent()
        {
            if (_current is null && _index == 0)
                throw new InvalidOperationException("Enumeration has not started. Call MoveNext.");
            return _current;
        }
    }

    private class CustomStackNode
    {
        public CustomStackNode(T value)
        {
            Value = value;
            Next = null;
        }

        public T Value { get; set; }
        public CustomStackNode Next { get; set; }
    }
}