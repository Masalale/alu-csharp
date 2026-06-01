using System;
using System.Collections.Generic;

class MyStack
{
    public static Stack<string> Info(Stack<string> aStack, string newItem, string search)
    {
        Console.WriteLine("Number of items: " + aStack.Count);

        if (aStack.Count == 0)
        {
            Console.WriteLine("Stack is empty");
            aStack.Push(newItem);
            return aStack;
        }

        string top = aStack.Pop();

        Console.WriteLine("Top item: " + top);

        bool contains = aStack.Contains(search);
        Console.WriteLine("Stack contains \"" + search + "\": " + contains);

        if (contains)
        {
            string[] arr = aStack.ToArray();
            int idx = -1;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == search)
                {
                    idx = i;
                    break;
                }
            }

            aStack.Clear();
            for (int i = arr.Length - 1; i > idx; i--)
                aStack.Push(arr[i]);
        }
        else
        {
            aStack.Push(top);
        }

        aStack.Push(newItem);
        return aStack;
    }
}
