using System;
using System.Reflection;

/// <summary>
/// Provides methods for object inspection.
/// </summary>
class Obj
{
    /// <summary>
    /// Prints the names of the available properties and methods of an object.
    /// </summary>
    /// <param name="myObj">The object to inspect.</param>
    public static void Print(object myObj)
    {
        TypeInfo t = myObj.GetType().GetTypeInfo();
        Console.WriteLine("{0} Properties:", t.Name);
        foreach (PropertyInfo p in t.GetProperties())
            Console.WriteLine(p.Name);
        Console.WriteLine("{0} Methods:", t.Name);
        foreach (MethodInfo m in t.GetMethods())
            Console.WriteLine(m.Name);
    }
}
