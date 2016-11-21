using System;
using System.Text.RegularExpressions;

namespace RegEx
{
    internal abstract class InputValidator
    {
        internal abstract string Pattern { get; }
        internal abstract string SuccessMessage { get; }
        internal abstract string FailMessage { get; }

        public void PrintInputValidity(string input)
        {
            Console.WriteLine(Regex.Match(input, Pattern).Success ? SuccessMessage : FailMessage);
        }
    }
}