using System;
using System.Collections.Generic;

class MyQueue
{
    public static Queue<string> Info(Queue<string> aQueue, string newItem, string search)
    {
        Console.WriteLine("Number of items: " + aQueue.Count);

        if (aQueue.Count == 0)
        {
            Console.WriteLine("Queue is empty");
            aQueue.Enqueue(newItem);
            return aQueue;
        }

        string first = aQueue.Dequeue();

        Console.WriteLine("First item: " + first);

        aQueue.Enqueue(newItem);

        bool contains = aQueue.Contains(search);
        Console.WriteLine("Queue contains \"" + search + "\": " + contains);

        if (contains)
        {
            string[] arr = aQueue.ToArray();
            int idx = -1;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == search)
                {
                    idx = i;
                    break;
                }
            }

            aQueue.Clear();
            for (int i = idx + 1; i < arr.Length; i++)
                aQueue.Enqueue(arr[i]);
        }
        else
        {
            aQueue.Enqueue(first);
        }

        return aQueue;
    }
}
