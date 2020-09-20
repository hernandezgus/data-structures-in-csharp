using data_structures_in_csharp.Structures;
using System;

namespace data_structures_in_csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            MyLinkedListTest();
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
    }
}
