using System;
using System.Collections.Generic;

class List
{
    public static List<int> CommonElements(List<int> list1, List<int> list2)
    {
        List<int> result = new List<int>();
        HashSet<int> set2 = new HashSet<int>(list2);

        foreach (int n in list1)
        {
            if (set2.Contains(n) && !result.Contains(n))
                result.Add(n);
        }

        result.Sort();
        return result;
    }
}
