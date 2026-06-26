namespace Text
{
    /// <summary>String helpers.</summary>
    public static class Str
    {
        /// <summary>Counts the words in a camelCase string.</summary>
        /// <param name="s">camelCase string.</param>
        /// <returns>Number of words.</returns>
        public static int CamelCase(string s)
        {
            if (string.IsNullOrEmpty(s))
                return 0;

            int count = 1;
            foreach (char c in s)
            {
                if (char.IsUpper(c))
                    count++;
            }
            return count;
        }
    }
}
