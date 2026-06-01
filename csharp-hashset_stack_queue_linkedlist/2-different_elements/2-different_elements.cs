using System;
using System.Collections.Generic;

class List
{
    public static List<int> DifferentElements(List<int> list1, List<int> list2)
    {
        HashSet<int> set1 = new HashSet<int>(list1);
        HashSet<int> set2 = new HashSet<int>(list2);
        List<int> result = new List<int>();

        foreach (int n in set1)
        {
            if (!set2.Contains(n))
                result.Add(n);
        }

        foreach (int n in set2)
        {
            if (!set1.Contains(n))
                result.Add(n);
        }

        result.Sort();
        return result;
    }
}
