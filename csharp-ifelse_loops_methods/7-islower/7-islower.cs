using System;

class Character
{
    public static bool IsLower(char c)
    {
        return c >= 'a' && c <= 'z';
    }

    static void Main(string[] args)
    {
        Console.WriteLine(Character.IsLower('a'));
        Console.WriteLine(Character.IsLower('Z'));
    }
}
