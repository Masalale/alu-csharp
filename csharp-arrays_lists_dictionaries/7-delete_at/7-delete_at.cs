using System;
using System.Collections.Generic;

class List
{
    public static List<int> DeleteAt(List<int> myList, int index)
    {
        if (index < 0 || index >= myList.Count)
        {
            Console.WriteLine("Index is out of range");
            return myList;
        }

        List<int> updated = new List<int>();

        for (int i = 0; i < myList.Count; i++)
        {
            if (i != index)
                updated.Add(myList[i]);
        }

        myList.Clear();
        foreach (int item in updated)
        {
            myList.Add(item);
        }

        return myList;
    }
}
