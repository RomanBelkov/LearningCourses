using System;

namespace RegEx
{
    internal sealed class Program
    {
        public static void Main(string[] args)
        {
            var postCodeValidator = new PostCodeValidator();
            var phoneValidator = new PhoneValidator();
            var emailValidator = new EMailValidator();

            while (true)
            {
                Console.WriteLine("Type a string and press Enter. Input empty string to exit");
                var input = Console.ReadLine();
                if (input == "") return;

                postCodeValidator.CheckIfValid(input);
                phoneValidator.CheckIfValid(input);
                emailValidator.CheckIfValid(input);
            }
        }
    }
}


