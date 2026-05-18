using System;

class Program
{
    static void Main(string[] args)
    {
        for (int i = 0; i <= 99; i++)
        {
            for (int j = i + 1; j <= 99; j++)
            {
                Console.Write("{0:D2} {1:D2}", i, j);
                if (i != 98 || j != 99)
                {
                    Console.Write(", ");
                }
            }
        }
        Console.WriteLine();
    }
}
