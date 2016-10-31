using System.Text.RegularExpressions;

namespace RegEx
{
    internal sealed class PhoneValidator : InputValidator
    {
        internal override string Pattern => @"^[0-9()\-+ ]+$";
        internal override string SuccessMessage => "Correct phone";
        internal override string FailMessage => "Not a phone number";
    }
}