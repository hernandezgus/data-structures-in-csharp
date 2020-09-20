using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace data_structures_in_csharp.Structures
{
    public class MyLinkedList<T>
    {
        public MyNode<T> Root { get; private set; }

        public MyNode<T> Add(T value)
        {
            var newNode = new MyNode<T>()
            {
                Value = value,
                Next = null
            };
            if (Root == null)
            {
                Root = newNode;
            } else
            {
                var node = Root;
                while(node.Next != null)
                {
                    node = node.Next;
                }
                node.Next = newNode;
            }
            return newNode;
        }

        public MyNode<T> AddAfter(MyNode<T> node, T value)
        {
            var newNode = new MyNode<T>()
            {
                Value = value,
                Next = null
            };
            if (node == null)
            {
                Root = newNode;
            } else
            {
                newNode.Next = node.Next;
                node.Next = newNode;
            }
            return newNode;
        }

        public (MyNode<T> previous, MyNode<T> found) FindFirst(T value)
        {
            MyNode<T> current = Root;
            MyNode<T> previous = null;

            if (current == null)
            {
                return (null, null);
            }
            if (current.Value.Equals(value))
            {
                return (null, Root);
            }

            do
            {
                previous = current;
                current = current.Next;
                if (current.Value.Equals(value))
                {
                    return (previous, current);
                }
            } while (null != current.Next);
            return (null, null);
        }
        public bool DeleteAfter(MyNode<T> node)
        {
            if (node == null || node.Next == null)
            {
                return false;
            }
            var nextNode = node.Next;
            node.Next = nextNode.Next;
            return true;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder("[");
            var node = Root;
            while (node != null)
            {
                builder.Append($"{ node.Value }");
                if (node.Next != null)
                {
                    builder.Append(",");
                }
                node = node.Next;
            }
            builder.Append("]");
            return builder.ToString();
        }
    }

    public class MyNode<T>
    {
        public MyNode<T> Next { get; set; }

        public T Value { get; set; }
    }
}
