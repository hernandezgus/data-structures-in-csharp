using data_structures_in_csharp.Structures;
using System;

namespace data_structures_in_csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //MyLinkedListTest();

            MyHashtableTest();
        }

        private static void MyLinkedListTest()
        {
            var list = new MyLinkedList<int>();
            list.Add(1);
            list.Add(5);
            list.Add(12);
            list.Add(15);

            Console.WriteLine(list);

            var (previous, node) = list.FindFirst(5);

            Console.WriteLine(node.Value);
            Console.WriteLine(node.Next.Value);

            list.DeleteAfter(previous);

            Console.WriteLine(list);

            list.AddAfter(previous, 10);

            Console.WriteLine(list);
        }

        private static void MyHashtableTest()
        {
            var h = new MyHashtable<int>(4);

            Console.WriteLine(h.GetBucketByKey("one"));
            Console.WriteLine(h.GetBucketByKey("two"));
            Console.WriteLine(h.GetBucketByKey("three"));

            h.Add("one", 1);
            h.Add("two", 2);
            h.Add("three", 3);

            Console.WriteLine(h.Get("one"));
            Console.WriteLine(h.Get("two"));
            Console.WriteLine(h.Get("three"));

            try
            {
                Console.WriteLine(h.Get("four"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine(h.Remove("three"));
            Console.WriteLine(h.Remove("three"));
            Console.WriteLine(h.Remove("two"));
            Console.WriteLine(h.Remove("two"));
        }
    }
}
