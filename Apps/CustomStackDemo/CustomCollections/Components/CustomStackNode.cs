using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomStackDemo.CustomCollections.Components
{
    internal class CustomStackNode<T>
    {
        public CustomStackNode(T value)
        {
            Value = value;
            Next = null;
        }

        public T Value { get; set; }
        public CustomStackNode<T> Next { get; set; }
    }
}
