using System.Text.RegularExpressions;

namespace Text
{
    /// <summary>String helpers.</summary>
    public static class Str
    {
        /// <summary>Checks if a string reads the same both ways, ignoring case and non-alphanumerics.</summary>
        /// <param name="s">String to check.</param>
        /// <returns>True if a palindrome (empty counts as true).</returns>
        public static bool IsPalindrome(string s)
        {
            if (s == null || s.Length == 0)
                return true;

            string cleaned = Regex.Replace(s, "[^a-zA-Z0-9]", "").ToLower();
            int left = 0;
            int right = cleaned.Length - 1;

            while (left < right)
            {
                if (cleaned[left] != cleaned[right])
                    return false;
                left++;
                right--;
            }
            return true;
        }
    }
}
