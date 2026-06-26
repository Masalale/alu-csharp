using System.Collections.Generic;

namespace Text
{
    /// <summary>String helpers.</summary>
    public static class Str
    {
        /// <summary>Finds the first character that appears only once.</summary>
        /// <param name="s">String to search.</param>
        /// <returns>Index of the first unique character, or -1 if none.</returns>
        public static int UniqueChar(string s)
        {
            if (string.IsNullOrEmpty(s))
                return -1;

            Dictionary<char, int> counts = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (counts.ContainsKey(c))
                    counts[c]++;
                else
                    counts[c] = 1;
            }

            for (int i = 0; i < s.Length; i++)
            {
                if (counts[s[i]] == 1)
                    return i;
            }
            return -1;
        }
    }
}
