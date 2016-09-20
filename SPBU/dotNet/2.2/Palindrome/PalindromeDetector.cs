using System;

namespace Palindrome
{
    internal sealed class PalindromeDetector
    {
        private static bool IsDelimiter(char c)
        {
            return !Char.IsLetterOrDigit(c);
        }

        private static bool CharEquality(char a, char b)
        {
            return Char.ToLower(a).Equals(Char.ToLower(b));
        }

        public static bool IsPalindrome(string s)
        {
            if (s == null) throw new ArgumentNullException(nameof(s));
            var i = 0;
            var j = s.Length - 1;

            do
            {
                while (IsDelimiter(s[i])) i++;
                while (IsDelimiter(s[j])) j--;
                if (!CharEquality(s[i], s[j]))
                {
                    return false;
                }
                i++;
                j--;
            } while (i < j - 1);
            return true;

        }
    }
}