using System;
using System.Collections.Generic;
using System.Text;

namespace data_structures_in_csharp.Structures
{
    public class MyHashtableNode<T>
    {
        public MyHashtableNode<T> Next { get; set; }
        public string Key { get; set; }
        public T Value { get; set; }

    }

    public class MyHashtable<T>
    {
        private readonly MyHashtableNode<T>[] _buckets;

        public MyHashtable(int size)
        {
            _buckets = new MyHashtableNode<T>[size];
        }

        public void Add(string key, T item)
        {
            ValidateKey(key);
            var newNode = new MyHashtableNode<T>
            {
                Key = key,
                Value = item,
                Next = null
            };
            int position = GetBucketByKey(key);
            MyHashtableNode<T> listNode = _buckets[position];

            if (listNode == null)
            {
                _buckets[position] = newNode;
            }else
            {
                while (listNode.Next != null)
                {
                    listNode = listNode.Next;
                }
                listNode.Next = newNode;
            }
        }



        private void ValidateKey(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(nameof(key));
            }
        }

        public int GetBucketByKey(string key)
        {
            return key[0] % _buckets.Length;
        }

        private (MyHashtableNode<T> previous, MyHashtableNode<T> current) GetNodeByKey(string key)
        {
            int position = GetBucketByKey(key);
            MyHashtableNode<T> listNode = _buckets[position];
            MyHashtableNode<T> previous = null;

            while (listNode != null)
            {
                if (listNode.Key.Equals(key))
                {
                    return (previous, listNode);
                }
                previous = listNode;
                listNode = listNode.Next;
            }
            return (null, null);
        }

        public T Get(string key)
        {
            ValidateKey(key);
            var (_, node) = GetNodeByKey(key);
            if (node == null)
            {
                throw new ArgumentOutOfRangeException(nameof(key), $"The key '{key}' is not found!");
            }
            return node.Value;
        }

        public bool Remove(string key)
        {
            ValidateKey(key);
            int position = GetBucketByKey(key);
            var (previous, current) = GetNodeByKey(key);
            if (current == null)
            {
                return false;
            }

            if (previous == null)
            {
                _buckets[position] = null;
                return true;
            }

            previous.Next = current.Next;
            return true;  
        }

        public bool ContainsKey(string key)
        {
            ValidateKey(key);
            var (_, node) = GetNodeByKey(key);
            return node != null;
        }
    }
}
