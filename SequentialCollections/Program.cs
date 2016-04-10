using System;
using System.Collections;

namespace SequentialCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            // Excercise 1
            Queue queue = new Queue();

            queue.Enqueue("First");
            queue.Enqueue("Second");
            queue.Enqueue("Third");
            queue.Enqueue("Fourth");

            while (queue.Count > 0)
                Console.WriteLine(queue.Dequeue());

            // Excercise 2
            Stack stack = new Stack();

            stack.Push("First");
            stack.Push("Second");
            stack.Push("Third");
            stack.Push("Fourth");

            while (stack.Count > 0)
                Console.WriteLine(stack.Pop());
        }
    }
}
