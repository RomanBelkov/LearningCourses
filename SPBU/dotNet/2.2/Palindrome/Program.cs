using System;

namespace Palindrome
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Type a string:");
            var s = Console.ReadLine();
            Console.WriteLine(PalindromeDetector.IsPalindrome(s) ? "Palindrome" : "Not a palindrome");
        }
    }
}


