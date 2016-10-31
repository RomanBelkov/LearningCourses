using System;
using System.Collections.Generic;

namespace RegEx
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var postCodeValidator = new PostCodeValidator();
            var phoneValidator = new PhoneValidator();
            var emailValidator = new EMailValidator();

            while (true)
            {
                Console.WriteLine("Type a string and press Enter. Empty string to exit");
                var s = Console.ReadLine();
                if (s == "") return;

                postCodeValidator.CheckIfValid(s);
                phoneValidator.CheckIfValid(s);
                emailValidator.CheckIfValid(s);
            }
        }
    }
}


