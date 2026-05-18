using System;

class Number
{
    public static int PrintLastDigit(int number)
    {
        int last = number % 10;
        if (last < 0)
        {
            last = last * -1;
        }
        Console.Write(last);
        return last;
    }

    static void Main(string[] args)
    {
        Console.WriteLine(Number.PrintLastDigit(98));
        Console.WriteLine(Number.PrintLastDigit(-113));
    }
}
