using System.Text.RegularExpressions;

namespace RegEx
{
    internal sealed class EMailValidator : InputValidator
    {
        private const string Pre = @"[a-zA-Z+_][\w\-]*(\.[\-\w]+)*";
        private const string Post = @"([\w\-]+[\.])+((\w{2,3}|info|museum|travel|name|mobi|jobs|coop|asia|aero|marketing|sales|support|abuse|security|postmaster|hostmaster|usenet|webmaster))";
        internal override string Pattern => "^" + Pre + "@" + Post + "$";
        internal override string SuccessMessage => "Correct email";
        internal override string FailMessage => "Not an email";
    }
}