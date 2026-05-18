using System;

class Number
{
    public static int Add(int a, int b)
    {
        return a + b;
    }

    static void Main(string[] args)
    {
        Console.WriteLine(Number.Add(1, 2));
        Console.WriteLine(Number.Add(98, 0));
        Console.WriteLine(Number.Add(100, -2));
    }
}
