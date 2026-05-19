using System;
using System.Collections.Generic;

class List
{
    public static List<int>? CreatePrint(int size)
    {
        if (size < 0)
        {
            Console.WriteLine("Size cannot be negative");
            return null;
        }

        List<int> myList = new List<int>();

        for (int i = 0; i < size; i++)
        {
            myList.Add(i);
            Console.Write(myList[i]);
            if (i < size - 1)
                Console.Write(" ");
        }
        Console.WriteLine();

        return myList;
    }
}
