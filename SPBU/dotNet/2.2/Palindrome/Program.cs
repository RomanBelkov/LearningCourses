using System;

namespace Palindrome
{
    internal sealed class Program
    {
        private static void Main()
        {
            while (true)
            {
                Console.WriteLine("Type a string and press Enter. Type 'q' to exit");
                var s = Console.ReadLine();
                if (s == "q") return;
                Console.WriteLine(PalindromeDetector.IsPalindrome(s) ? "Palindrome" : "Not a palindrome");
            }
        }
    }
}
