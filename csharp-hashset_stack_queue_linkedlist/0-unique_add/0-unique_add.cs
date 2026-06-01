using System;
using System.Collections.Generic;

class List
{
    public static int Sum(List<int> myList)
    {
        HashSet<int> seen = new HashSet<int>();
        int sum = 0;

        foreach (int n in myList)
        {
            if (seen.Add(n))
                sum += n;
        }

        return sum;
    }
}
